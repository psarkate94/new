using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWithNunitProject
{
    class WindowHandleAndBasicAuthentication
    {
        [Test]
       public void HandlingWindow()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://www.uitestpractice.com/Students/Switchto";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            String CurrentWindowId = driver.CurrentWindowHandle;
            Console.WriteLine("Before Click ");
            Console.WriteLine("Number of window open by selenium is " + driver.WindowHandles.Count);
            Console.WriteLine("Current window id is " + CurrentWindowId);


            driver.FindElement(By.XPath("//a[contains(text(),'Opens in a new window')]")).Click();
            Console.WriteLine("After Click ");
            Console.WriteLine("Number of window open by selenium is " + driver.WindowHandles.Count);
            Console.WriteLine("Current window id is " + CurrentWindowId);
            IReadOnlyCollection<String > ListofWindow=driver.WindowHandles;
            foreach(var item in ListofWindow)
            {
                Console.WriteLine(item);
            }
            driver.SwitchTo().Window(driver.WindowHandles[1]);
           String text= driver.FindElement(By.Id("draggable")).Text;
            Console.WriteLine(text);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Thread.Sleep(2000);
            driver.Quit();
        }
        [Test]
        public void ModelWindow()
        {
            // for model window we can spy that pop-up
            // model window is dialog that forces user to interact with them beofre working on parent/main application
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://www.uitestpractice.com/Students/Switchto";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("(//button[@type='button'])[2]")).Click();
            driver.FindElement(By.XPath("//div[@class='modal-footer']//button[contains(text(),'Ok')]")).Click();
            driver.Quit();
           
        }
        [Test]
        public void HandlingBasicAuthentication()
        {
           /* We can handle basic authentication in 4 ways
       1.Passing user name and password along with the url
            driver.Url =“http://UserName:Password@ankpro.com”
       2.alert.SetAuthenticationCredentials method.
   driver.SwitchTo().Alert().SetAuthenticationCredentials(“username”,”password”)
 3.Using SendKeys
  alert.SendKeys("username" + Keys.Tab + "password" + Keys.Tab); alert.Accept();
  4.We can use the third party automation tools like AutoIt or Sikuli for sending the keys to this window.*/

        }
    }
}
