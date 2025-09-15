// src/ConversorMoedas.Core/Services/ExchangeRateApiService.cs

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConversorMoedas.Core.Interfaces;
using ConversorMoedas.Core.Models;
using Microsoft.Extensions.Configuration;

namespace ConversorMoedas.Core.Services
{
    public class ExchangeRateApiService : IExchangeRateService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;

        // Injeção de dependência para o HttpClient e Configuration (boas práticas)
        public ExchangeRateApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiKey = _configuration["ExchangeRateApiKey"];
        }

        public async Task<CurrencyRates> GetRatesAsync(string baseCurrency)
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new InvalidOperationException("API key não encontrada.");
            }

            var url = $"https://v6.exchangerate-api.com/v6/{_apiKey}/latest/{baseCurrency}";
            var response = await _httpClient.GetAsync(url);

            // Lança uma exceção se a resposta não for bem-sucedida
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var rates = JsonSerializer.Deserialize<CurrencyRates>(content);

            return rates;
        }
    }
}