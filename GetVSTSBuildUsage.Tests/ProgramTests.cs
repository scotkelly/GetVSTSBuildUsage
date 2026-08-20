using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetVSTSBuildUsage.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void HasValidArgumentsReturnsFalseForMissingArguments()
        {
            Assert.IsFalse(Program.HasValidArguments(new string[0]));
            Assert.IsFalse(Program.HasValidArguments(new[] { "https://account.visualstudio.com" }));
            Assert.IsFalse(Program.HasValidArguments(new[] { "https://account.visualstudio.com", "1/1/2016" }));
        }

        [TestMethod]
        public void HasValidArgumentsReturnsFalseForExtraArguments()
        {
            Assert.IsFalse(Program.HasValidArguments(new[]
            {
                "https://account.visualstudio.com",
                "1/1/2016",
                "1/31/2016",
                "unexpected"
            }));
        }

        [TestMethod]
        public void HasValidArgumentsReturnsTrueForThreeArguments()
        {
            Assert.IsTrue(Program.HasValidArguments(new[]
            {
                "https://account.visualstudio.com",
                "1/1/2016",
                "1/31/2016"
            }));
        }

        [TestMethod]
        public void ShowUsageWritesCommandLineUsage()
        {
            var originalOut = Console.Out;
            using (var writer = new StringWriter())
            {
                try
                {
                    Console.SetOut(writer);

                    Program.ShowUsage();

                    var output = writer.ToString();
                    StringAssert.Contains(output, "GetVSTSBuildUsage [account url and collection] [min build finish date] [max build finish date]");
                    StringAssert.Contains(output, "Example: GetVSTSBuildUsage");
                }
                finally
                {
                    Console.SetOut(originalOut);
                }
            }
        }

        [TestMethod]
        public void GetMaxFinishTimeReturnsPastDate()
        {
            var maxTime = new DateTime(2016, 1, 31);

            var result = Program.GetMaxFinishTime(maxTime);

            Assert.AreEqual(maxTime, result);
        }

        [TestMethod]
        public void GetMaxFinishTimeCapsFutureDateAtCurrentTime()
        {
            var futureTime = DateTime.Now.AddDays(1);
            var beforeCall = DateTime.Now;

            var result = Program.GetMaxFinishTime(futureTime);

            var afterCall = DateTime.Now;
            Assert.IsTrue(result.HasValue, "Expected a maximum finish time.");
            Assert.IsTrue(result.Value >= beforeCall, "Expected the result to be no earlier than the call start time.");
            Assert.IsTrue(result.Value <= afterCall, "Expected the result to be no later than the call end time.");
        }
    }
}
