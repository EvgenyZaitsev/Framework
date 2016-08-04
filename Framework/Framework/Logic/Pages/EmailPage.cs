using FrameworkCore.Core.Logic.Elements;
using FrameworkCore.Core.Utility.Waiter;
using OpenQA.Selenium;
using FrameworkCore.Core.Logic.Pages;
using System;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Configuration;

namespace Framework.Logic.Pages
{
    public class EmailPage : Page
    {
        private Button buttonCompose = new Button(By.XPath("//div[text()='COMPOSE']"));
        private Input inputTo = new Input(By.Name("to"));
        private Input inputEmailContent = new Input(By.XPath("//td[2]/div[2]/div"));
        private Button buttonSend = new Button(By.XPath("//div[text()='Send']"));
        private Button buttonAccount = new Button(By.XPath("//div/a/span"));
        private Button buttonSignOut = new Button(By.XPath("//div[3]/div[2]/a"));
        private Button checkboxForFirstMessage = new Button(By.XPath("/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div/div[7]/div/div[1]/div[2]/div/table/tbody/tr[1]/td[2]/div"));
        private Button buttonSpam = new Button(By.XPath("//div[@class='T-I J-J5-Ji nN T-I-ax7 T-I-Js-Gs T-I-Js-IF ar7']"));
        private Input inputSearch = new Input(By.XPath("//td/div/input"));
        private Button buttonSearch = new Button(By.XPath("//button[@aria-label='Search Gmail']"));

        private Button buttonForwarding = new Button(By.XPath("//input[@value='Add a forwarding address']"));
        private Input inputForwardAdress = new Input(By.XPath("//*[@class='PN']/input"));
        private Button buttonForFirstMessage = new Button(By.XPath("//div[2]/div/table/tbody/tr/td[4]"));
        private Link linkConfirmation = new Link(By.XPath("//a[4]"));
        private Button buttonForwardMailTo = new Button(By.XPath("//span[contains(.,'Forward a copy of incoming mail to')]/../preceding-sibling::td/input"));
        private Button buttonSaveChanges = new Button(By.XPath("//td/div/button"));
        private Link linkOpenFilters = new Link(By.XPath("//span[text()='creating a filter!']"));
        private Input inputFilterFrom = new Input(By.XPath("//span[2]/input"));
        private Link linkAdvancedFilter = new Link(By.XPath("//div[text()='Create filter with this search »']"));
        private Button buttonSaveFilter = new Button(By.Name("ok"));
        private Button checkboxDeleteIt = new Button(By.XPath("//div[6]/input"));
        private Button checkboxMarkAsImportant = new Button(By.XPath("//div[8]/input"));
        private Button buttonSaveAdvancedFilter = new Button(By.XPath("//div[text()='Create filter']"));
        private Button buttonAttachFiles = new Button(By.XPath("//td[4]/div/div/div/div/div"));
        private Button buttonUseSignature = new Button(By.XPath("//tr[19]/td[2]/table[2]/tbody/tr/td/input"));
        private Input inputSetSignatureText = new Input(By.XPath("//span/div/table/tbody/tr/td[2]/div[2]/div"));
        private Button checkboxIsStarred = new Button(By.XPath("//td[3]/span"));
        private Button buttonRemoveFromSpam = new Button(By.XPath("//div[text()='Not spam']"));
        private Link linkSetTheme = new Link(By.LinkText("Set Theme."));
        private Button buttonMyPhotos = new Button(By.XPath("//div[text()='My Photos']"));
        private Button tabUploadPhoto = new Button(By.XPath("//div[@class='a-ki']/div[contains(text(),'Upload a photo')]"));
        private Button buttonSelectPhoto = new Button(By.XPath("//div[contains(text(),'Select a photo from your computer')]"));
        private Button radioAutoreplyOn = new Button(By.XPath("//tr[2]/td/input"));
        private Input inputVacationSubject = new Input(By.XPath("//tr[4]/td[3]/input"));
        private Input inputVacationMessage = new Input(By.XPath("//td[3]/div/table/tbody/tr/td[2]/div/div/textarea"));
        private Link linkPlainText = new Link(By.XPath("//span[4]"));
        private Button buttonSelectEmoticon = new Button(By.XPath("//td[4]/div/div[5]"));
        private Button buttonEmoticon1 = new Button(By.XPath("//div[2]/div/div/div/div/button"));
        private Button buttonEmoticon2 = new Button(By.XPath("//div[2]/div/div/div/div/button[2]"));
        private Input inputSubject = new Input(By.Name("subjectbox"));

