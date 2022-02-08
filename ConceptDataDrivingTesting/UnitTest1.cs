using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ConceptDataDrivingTesting
{
    //NOTE: To use dataRow/DynamicData need to create project with msTest instaed of nunit

    /*Why data driven testing is required?
   1. Allows testing of the application with multiple sets of data values
  2. Separates the test case data from the executable test script
  3. Allows reusing of Actions and Functions in different tests
  4. Data driven test cases are flexible and easy to maintain
  5. The same test cases are executed several times which helps to reduce efforts and code
  6. Any changes in the test script do not effect the test data
*/
    /*DataRow and DynamicData Attribute
DataRow
 Attribute to define in-line data for a test method.
  Example :firstname lastname enrollmentdate
   [DataRow("NARENDRA", "MODI", "01/01/2019")]
    DynamicData
 Attribute to define dynamic data for a test method.
  Example :getdata method supply data and mentioned where is source of that method(getdata)
   [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]*/

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow("Narendra", "Modi", "01/01/2019")]
        [DataRow("donald", "trump", "07/01/2020")]
        [DataRow("BORIS", "JOHNSON", "12/31/2021")]
        public void DataDrivenTestingUsingDataRow(string fName, string lName, string eDate)
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

        // for this we need to craete method that pass the data in form of array and also need to mentioned type of source

        [TestMethod]
        [DynamicData(nameof(GettingDataForcreatinguser),DynamicDataSourceType.Method)]
        public void DataDrivenTestingUsingDynamicData(string fName, string lName, string eDate)
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
        [TestMethod]
        [DynamicData(nameof(ReadExcel), DynamicDataSourceType.Method)]
        public void DataDrivenTestingUsingExcel(string fName, string lName, string eDate)
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
        public static IEnumerable<object[]> GettingDataForcreatinguser()
        {
            yield return new object[] { "Narendra", "Modi", "01/01/2019" } ;
            yield  return new object[] { "donald", "trump", "07/01/2020" };
            yield return new object[] { "BORIS", "JOHNSON", "12/31/2021" };
        }
        public static IEnumerable <object[]> ReadExcel()
        {
            using (ExcelPackage package = new ExcelPackage(new FileInfo("data.xlsx")))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                int rowCount = worksheet.Dimension.End.Row;     //get row count
               
                for (int i = 2; i<= rowCount; i++)
                {
                    yield return new object[] {
                        worksheet.Cells[i, 1].Value?.ToString().Trim(), // First name
                        worksheet.Cells[i, 2].Value?.ToString().Trim(), // Last name
                        worksheet.Cells[i, 3].Value?.ToString().Trim()  // Enrollment date
                    };
                }
            }
        }
    }
}
