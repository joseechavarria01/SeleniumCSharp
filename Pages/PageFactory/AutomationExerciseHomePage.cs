using OpenQA.Selenium;
using SeleniumExample.Services;
using SeleniumExtras.PageObjects;

namespace SeleniumExample.Pages;

public class AutomationExerciseHomePage
{
    private readonly IBrowserService _browserService;
    private readonly IWebDriver _driver;


    public AutomationExerciseHomePage(IBrowserService browserService)
    {
        _browserService = browserService;
        _driver = _browserService.GetDriver();
        PageFactory.InitElements(_driver, this);
    }

    /**
     *
     * @return true if slider carousel is displayed
     */
    public bool verifyPage()
    {
        return sliderCarousel.Displayed;
    }

    /**
     * Click on Signup / Login link navigate to login page
     */
    public void goToLogin()
    {
        signUp.Click();
    }

    /**
     * Click on Products link navigate to Product Page
     */
    public void goToProducts()
    {
        products.Click();
    }

    //Localizadores
    [FindsBy(How = How.CssSelector,  Using = "[href='/login']" )]
    IWebElement signUp;

    [FindsBy(How = How.CssSelector,  Using = "[id='slider-carousel'] [class='carousel-inner']" )]
    IWebElement sliderCarousel;

    [FindsBy(How = How.CssSelector,  Using = "[href='/products']" )]
    IWebElement products;
}
