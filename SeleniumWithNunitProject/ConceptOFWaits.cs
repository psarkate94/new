using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWithNunitProject
{
    class ConceptOFWaits
    {

        /*LinkText: it returns elements with an exact match of the given text
         PartialLinkText returns elements which include the given text*/
        [Test]
        public void ThreadWaitExample()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.uitestpractice.com/Students/Contact";
            driver.FindElement(By.LinkText("This is a Ajax link")).Click();
            Thread.Sleep(12000);
           String result= driver.FindElement(By.ClassName("ContactUs")).Text;
            Console.WriteLine(result.Contains("Python "));

            driver.Quit();

        }
        [Test]
        public void ImplicitWaitExample()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Url = "http://www.uitestpractice.com/Students/Contact";
            driver.FindElement(By.LinkText("This is a Ajax link")).Click();
           
            String result = driver.FindElement(By.ClassName("ContactUs")).Text;
            Console.WriteLine(result.Contains("Python "));

            driver.Quit();

        }
        [Test]
        public void ExplicittWaitExample()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
           
            driver.Url = "http://www.uitestpractice.com/Students/Contact";
            driver.FindElement(By.LinkText("This is a Ajax link")).Click();
            

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            
           bool b= wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.ClassName("ContactUs"), "Python"));
            /*wait.Until(ExpectedConditions.ElementExists(By.ClassName("ContactUs")));
            String result = driver.FindElement(By.ClassName("ContactUs")).Text;
            Console.WriteLine(result.Contains("Python "));*/
            Console.WriteLine(b);

            driver.Quit();

        }
        [Test]
        public void PageLoadWait()
        {
            // used to set amount of time  for  page to load before throwing an exception 

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/Students/Contact";
            driver.Quit();
        }
        // how to write custom expected condition , there r 3 ways 
         /*1. By defining a named method that has exactly one parameter of type IWebDriver and returns a value.
            2. By writing a lambda expression that accepts exactly one parameter of type IWebDriver and returns a value.
            3. By defining a method which returns a value of type Func IWebDriver, TResult*/
    }
}
