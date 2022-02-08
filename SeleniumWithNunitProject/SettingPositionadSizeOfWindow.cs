using NUnit.Framework;
using OpenQA.Selenium;
using System.Drawing;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWithNunitProject
{
    class SettingPositionadSizeOfWindow
    {
        [Test]
        public void GettingPositions()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            /*driver.Manage().Window.Position = new Point(400, 200);
            Point point =driver.Manage().Window.Position;
            Console.WriteLine("Position of Window is"+ point);
*/
            // getting size of window 
            driver.Manage().Window.Size = new Size(400,600);
           Size size= driver.Manage().Window.Size;
            Thread.Sleep(3000);
            Console.WriteLine("size of Window is" + size);
            driver.Close();
        }
    }
}
