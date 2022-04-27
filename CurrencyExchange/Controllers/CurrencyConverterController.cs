using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace CurrencyExchange.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyConverterController : ControllerBase
    {
        private readonly ICurrencyConverterService _currencyConverterService;

        public CurrencyConverterController(ICurrencyConverterService currencyConverterService)
        {
            _currencyConverterService = currencyConverterService;
        }

        [HttpGet("Converter/{amount:int}")]
        public IActionResult Get(int fromCurrencyId, int toCurrencyId, double amount)
        {
            var convertedMoney = _currencyConverterService.Convert(fromCurrencyId, toCurrencyId, amount);
            
            if(convertedMoney == null)
                return NotFound();

            return Ok(convertedMoney);
        }
    }
}
