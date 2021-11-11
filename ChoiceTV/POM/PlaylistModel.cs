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
    public class PlaylistModel
    {
        private IWebDriver driver;

        public PlaylistModel(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenNewPlaylistForm()
        {
            ClickToElement(driver, "//ul//div[@class='add-new-group ']");
            ClickToElement(driver, "//ul//div[@class='add-new-group opened']/div[4]");
        }

        public void CreatePlaylist(string PlaylistTitle, string text, string url, string tag)
        {
            SendKeys(driver, "//form[contains(@class,'create-playlist-form')]//input[@placeholder='Name']", PlaylistTitle);
            SendKeys(driver, "//form[contains(@class,'create-playlist-form')]//textarea", text);
            SendKeys(driver, "//form[contains(@class,'create-playlist-form')]//input[@placeholder='Paste URL here']", url);
            SendKeys(driver, "//form[contains(@class,'create-playlist-form')]//input[@placeholder='Create tag']", tag);
            ClickToElement(driver, "//button[@type='submit']");
        }

        public void DeletePlaylist(string PlaylistName)
        {
            ClickToElement(driver, $"//h2[text()='{PlaylistName}']/../../div[3]");
            ClickToElement(driver, "//div[@class='popup-item'][4]");
        }
    }
}
