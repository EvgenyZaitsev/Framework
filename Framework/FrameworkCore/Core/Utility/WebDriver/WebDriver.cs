using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;

namespace FrameworkCore.Core.Utility.WebDriver
{
    public class WebDriver
    {
        private static IWebDriver driver = CreateDriver();
        private WebDriver() { }
        public static IWebDriver GetDriver()
        {
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            if (driver != null)
                return driver;
            return CreateDriver();
        }
        public static void CloseDriver()
        {
//            driver.Quit();
            driver.Close();
//            driver = null;
        }
        public static IWebDriver CreateDriver()
        {
            if (driver != null)
                return driver;
            string browser = "Firefox";//ConfigurationManager.AppSettings["browser"];
            switch (browser)
            {
                case "Chrome":
                    return new ChromeDriver();
                case "IE":
                    return new InternetExplorerDriver();
                case "Firefox":
                default:
                    return new FirefoxDriver();
            }
        }
        public static IWebDriver ReCreateDriver()
        {
            string browser = "Firefox";//ConfigurationManager.AppSettings["browser"];
            switch (browser)
            {
                case "Chrome":
                    return new ChromeDriver();
                case "IE":
                    return new InternetExplorerDriver();
                case "Firefox":
                default:
                    return new FirefoxDriver();
            }
        }
    }
}
