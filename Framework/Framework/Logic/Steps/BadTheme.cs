using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using Framework.Logic.Pages;

namespace Framework.Logic.Steps
{
    public class BadTheme
    {
        public bool SetBadTheme(string Path)
        {
            string login = ConfigurationManager.AppSettings["login1"];
            string pass = ConfigurationManager.AppSettings["password1"];
            //string path = ConfigurationManager.AppSettings["attachPath"];
            LoginPage loginPage = new LoginPage();
            loginPage.OpenPage();
            Thread.Sleep(4000);
            LoginPage lp = new LoginPage();
            try
            {
                lp.SwitchUser();
            }
            catch (Exception) { }
            loginPage.SetLoginAndPassword(login, pass);
            EmailPage ep = new EmailPage();
            return ep.SetInvalidTheme(Path);
        }
    }
}
