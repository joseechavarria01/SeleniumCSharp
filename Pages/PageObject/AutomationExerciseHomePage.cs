using OpenQA.Selenium;
using SeleniumExample.Services;

namespace SeleniumExample.Pages;

public class AExerciseHomePage
{
    private readonly IBrowserService _browserService;
    private readonly IWebDriver _driver;

    public AExerciseHomePage(IBrowserService browserService)
    {
        _browserService = browserService;
        _driver = _browserService.GetDriver();
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
    private IWebElement signUp => _driver.FindElement(By.CssSelector("[href='/login']"));
    private IWebElement sliderCarousel => _driver.FindElement(By.CssSelector("[id='slider-carousel'] [class='carousel-inner']"));
    private IWebElement products => _driver.FindElement(By.CssSelector("[href='/products']"));
}
