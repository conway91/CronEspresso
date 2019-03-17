using System;
using CronEspresso.NETCore.Utils;
using NUnit.Framework;

namespace CronEspresso.NETCore.Test.RemoveYearValue
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
