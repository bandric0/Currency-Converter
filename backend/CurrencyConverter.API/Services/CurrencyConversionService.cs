using CurrencyConverter.API.Models;
using System;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Services
{
    public class CurrencyConversionService : ICurrencyConversionService
    {
        private readonly IMongoDbService _mongoDbService;
        private readonly IFixerApiService _fixerApiService;

        public CurrencyConversionService(IMongoDbService mongoDbService, IFixerApiService fixerApiService)
        {
            _mongoDbService = mongoDbService;
            _fixerApiService = fixerApiService;
        }

        public async Task<CurrencyConversionResponse> ConvertCurrencyAsync(CurrencyConversionRequest request)
        {
            var existingRate = await _mongoDbService.GetCurrencyRateAsync(
                request.FromCurrency, 
                request.ToCurrency, 
                request.Date);

            decimal exchangeRate;

            if (existingRate != null)
            {
                exchangeRate = existingRate.Rate;
            }
            else
            {
                exchangeRate = await _fixerApiService.GetExchangeRateAsync(
                    request.FromCurrency, 
                    request.ToCurrency, 
                    request.Date);

                var currencyRate = new CurrencyRate
                {
                    BaseCurrency = request.FromCurrency.ToUpper(),
                    TargetCurrency = request.ToCurrency.ToUpper(),
                    Rate = exchangeRate,
                    Date = request.Date.Date,
                    CreatedAt = DateTime.UtcNow
                };

                await _mongoDbService.SaveCurrencyRateAsync(currencyRate);
            }

            var convertedAmount = request.Amount * exchangeRate;

            return new CurrencyConversionResponse
            {
                FromCurrency = request.FromCurrency.ToUpper(),
                ToCurrency = request.ToCurrency.ToUpper(),
                OriginalAmount = request.Amount,
                ConvertedAmount = convertedAmount,
                ExchangeRate = exchangeRate,
                Date = request.Date
            };
        }
    }
}