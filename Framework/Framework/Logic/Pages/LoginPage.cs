using FrameworkCore.Core.Logic.Elements;
using FrameworkCore.Core.Logic.Pages;
using FrameworkCore.Core.Utility.Exceptions;
using FrameworkCore.Core.Utility.Waiter;
using FrameworkCore.Core.Utility.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Framework.Logic.Pages
{
    public class LoginPage : Page
    {
        private Input inputEmail = new Input(By.Id("Email"));
        private Button buttonNext = new Button(By.Name("signIn"));
        private Input inputPassword = new Input(By.Id("Passwd"));
        private Button buttonEnter = new Button(By.XPath("//form[@id='gaia_loginform']/div[2]/div/input"));
        private Link linkChangeUser = new Link(By.Id("account-chooser-link"));
        private Link linkAddAccount = new Link(By.Id("account-chooser-add-account"));

        
        public LoginPage()
        {
            URI = @"http://gmail.com";
        }
        public void SetLoginAndPassword(string login, string password)  
        {
            Thread.Sleep(1000);
            Waiter.ExplicitWaitWithCondition(1000,ExpectedConditions.ElementIsVisible(inputEmail.By)).SendKeys(login);
            Waiter.ExplicitWaitBy(1000, buttonNext.By).Click();
            Thread.Sleep(1000);
            Waiter.ExplicitWaitWithCondition(1000, ExpectedConditions.ElementIsVisible(inputPassword.By)).SendKeys(password);
            Waiter.ExplicitWaitBy(1000, buttonEnter.By).Click();
    }
        public void SwitchUser()
        {
            Thread.Sleep(2000);
            try
            {
                Driver.FindElement(linkChangeUser.By).Click();
            }
            catch(NoSuchElementException) { }
            catch (UnhandledAlertException) { }
            try
            {
                Driver.FindElement(linkAddAccount.By).Click();
            }
            catch (NoSuchElementException) { }
            catch (UnhandledAlertException) { }
            
        }
    }
}
