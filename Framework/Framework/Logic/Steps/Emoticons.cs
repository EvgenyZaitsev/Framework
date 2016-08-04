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
    public class Emoticons
    {
        public bool SendEmoticons()
        {
            string login1 = ConfigurationManager.AppSettings["login1"];
            string pass1 = ConfigurationManager.AppSettings["password1"];
            string login3 = ConfigurationManager.AppSettings["login3"];
            string pass3 = ConfigurationManager.AppSettings["password3"];
            string message = ConfigurationManager.AppSettings["message"];
            string subject = "Emoticons";
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
            EmailPage emailPage = new EmailPage();
            emailPage.SendEmailWithEmoticons(login1, subject);
            emailPage.Logout();
            loginPage.SwitchUser();
            loginPage.SetLoginAndPassword(login1, pass1);
            Thread.Sleep(2000);
            return emailPage.CheckFirstMessage(subject);
        }
    }   
}
