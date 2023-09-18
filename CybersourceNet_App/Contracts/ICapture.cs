using CybersourceNet_App.ViewModels.Request;
using HGUtils.Common.Interfaces;

namespace CybersourceNet_App.Contracts
{
    public interface ICapture
    {
        Task<IResult> CapturePayment(CaptureRequestViewModel captureRequest);
    }
}
