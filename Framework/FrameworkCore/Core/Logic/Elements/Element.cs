using OpenQA.Selenium;
using System;

namespace FrameworkCore.Core.Logic.Elements
{
    public abstract class Element
    {
        public By By;
        public IWebDriver driver;
        public Element(By by)
        {
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            By = by;
        }
    }
}
