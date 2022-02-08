using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWithNunitProject
{
    class ConceptOfAlertAndFrame
    {
        [Test]
        public void SimpleAlert()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://www.uitestpractice.com/Students/Switchto";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("alert")).Click();
            Thread.Sleep(1000);
            IAlert alert =driver.SwitchTo().Alert();
            String text = alert.Text;
            alert.Accept();
            driver.Close();

   }
        [Test]
        public void PromptAlert()
        {
            // prompt alert ask input from user 
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://www.uitestpractice.com/Students/Switchto";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("prompt")).Click();
            Thread.Sleep(4000);
            driver.SwitchTo().Alert().SendKeys("pravi");
            //alert.SendKeys("pravinkumar");
            Thread.Sleep(3000);
            /*alert.Accept();
            driver.Close();*/

        }
        [Test]
        public void ConformationAlert()
        {
            // ask permission to do some type of operation
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://www.uitestpractice.com/Students/Switchto";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("confirm")).Click();
         IAlert alert =driver.SwitchTo().Alert();
            Console.WriteLine(alert.Text);
            alert.Dismiss();
            Thread.Sleep(3000);
            driver.Quit();
        }
        [Test]
        public void HandlingFrame()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://www.uitestpractice.com/Students/Switchto";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            driver.SwitchTo().Frame("iframe_a");
            driver.FindElement(By.Id("name")).SendKeys("pravinkumar");
            driver.SwitchTo().DefaultContent();
            driver.FindElement(By.XPath("//a[contains(text(),'Opens in a new window')]")).Click();
            driver.Quit();

        }

    }
}