        public void SendEmail(string receiverEmail, string text)
        {
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(buttonCompose.By)).Click();
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(inputTo.By)).SendKeys(receiverEmail);
            var textarea = Waiter.ExplicitWaitBy(20, inputEmailContent.By);
            textarea.Clear();
            textarea.SendKeys(text);
            Waiter.ExplicitWaitBy(20, buttonSend.By).Click();
        }
        public void Logout()
        {
            Thread.Sleep(4000);
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(buttonAccount.By)).Click();
            Waiter.ExplicitWaitBy(20, buttonSignOut.By).Click();
        }
        public void AddToSpam()
        {
            try
            {
                Thread.Sleep(2000);
                if (Driver.FindElement(By.XPath("/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div[1]/div[7]/div/div[1]/div[2]/div/table/tbody/tr[1]/td[5]/div[2]/span"))?.Text == "Test 1")
                {
                    Thread.Sleep(1000);
                    Waiter.ExplicitWaitBy(20, checkboxForFirstMessage.By).Click();
                    Waiter.ExplicitWaitBy(20, buttonSpam.By).Click();
                    Thread.Sleep(1000);
                    GoToSpam();
                    //Waiter.ExplicitWaitBy(20, inputSearch.By).SendKeys("in:spam");
                    //Waiter.ExplicitWaitBy(20, buttonSearch.By).Click();
                }
            }
            catch (NoSuchElementException) { }
        }
        public void GoToSpam()
        {
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(inputSearch.By)).SendKeys("in:spam");
            Waiter.ExplicitWaitBy(20, buttonSearch.By).Click();
        }
        public void GoToStarred()
        {
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(inputSearch.By)).SendKeys("is:starred");
            Waiter.ExplicitWaitBy(20, buttonSearch.By).Click();
        }
        public bool CheckSpam(string text)
        {
            try
            {
                return Driver.FindElement(By.XPath("//div/span[2]"))?.Text == $" - {text}";
            }
            catch (NoSuchElementException) { return false;}
        }
        public void GoToThemes()
        {
            Driver.Navigate().GoToUrl(@"https://mail.google.com/mail/u/0/#settings/oldthemes");
        }
        public void GoToInbox()
        {
            Driver.Navigate().GoToUrl(@"https://mail.google.com/mail/u/0/#inbox");
        }
        public void GoToForwarding()
        {
            Driver.Navigate().GoToUrl(@"https://mail.google.com/mail/u/0/#settings/fwdandpop");
        }
        public void GoToSettings()
        {
            Driver.Navigate().GoToUrl(@"https://mail.google.com/mail/u/0/#settings/general");
        }
        public void GoToFilters()
        {
            Driver.Navigate().GoToUrl(@"https://mail.google.com/mail/u/0/#settings/filters");
        }
        public void SetForward(string email)
        {
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementToBeClickable(buttonForwarding.By)).Click(); 
            Waiter.ExplicitWaitBy(20, inputForwardAdress.By).SendKeys(email);
            Driver.FindElement(By.XPath("//div[3]/button")).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Thread.Sleep(4000);
            Driver.FindElement(By.XPath("//input[@value='Proceed']")).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.First());
            Thread.Sleep(1000);
            try
            {
                Driver.FindElement(By.Name("ok")).Click();
            }
            catch (NoSuchElementException) { }
        }
        public void ConfirmForward()
        {
            Thread.Sleep(1000);
            Waiter.ExplicitWaitBy(20, buttonForFirstMessage.By).Click();
            Waiter.ExplicitWaitBy(20, linkConfirmation.By).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Driver.FindElement(By.XPath("//input[@value='Confirm']")).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.First());
        }
        public void SelectForwardToAndAddFilters(string email)
        {
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementToBeClickable(buttonForwardMailTo.By)).Click();
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementToBeClickable(buttonSaveChanges.By)).Click();
            Thread.Sleep(4000);
            GoToForwarding();
            Thread.Sleep(4000);
            Waiter.ExplicitWaitBy(20, linkOpenFilters.By).Click();
            Thread.Sleep(2000);
            Waiter.ExplicitWaitBy(20, inputFilterFrom.By).SendKeys(email);
            Driver.FindElement(By.XPath("//div[7]/span/input")).Click();
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(linkAdvancedFilter.By)).Click();
            try
            {
                Waiter.ExplicitWaitWithCondition(5, ExpectedConditions.ElementIsVisible(buttonSaveFilter.By)).Click();
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException) { }
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(checkboxDeleteIt.By)).Click();
            Waiter.ExplicitWaitBy(20, checkboxMarkAsImportant.By).Click();
            Waiter.ExplicitWaitBy(20, buttonSaveAdvancedFilter.By).Click();
        }
        public bool SendEmailWithAttach(string path, string receiverEmail, string text)
        {
            Waiter.ExplicitWaitWithCondition(20,ExpectedConditions.ElementToBeClickable(buttonCompose.By)).Click();
            Waiter.ExplicitWaitBy(20, inputTo.By).SendKeys(receiverEmail);
            var textarea = Waiter.ExplicitWaitBy(20, inputEmailContent.By);
            textarea.Clear();
            textarea.SendKeys(text);
            Thread thread = new Thread(
               () =>
               {
                   System.Windows.Forms.Clipboard.SetText(path);
               });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
//            System.Windows.Forms.Clipboard.SetText(path);
            Waiter.ExplicitWaitBy(20, buttonAttachFiles.By).Click();
            Thread.Sleep(4000);
            System.Windows.Forms.SendKeys.SendWait("^(v)");
            Thread.Sleep(1000);
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            Thread.Sleep(500);
            try
            {
                //        var element = Driver.FindElement(By.Name("ok"));
                //        element.Click();
                var elements = Driver.FindElements(By.XPath("//button"));
                foreach (var element in elements)
                    if (element.Text == "Cancel")
                    {
                        element.Click();
                        return true;
                    }
             
            }
            catch (Exception)
            {
                Waiter.ExplicitWaitBy(20, buttonSend.By).Click();
                return false; }
            Waiter.ExplicitWaitBy(20, buttonSend.By).Click();
            return true;
        }
        public void GoToBin()
        {
            Waiter.ExplicitWaitBy(20, inputSearch.By).SendKeys("in:trash");
            Waiter.ExplicitWaitBy(20, buttonSearch.By).Click();
        }
        public bool CheckInbox(string text)
        {
            try
            {
                return Driver.FindElement(By.XPath("//div/div/span[2]"))?.Text == $" - {text}";
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CheckBin(string text)
        {
            try
            {
                return Driver.FindElement(By.XPath("//div[4]/div/div/table/tbody/tr/td[6]/div/div/div/span[2]"))?.Text == $" - {text}";
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void SetSignature(string text)
        {
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementToBeClickable(buttonUseSignature.By)).Click();
            var input = Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(inputSetSignatureText.By));
            input.Clear();
            input.SendKeys(text);
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementToBeClickable(buttonSaveChanges.By)).Click();
        }
        public bool CheckSignature(string text)
        {
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(buttonCompose.By)).Click();
            try
            {
                return Driver.FindElement(inputEmailContent.By).Text.Contains($"--\r\n{text}");
            }
            catch (Exception) { return false; }
        }
        public string SetStarred()
        {
            Thread.Sleep(1000);
            if (Driver.FindElement(checkboxIsStarred.By).GetAttribute("title") != "Starred")
                Waiter.ExplicitWaitBy(20, checkboxIsStarred.By).Click();
            return Driver.FindElement(By.XPath("//div/div/span/b")).Text;
        }
        public bool CheckStarred(string text)
        {
            GoToStarred();
            try
            {
                var subjectStarred = Driver.FindElement(By.XPath("//div[2]/span/b")).Text;
                return subjectStarred.Equals(text);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string RemoveToSpam()
        {
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementToBeClickable(By.XPath("//div[2]/div/table/tbody/tr/td[2]/div/div"))).Click();
            var subjectSpam = Driver.FindElement(By.XPath("//div/div/span/b")).Text;
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementToBeClickable(buttonSpam.By)).Click();
            return subjectSpam;
        }
        public bool RemoveFromSpam(string text)
        {
            GoToSpam();
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementToBeClickable(By.XPath("//div[4]/div/div/table/tbody/tr/td[2]/div/div"))).Click();
            var subjectSpam = Driver.FindElement(By.XPath("//div[4]/div/div/table/tbody/tr/td[6]/div/div/div/span/b")).Text;
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementToBeClickable(buttonRemoveFromSpam.By)).Click();
            return subjectSpam.Equals(text);
        }
        public bool SetInvalidTheme(string path)
        {
            GoToThemes();
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementToBeClickable(linkSetTheme.By)).Click();
            Thread.Sleep(2000);
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementToBeClickable(buttonMyPhotos.By)).Click();
            Thread.Sleep(2000);
            Driver.SwitchTo().Frame(Driver.FindElement(By.XPath("//iframe[@class='KA-JQ']")));
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementToBeClickable(tabUploadPhoto.By)).Click();
            Thread thread = new Thread(
                           () =>
                           {
                               System.Windows.Forms.Clipboard.SetText(path);
                           });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementToBeClickable(buttonSelectPhoto.By)).Click();
            Thread.Sleep(4000);
            System.Windows.Forms.SendKeys.SendWait("^(v)");
            Thread.Sleep(1000);
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            Thread.Sleep(2000);
            try
            {
                if (Driver.FindElement(By.XPath("//div[contains(text(),'is not supported for upload.')]")).Displayed)
                {
                    Thread.Sleep(2000);
                    Driver.FindElement(By.XPath("//div[@aria-label='Close']")).Click();
                    Thread.Sleep(2000);
                    Driver.SwitchTo().DefaultContent();
                    Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Cancel']"))).Click();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                GoToSettings();
                return false;
            }
        }
        public void SetVacationResponder(string vacationSubject, string vacationMessage)
        {
            GoToSettings();
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementToBeClickable(radioAutoreplyOn.By)).Click();
            var subject = Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(inputVacationSubject.By));
            subject.Clear();
            subject.SendKeys(vacationSubject);
            if (Driver.FindElement(By.XPath("//span[4]")).Text == "« Plain Text")
                Driver.FindElement(By.XPath("//span[4]")).Click();
            var message = Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(inputVacationMessage.By));
            message.Clear();
            message.SendKeys(vacationMessage);
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(buttonSaveChanges.By)).Click();
        }
        public bool CheckFirstMessage(string subject)
        {
            try
            {
                return Driver.FindElement(By.XPath("//div/div/span/b")).Text.Contains(subject);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void SendEmailWithEmoticons(string email, string subject)
        {
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(buttonCompose.By)).Click();
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(inputTo.By)).SendKeys(email);
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(inputSubject.By)).SendKeys(subject);
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementToBeClickable(buttonSelectEmoticon.By)).Click();
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(By.XPath("//button[2]"))).Click();
            Waiter.ExplicitWaitBy(20, inputEmailContent.By).SendKeys("");
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(buttonEmoticon1.By)).Click();
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementIsVisible(buttonEmoticon2.By)).Click();
            Thread.Sleep(1000);
            Waiter.ExplicitWaitWithCondition(20, ExpectedConditions.ElementToBeClickable(buttonSend.By)).Click();
        }
    }
    
}
