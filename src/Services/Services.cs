using OpenQA.Selenium;
using SeleniumExample.Configuration;
using Microsoft.Extensions.Options;
using SeleniumExample.Utils;
namespace SeleniumExample.Services
{
    public interface IBrowserService
    {
        IWebDriver GetDriver();
        void Quit();
    }

    public class BrowserService : IBrowserService
    {
        private readonly SeleniumSettings _settings;
        private readonly IDriverFactory _driverFactory;
        private IWebDriver _driver;

        public BrowserService(IOptions<SeleniumSettings> options, IDriverFactory driverFactory)
        {
            _settings = options.Value;
            _driverFactory = driverFactory;
            _driver = _driverFactory.CreateDriver();

        }

        public IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                throw new DriverServiceNotFoundException($"El driver '{_driver}' no se ha iniciado.");
            }
            return _driver;
        }

        public void Quit()
        {
            _driver?.Quit();
        }
    }
}
