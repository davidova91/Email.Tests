using System;
using OpenQA.Selenium;

namespace Email.Pages
{
    public class InboxPage
    {
        public static void GoTo()
        {
            try
            {
                var by = By.XPath("//span/a[@href='#inbox']");
                Driver.WaitForElement(by, 5);
                Driver.Instance.FindElement(by).Click();
            }
            catch (Exception)
            {
                Driver.TakeScreenshot(nameof(InboxPage));
                throw;
            }

        }

        public static bool IsEmailExist(string email)
        {
            try
            {
                return Driver.Instance.FindElements(By.XPath("//span[.='" + email + "']")).Count > 0;
            }
            catch (Exception)
            {
                Driver.TakeScreenshot(nameof(InboxPage));
                throw;
            }
        }
    }
}