using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutomationFW.Base;
using static ChoiceTV.BaseClass;

namespace ChoiceTV.POM
{
    internal class RegistrationModel
    {
        private static IWebDriver driver;

        public RegistrationModel(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void RegisterUser(string Email, string Nickname, string Password)
        {
            EmailInput.SendKeys(Email);
            NicknameInput.SendKeys(Nickname);
            PasswordInput.SendKeys(Password);
            ConfirmPasswordInput.SendKeys(Password);
            CheckCaptcha(driver);
            TCCheckmark.Click();
            RegisterButton.Click();
        }



        private static IWebElement EmailInput
        {
            get
            {
                const string errorMessage = "Email input not found";
                return FindElement(driver, "//form/div[1]//input", errorMessage);
            }
        }

        private static IWebElement NicknameInput
        {
            get
            {
                const string errorMessage = "Nickname input not found";
                return FindElement(driver, "//form/div[2]//input", errorMessage);
            }
        }

        private static IWebElement PasswordInput
        {
            get
            {
                const string errorMessage = "Password input not found";
                return FindElement(driver, "//form/div[3]//input", errorMessage);
            }
        }

        private static IWebElement ConfirmPasswordInput
        {
            get
            {
                const string errorMessage = "Confirm Password input not found";
                return FindElement(driver, "//form/div[4]//input", errorMessage);
            }
        }

        private static IWebElement TCCheckmark
        {
            get
            {
                const string errorMessage = "Terms and Conditions checkmark not found";
                return FindElement(driver, "//input[@type='checkbox']", errorMessage);
            }
        }

        private static IWebElement RegisterButton
        {
            get
            {
                const string errorMessage = "Register button not found";
                return FindElement(driver, "//button[@type='submit']", errorMessage);
            }
        }

    }
}
