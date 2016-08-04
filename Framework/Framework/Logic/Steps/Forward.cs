using Framework.Logic.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;

namespace Framework.Logic.Steps
{
    public class Forward
    {
        public const string URL = @"https://www.gmail.com";
        public bool ForwardMailToAnotherUser(string Path)
        {
            string login1 = ConfigurationManager.AppSettings["login1"];
            string pass1 = ConfigurationManager.AppSettings["password1"];
            string login2 = ConfigurationManager.AppSettings["login2"];
            string pass2 = ConfigurationManager.AppSettings["password2"];
            string login3 = ConfigurationManager.AppSettings["login3"];
            string pass3 = ConfigurationManager.AppSettings["password3"];
            string textToSend = "Check Forward with attach";
            string textToSend2 = "Check Forward without attach";
            LoginPage loginPage = new LoginPage();
            loginPage.OpenPage();
            Thread.Sleep(4000);
            EmailPage ep = new EmailPage();
            LoginPage lp = new LoginPage();
            try
            {
//                ep.Logout();
                lp.SwitchUser();
            }
            catch (Exception) { }
            loginPage.SetLoginAndPassword(login2, pass2);
            EmailPage emailPage = new EmailPage();
            emailPage.GoToForwarding();
            emailPage.SetForward(login3);
            emailPage.Logout();
            loginPage.SwitchUser();
            loginPage.SetLoginAndPassword(login3, pass3);
            emailPage.ConfirmForward();
            emailPage.Logout();
            loginPage.SwitchUser();
            loginPage.SetLoginAndPassword(login2, pass2);
            emailPage.GoToForwarding();
            emailPage.SelectForwardToAndAddFilters(login1);
            emailPage.Logout();
            loginPage.SwitchUser();
            loginPage.SetLoginAndPassword(login1, pass1);
            Thread.Sleep(4000);
            emailPage.SendEmailWithAttach(/*ConfigurationManager.AppSettings["attachPath"]*/ Path, login2, textToSend);
            emailPage.SendEmail(login2, textToSend2);
            emailPage.Logout();
            loginPage.SwitchUser();
            loginPage.SetLoginAndPassword(login2, pass2);
            bool check1 = emailPage.CheckInbox(textToSend2);
            emailPage.GoToBin();
            bool check2 = emailPage.CheckBin(textToSend);
            emailPage.Logout();
            loginPage.SwitchUser();
            loginPage.SetLoginAndPassword(login3, pass3);
            bool check3 = emailPage.CheckInbox(textToSend2);
            return check1 && check2 && check3;
        }
    }
}
