using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWithNunitProject
{
    class ExampleofNavigationinCSharp
    {
       [Test]
       public void NavigationOfDemo()
        {
            // launching browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Url = "https://demoqa.com/";
            String PageUrl = driver.Url;
            IWebElement ele=driver.FindElement(By.XPath("//div[@class='card-body']//h5[contains(text(),'Alerts, Frame & Windows')]"));
            Console.WriteLine("Element is present " + ele.Displayed);
            /*Console.WriteLine("Before Navigation url of Application is " + PageUrl);
            driver.SwitchTo().Frame(0);
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(30));
            wait.Until(drv => drv.FindElement(By.XPath("//div[@class='card-body']//h5[contains(text(),'Alerts, Frame & Windows')]")));
            driver.FindElement(By.XPath("//div[@class='card-body']//h5[contains(text(),'Alerts, Frame & Windows')]")).Click();*/

            Console.WriteLine("After Clicking on Element Application is " + PageUrl);
            driver.Navigate().Back();
            String PageUrl2 = driver.Url;
            Console.WriteLine("After back NAvigation url of  Application is " + PageUrl2);
            driver.Navigate().Forward();
            String PageUrl3 = driver.Url;
            Console.WriteLine("After back NAvigation url of  Application is " + PageUrl3);
            driver.Navigate().Refresh();
            driver.Close();


        }

    }
}
