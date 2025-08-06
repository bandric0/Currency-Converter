using System;

namespace CurrencyConverter.API.Models
{
    public class CurrencyConversionResponse
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal OriginalAmount { get; set; }
        public decimal ConvertedAmount { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime Date { get; set; }
    }
}