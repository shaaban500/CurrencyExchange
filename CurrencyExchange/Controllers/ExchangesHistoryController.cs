using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Dtos;
using RepositoryLayer.Implementations;
using RepositoryLayer.Interfaces;
using ServiceLayer.Interfaces;

namespace CurrencyExchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangesHistoryController : ControllerBase
    {
        private readonly IExchangesHistoryService _exchangesHistoryService;

        public ExchangesHistoryController(IExchangesHistoryService exchangesHistoryService)
        {
            _exchangesHistoryService = exchangesHistoryService;
        }

        [HttpGet("GetHighestNCurrencies")]
        public IActionResult GetHighestNCurrencies(int? n, DateTime fromDate, DateTime toDate)
        {
            if (n == 0 || n == null)
                return BadRequest();

            var highstCurrencies = _exchangesHistoryService.GetHighestNCurrencies((int)n, fromDate, toDate);
            
            if(highstCurrencies == null)
                return NotFound("No Currencies Found");
            
            return Ok(highstCurrencies);
            
        }

        [HttpGet(Name = "GetLowestNCurrencies")]
        public IActionResult GetLowestNCurrencies(int? n, DateTime fromDate, DateTime toDate)
        {
            if (n == 0 || n == null)
                return BadRequest();
            
            var lowestCurrencies = _exchangesHistoryService.GetLowestNCurrencies((int)n, fromDate, toDate);
            
            if(lowestCurrencies == null)
                return NotFound("No Currencies Found");

            return Ok(lowestCurrencies);
        }

        [HttpGet("GetMostNImprovedCurrenciesByDate")]
        public IActionResult GetMostNImprovedCurrenciesByDate(int? n, DateTime fromDate, DateTime toDate)
        {
            if (fromDate == null || toDate == null || n == 0 || n == null)
                return BadRequest();

            var mostImprovedCurrencies = _exchangesHistoryService.GetMostNImprovedCurrenciesByDate((int)n, fromDate, toDate);
            
            if(mostImprovedCurrencies == null)
                return NotFound("No Currencies Found");

            return Ok(mostImprovedCurrencies);
        }

        [HttpGet("GetLeastNImprovedCurrenciesByDate")]
        public IActionResult GetLeastNImprovedCurrenciesByDate(int? n, DateTime fromDate, DateTime toDate)
        {
            if (fromDate == null || toDate == null || n == 0 || n == null)
                return BadRequest();

            var leastImprovedCurrencies = _exchangesHistoryService.GetLeastNImprovedCurrenciesByDate((int)n, fromDate, toDate);

            if(leastImprovedCurrencies == null)
                return NotFound("No Currencies Found");

            return Ok(leastImprovedCurrencies);
        }


    }
}
