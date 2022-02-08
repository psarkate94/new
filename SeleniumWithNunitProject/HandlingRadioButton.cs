using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWithNunitProject
{
    class HandlingRadioButton
    {
        [Test]
        public void CheckingRadioButton()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Url = "https://demoqa.com/automation-practice-form/";

            IList<IWebElement> RadioListCheckbox=driver.FindElements(By.XPath("//div[@id='genterWrapper']//label"));
            foreach(IWebElement l in RadioListCheckbox)
            {
                Console.WriteLine(l.Text);
                if (l.Text.Equals("Female"))
                {
                   
                    bool checking =l.Selected;
                    if(checking ==false)
                    {
                        l.Click();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
