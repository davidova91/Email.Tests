using System.IO.Ports;

namespace Email.Core
{
    public class TestResult
    {
        public string Account { get; set; }
        public string Result { get; set; }
        public string FailuresReason { get; set; }

        public static TestResult GetPassedTestResult(string account)
        {
            return new TestResult {Account = account, Result = "Passed"};
        }

        public static TestResult GetFailedTestResult(string account, string error)
        {
            return new TestResult() {Account = account, Result = "Failed", FailuresReason = error};
        }
    }
}