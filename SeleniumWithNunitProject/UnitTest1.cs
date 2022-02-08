using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWithNunitProject
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }
        [TearDown]
        public void CLoseBrowser()
        {
            driver.Close();
    }
    }
  
}