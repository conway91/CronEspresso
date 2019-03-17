using System;
using CronEspresso.NETCore.Resources;
using NUnit.Framework;
using CronEspressoGenerator = CronEspresso.NETCore.CronGenerator;

namespace CronEspresso.NETCore.Test.CronGenerator.GenerateHourlyCronExpression
{
    [TestFixture]
    public class when_a_user_generates_an_hourly_cron_with_a_negative_number
    {
        private const int NegativeNumber = -1;

        [Test]
        public void it_throws_an_argument_out_of_range_exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CronEspressoGenerator.GenerateHourlyCronExpression(NegativeNumber), ExceptionMessages.InvalidHourParameterException);
        }
    }
}
