using System;

namespace CurrencyConverter.API.Models
{
    public class CurrencyConversionRequest
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}