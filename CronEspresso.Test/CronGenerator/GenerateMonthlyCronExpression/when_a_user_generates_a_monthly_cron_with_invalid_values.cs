using System;
using CronEspresso.Utils;
using NUnit.Framework;
using CronEspressoGenerator = CronEspresso.CronGenerator;

namespace CronEspresso.Test.CronGenerator.GenerateMonthlyCronExpression
{
    [TestFixture]
    public class when_a_user_generates_a_monthly_cron_with_invalid_values
    {
        private readonly TimeSpan _midDayTime = TimeSpan.Parse("12:00:00");
        private const int Zero = 0;
        private const int NegativeValue = -1;
        private const int InvalidMaxMonth = 13;
        private const int InvalidMaxDay= 32;
        private const int ValidMonthAndDay = 1;

        [Test]
        public void it_throws_an_argument_out_of_range_exception_when_month_is_zero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CronEspressoGenerator.GenerateMonthlyCronExpression(_midDayTime, ValidMonthAndDay, Zero), ExceptionMessages.InvalidAmountOfMonthsToRunAfterException);
        }

        [Test]
        public void it_throws_an_argument_out_of_range_exception_when_day_is_zero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CronEspressoGenerator.GenerateMonthlyCronExpression(_midDayTime, Zero, ValidMonthAndDay), ExceptionMessages.InvalidDayofTheMonthException);
        }

        [Test]
        public void it_throws_an_argument_out_of_range_exception_when_month_is_negative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CronEspressoGenerator.GenerateMonthlyCronExpression(_midDayTime, ValidMonthAndDay, NegativeValue), ExceptionMessages.InvalidAmountOfMonthsToRunAfterException);
        }

        [Test]
        public void it_throws_an_argument_out_of_range_exception_when_day_is_negative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CronEspressoGenerator.GenerateMonthlyCronExpression(_midDayTime, NegativeValue, ValidMonthAndDay), ExceptionMessages.InvalidDayofTheMonthException);
        }

        [Test]
        public void it_throws_an_argument_out_of_range_exception_when_month_is_over_max()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CronEspressoGenerator.GenerateMonthlyCronExpression(_midDayTime, ValidMonthAndDay, InvalidMaxMonth), ExceptionMessages.InvalidAmountOfMonthsToRunAfterException);
        }

        [Test]
        public void it_throws_an_argument_out_of_range_exception_when_day_is_over_max()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CronEspressoGenerator.GenerateMonthlyCronExpression(_midDayTime, InvalidMaxDay, ValidMonthAndDay), ExceptionMessages.InvalidDayofTheMonthException);
        }
    }
}
