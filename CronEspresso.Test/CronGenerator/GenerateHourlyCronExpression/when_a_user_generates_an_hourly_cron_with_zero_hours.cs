using System;
using CronEspresso.Resources;
using CronEspresso.Utils;
using NUnit.Framework;
using CronEspressoGenerator = CronEspresso.CronGenerator;

namespace CronEspresso.Test.CronGenerator.GenerateHourlyCronExpression
{
    [TestFixture]
    public class when_a_user_generates_an_hourly_cron_with_zero_hours
    {
        private const int Zero = 0;

        [Test]
        public void it_throws_an_argument_out_of_range_exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CronEspressoGenerator.GenerateHourlyCronExpression(Zero), ExceptionMessages.InvalidHourParamaterException);
        }
    }
}
