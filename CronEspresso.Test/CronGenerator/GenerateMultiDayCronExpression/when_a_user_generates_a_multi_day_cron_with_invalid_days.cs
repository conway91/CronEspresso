using System;
using System.Collections.Generic;
using CronEspresso.Resources;
using CronEspresso.Utils;
using NUnit.Framework;
using CronEspressoGenerator = CronEspresso.CronGenerator;

namespace CronEspresso.Test.CronGenerator.GenerateMultiDayCronExpression
{
    [TestFixture]
    public class when_a_user_generates_a_multi_day_cron_with_invalid_days
    {
        private readonly TimeSpan _midDayTime = TimeSpan.Parse("12:00:00");
        private readonly List<DayOfWeek> _dupliacteDaysEnum = new List<DayOfWeek> { DayOfWeek.Sunday, DayOfWeek.Sunday };
        private readonly List<int> _dupliacteDaysInt = new List<int> { 0, 0 };
        private readonly List<int> _negativeDay = new List<int> { 0, 1, 2, -1 };
        private readonly List<int> _higherDay = new List<int> { 0, 1, 2, 7 };

        [Test]
        public void it_throws_an_argument_out_of_range_exception_when_duplicate_enum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CronEspressoGenerator.GenerateMultiDayCronExpression(_midDayTime, _dupliacteDaysEnum), ExceptionMessages.DuplicateDaysException);
        }

        [Test]
        public void it_throws_an_argument_out_of_range_exception_when_duplicate_int()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CronEspressoGenerator.GenerateMultiDayCronExpression(_midDayTime, _dupliacteDaysInt), ExceptionMessages.DuplicateDaysException);
        }

        [Test]
        public void it_throws_an_argument_out_of_range_exception_when_negative_day()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CronEspressoGenerator.GenerateMultiDayCronExpression(_midDayTime, _negativeDay), ExceptionMessages.InvalidDayofTheWeekParameterException);
        }

        [Test]
        public void it_throws_an_argument_out_of_range_exception_when_higher_day()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CronEspressoGenerator.GenerateMultiDayCronExpression(_midDayTime, _higherDay), ExceptionMessages.InvalidDayofTheWeekParameterException);
        }
    }
}
