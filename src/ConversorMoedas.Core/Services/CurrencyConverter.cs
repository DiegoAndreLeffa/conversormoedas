// src/ConversorMoedas.Core/Services/CurrencyConverter.cs

namespace ConversorMoedas.Core.Services
{
    public class CurrencyConverter
    {
        /// <summary>
        /// Converte um valor de uma moeda para outra com base nas cotações.
        /// </summary>
        public decimal Convert(decimal amount, decimal rateFrom, decimal rateTo)
        {
            // A conversão é feita geralmente através de uma moeda base (ex: USD).
            // Fórmula: (amount / rateFrom) * rateTo
            if (rateFrom <= 0)
            {
                throw new ArgumentException("A taxa da moeda de origem deve ser positiva.", nameof(rateFrom));
            }

            return (amount / rateFrom) * rateTo;
        }
    }
}