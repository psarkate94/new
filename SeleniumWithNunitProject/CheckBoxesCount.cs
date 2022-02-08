using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWithNunitProject
{
    class CheckBoxesCount
    {
        [Test]
        public void CountOfCheckboxex()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/Students/Form";
            driver.FindElement(By.CssSelector("input[value='dance']")).Click();
            driver.FindElement(By.CssSelector("input[value='read']")).Click();
            IReadOnlyCollection<IWebElement> ListOfCheckboxes=driver.FindElements(By.CssSelector("input[type='checkbox']"));

            int CheckedCount = 0;
            int uncheckedCount = 0;
            foreach(var item in ListOfCheckboxes)
            {
                if(item.Selected==true)
                {
                    CheckedCount++;
                  
                }
                else
                {
                    uncheckedCount++;
                   
                }

                
            }
            Console.WriteLine("Number of checkboxes are checked is: " + CheckedCount);
            Console.WriteLine("Number of checkboxes are unchecked is: " + uncheckedCount);

            driver.FindElement(By.CssSelector("#comment")).SendKeys("Good \n morning");
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#comment")).SendKeys("\n Good"+Keys.Space+ "morning");
            Thread.Sleep(3000);
            driver.Close();

        }
    }
}
