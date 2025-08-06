using CurrencyConverter.API.Models;
using CurrencyConverter.API.Settings;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Services
{
    public class MongoDbService : IMongoDbService
    {
        private readonly IMongoCollection<CurrencyRate> _currencyRates;

        public MongoDbService(MongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _currencyRates = database.GetCollection<CurrencyRate>(settings.CollectionName);
        }

        public async Task<CurrencyRate> GetCurrencyRateAsync(string baseCurrency, string targetCurrency, DateTime date)
        {
            var dateOnly = date.Date;
            var filter = Builders<CurrencyRate>.Filter.Eq(r => r.BaseCurrency, baseCurrency.ToUpper()) &
                        Builders<CurrencyRate>.Filter.Eq(r => r.TargetCurrency, targetCurrency.ToUpper()) &
                        Builders<CurrencyRate>.Filter.Gte(r => r.Date, dateOnly) &
                        Builders<CurrencyRate>.Filter.Lt(r => r.Date, dateOnly.AddDays(1));

            return await _currencyRates.Find(filter).FirstOrDefaultAsync();
        }

        public async Task SaveCurrencyRateAsync(CurrencyRate currencyRate)
        {
            await _currencyRates.InsertOneAsync(currencyRate);
        }
    }
}