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
    public class PaymentController : ControllerBase
    {

        private readonly IPayment _payment;
        public PaymentController(IPayment payment)
        {
            _payment = payment;
        }

        [HttpPost("simpleauthorization")]
        public async Task<IResult> SimpleAuthorization([FromBody] PaymentRequestViewModel paymentRequestViewModel) =>
            await _payment.SimpleAuthorizationInternet(paymentRequestViewModel);


    }
}
