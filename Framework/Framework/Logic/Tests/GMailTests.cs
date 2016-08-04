//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Framework.Logic.Steps;
//using FrameworkCore.Core.Utility.WebDriver;
//using Framework.Logic.Pages;

//namespace Framework.Logic.Tests
//{
//    [TestClass]
//    public class GMailTests
//    {
//        //[TestInitialize]
//        //public void TestInitialize()
//        //{
//        //    WebDriver.ReCreateDriver();
//        //}

//        [TestCleanup]
//        public void TestCleanUp()
//        {
//            //    WebDriver.CloseDriver();
//            EmailPage ep = new EmailPage();
//            LoginPage lp = new LoginPage();
//            try
//            {
//                ep.Logout();
//                lp.SwitchUser();
//            }
//            catch (Exception) { }
//        }
//        [TestMethod]
//        public void CheckingForSpam()
//        {
//            Spam a = new Spam();
//            Assert.IsTrue(a.AutorizeAndCheckSpam());
//    }
//        [TestMethod]
//        public void CheckingForForward()
//        {
//            Forward f = new Forward();
//            Assert.IsTrue(f.ForwardMailToAnotherUser());
//        }
//        [TestMethod]
//        public void CheckingForBigAttachment()
//        {
//            Attachment a = new Attachment();
//            Assert.IsTrue(a.BigAttachment());
//        }
//        [TestMethod]
//        public void CheckingForSignature()
//        {
//            Signature s = new Signature();
//            Assert.IsTrue(s.SetSignature());
//        }
//        [TestMethod]
//        public void CheckingForStarred()
//        {
//            Starred s = new Starred();
//            Assert.IsTrue(s.SetStarred());
//        }
//        [TestMethod]
//        public void CheckingForSetAndUnsetSpam()
//        {
//            MarkAndUnmarkSpam maus = new MarkAndUnmarkSpam(); 
//            Assert.IsTrue(maus.SetAndUnSetSpam());
//        }
//        [TestMethod]
//        public void CheckingForSetInvalidTheme()
//        {
//            BadTheme bt = new BadTheme();
//            Assert.IsTrue(bt.SetBadTheme());
//        }
//        [TestMethod]
//        public void CheckingForVacation()
//        {
//            Vacation v = new Vacation();
//            Assert.IsTrue(v.SetVacation());
//        }
//        [TestMethod]
//        public void CheckingEmoticons()
//        {
//            Emoticons e = new Emoticons();
//            Assert.IsTrue(e.SendEmoticons());
//        }
//    }
//}
