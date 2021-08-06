using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutorizationCianAutoTests.PageObjects
{
    class AutorizationPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _loginInput = By.XPath("//input[@name = 'username']");
        private readonly By _continueButton = By.XPath("//button[@data-mark ='ContinueAuthBtn']");
        private readonly By _passwordInput = By.XPath("//input[@name = 'password']");
        private readonly By _autorizate = By.XPath("//button[@data-mark = 'ContinueAuthBtn']");
        private readonly By _switchOnEmailButton = By.XPath("//button[@data-mark ='SwitchToEmailAuth']");

        public AutorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MainMenuPageObject Login(string login, string password)
        {
            _webDriver.FindElement(_loginInput).SendKeys(login);
            _webDriver.FindElement(_continueButton).Click();
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_passwordInput));
            _webDriver.FindElement(_passwordInput).SendKeys(password);
            _webDriver.FindElement(_autorizate).Click();

            return new MainMenuPageObject(_webDriver);
        }

        public void SwitchAutorizationOnEmail()
        {
            _webDriver.FindElement(_switchOnEmailButton).Click();
        }

        public bool CheckAuthorizationMethod()
        {
            try
            {
                _webDriver.FindElement(_switchOnEmailButton);
                return true;
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        }
    }
}
