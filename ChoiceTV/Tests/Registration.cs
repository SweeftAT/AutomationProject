using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using FluentAssertions;
using static AutomationFW.Base;
using ChoiceTV.Resources;
using ChoiceTV.POM;

namespace ChoiceTV.Tests
{
    [TestClass]
    public class Registration : BaseDesktopTest
    {
        
        [TestMethod]
        public void RegistrationTest()
        {
            GoToUrl(driver, URL);
            new NavigationModel(driver).NavigateTo(TabName.Channels);

            ClickToElement(driver, "//div[@class='first-dimension']//button[2]");

            string email = "random@ma.il";
            string username = "AutomationTestUsername";
            string password = "Paroli1#";

            new RegistrationModel(driver).RegisterUser(email, username, password);

        }

        
    }
}