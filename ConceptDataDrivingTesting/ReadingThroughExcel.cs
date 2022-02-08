using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConceptDataDrivingTesting
{/*
    What is EPPlus library
EPPlus is a.NET library
Reads and writes Excel files using the Open Office XML format(*.xlsx)

ExcelPackage class
 Represents an Excel  XLSX file package.
 This is the top level object to access all parts of the document.
Has a FileInfo parameterized

ExcelWorksheet class Represents an Excel worksheet and provides access to its properties and methods

Cells Property
ReadOnly property
Returns a cell value when we provide Row and Column parameters*/
    [TestClass]
    class ReadingThroughExcel
    {
        [TestMethod]
        [DynamicData(nameof(ExcelRead), DynamicDataSourceType.Method)]

        public void DataDrivenUsingExcel(string fName, string lName, string eDate)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";

            driver.FindElement(By.Id("FirstName")).SendKeys(fName);
            driver.FindElement(By.Id("LastName")).SendKeys(lName);
            driver.FindElement(By.Id("EnrollmentDate")).SendKeys(eDate);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            driver.Quit();
        }
        public static IEnumerable<object[]> ExcelRead()
        {
            using (ExcelPackage package = new ExcelPackage(new FileInfo("Data.xlsx")))
            {
                ExcelWorksheet sheets = package.Workbook.Worksheets["Sheet1"];
                int rowCount = sheets.Dimension.End.Row;
                for (int i = 2; i <= rowCount; i++)
                {
                    yield return new object[]
                    {
                        sheets.Cells[i,1].Value?.ToString().Trim(),//firstname
                    sheets.Cells[i, 2].Value?.ToString().Trim(),//Lasttname
                    sheets.Cells[i, 3].Value?.ToString().Trim() //Enrolldate
                };
                }


            }
        }
    }
}


    


   

