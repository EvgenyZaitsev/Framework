using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkCore.Core.Utility.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace FrameworkCore.Core.Utility.Waiter
{
    public static class Waiter
    {
        public static void ImplicitWait(int timeout)
        {
           WebDriver.WebDriver.GetDriver().Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(timeout));
        }
        public static IWebElement ExplicitWaitBy(int timeout, By By)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver.WebDriver.GetDriver(), TimeSpan.FromSeconds(timeout));
            return wait.Until<IWebElement>(d => d.FindElement(By));
        }
        public static IWebElement ExplicitWaitWithCondition(int timeout, Func<IWebDriver, IWebElement> expectedConditions)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver.WebDriver.GetDriver(), TimeSpan.FromSeconds(timeout));
            return wait.Until(expectedConditions);
        }
    }
}