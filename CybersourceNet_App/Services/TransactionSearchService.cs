using CyberSource.Api;
using CyberSource.Model;
using CybersourceNet_App.Contracts;
using CybersourceNet_App.Services.utils;
using CybersourceNet_App.ViewModels.Request;
using CybersourceNet_App.ViewModels.Response;
using HGUtils.Common.Enums;
using HGUtils.Common.Interfaces;
using HGUtils.Common.Models;
using HGUtils.Exceptions.Contracts;
using HGUtils.Exceptions.LayerExceptions;

namespace CybersourceNet_App.Services
{
    public class TransactionSearchService : ITransactionSearch
    {
        private readonly IExceptionHandler _exception;
        public TransactionSearchService(IExceptionHandler exception) { _exception = exception; }


        public async Task<IResult> CreateSearch(CreateSearchRequestViewModel request) =>
        await _exception.UseCatchExceptionAsync<IResult, AppLayerException>(
        async (addError, execError) =>
        {

            CreateSearchRequest requestObj = new()
            {
                Save = request.Save,
                Query = request.Query,
                Offset = request.Offset,
                Limit = request.Limit,
                Name = !string.IsNullOrEmpty(request.Name?.Trim()) ? request.Name : null,
                Timezone = !string.IsNullOrEmpty(request.Timezone?.Trim()) ? request.Timezone : null,
                Sort = !string.IsNullOrEmpty(request.Sort?.Trim()) ? request.Sort : null,
            };

            var configDictionary = new CybersourceConfig().GetConfiguration(request.CybersourceConfiguration);
            var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

            var apiInstance = new SearchTransactionsApi(clientConfig);
            TssV2TransactionsPost201Response result = await apiInstance.CreateSearchAsync(requestObj);

            List<CreateSearchResponseViewModel> ceateSearchResponseViewModelList = new();
            foreach (var item in result.Embedded?.TransactionSummaries ?? new())
            {
                CreateSearchResponseViewModel createSearchResponseViewModel = new()
                {
                    Id = item?.Id,
                    ApprovalCode = item?.ProcessorInformation?.ApprovalCode,
                    CardSuffix = $"xxxxxxxxxxxx{item?.PaymentInformation?.Card?.Suffix}",
                    RFlag = item?.ApplicationInformation?.RFlag,
                    ReasonCode = item?.ApplicationInformation?.ReasonCode,
                    ApplicationsList = new List<Application>()

                };
                var aplicationsList = item?.ApplicationInformation?.Applications;
                if (aplicationsList != null && aplicationsList.Any())
                {
                    createSearchResponseViewModel.ApplicationsList = aplicationsList.Select(x => new Application
                    {
                        Name = x.Name,
                        RCode = x.RCode,
                        ReasonCode = x.ReasonCode,
                        RFlag = x.RFlag,
                        ReconciliationId = x.ReconciliationId,
                        ReturnCode = x.ReturnCode,
                        RMessage = x.RMessage
                    }).ToList();
                }

                ceateSearchResponseViewModelList.Add(createSearchResponseViewModel);
            }


            return new Result<List<CreateSearchResponseViewModel>>(ceateSearchResponseViewModelList, ResultType.Success, "Consumo exitoso");
        },
        layer: Layer.Application,
        service: nameof(TransactionSearchService),
        operation: nameof(CreateSearch),
        genericErrorMessage: $"Ha ocurrido un error no controlado al momento de obtener la información de la transacción: {request.Query}"
        );
    }

}
