using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using SeleniumExample.Configuration;

namespace SeleniumExample.Utils;

public class FirefoxDriverFactory : IDriverFactory
{
    private readonly SeleniumSettings _settings;

    public FirefoxDriverFactory(SeleniumSettings settings)
    {
        _settings = settings;
    }

    public IWebDriver CreateDriver()
    {
        if (_settings.SeleniumGrid.Enabled)
        {
            return new RemoteWebDriver(new Uri(_settings.SeleniumGrid.Url), GetFirefoxOptions());
        }
        return new FirefoxDriver(GetFirefoxOptions());
    }

    private FirefoxOptions GetFirefoxOptions()
    {
        var firefoxOptions = new FirefoxOptions();
        return firefoxOptions;
    }
}
