using OpenQA.Selenium;
using FrameworkCore.Core.Utility.WebDriver;
using System;

namespace FrameworkCore.Core.Logic.Pages
{
    public abstract class Page
    {
        public string URI;
        public IWebDriver Driver;
        public Page()
        {
//            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            this.Driver = WebDriver.GetDriver();
        }
        public void OpenPage()
        {
            this.Driver.Navigate().GoToUrl(this.URI);
        }
        public void ClosePage()
        {
            this.Driver.Close();
        }
    }
}
