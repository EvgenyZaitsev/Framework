using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FrameworkCore.Core.Utility.Logger
{
    public class Logger
    {
        public string Message { get; set; }
        public string Path { get; set; }
        public Logger() { }
        public Logger(string path) { this.Path = path; }
        public Logger(string path, string message) { this.Path = path; this.Message = message; }
        public void log()
        {
            using (StreamWriter sr = new StreamWriter(this.Path, true, Encoding.UTF8))
            {
                sr.WriteLine($"{DateTime.Now.ToString("F")}\t{this.Message}");
            }
        }
    }
}
