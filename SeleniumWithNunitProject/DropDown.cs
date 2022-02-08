using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWithNunitProject
{
    class DropDown
    {
        [Test]
        public void CheckingDropDown()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
           IWebElement ele= driver.FindElement(By.Id("dropdown-class-example"));
            ele.Click();
            SelectElement select = new SelectElement(ele);
            select.SelectByText("Option2");


        }
    }
}
