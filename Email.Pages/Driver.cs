using System;
using System.Drawing.Imaging;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Email.Pages
{
    public class Driver
    {
        private static string _windowHandle;
        public static IWebDriver Instance { get; set; }

        public static string BaseAddress => "https://mail.tut.by";

        public static void Initialize()
        {
            Instance = new FirefoxDriver();
            Instance.Manage().Window.Maximize();
            _windowHandle = Instance.CurrentWindowHandle;
        }

        public static void Close()
        {
            Instance.Close();
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)timeSpan.TotalMilliseconds);
        }

        public static void WaitOneSecond()
        {
            Wait(TimeSpan.FromSeconds(1));
        }

        public static void ClickElementWithAction(IWebElement element)
        {
            var js = (IJavaScriptExecutor)Instance;
            js.ExecuteScript("var evt = document.createEvent('MouseEvents');" + "evt.initMouseEvent('click',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" + "arguments[0].dispatchEvent(evt);", element);
        }

        public static string TakeScreenshot(string prefix)
        {
            var fileName = $"{prefix}{DateTime.Now.ToString("HHmmss")}{".png"}";
            var screenShot = ((ITakesScreenshot)Instance).GetScreenshot();
            screenShot.SaveAsFile(fileName, ImageFormat.Png);
            return fileName;
        }

        public static void WaitForElement(By by, int timeout)
        {
            if (timeout <= 0) return;
            var wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
    }
}