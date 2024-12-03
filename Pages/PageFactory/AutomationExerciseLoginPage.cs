using OpenQA.Selenium;
using SeleniumExample.Services;
using SeleniumExtras.PageObjects;

namespace SeleniumExample.Pages;
public class AutomationExerciseLoginPage {
    
    private readonly IBrowserService _browserService;
    private readonly IWebDriver _driver;


    public AutomationExerciseLoginPage(IBrowserService browserService)
    {
        _browserService = browserService;
        _driver = _browserService.GetDriver();
        PageFactory.InitElements(_driver, this);
    }

    /**
     *
     * @return true if login form is displayed.
     */
    public bool verifyLoginForm() {
        return formTitleLabel.Displayed;
    }

    /**
     * Set username
     * @param emailAddress
     */
    public void setSignUsername(String emailAddress) {
        userText.SendKeys(emailAddress);
    }

    /**
     * Set user password
     * @param password
     */
    public void setSignPassword(String password) {
        passwordText.SendKeys(password);
    }

    /**
     * Click on login button
     */
    public void signlogin() {
        loginButton.Submit();
    }

    /**
     * Gets the error message from an incorrect login attempt.
     * @return
     */
    public String getErrorMessage()
    {
        return loginErrorLabel.Text;
    }

    //Localizadores
    [FindsBy(How = How.CssSelector, Using = "[action='/login'] [name='email']")]
    IWebElement formTitleLabel;

    [FindsBy(How = How.CssSelector, Using = "[action='/login'] [name='email']")]
    IWebElement userText;

    [FindsBy(How = How.CssSelector, Using = "[action='/login'] [name='password']")]
    IWebElement passwordText;

    [FindsBy(How = How.CssSelector, Using = "[data-qa='login-button']" )]
    IWebElement loginButton;

    [FindsBy(How = How.CssSelector, Using = "[name='password'] + p" )]
    IWebElement loginErrorLabel;
}
