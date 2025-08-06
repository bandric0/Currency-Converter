using CurrencyConverter.API.Models;
using System;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Services
{
    public interface IMongoDbService
    {
        Task<CurrencyRate> GetCurrencyRateAsync(string baseCurrency, string targetCurrency, DateTime date);
        Task SaveCurrencyRateAsync(CurrencyRate currencyRate);
    }
}