using System;
using CronEspresso.Utils;
using NUnit.Framework;

namespace CronEspresso.Test.RemoveYearValue
{
    [TestFixture]
    public class when_a_user_removes_the_year_from_an_invalid_cron
    {
        private const string InvalidCron = "0 0 0 * * ? * * * *";

        [Test]
        public void it_throws_an_argument_excpetion()
        {
            Assert.Throws<ArgumentException>(() => CronHelpers.RemoveCronYearValue(InvalidCron));
        }
    }
}
