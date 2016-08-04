using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Framework.Logic.Pages;
using System.Threading;
namespace Framework.Logic.Steps
{
    public class Signature
    {
        public bool SetSignature()
        {
            string login = ConfigurationManager.AppSettings["login1"];
            string pass = ConfigurationManager.AppSettings["password1"];
            string signature = "Evgeny Zaitsev, Test Automation Lab";
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
            ep.GoToSettings();
            ep.SetSignature(signature);
            return ep.CheckSignature(signature);
        }
    }
}
