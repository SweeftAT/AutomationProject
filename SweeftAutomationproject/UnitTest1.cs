using AutomationFW;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using static AutomationFW.Base;

namespace SweeftAutomationproject
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;

        [TestInitialize]
        public void Start()
        {
            BrowserDrivers browserDrivers = new BrowserDrivers();
            driver = browserDrivers.GetWebDriver(BrowserType.ChromeDesktopLocal);
        }

        [TestCleanup]
        public void Cleanup()
        {
            FinishTest(driver);
        }
        
        [TestMethod]
        public void TestMethod1()
        {

            GoToUrl(driver, "https://zoommer.ge/");
            ClickToElement(driver, "//span[@class='welcome-text-desktop']");
            SendKeys(driver, "//input[@id='EmailOrPhone']", "asdaddd");
            SendKeys(driver, "//input[@id='Password']", "asddeq2");
            ClickToElement(driver, "//button[@id='login-btn']");
            WaitFewSeconds(driver, 500);

            string value = FindElement(driver, "//input[@id='EmailOrPhone']").GetCssValue("border-color");
            driver.FindElement(By.XPath("inputXpath")).GetCssValue("border-color");

            WaitFewSeconds(driver, 1000);

        }
    }
}