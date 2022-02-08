using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ToolQASelenium
{
    class FirstTestcase
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }
    }
}
