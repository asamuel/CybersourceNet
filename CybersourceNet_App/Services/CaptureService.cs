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
    public class CaptureService : ICapture
    {
        private readonly IExceptionHandler _exception;
        public CaptureService(IExceptionHandler exception)
        {
            _exception = exception;
        }

        public async Task<IResult> CapturePayment(CaptureRequestViewModel captureRequest) =>
        await _exception.UseCatchExceptionAsync<IResult, AppLayerException>(
        async (addError, execError) =>
        {

            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new(
               Code: captureRequest.ClientReferenceInformationCode
          );

            Ptsv2paymentsidcapturesOrderInformationAmountDetails orderInformationAmountDetails = new(
                TotalAmount: captureRequest.OrderInformation.TotalAmount,
                Currency: captureRequest.OrderInformation.Currency
           );


            Ptsv2paymentsidcapturesOrderInformation orderInformation = new(
                AmountDetails: orderInformationAmountDetails
            );


            var requestObj = new CapturePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                OrderInformation: orderInformation
           );

            var configDictionary = new CybersourceConfig().GetConfiguration(captureRequest.CybersourceConfiguration);
            var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

            var apiInstance = new CaptureApi(clientConfig);
            PtsV2PaymentsCapturesPost201Response result = await apiInstance.CapturePaymentAsync(requestObj, captureRequest.TransactionId);
            return new Result<PtsV2PaymentsCapturesPost201Response>(result, ResultType.Success, "Consumo exitoso");
        },
        layer: Layer.Application,
        service: nameof(CaptureService),
        operation: nameof(CapturePayment),
        genericErrorMessage: $"Ha ocurrido un error no controlado al momento de liquidar la transacción: {captureRequest.TransactionId}"
    );


    }
}
