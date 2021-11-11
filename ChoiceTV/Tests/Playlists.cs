using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using FluentAssertions;
using static AutomationFW.Base;
using static ChoiceTV.BaseClass;
using ChoiceTV.Resources;
using ChoiceTV.POM;
using ChoiceTV.Models;

namespace ChoiceTV.Tests
{
    [TestClass]
    public class Playlists : BaseDesktopTest
    {
        private LoginModel login;
        private PlaylistModel playlist;
        private NavigationModel navigation;

        [TestMethod]
        public void CreatePlaylist()
        {
            playlist = new (driver);
            navigation = new (driver);

            GoToUrl(driver, URL);
            navigation.NavigateTo(TabName.Playlist);
            ClickToElement(driver, "//div[contains(@class,'login')]/button[1]");

            new LoginModel(driver).DesktopAuthorization(new Users().SweeftTest001);

            

            playlist.OpenNewPlaylistForm();

            string playlistName = "Test Automations Playlist";
            string text = "This Playlist was created using automated test and if you can see it, it means either test is running or if it's more than few minutes, test failed";
            string url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
            playlist.CreatePlaylist(playlistName, text, url, "AutomatedTestTag");
            


            WaitFewSeconds(driver, 1500);

            navigation.NavigateTo(TabName.Playlist);



            playlist.DeletePlaylist(playlistName);

            WaitFewSeconds(driver, 500);

        }

    }
}
