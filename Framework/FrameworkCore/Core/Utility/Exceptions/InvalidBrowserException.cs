using System;

namespace FrameworkCore.Core.Utility.Exceptions
{
    public class InvalidBrowserException : Exception
    {
        private string message;

        public InvalidBrowserException()
        {
            this.message = "Check your browser, because we can't work with it.";
        }
        public InvalidBrowserException(string message)
        {
            this.message = message;
        }
        public override string Message
        {
            get
            {
                return this.message;
            }
        }
    }
}
