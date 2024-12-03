using Microsoft.Extensions.Logging;
using NUnit.Framework;
using SeleniumExample.Pages;

namespace SeleniumExample.tests;

[TestFixture]
public class LoginTests : BaseTest
{

    [Test]
    public void Test_Login()
    {
        AutomationExerciseHomePage indexPage = new AutomationExerciseHomePage(BrowserService);
        AutomationExerciseLoginPage loginPage = new AutomationExerciseLoginPage(BrowserService);
        AutomationExerciseUserHomePage homePage = new AutomationExerciseUserHomePage(BrowserService);
        String email = "xavomawusse-1109@yopmail.com";
        String password = "AJghEJY2g3S5Ay";


        _logger.LogInformation("2. Navigate to url https://automationexercise.com/.");
        navigateTo("https://automationexercise.com/");

        _logger.LogInformation("3. Verify that home page is visible successfully.");
        Assert.That(indexPage.verifyPage(), Is.True,"Page is not available.");

        _logger.LogInformation("4. Click on 'Signup / Login' button.");
        indexPage.goToLogin();

        _logger.LogInformation("5. Verify 'Login to your account' is visible.");
        Assert.That(loginPage.verifyLoginForm(), Is.True, "Login page is not displayed.");

        _logger.LogInformation("6. Enter correct email address and password.");
        loginPage.setSignUsername(email);
        loginPage.setSignPassword(password);

        _logger.LogInformation("7. Click 'login' button.");
        loginPage.signlogin();

        _logger.LogInformation("8. Verify that 'Logged in as username' is visible");
        Assert.That(homePage.VerifyUserName(), Is.True, "Home page is not displayed.");

        _logger.LogInformation("9. Click 'Logout' button.");
        homePage.LogOut();

        _logger.LogInformation("10. Verify that user is navigated to login page.");
        Assert.That(loginPage.verifyLoginForm(), Is.True, "Login page is not displayed.");

    }
}
