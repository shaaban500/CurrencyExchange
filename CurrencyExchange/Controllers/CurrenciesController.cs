using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Dtos;
using ServiceLayer.Interfaces;

namespace CurrencyExchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrenciesService _currenciesService;
        
        public CurrenciesController(ICurrenciesService currenciesService)
        {
            _currenciesService = currenciesService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var currencies = _currenciesService.GetAll();
            return Ok(currencies);
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(CurrencyDto currencyDto)
        {
            if (currencyDto == null)
                return BadRequest();

            if (_currenciesService.GetByName(currencyDto.Name) != null)
                return BadRequest();

            var currency = await _currenciesService.Add(currencyDto);
            return Ok(currency);
        }

        
        
        
        [HttpGet("{name}")]
        public IActionResult GetByName(string? name)
        {
            if (name == null)
                return BadRequest();

            var currency = _currenciesService.GetByName(name);

            if (currency == null)
                return NotFound();

            return Ok(currency);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int? id, [FromBody] CurrencyDto currencyDto)
        {
            if (currencyDto == null || id == null)
                return BadRequest();

            var currency = _currenciesService.Update((int) id, currencyDto);

            if (currency == null)
                return NotFound();

            return Ok(currency);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var currency = _currenciesService.Delete((int)id);

            if (currency == null)
                return NotFound();

            return Ok(currency);
        }
        
    }
}
