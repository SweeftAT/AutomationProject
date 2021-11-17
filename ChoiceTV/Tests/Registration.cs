using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using FluentAssertions;
using static AutomationFW.Base;
using static ChoiceTV.BaseClass;
using ChoiceTV.Resources;
using ChoiceTV.POM;
using System;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using FluentAssertions.Execution;

namespace ChoiceTV.Tests
{
    [TestClass]
    public class Registration : BaseDesktopTest
    {
        
        [TestMethod]
        public void RegistrationTest()
        {
            GoToUrl(driver, URL);
            new NavigationModel(driver).NavigateTo(TabName.Playlist);
            ClickToElement(driver, "//div[@class='auth-required-container']//button[2]");
            string user = DateTime.Now.GetHashCode().ToString();

            string email = $"e2f9d.{user}@inbox.testmail.app";
            string username = $"AutomationTestUsername{user}";
            string password = "Paroli1#";


            new RegistrationModel(driver).RegisterUser(email, username, password);

            WaitFewSeconds(driver, 1000);



            using (new AssertionScope())
            {
                ElementExists(driver, "//div[@role='alert']").Should().BeTrue();
                FindElement(driver, "//div[@class='ant-alert-message']").Text.Should().Contain(email);
                ClickToElement(driver, "//div[@role='alert']//button");
                ElementVanished(driver, "//div[@role='alert']").Should().BeTrue("");
            }


            string activationUrl;
            do
            {
                activationUrl = GetActivationUrl(user);
            }
            while(activationUrl == null);



            //OpenUrlInNewTab(driver, activationUrl);


            

        }

        [TestMethod]
        public void AlreadyUserEmail()
        {
            GoToUrl(driver, URL);
            new NavigationModel(driver).NavigateTo(TabName.Playlist);
            ClickToElement(driver, "//div[@class='auth-required-container']//button[2]");

            string email = "yevopoj790@ecofreon.com";
            string username = "AutomationTestUsername";
            string password = "Paroli1#";

            new RegistrationModel(driver).RegisterUser(email, username, password);
                
            WaitFewSeconds(driver, 1000);

            Assert.IsTrue(ElementExists(driver, "//div[@role='alert']"), "");
            FindElement(driver, "//div[@class='ant-alert-message']").Text.Should().Be("The email has already been taken.");

            ClickToElement(driver, "//div[@role='alert']//button");
            ElementVanished(driver, "//div[@role='alert']").Should().BeTrue("");

        }


        

    }
}