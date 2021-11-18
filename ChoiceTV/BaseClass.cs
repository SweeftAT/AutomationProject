using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        public static string GetActivationUrl(string user)
        {
            string rui = $"https://api.testmail.app/api/json?apikey=f55e0560-cd0b-48a5-bbe9-b06816459c04&namespace=e2f9d&tag={user}";

            string[] arr = GetHttpResponse(rui).Split("\",\"");
            foreach (var item in arr)
            {
                if (item.Contains("https://api.dev.watchchoice.tv"))
                {
                    string[] arr2 = item.Split(' ');
                    foreach (var item2 in arr2)
                    {
                        if (item2.Contains("watchchoice") && item2.Length > 100)
                        {
                            return item2.Replace("\\n", "");
                        }
                    }
                }
            }
            return null;
        }

        public static string GetHttpResponse(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }


    }
}
