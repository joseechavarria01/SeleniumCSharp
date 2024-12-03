using OpenQA.Selenium;
using SeleniumExample.Services;

namespace SeleniumExample.Pages;
public class AExerciseProductPage {
    
    private readonly IBrowserService _browserService;
    private readonly IWebDriver _driver;

    public AExerciseProductPage(IBrowserService browserService)
    {
        _browserService = browserService;
        _driver = _browserService.GetDriver();
    }

    /**
     *
     * Search a product.
     */
    public void searchProduct(String product) {
        searchProductsText.SendKeys(product);
        submitSearch.Click();
    }

    /**
     *
     * Verify 'SEARCHED PRODUCTS' is visible
     */
    public bool verifySearchedProduct(String product)
    {
        return singleProductsDiv.Displayed && productNamelabel.Displayed;
    }

    /**
     *
     * @return true if search products is displayed.
     */
    public bool searchProductIsDisplayed()
    {
        return searchProductsText.Displayed;
    }

    //Localizadores
    private IWebElement searchProductsText => _driver.FindElement(By.Id("search_product"));
    private IWebElement submitSearch => _driver.FindElement(By.Id("submit_search"));
    private IWebElement singleProductsDiv => _driver.FindElement(By.CssSelector("[class='single-products']"));
    private IWebElement productNamelabel => _driver.FindElement(By.CssSelector("[class='productinfo text-center']"));
}
