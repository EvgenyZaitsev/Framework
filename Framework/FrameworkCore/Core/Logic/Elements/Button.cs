using OpenQA.Selenium;

namespace FrameworkCore.Core.Logic.Elements
{
    public class Button : Element
    {
        public string ID { get; set; }
        public string Text { get; set; }
        public bool Visible { get; set; }
        public bool ReadOnly { get; set; }
        public Button(By by) : base(by) { }
        public void Click()
        {
            //Click button
        }
    }
}
