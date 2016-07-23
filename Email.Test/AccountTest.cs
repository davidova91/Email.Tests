using System;
using Email.Core;
using Email.Pages;
using Serilog;
using Serilog.Core;
using Xunit;

namespace Email.Test
{
    public class AccountTest : IDisposable
    {
        private readonly AccountReaderFactory _factory;
        private readonly Logger _logger;

        public AccountTest()
        {
            _logger = new LoggerConfiguration().WriteTo.File("results.txt").CreateLogger();

            Driver.Initialize();
            _factory = new AccountReaderFactory();

            var accounts = _factory.Make("csv").GetAccounts();
            var sqlManager = new SqlAccountManager();
            sqlManager.ResetDatabase(accounts);

            //var sender = new EmailSender();
            //var mainAccount = accounts[0];
            //foreach (var account in accounts)
            //{
            //    sender.SendTestEmail(mainAccount.Email, mainAccount.Password, account.Email);
            //}
        }

        public void Dispose()
        {
            Driver.Close();
        }

        [Fact]
        public void OutboxTest()
        {
            var email = string.Empty;
            try
            {
                var accounts = _factory.Make("sql").GetAccounts();
                var account = accounts[0];
                email = account.Email;

                LoginPage.GoTo();
                LoginPage.Login(account.Name, account.Password);

                OutboxPage.GoTo();

                Assert.True(OutboxPage.IsEmailExist(email));

                LoginPage.LogOut();
                _logger.Information("Outbox {@result}", TestResult.GetPassedTestResult(email));
            }
            catch (Exception e)
            {
                Driver.TakeScreenshot(nameof(AccountTest));
                _logger.Information("Outbox {@result}", TestResult.GetFailedTestResult(email, e.Message));
                throw;
            }
        }


        [Fact]
        public void InboxTest()
        {
            var email = string.Empty;
            try
            {
                var accounts = _factory.Make("csv").GetAccounts();

                foreach (var account in accounts)
                {
                    email = account.Email;

                    LoginPage.GoTo();
                    LoginPage.Login(account.Name, account.Password);

                    InboxPage.GoTo();

                    Assert.True(InboxPage.IsEmailExist(email));

                    LoginPage.LogOut();
                    _logger.Information("Inbox {@result}", TestResult.GetPassedTestResult(email));
                }
            }
            catch (Exception e)
            {
                Driver.TakeScreenshot(nameof(AccountTest));
                _logger.Information("Inbox {@result}", TestResult.GetFailedTestResult(email, e.Message));
                throw;
            }
        }
    }
}