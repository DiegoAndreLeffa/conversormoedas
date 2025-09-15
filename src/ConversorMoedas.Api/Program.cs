// src/ConversorMoedas.Api/Program.cs

using System;
using System.Threading.Tasks;
using ConversorMoedas.Core.Interfaces;
using ConversorMoedas.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var app = host.Services.GetRequiredService<ConsoleApplication>();
        await app.Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // Adiciona o HttpClient para ser injetado
                services.AddHttpClient<IExchangeRateService, ExchangeRateApiService>();

                // Adiciona nossos serviços
                services.AddSingleton<CurrencyConverter>();
                services.AddSingleton<ConsoleApplication>(); // Nossa classe principal da UI
            });
}

/// <summary>
/// Classe principal que gerencia a interface do console.
/// </summary>
public class ConsoleApplication
{
    private readonly IExchangeRateService _exchangeRateService;
    private readonly CurrencyConverter _currencyConverter;

	public ConsoleApplication(IExchangeRateService exchangeRateService, CurrencyConverter currencyConverter)
	{
		_exchangeRateService = exchangeRateService;
		_currencyConverter = currencyConverter;
    }

    public async Task Run()
    {
        Console.WriteLine("Bem-vindo ao Conversor de Moedas!");
        Console.WriteLine("---------------------------------");

        try
        {
            Console.Write("Digite a moeda de origem (ex: BRL): ");
            var fromCurrency = Console.ReadLine().ToUpper();

            Console.Write("Digite a moeda de destino (ex: USD): ");
            var toCurrency = Console.ReadLine().ToUpper();

            Console.Write("Digite o valor a ser convertido: ");
            var amount = decimal.Parse(Console.ReadLine());

            // Para simplificar, estamos usando o USD como base para todas as cotações
            var rates = await _exchangeRateService.GetRatesAsync("USD");

            if (rates.Rates.TryGetValue(fromCurrency, out var rateFrom) &&
                rates.Rates.TryGetValue(toCurrency, out var rateTo))
            {
                var convertedAmount = _currencyConverter.Convert(amount, rateFrom, rateTo);
                Console.WriteLine($"\n{amount} {fromCurrency} = {convertedAmount:F2} {toCurrency}");
            }
            else
            {
                Console.WriteLine("\nUma ou ambas as moedas são inválidas.");
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nOcorreu um erro: {ex.Message}");
            Console.ResetColor();
        }
    }
}