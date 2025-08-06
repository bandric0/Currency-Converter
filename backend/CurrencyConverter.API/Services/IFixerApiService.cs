using System;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Services
{
    public interface IFixerApiService
    {
        Task<decimal> GetExchangeRateAsync(string baseCurrency, string targetCurrency, DateTime date);
    }
}