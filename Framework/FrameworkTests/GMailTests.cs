using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Logic.Steps;
using FrameworkCore.Core.Utility.WebDriver;
using Framework.Logic.Pages;
using NUnit.Framework;
using System.Configuration;
namespace FrameworkTests
{
    [TestFixture]
    public class GMailTests
    {
        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    WebDriver.ReCreateDriver();
        //}

        [TearDown]
        public void TestCleanUp()
        {
            //    WebDriver.CloseDriver();
            EmailPage ep = new EmailPage();
            LoginPage lp = new LoginPage();
            try
            {
                ep.Logout();
                lp.SwitchUser();
            }
            catch (Exception) { }
        }
        [Test]
        public void CheckingForSpam()
        {
            Spam a = new Spam();
            Assert.IsTrue(a.AutorizeAndCheckSpam());
    }
        [Test]
        public void CheckingForForward()
        {
            string Path = TestContext.CurrentContext.TestDirectory + "\\" + ConfigurationManager.AppSettings["bigAttachName"];

            Forward f = new Forward();
            Assert.IsTrue(f.ForwardMailToAnotherUser(Path));
        }
        [Test]
        public void CheckingForBigAttachment()
        { 
            string Path = TestContext.CurrentContext.TestDirectory + "\\" + ConfigurationManager.AppSettings["bigAttachName"];

            Attachment a = new Attachment();
            Assert.IsTrue(a.BigAttachment(Path));
        }
        [Test]
        public void CheckingForSignature()
        {
            Signature s = new Signature();
            Assert.IsTrue(s.SetSignature());
        }
        [Test]
        public void CheckingForStarred()
        {
            Starred s = new Starred();
            Assert.IsTrue(s.SetStarred());
        }
        [Test]
        public void CheckingForSetAndUnsetSpam()
        {
            MarkAndUnmarkSpam maus = new MarkAndUnmarkSpam(); 
            Assert.IsTrue(maus.SetAndUnSetSpam());
        }
        [Test]
        public void CheckingForSetInvalidTheme()
        {
            string Path = TestContext.CurrentContext.TestDirectory + "\\" + ConfigurationManager.AppSettings["attachName"];
            BadTheme bt = new BadTheme();
            Assert.IsTrue(bt.SetBadTheme(Path));
        }
        [Test]
        public void CheckingForVacation()
        {
            Vacation v = new Vacation();
            Assert.IsTrue(v.SetVacation());
        }
        [Test]
        public void CheckingEmoticons()
        {
            Emoticons e = new Emoticons();
            Assert.IsTrue(e.SendEmoticons());
        }
    }
}
