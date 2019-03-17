using System;
using CronEspresso.NETCore.Resources;
using NUnit.Framework;
using CronEspressoGenerator = CronEspresso.NETCore.CronGenerator;

namespace CronEspresso.NETCore.Test.CronGenerator.GenerateHourlyCronExpression
{
    [TestFixture]
    public class when_a_user_generates_an_hourly_cron_with_a_higher_number
    {
        private const int HigherThanHoursLimit = 24;

        [Test]
        public void it_throws_an_argument_out_of_range_exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CronEspressoGenerator.GenerateHourlyCronExpression(HigherThanHoursLimit), ExceptionMessages.InvalidHourParameterException);
        }
    }
}
