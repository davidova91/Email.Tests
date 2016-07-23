using System;
using OpenQA.Selenium;

namespace Email.Pages
{
    public class LoginPage
    {
        public static void GoTo()
        {
            try
            {
                Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress);
            }
            catch (Exception)
            {
                Driver.TakeScreenshot(nameof(LoginPage));
                throw;
            }
        }

        public static void Login(string login, string pass)
        {
            try
            {
                var by = By.Id("Username");
                Driver.WaitForElement(by, 5);
                Driver.Instance.FindElement(by).SendKeys(login);
                Driver.Instance.FindElement(By.Id("Password")).SendKeys(pass);
                Driver.Instance.FindElement(By.XPath("//input[@class='button loginButton gradientforbutton']")).Click();
            }
            catch (Exception)
            {
                Driver.TakeScreenshot(nameof(LoginPage));
                throw;
            }
        }

        public static void LogOut()
        {
            try
            {
                var element = Driver.Instance.FindElement(By.XPath("//span[@class='header-user-name js-header-user-name']"));
                Driver.ClickElementWithAction(element);
                Driver.Instance.FindElement(By.LinkText("Выход")).Click();
                Driver.WaitOneSecond();
            }
            catch (Exception)
            {
                Driver.TakeScreenshot(nameof(LoginPage));
                throw;
            }
        }
    }
}