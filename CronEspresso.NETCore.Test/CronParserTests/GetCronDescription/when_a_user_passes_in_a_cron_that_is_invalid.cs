using System;
using NUnit.Framework;

namespace CronEspresso.NETCore.Test.CronParserTests.GetCronDescription
{
    [TestFixture]
    public class when_a_user_passes_in_a_cron_that_is_invalid
    {
        private const string InvalidCron = "* * * * * * * *";

        [Test]
        public void it_throws_the_expected_exception()
        {
            Assert.Throws<ArgumentException>(() =>  CronParser.GetCronDescription(InvalidCron));
        }
    }
}
