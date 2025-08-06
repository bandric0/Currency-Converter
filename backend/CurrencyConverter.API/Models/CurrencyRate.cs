using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CurrencyConverter.API.Models
{
    public class CurrencyRate
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("baseCurrency")]
        public string BaseCurrency { get; set; }

        [BsonElement("targetCurrency")]
        public string TargetCurrency { get; set; }

        [BsonElement("rate")]
        public decimal Rate { get; set; }

        [BsonElement("date")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Date { get; set; }

        [BsonElement("createdAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}