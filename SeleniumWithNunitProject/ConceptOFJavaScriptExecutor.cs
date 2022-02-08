using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWithNunitProject
{
    class ConceptOFJavaScriptExecutor
    {
        [Test]
        public void CreatingAlertUsingJE()
        {
            // JE
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/Students/Select";
         IJavaScriptExecutor jb = ((IJavaScriptExecutor)driver);
            jb.ExecuteScript("alert('Hello pk is here')");
            Thread.Sleep(1000);
            driver.Quit();
        }
        [Test]
        public void RefreshingThePageUsingJE()
        {
            // JE
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/Students/Select";
            IJavaScriptExecutor jb = ((IJavaScriptExecutor)driver);
            jb.ExecuteScript("history.go(0)");
           Thread.Sleep(1000);
            driver.Quit();
        }
        [Test]
        public void GettingValueOFHiddenElementUsingJE()
        {
            // JE
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/Students/Index";
            IJavaScriptExecutor jb = ((IJavaScriptExecutor)driver);
            driver.FindElement(By.XPath("(//table//tbody//tr//td[4]//button[contains(text(),'EDIT')])[1]"));
            string s = ((IJavaScriptExecutor)driver).ExecuteScript(" return document.getElementById('Id').value").ToString();
            Console.WriteLine(s);
            driver.Quit();
        }
        [Test]
        public void HighLightELement()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/Students/Index";
            IWebElement ele = driver.FindElement(By.Id("Search_Data"));
           IWebElement ele2= driver.FindElement(By.XPath("//table//tbody//tr[2]//td[1]"));
            HighLightElement(ele, driver);
            HighLightElement(ele2, driver);
            Thread.Sleep(4000);
            driver.Quit();
        }
        private void HighLightElement(IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px dotted red'", element);




        }
    }
}
