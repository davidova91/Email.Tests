using System;
using OpenQA.Selenium;

namespace Email.Pages
{
    public class OutboxPage
    {
        public static void GoTo()
        {
            try
            {
                var by = By.XPath("//span/a[@title='Отправленные']");
                Driver.WaitForElement(by, 5);
                var element = Driver.Instance.FindElement(by);
                element.Click();
            }
            catch (Exception)
            {
                Driver.TakeScreenshot(nameof(OutboxPage));
                throw;
            }
        }

        public static bool IsEmailExist(string email)
        {
            try
            {
                return Driver.Instance.FindElements(By.XPath("//a/span[.='" + email + "']")).Count > 0;
            }
            catch (Exception)
            {
                Driver.TakeScreenshot(nameof(OutboxPage));
                throw;
            }
        }
    }
}