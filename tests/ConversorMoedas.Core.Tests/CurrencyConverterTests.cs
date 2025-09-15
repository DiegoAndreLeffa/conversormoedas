// tests/ConversorMoedas.Core.Tests/CurrencyConverterTests.cs

using ConversorMoedas.Core.Services;
using System;
using Xunit;

namespace ConversorMoedas.Core.Tests
{
    public class CurrencyConverterTests
    {
        private readonly CurrencyConverter _converter;

        public CurrencyConverterTests()
        {
            _converter = new CurrencyConverter();
        }

        [Fact]
        public void Convert_WithValidRates_ShouldReturnCorrectValue()
        {
            // Arrange
            var amount = 100m; // 100 BRL
            var rateFromBRL = 5.25m; // 1 USD = 5.25 BRL
            var rateToEUR = 0.92m; // 1 USD = 0.92 EUR

            // Act
            var result = _converter.Convert(amount, rateFromBRL, rateToEUR);

            // Assert
            // (100 / 5.25) * 0.92 = 17.5238...
            Assert.Equal(17.52m, result, 2); // Comparando com 2 casas decimais
        }

        [Fact]
        public void Convert_WithZeroRateFrom_ShouldThrowArgumentException()
        {
            // Arrange
            var amount = 100m;
            var rateFrom = 0m;
            var rateTo = 0.92m;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _converter.Convert(amount, rateFrom, rateTo));
        }
    }
}