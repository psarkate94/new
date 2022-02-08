using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWithNunitProject
{
    class Execrice1
    {
        IWebDriver driver;
        // opening url get title ,url and pagesource
        [Test]
        public void Application()
        {
            // launching browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            String PageUrl=driver.Url;
            Console.WriteLine("Url of Application is " + PageUrl);
           String TitleOfPage= driver.Title;
            Console.WriteLine("Title of Application is " + TitleOfPage);
           int LengthOfTitle= TitleOfPage.Length;
            Console.WriteLine("LengthOfTitle of Application is " + LengthOfTitle);
           String PageSource =driver.PageSource;
            Console.WriteLine("PageSource "+ PageSource);
            driver.Close();


        }
    }
}
