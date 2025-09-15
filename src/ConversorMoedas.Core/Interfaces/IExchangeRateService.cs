// src/ConversorMoedas.Core/Interfaces/IExchangeRateService.cs

using ConversorMoedas.Core.Models;

namespace ConversorMoedas.Core.Interfaces
{
    /// <summary>
    /// Define o contrato para o serviço que busca as cotações de moeda.
    /// </summary>
    public interface IExchangeRateService
    {
        /// <summary>
        /// Busca as cotações mais recentes para uma moeda base.
        /// </summary>
        /// <param name="baseCurrency">A moeda base (ex: "USD").</param>
        /// <returns>Um objeto com as cotações.</returns>
        Task<CurrencyRates> GetRatesAsync(string baseCurrency);
    }
}