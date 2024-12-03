using OpenQA.Selenium;
using SeleniumExample.Services;
using SeleniumExtras.PageObjects;

namespace SeleniumExample.Pages;

public class AutomationExerciseUserHomePage {
    private readonly IBrowserService _browserService;
    private readonly IWebDriver _driver;


    public AutomationExerciseUserHomePage(IBrowserService browserService)
    {
        _browserService = browserService;
        _driver = _browserService.GetDriver();
        PageFactory.InitElements(_driver, this);
    }

    /**
     * @return true if username is displayed
     */
    public bool VerifyUserName() {
        return usernameLabel.Displayed;
    }

    /**
     *
     * Logout User
     */
    public void LogOut() {
        logout.Click();
    }

    //Localizadores
    [FindsBy(How = How.CssSelector, Using = "[class='fa fa-user'] + b" )]
    IWebElement usernameLabel;

    [FindsBy(How = How.CssSelector, Using = "[href='/logout']" )]
    IWebElement logout;
}
