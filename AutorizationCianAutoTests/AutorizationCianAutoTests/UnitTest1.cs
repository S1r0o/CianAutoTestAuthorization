using AutorizationCianAutoTests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace AutorizationCianAutoTests
{
    public class Tests
    {
        private IWebDriver _webDriver;

       [SetUp]
        public void Setup()
        {
            _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _webDriver.Navigate().GoToUrl("https://cian.ru");
            _webDriver.Manage().Window.Maximize();
        }

        [Test]
        public void LoginAsUser()
        {
            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu
                .SignIn()
                .Login(UserData.MainUser.Login, UserData.MainUser.Password);
            Thread.Sleep(1000);
            string actualName = mainMenu.GetUserID();

            Assert.AreEqual(UserData.MainUser.UserName, actualName, UserData.MainUser.UserName);
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}