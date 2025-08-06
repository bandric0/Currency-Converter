using CurrencyConverter.API.Settings;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Services
{
    public class FixerApiService : IFixerApiService
    {
        private readonly HttpClient _httpClient;
        private readonly FixerApiSettings _settings;

        public FixerApiService(HttpClient httpClient, FixerApiSettings settings)
        {
            _httpClient = httpClient;
            _settings = settings;
        }

        public async Task<decimal> GetExchangeRateAsync(string baseCurrency, string targetCurrency, DateTime date)
        {
            var dateStr = date.ToString("yyyy-MM-dd");
            
            // Free plan only supports EUR as base currency, so we need to calculate accordingly
            var url = $"{_settings.BaseUrl}/{dateStr}?access_key={_settings.ApiKey}&symbols={baseCurrency.ToUpper()},{targetCurrency.ToUpper()}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);

            if (json["success"]?.Value<bool>() != true)
            {
                var error = json["error"];
                throw new Exception($"Fixer API error: {error?["info"]?.Value<string>() ?? error?["type"]?.Value<string>() ?? "Unknown error"}");
            }

            var rates = json["rates"];
            if (rates == null)
            {
                throw new Exception("No rates data received from Fixer API");
            }

            // Get EUR to base and EUR to target rates
            var eurToBase = rates[baseCurrency.ToUpper()]?.Value<decimal>() ?? 0;
            var eurToTarget = rates[targetCurrency.ToUpper()]?.Value<decimal>() ?? 0;

            if (eurToBase == 0 || eurToTarget == 0)
            {
                throw new Exception($"Exchange rate not found for {baseCurrency} or {targetCurrency}");
            }

            // Calculate base to target rate: (EUR/BASE) / (EUR/TARGET) = TARGET/BASE
            // But we want BASE/TARGET, so we need: (EUR/TARGET) / (EUR/BASE)
            return eurToTarget / eurToBase;
        }
    }
}