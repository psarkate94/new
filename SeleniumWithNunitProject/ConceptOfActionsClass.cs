using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWithNunitProject
{
    class ConceptOfActionsClass
    {
        [Test]
        public void MovetoElement()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/Students/Actions";
            // here if we move to that element then color will be change
            Actions action = new Actions(driver);
            // 1.   action.MoveToElement(driver.FindElement(By.Id("div2"))).Build().Perform();
            // 2. way     action.MoveToElement(driver.FindElement(By.Id("div2")),20,20).Build().Perform();

            // this will move to element and calculate top left of element and click on it 
            // action.MoveToElement(driver.FindElement(By.Id("div2")), 20, 20, MoveToElementOffsetOrigin.TopLeft).ContextClick().Build().Perform();

            // this will move to element and calculate centre  of element and click on it 
            action.MoveToElement(driver.FindElement(By.Id("div2")), 20, 20, MoveToElementOffsetOrigin.Center).ContextClick().Build().Perform();

            Thread.Sleep(2000);
            driver.Close();

        }

        [Test]
        public void ClickwithWebElementandClick()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/Students/Actions";
            Actions action = new Actions(driver);
            // action.MoveToElement(driver.FindElement(By.XPath("//button[@name='click']"))).Click().Build().Perform();
            action.Click(driver.FindElement(By.XPath("//button[@name='click']")));

            driver.Close();
        }
        [Test]
        public void DoubleClickwithWebElementandDoubleClick()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/Students/Actions";
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath("//button[@name='dblClick']"))).DoubleClick().Build().Perform();
           
           // action.DoubleClick(driver.FindElement(By.XPath("//button[@name='dblClick']")));

            driver.Quit();
        }

       // NotE:whenever we perform only on action using actions class then no need to use build , we can direclty use perform
        [Test]
        public void KeysUpAndDown()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/Students/Actions";
            Actions action = new Actions(driver);
            action.KeyDown(Keys.Control).Click(driver.FindElement(By.XPath("//li[@name='one']")))
                .Click(driver.FindElement(By.XPath("//li[@name='six']"))).
                Click(driver.FindElement(By.XPath("//li[@name='eleven']"))).Build().Perform();
            action.DoubleClick(driver.FindElement(By.XPath("//button[@name='dblClick']"))).Build().Perform();
            driver.Quit();

        }
        [Test]
        public void UseOFSendKeysforPageUpAndDown()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/Students/Actions";
            Actions action = new Actions(driver);
            // scrolling down to bottom
            action.SendKeys(Keys.End).Perform();
            Thread.Sleep(1000);
            //scrolling to top 
            action.SendKeys(Keys.Home).Perform();
            Thread.Sleep(1000);
            driver.Quit();


        }
        [Test]
        public void UseOFSendKeysWithWebElement()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/Students/Actions";
            Actions action = new Actions(driver);
            action.SendKeys(driver.FindElement(By.Name("click")), Keys.Enter).Perform();
          
        }
        [Test]
        public void withMultipleSenkeysTosendData()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "https://accounts.google.com/signup";
            Actions action = new Actions(driver);
            // take one webelement 
            action.Click(driver.FindElement(By.Id("firstName")))
                .SendKeys("pravin" + Keys.Tab)
                .SendKeys("xy" + Keys.Tab)
                .SendKeys("xyz123453566654" + Keys.Tab)
                .SendKeys("12345687867867867" + Keys.Tab)
                .Build().Perform();
            driver.Quit();
               

        }
    }
}
