using CybersourceNet_Common.Configurations;
using CybersourceNet_Data.Constants;
using Dapper;
using HGUtils.Common.Enums;
using HGUtils.Exceptions.Contracts;
using HGUtils.Exceptions.LayerExceptions;
using HGUtils.Logging.Contracts;
using HGUtils.Logging.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;


namespace CybersourceNet_Data.Services
{
    public class LoggingService : ILogging
    {
        private readonly string _apiLoggingConnectionString;
        private readonly ApiConfig _apiConfig;
        private readonly IExceptionHandler _exception;
        public LoggingService(
      IConfiguration configuration,
      ApiConfig apiConfig,
      IExceptionHandler exception)
        {
            _apiLoggingConnectionString = configuration.GetConnectionString(DatabaseConstants.ApiLoggingConnectionStringName);
            _apiConfig = apiConfig;
            _exception = exception;
        }

        public async Task WriteLog(RequestInfo request, ResponseInfo response) =>
         await _exception.UseCatchExceptionAsync<DataLayerException>(
         async (addError, execError) =>
         {
             var sqlQuery = $"INSERT INTO {DatabaseConstants.ApiLoggingTableName}(application_id, resource_uri, method, request_datetime, response_dateTime, status_code, request, response) VALUES ( @ApplicationId, @ResourceUri, @Method, @RequestDateTime, @ResponseDateTime, @StatusCode, @Request, @Response )";

             using var con = new MySqlConnection(_apiLoggingConnectionString);

             var affectedRows = await con.ExecuteAsync(
                        sqlQuery,
                        new
                        {
                            _apiConfig.ApplicationId,
                            ResourceUri = request.Uri,
                            request.Method,
                            RequestDateTime = request.RequestTime,
                            ResponseDateTime = response.ResponseTime,
                            response.StatusCode,
                            Request = request.Body,
                            Response = response.Body
                        });

             if (affectedRows.Equals(0))
                 addError("No se insertó el registro de la bitácora del api");
         },
         layer: Layer.Data,
         service: nameof(LoggingService),
         operation: nameof(WriteLog),
         genericErrorMessage: "Ha ocurrido un error no controlado al momento de registrar bitácoras en base de datos",
         throwGenericException: false
     );

    }
}
