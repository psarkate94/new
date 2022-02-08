using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace SeleniumWithNunitProject
{
    class ScreenshotAndRecording
    {
        IWebElement eleofCheckBox;
        [Test]
        public void TakingScreenShot()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://www.uitestpractice.com/Students/Switchto";
            ITakesScreenshot ts =( (ITakesScreenshot)driver);
            ts.GetScreenshot().SaveAsFile("C://Driver//Test.png", ScreenshotImageFormat.Png);
            driver.Quit();
        }
        [Test]
        public void TakingScofPerticularElement()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            eleofCheckBox = driver.FindElement(By.XPath("(//div[@class='right-align'])[1]"));
            TakeScreenshot(driver, eleofCheckBox);
            driver.Quit();
        }
        public void TakeScreenshot(IWebDriver driver,IWebElement element)
        {
            // 1. creating file with dattime and extension 
            String s = "C://Driver//Test ";
            String FileName=s + DateTime.Now.ToString("yyyy-mm-dd HH-mm-ss" )+".jpg";
            Byte[] byteArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            Bitmap screenshot = new Bitmap(new System.IO.MemoryStream(byteArray));
            Rectangle croppedImage = new Rectangle(element.Location.X, element.Location.Y, element.Size.Width, element.Size.Height);
            screenshot = screenshot.Clone(croppedImage, screenshot.PixelFormat);
           
            screenshot.Save(String.Format(FileName, ImageFormat.Jpeg));
        }

        [Test]
        public void ScreenRecodring()
        {
           /* // not able to download microsoft.expression.encoder
           // ScreenCaptureJob scj = new ScreenCaptureJob();
            scj.OutputScreenCaptureFileName = @"D:\Results\Test.avi";
            scj.Start();
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://ankpro.com";
            scj.Stop();
            driver.Quit();*/

        }
        [Test]
        public void FullPageSc()
        {
            // ITakesScreenshot is not usefull to take full sc of page 
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.uitestpractice.com/Students/Switchto";
            VerticalCombineDecorator vcd= new VerticalCombineDecorator(new ScreenshotMaker());
            driver.TakeScreenshot(vcd).ToMagickImage().Write("C://Driver//newChromeSC.png", ImageMagick.MagickFormat.Png);
            driver.Quit();
        }
    }
}
