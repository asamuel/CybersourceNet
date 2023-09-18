using CyberSource.Api;
using CyberSource.Model;
using CybersourceNet_App.Contracts;
using CybersourceNet_App.Services.utils;
using CybersourceNet_App.ViewModels.Request;
using HGUtils.Common.Enums;
using HGUtils.Common.Interfaces;
using HGUtils.Common.Models;
using HGUtils.Exceptions.Contracts;
using HGUtils.Exceptions.LayerExceptions;

namespace CybersourceNet_App.Services
{
    public class ReversalService : IReversal
    {

        private readonly IExceptionHandler _exception;
        public ReversalService(IExceptionHandler exception)
        {
            _exception = exception;
        }


        public async Task<IResult> AuthorizationReversal(ReversalRequestViewModel reversalRequest) =>
        await _exception.UseCatchExceptionAsync<IResult, AppLayerException>(
        async (addError, execError) =>
        {

            Ptsv2paymentsidreversalsClientReferenceInformation clientReferenceInformation = new(
                Code: reversalRequest.ClientReferenceInformationCode
           );

            Ptsv2paymentsidreversalsReversalInformationAmountDetails reversalInformationAmountDetails = new(
                TotalAmount: reversalRequest.OrderInformation.TotalAmount
           );

            Ptsv2paymentsidreversalsReversalInformation reversalInformation = new(
                AmountDetails: reversalInformationAmountDetails,
                Reason: reversalRequest.ReversalInformationReason
           );

            var requestObj = new AuthReversalRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ReversalInformation: reversalInformation
           );

            var configDictionary = new CybersourceConfig().GetConfiguration(reversalRequest.CybersourceConfiguration);
            var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

            var apiInstance = new ReversalApi(clientConfig);
            PtsV2PaymentsReversalsPost201Response result = await apiInstance.AuthReversalAsync(reversalRequest.TransactionId, requestObj);
            return new Result<PtsV2PaymentsReversalsPost201Response>(result, ResultType.Success, "Consumo exitoso");
        },
        layer: Layer.Application,
        service: nameof(ReversalService),
        operation: nameof(AuthorizationReversal),
        genericErrorMessage: $"Ha ocurrido un error no controlado al momento de anular la transacción: {reversalRequest.TransactionId}"
    );
    }
}
