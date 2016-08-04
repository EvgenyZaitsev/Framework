using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Core.Logic.Elements
{
    public class Input : Element
    {
        protected string text { get; set; }
        public Input(By by)
            :base(by)
        {
            
        }
    }
}
