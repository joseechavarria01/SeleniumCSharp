using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using SeleniumExample.Configuration;

namespace SeleniumExample.Utils;

public class DriverFactory : IDriverFactory
{
    private readonly SeleniumSettings _settings;
    private readonly IDictionary<string, IDriverFactory> _driverFactories;

    public DriverFactory(IOptions<SeleniumSettings>  options)
    {
        _settings = options.Value;
        _driverFactories = new Dictionary<string, IDriverFactory>
        {
            { "CHROME", new ChromeDriverFactory(_settings) },
            { "FIREFOX", new FirefoxDriverFactory(_settings) }
        };
    }


    // Registro de las fábricas de drivers
    public IWebDriver CreateDriver()
    {
        _settings.Browser = _settings.Browser?.ToUpperInvariant() ?? throw new ArgumentNullException(nameof(_settings.Browser));

        if (!_driverFactories.TryGetValue(_settings.Browser, out var factory))
        {
            throw new NotSupportedException($"El navegador '{_settings.Browser}' no está soportado.");
        }
        return factory.CreateDriver();
    }
}