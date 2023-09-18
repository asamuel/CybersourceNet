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
    public class ReversalController
    {

        private readonly IReversal _reversal;
        public ReversalController(IReversal reversal)
        {
            _reversal = reversal;
        }


        [HttpPost("reversal")]
        public async Task<IResult> AuthorizationReversal([FromBody] ReversalRequestViewModel reversalRequestViewModel) =>
            await _reversal.AuthorizationReversal(reversalRequestViewModel);
    }
}
