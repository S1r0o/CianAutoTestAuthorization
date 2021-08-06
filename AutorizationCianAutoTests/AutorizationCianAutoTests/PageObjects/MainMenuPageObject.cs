using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutorizationCianAutoTests.PageObjects
{
    class MainMenuPageObject
    {
        private IWebDriver _webDriver;
        private readonly By _signInButton = By.CssSelector("#login-btn");
        private readonly By _userMenu = By.Id("header-user-menu");
        private readonly By _userName = By.CssSelector("div a.user-name");

        public MainMenuPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AutorizationPageObject SignIn()
        {
            _webDriver.FindElement(_signInButton).Click();
            var autorization = new AutorizationPageObject(_webDriver);
            if (autorization.CheckAuthorizationMethod())
            {
                autorization.SwitchAutorizationOnEmail();
            }
            return new AutorizationPageObject(_webDriver);
        }

        public string GetUserID()
        {
            _webDriver.FindElement(_userMenu).Click();
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_userName));
            string userName = _webDriver.FindElement(_userName).Text;
            return userName;

        }
    }
}
