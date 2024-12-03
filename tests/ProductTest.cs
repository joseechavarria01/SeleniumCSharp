using Microsoft.Extensions.Logging;
using NUnit.Framework;
using SeleniumExample.Pages;

namespace SeleniumExample.tests;

[TestFixture]
public class ProductTest : BaseTest
{
    [Test]
    public void ProductTest_Ok() {
        AExerciseHomePage homePage = new AExerciseHomePage(BrowserService);
        AExerciseProductPage productPage = new AExerciseProductPage(BrowserService);
        String product = "Summer White Top";

        _logger.LogInformation("2. Navigate to url https://automationexercise.com");
        navigateTo("https://automationexercise.com/");

        _logger.LogInformation("3. Verify that home page is visible successfully.");
        Assert.That(homePage.verifyPage(),Is.True,"Page is not available.");

        _logger.LogInformation("4. Click on 'Products' button");
        homePage.goToProducts();

        _logger.LogInformation("5. Verify user is navigated to ALL PRODUCTS page successfully.");
        Assert.That(productPage.searchProductIsDisplayed(),Is.True, "Products page is not displayed.");

        _logger.LogInformation("6. Enter product name in search input and click search button.");
        productPage.searchProduct(product);

        _logger.LogInformation("7. Verify 'SEARCHED PRODUCTS' is visible.");
        Assert.That(productPage.verifySearchedProduct(product),Is.True, "Search product is not displayed.");
    }
}