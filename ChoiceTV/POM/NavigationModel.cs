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
    public class NavigationModel
    {
        private static IWebDriver driver;
        public NavigationModel(IWebDriver webDriver)
        {
            driver = webDriver;
        }


        public void NavigateTo(TabName tab)
        {
            switch (tab)
            {
                case TabName.Channels:
                    Channels.Click();
                    break;
                case TabName.Playlist:
                    Playlist.Click();
                    break;
                case TabName.Following:
                    Following.Click();
                    break;
                case TabName.Search:
                    Search.Click();
                    break;
                case TabName.Settings:
                    Settings.Click();
                    break;
                case TabName.HomeButton:
                    HomeButton.Click();
                    break;
                    
            }
        }



        private static IWebElement Channels
        {
            get
            {
                const string errorMessage = "TV Channels navigation button not found";
                return FindElement(driver, "//ul/a[contains(@href,'channels')]", errorMessage);
            }
        }

        private static IWebElement Playlist
        {
            get
            {
                const string errorMessage = "Playlist navigation button not found";
                return FindElement(driver, "//ul/a[contains(@href,'playlists')]", errorMessage);
            }
        }

        private static IWebElement Following
        {
            get
            {
                const string errorMessage = "Following navigation button not found";
                return FindElement(driver, "//ul/a[contains(@href,'following')]", errorMessage);
            }
        }

        private static IWebElement Search
        {
            get
            {
                const string errorMessage = "Search navigation button not found";
                return FindElement(driver, "//ul/a[contains(@href,'search')]", errorMessage);
            }
        }

        private static IWebElement Settings
        {
            get
            {
                const string errorMessage = "Settings navigation button not found";
                return FindElement(driver, "//ul/a[contains(@href,'settings')]", errorMessage);
            }
        }

        private static IWebElement HomeButton
        {
            get
            {
                const string errorMessage = "Home Button navigation button not found";
                return FindElement(driver, "//ul/li", errorMessage);
            }
        }
    }
}


public enum TabName
{
    Channels,
    Playlist,
    Following,
    Search,
    Settings,
    HomeButton
}