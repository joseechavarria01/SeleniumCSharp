using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumExample.Pages;
public class AutomationExerciseProductPage {
    private WebDriver driver;

    public AutomationExerciseProductPage(WebDriver _driver) {
        driver = _driver;
        PageFactory.InitElements(driver, this);
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
    [FindsBy(How = How.CssSelector, Using = "search_product" )]
    IWebElement searchProductsText;

    [FindsBy(How = How.CssSelector, Using = "submit_search" )]
    IWebElement submitSearch;

    [FindsBy(How = How.CssSelector, Using = "[class='single-products']" )]
    IWebElement singleProductsDiv;

    [FindsBy(How = How.CssSelector, Using = "[class='productinfo text-center']" )]
    IWebElement productNamelabel;
}
