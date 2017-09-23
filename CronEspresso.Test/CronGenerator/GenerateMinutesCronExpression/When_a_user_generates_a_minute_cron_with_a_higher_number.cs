using System;
using CronEspresso.Resources;
using NUnit.Framework;
using CronEspressoGenerator = CronEspresso.CronGenerator;

namespace CronEspresso.Test.CronGenerator.GenerateMinutesCronExpression
{
    [TestFixture]
    public class when_a_user_generates_a_minute_cron_with_a_higher_number
    {
        private const int HigherThanMinutesLimit = 60;

        [Test]
        public void it_throws_an_argument_out_of_range_exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CronEspressoGenerator.GenerateMinutesCronExpression(HigherThanMinutesLimit), ExceptionMessages.InvalidMinuteParamaterException);
        }
    }
}
