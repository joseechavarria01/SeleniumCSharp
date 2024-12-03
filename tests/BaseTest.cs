using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using SeleniumExample.Configuration;
using SeleniumExample.Services;
using SeleniumExample.Utils;
using Serilog;

namespace SeleniumExample.tests;

[TestFixture]
public class BaseTest 
{
    protected IServiceProvider ServiceProvider { get; private set; }
    protected IBrowserService BrowserService { get; private set; }
    protected ILogger<BaseTest> _logger;

    // Constructor sin parámetros
    public BaseTest() 
    {
    }
    
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        // Cargar la configuración desde appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) 
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        
        // Configuración de Serilog usando los datos del archivo appsettings.json
        // Configuración de Serilog usando los datos del archivo appsettings.json
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration, sectionName: "Logging")
            .CreateLogger();

        // Configurar el contenedor de dependencias
        ServiceProvider = new ServiceCollection()
            .Configure<SeleniumSettings>(configuration.GetSection("SeleniumSettings"))
            .AddLogging(loggingBuilder => loggingBuilder.AddSerilog())
            .AddScoped<IDriverFactory, DriverFactory>()
            .AddScoped<IBrowserService, BrowserService>()
            .BuildServiceProvider();

        _logger = ServiceProvider.GetService<ILogger<BaseTest>>();
        
        // Obtener una instancia de BrowserService
        _logger.LogInformation("1.- Launch Browser");
        BrowserService = ServiceProvider.GetService<IBrowserService>();
        BrowserService.GetDriver().Manage().Window.Maximize();
        
    }

    public void navigateTo(string url)
    {
        BrowserService.GetDriver().Navigate().GoToUrl(url);
    }
    
    [TearDown]
    public void TearDown()
    {
        if (BrowserService != null)
        {
            BrowserService.Quit();
        }
        
    }
}