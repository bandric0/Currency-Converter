using CurrencyConverter.API.Models;
using CurrencyConverter.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyConverterController : ControllerBase
    {
        private readonly ICurrencyConversionService _conversionService;

        public CurrencyConverterController(ICurrencyConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpPost("convert")]
        public async Task<ActionResult<CurrencyConversionResponse>> ConvertCurrency([FromBody] CurrencyConversionRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request");
                }

                if (string.IsNullOrWhiteSpace(request.FromCurrency) || string.IsNullOrWhiteSpace(request.ToCurrency))
                {
                    return BadRequest("Currency codes cannot be empty");
                }

                if (request.Amount <= 0)
                {
                    return BadRequest("Amount must be greater than zero");
                }

                var result = await _conversionService.ConvertCurrencyAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}