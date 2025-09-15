// src/ConversorMoedas.Core/Models/CurrencyRates.cs

using System.Text.Json.Serialization;

namespace ConversorMoedas.Core.Models
{
    /// <summary>
    /// Representa a resposta da API de cotações.
    /// </summary>
    public class CurrencyRates
    {
        [JsonPropertyName("base_code")]
        public string BaseCode { get; set; }

        [JsonPropertyName("conversion_rates")]
        public Dictionary<string, decimal> Rates { get; set; }
    }
}