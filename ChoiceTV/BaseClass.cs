using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutomationFW.Base;

namespace ChoiceTV
{
    internal static class BaseClass
    {
        public static void CheckCaptcha(IWebDriver driver)
        {
            SwitchToFrame(driver, "//iframe[@title='reCAPTCHA']");
            ClickToElement(driver, "//div[@class='recaptcha-checkbox-border']");
            Wait(driver).Until(dr => dr.FindElements(By.XPath("//div[@style='animation-play-state: running;']")).Count > 0);
            SwitchToDefaultFrame(driver);
        }
    }
}
