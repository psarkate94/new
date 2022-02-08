using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWithNunitProject
{
    class DropDownConcept
    {
        [Test]
        public void GettingAllOptionsfromDropDon()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/Students/Select";
            IWebElement element = driver.FindElement(By.Id("countriesSingle"));
            SelectElement selectElement = new SelectElement(element);
            IList<IWebElement> ele = selectElement.Options;
            Console.WriteLine("OPtions availiable in DropDown is " + ele.Count);
            foreach (IWebElement e in ele)
            {
                Console.WriteLine(e.Text);
            }
            bool isMultiSelect = selectElement.IsMultiple;
            Console.WriteLine("Checking dropdown is support for multiSelect is :  " + isMultiSelect);
            driver.Close();
        }
        [Test]
        public void MultiSelectDropDown()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/Students/Select";
            IWebElement element = driver.FindElement(By.Id("countriesMultiple"));
            SelectElement selectElement = new SelectElement(element);
            IList<IWebElement> ele = selectElement.Options;
            Console.WriteLine("OPtions availiable in DropDown is " + ele.Count);

            bool isMultiSelect = selectElement.IsMultiple;
            Console.WriteLine("Checking dropdown is support for multiSelect is :  " + isMultiSelect);
            
            selectElement.SelectByText("United states of America");
            selectElement.SelectByText("China");
            selectElement.SelectByText("England");
            Thread.Sleep(3000);
          IList<IWebElement> selectedOptions = selectElement.AllSelectedOptions;
            Console.WriteLine("Count of selected options are " + selectedOptions.Count);
            foreach(IWebElement e in selectedOptions)
            {
                Console.WriteLine(e.Text);
            }
            driver.Close();
        }
        [Test]
        public void BootStrapDropdown()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/Students/Select";

            driver.FindElement(By.Id("dropdownMenu1")).Click();
           IReadOnlyCollection<IWebElement> ele  = driver.FindElements(By.XPath("//ul[@class='dropdown-menu']//li//a"));

            Console.WriteLine("Bootstrap dropdown count is "+ele.Count);
            foreach(var e in ele)
            {
                Console.WriteLine(e.Text);
                if(e.Text.Equals("England"))
                {
                    Console.WriteLine("inside if loop");
                    e.Click();
                }
            }
          
            Thread.Sleep(3000);
            String text=driver.FindElement(By.Id("dropdownMenu1")).Text;
            Console.WriteLine(text);
            driver.Close();
        }
    }
}