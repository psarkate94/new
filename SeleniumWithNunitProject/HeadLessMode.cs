using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWithNunitProject
{
    class HeadLessMode
    {
        [Test]
        public void UsingChromeOptions()
        {
            // JE
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--headless");
            IWebDriver driver = new ChromeDriver(option);
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/";
            String s = driver.FindElement(By.XPath("//div[@class='container green']//h3")).Text;
            Console.WriteLine(s);
            driver.Quit();
        }
        [Test]
        public void UsingFirefoxOptions()
        {
            // JE
           FirefoxOptions option = new FirefoxOptions();
            option.AddArgument("--headless");
            IWebDriver driver = new FirefoxDriver(option);
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/";
            String s = driver.FindElement(By.XPath("//div[@class='container green']//h3")).Text;
            Console.WriteLine(s);
            driver.Quit();
        }
    }
}
