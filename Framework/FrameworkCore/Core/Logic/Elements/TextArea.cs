using OpenQA.Selenium;

namespace FrameworkCore.Core.Logic.Elements
{
    public class TextArea : Element
    {
        public TextArea(By by) : base(by)
        {
        }

        public string ID { get; set; }
        public string Text { get; set; }
        public bool Visible { get; set; }
    }
}
