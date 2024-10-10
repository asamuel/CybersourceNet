using CybersourceNet_App.Contracts;
using CybersourceNet_App.ViewModels.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IResult = HGUtils.Common.Interfaces.IResult;

namespace CybersourceNet_Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class TransactionSearchController
    {
        private readonly ITransactionSearch _transactionSearch;
        public TransactionSearchController(ITransactionSearch transactionSearch)
        {
            _transactionSearch = transactionSearch;
        }

        [HttpPost("create")]
        public async Task<IResult> CreateSearch([FromBody] CreateSearchRequestViewModel createSearchRequestViewModel) =>
           await _transactionSearch.CreateSearch(createSearchRequestViewModel);
    }
}
