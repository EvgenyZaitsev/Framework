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
    public class Vacation
    {
        public bool SetVacation()
        {
            string login1 = ConfigurationManager.AppSettings["login1"];
            string pass1 = ConfigurationManager.AppSettings["password1"];
            string login3 = ConfigurationManager.AppSettings["login3"];
            string pass3 = ConfigurationManager.AppSettings["password3"];
            string subject = ConfigurationManager.AppSettings["subject"];
            string message = ConfigurationManager.AppSettings["message"];
            LoginPage loginPage = new LoginPage();
            loginPage.OpenPage();
            Thread.Sleep(4000);
            LoginPage lp = new LoginPage();
            try
            {
                //                ep.Logout();
                lp.SwitchUser();
            }
            catch (Exception) { }
            loginPage.SetLoginAndPassword(login3, pass3);
            EmailPage ep = new EmailPage();
            ep.SetVacationResponder(subject, message);
            ep.Logout();
            loginPage.SwitchUser();
            loginPage.SetLoginAndPassword(login1, pass1);
            ep.SendEmail(login3, "testing");
            Thread.Sleep(10000);
            ep.Driver.Navigate().Refresh();
            return ep.CheckFirstMessage(subject);
        }
    }
}
