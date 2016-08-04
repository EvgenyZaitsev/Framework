using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Logic.Pages;
using System.Configuration;
using System.Threading;
namespace Framework.Logic.Steps
{
    public class Starred
    {
        public bool SetStarred()
        {
            string login = ConfigurationManager.AppSettings["login1"];
            string pass = ConfigurationManager.AppSettings["password1"];
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
            return ep.CheckStarred(ep.SetStarred());
        }
    }
}
