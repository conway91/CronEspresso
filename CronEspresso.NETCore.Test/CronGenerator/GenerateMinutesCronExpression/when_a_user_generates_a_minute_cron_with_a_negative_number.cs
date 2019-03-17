using System;
using CronEspresso.NETCore.Resources;
using NUnit.Framework;
using CronEspressoGenerator = CronEspresso.NETCore.CronGenerator;

namespace CronEspresso.NETCore.Test.CronGenerator.GenerateMinutesCronExpression
{
    [TestFixture]
    public class when_a_user_generates_a_minute_cron_with_a_negative_number
    {
        private const int NegativeNumber = -1;

        [Test]
        public void it_throws_an_argument_out_of_range_exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CronEspressoGenerator.GenerateMinutesCronExpression(NegativeNumber), ExceptionMessages.InvalidMinuteParameterException);
        }
    }
}
