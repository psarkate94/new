using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWithNunitProject
{
    class ExampleOfWeElementCommand
    {
        [Test]
        public void WebCommands()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            String att=driver.FindElement(By.Id("openwindow")).GetAttribute("class");

            // 2 nd way to write webelement
            /*By Locator=By.Id("openwindow");
            IWebElement e=driver.FindElement(Locator);*/

            Console.WriteLine(att);
            ///// finding elements in application
           IReadOnlyCollection<IWebElement> list= driver.FindElements(By.XPath("//div[@id='radio-btn-example']//label"));
            Console.WriteLine("size of list " + list.Count);
           
            foreach(IWebElement l in list)
            {
               
                Console.WriteLine(l.Text);
            }
            driver.Close();
        }
    }
}
