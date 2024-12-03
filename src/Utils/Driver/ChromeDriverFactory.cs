using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using SeleniumExample.Configuration;
using WebDriverManager.DriverConfigs.Impl;


namespace SeleniumExample.Utils;

public class ChromeDriverFactory : IDriverFactory
{
    private readonly SeleniumSettings _settings;

    public ChromeDriverFactory(SeleniumSettings settings)
    {
        _settings = settings;
    }

    public IWebDriver CreateDriver()
    {
        if (_settings.SeleniumGrid.Enabled)
        {
            return new RemoteWebDriver(new Uri(_settings.SeleniumGrid.Url), new ChromeOptions());
        }
        else
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

            return new ChromeDriver();
        }
    }

    public ChromeOptions GetChromeOptions()
    {
        ChromeOptions options = new ChromeOptions();
        
        foreach(KeyValuePair<string, string> kvp in _settings.Capabilities.Caps )
        {
            if (kvp.Key.Equals("args", StringComparison.OrdinalIgnoreCase))
            {
                options.AddArguments(kvp.Value);
            }
            else
            {
                options.AddAdditionalChromeOption(kvp.Key, kvp.Value);
            }
        }
/*

        if (!mobileEmulation.isEmpty() && (boolean)mobileEmulation.get("enable"))
        {
            Map<String, String> mobileConfig = new HashMap<>();
            String deviceName = config.getCapabilities().getMobileEmulation().get("deviceName").toString();

            if (deviceName.isEmpty() || deviceName == null)
            {
                for (Map.Entry < String, Object > entry : mobileEmulation.entrySet())
                {

                    if (!entry.getKey().equalsIgnoreCase("deviceName"))
                    {
                        //  mobileConfig.put(entry.getKey(), entry.getValue());
                    }
                }
            }
            else
            {
                mobileConfig.put("deviceName", deviceName);
            }

            options.setExperimentalOption("mobileEmulation", mobileConfig);
        }*/
        return options;
    }
}
