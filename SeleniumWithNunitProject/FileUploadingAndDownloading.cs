using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace SeleniumWithNunitProject
{
    class FileUploadingAndDownloading
    {
        [Test]
        public void VerifyingDownloadedFile()
        {
            string expectedFilePath = "//uszu2naseplv016.pwcglb.com//ushzncfs01//ushzncpf//pfredir//psarkate001//Downloads//images.ping";
            bool fileExists = false;
            ChromeOptions option = new ChromeOptions();
            option.AddUserProfilePreference("download.default_directory", "//uszu2naseplv016.pwcglb.com//ushzncfs01//ushzncpf//pfredir//psarkate001//Downloads");
           
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            
           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "http://www.uitestpractice.com/Students/Widgets";
            driver.FindElement(By.XPath("//button/a")).Click();
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until<bool> (x => fileExists = File.Exists(expectedFilePath));

                Console.WriteLine("File exists : " + fileExists);

                FileInfo fileInfo = new FileInfo(expectedFilePath);

                Console.WriteLine("File Length : " + fileInfo.Length);
                Console.WriteLine("File Name : " + fileInfo.Name);
                Console.WriteLine("File Full Name :" + fileInfo.FullName);

                Assert.AreEqual(1517, fileInfo.Length);
                Assert.AreEqual(fileInfo.Name, "images.png");
                Assert.AreEqual(fileInfo.FullName, @"C:\Downloads\images.png");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (File.Exists(expectedFilePath))
                    File.Delete(expectedFilePath);

            }
           // driver.Quit();

        }
    }
}
