using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Core.Utility.Exceptions
{
    public class InvalidDataException : Exception
    {
        private string message;

        public InvalidDataException()
        {
            this.message = "No data inputted, please write it correctly.";
        }
        public InvalidDataException(string message)
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
