using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolQASelenium
{
    class Class1
    {
        IWebDriver driver;
        [SetUp]
        public void Initialization()
        {
            driver = new ChromeDriver();
        }
        [Test]
        public void ApplicationTest()
        {
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }
        [TearDown]
        public void down()
        {
            driver.Close();

        }
    }
}
