using OpenQA.Selenium;
using SeleniumExample.Configuration;

namespace SeleniumExample.Utils;

public interface IDriverFactory
{
    IWebDriver CreateDriver();
    
}
