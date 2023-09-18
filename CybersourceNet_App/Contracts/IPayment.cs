using CybersourceNet_App.ViewModels.Request;
using HGUtils.Common.Interfaces;

namespace CybersourceNet_App.Contracts
{
    public interface IPayment
    {
        Task<IResult> SimpleAuthorizationInternet(PaymentRequestViewModel paymentRequest);
    }
}
