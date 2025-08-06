using CurrencyConverter.API.Models;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Services
{
    public interface ICurrencyConversionService
    {
        Task<CurrencyConversionResponse> ConvertCurrencyAsync(CurrencyConversionRequest request);
    }
}