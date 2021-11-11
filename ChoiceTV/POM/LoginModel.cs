using ChoiceTV.Models;
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
    public class LoginModel
    {
        private IWebDriver driver;

        public LoginModel(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void DesktopAuthorization(string username, string password)
        {
            SendKeys(driver, "//form/div[1]//input", username);
            SendKeys(driver, "//form/div[2]//input", password);

            CheckCaptcha(driver);

            ClickToElement(driver, "//button[@type='submit']");

            CloseMessage();
        }

        public void DesktopAuthorization(User credentials) => DesktopAuthorization(credentials.Username, credentials.Password);


        private void CloseMessage()
        {
            if (ElementExists(driver, "//div[@class='ant-modal-content']/button"))
            {
                ClickToElement(driver, "//div[@class='ant-modal-content']/button");
            }
        }
    }
}
