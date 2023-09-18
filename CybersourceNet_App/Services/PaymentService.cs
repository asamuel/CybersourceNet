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
    public class PaymentService : IPayment
    {
        private readonly IExceptionHandler _exception;
        public PaymentService(IExceptionHandler exception)
        {
            _exception = exception;
        }

        public async Task<IResult> SimpleAuthorizationInternet(PaymentRequestViewModel paymentRequest) =>
        await _exception.UseCatchExceptionAsync<IResult, AppLayerException>(
        async (addError, execError) =>
        {
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new(Code: paymentRequest.ClientReferenceInformationCode);
            Ptsv2paymentsProcessingInformation processingInformation = new(Capture: paymentRequest.CaptureTrueForProcessPayment);


            Ptsv2paymentsPaymentInformationCard paymentInformationCard = new(
                Number: paymentRequest.PaymentInformationCard.CardNumber,
                ExpirationMonth: paymentRequest.PaymentInformationCard.CardExpirationMonth,
                ExpirationYear: paymentRequest.PaymentInformationCard.CardExpirationYear
                );

            Ptsv2paymentsPaymentInformation paymentInformation = new(Card: paymentInformationCard);


            Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new(
                TotalAmount: paymentRequest.OrderInformation.TotalAmount,
                Currency: paymentRequest.OrderInformation.Currency
           );

            Ptsv2paymentsOrderInformationBillTo orderInformationBillTo = new(
                FirstName: paymentRequest.OrderInformationBillTo.FirstName,
                LastName: paymentRequest.OrderInformationBillTo.LastName,
                Address1: paymentRequest.OrderInformationBillTo.Address1,
                Locality: paymentRequest.OrderInformationBillTo.Locality,
                AdministrativeArea: paymentRequest.OrderInformationBillTo.AdministrativeArea,
                PostalCode: paymentRequest.OrderInformationBillTo.PostalCode,
                Country: paymentRequest.OrderInformationBillTo.Country,
                Email: paymentRequest.OrderInformationBillTo.Email,
                PhoneNumber: paymentRequest.OrderInformationBillTo.PhoneNumber
           );

            Ptsv2paymentsOrderInformation orderInformation = new(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo
           );

            var requestObj = new CreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ProcessingInformation: processingInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation
           );

            var configDictionary = new CybersourceConfig().GetConfiguration(paymentRequest.CybersourceConfiguration);
            var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

            var apiInstance = new PaymentsApi(clientConfig);
            PtsV2PaymentsPost201Response result = await apiInstance.CreatePaymentAsync(requestObj);
            return new Result<PtsV2PaymentsPost201Response>(result, ResultType.Success, "Consumo exitoso");
        },
        layer: Layer.Application,
        service: nameof(PaymentService),
        operation: nameof(SimpleAuthorizationInternet),
        genericErrorMessage: "Ha ocurrido un error no controlado al momento de generar la autorización del pago"
    );
    }
}
