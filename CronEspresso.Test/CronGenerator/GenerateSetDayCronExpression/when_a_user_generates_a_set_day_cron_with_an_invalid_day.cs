using System;
using CronEspresso.Resources;
using CronEspresso.Utils;
using NUnit.Framework;
using CronEspressoGenerator = CronEspresso.CronGenerator;

namespace CronEspresso.Test.CronGenerator.GenerateSetDayCronExpression
{
    [TestFixture]
    public class when_a_user_generates_a_set_day_cron_with_an_invalid_day
    {
        private readonly TimeSpan _midDayTime = TimeSpan.Parse("12:00:00");
        private const int NeagtiveNumber = -1;
        private const int InvalidDay = 7;

        [Test]
        public void it_throws_an_argument_out_of_range_exception_when_negative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CronEspressoGenerator.GenerateSetDayCronExpression(_midDayTime, NeagtiveNumber), ExceptionMessages.InvalidDayofTheWeekParameterException);
        }

        [Test]
        public void it_throws_an_argument_out_of_range_exception_when_higher()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CronEspressoGenerator.GenerateSetDayCronExpression(_midDayTime, InvalidDay), ExceptionMessages.InvalidDayofTheWeekParameterException);
        }
    }
}
