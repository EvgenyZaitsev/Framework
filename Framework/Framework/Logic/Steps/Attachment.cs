using Framework.Logic.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Logic.Steps
{
    public class Attachment
    {
        public bool BigAttachment(string path)
        {
            string login = ConfigurationManager.AppSettings["login3"];
            string pass = ConfigurationManager.AppSettings["password3"];
            string login1 = ConfigurationManager.AppSettings["login1"];
            string textToSend = "Check Forward with big attach";
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
            loginPage.SetLoginAndPassword(login, pass);
            EmailPage emailPage = new EmailPage();
            return emailPage.SendEmailWithAttach(/*ConfigurationManager.AppSettings["bigAttachPath"]*/ path, login1, textToSend );
        }
    }
}
