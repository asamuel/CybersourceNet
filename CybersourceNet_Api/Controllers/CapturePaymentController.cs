using CybersourceNet_App.Contracts;
using CybersourceNet_App.ViewModels.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IResult = HGUtils.Common.Interfaces.IResult;

namespace CybersourceNet_Api.Controllers
{
    [Route("api/v1/payment")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class CapturePaymentController
    {
        private readonly ICapture _capture;
        public CapturePaymentController(ICapture capture)
        {
            _capture = capture;
        }

        [HttpPost("capture")]
        public async Task<IResult> CapturePayment([FromBody] CaptureRequestViewModel captureRequestViewModel) =>
            await _capture.CapturePayment(captureRequestViewModel);


    }
}
