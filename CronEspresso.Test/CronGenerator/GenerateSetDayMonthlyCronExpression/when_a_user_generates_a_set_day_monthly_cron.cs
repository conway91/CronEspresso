using System;
using CronEspresso.Utils;
using NUnit.Framework;
using CronEspressoGenerator = CronEspresso.CronGenerator;

namespace CronEspresso.Test.CronGenerator.GenerateSetDayMonthlyCronExpression
{
    [TestFixture]
    public class when_a_user_generates_a_set_day_monthly_cron
    {
        private readonly TimeSpan _midDayTime = TimeSpan.Parse("12:00:00");
        private readonly TimeOfMonthToRun _firstOfTheMonth = TimeOfMonthToRun.First;
        private readonly TimeOfMonthToRun _secondOfTheMonth = TimeOfMonthToRun.Second;
        private readonly TimeOfMonthToRun _thirdOfTheMonth = TimeOfMonthToRun.Third;
        private readonly TimeOfMonthToRun _forthOfTheMonth = TimeOfMonthToRun.Fourth;
        private readonly TimeOfMonthToRun _lastOfTheMonth = TimeOfMonthToRun.Last;
        private readonly DayOfWeek _validDayOfTheWeekEnum = DayOfWeek.Monday;
        private const int ValidDayOfTheWeekInt = 1;
        private const int ValidMonthsToRun = 2;
        private const string FirstMondayCron = "0 0 12 ? 1/2 MON#1 *";
        private const string SecondMondayCron = "0 0 12 ? 1/2 MON#2 *";
        private const string ThirdMondayCron = "0 0 12 ? 1/2 MON#3 *";
        private const string FourthMondayCron = "0 0 12 ? 1/2 MON#4 *";
        private const string LastMondayCron = "0 0 12 ? 1/2 2L *";

        [Test]
        public void it_can_run_on_the_first_monday_of_the_month_enum()
        {
            var cron = CronEspressoGenerator.GenerateSetDayMonthlyCronExpression(_midDayTime, _firstOfTheMonth, _validDayOfTheWeekEnum, ValidMonthsToRun);
            Assert.AreEqual(FirstMondayCron, cron);
        }

        [Test]
        public void it_can_run_on_the_first_monday_of_the_month_int()
        {
            var cron = CronEspressoGenerator.GenerateSetDayMonthlyCronExpression(_midDayTime, _firstOfTheMonth, ValidDayOfTheWeekInt, ValidMonthsToRun);
            Assert.AreEqual(FirstMondayCron, cron);
        }

        [Test]
        public void it_can_run_on_the_second_monday_of_the_month_enum()
        {
            var cron = CronEspressoGenerator.GenerateSetDayMonthlyCronExpression(_midDayTime, _secondOfTheMonth, _validDayOfTheWeekEnum, ValidMonthsToRun);
            Assert.AreEqual(SecondMondayCron, cron);
        }

        [Test]
        public void it_can_run_on_the_second_monday_of_the_month_int()
        {
            var cron = CronEspressoGenerator.GenerateSetDayMonthlyCronExpression(_midDayTime, _secondOfTheMonth, ValidDayOfTheWeekInt, ValidMonthsToRun);
            Assert.AreEqual(SecondMondayCron, cron);
        }

        [Test]
        public void it_can_run_on_the_third_monday_of_the_month_enum()
        {
            var cron = CronEspressoGenerator.GenerateSetDayMonthlyCronExpression(_midDayTime, _thirdOfTheMonth, _validDayOfTheWeekEnum, ValidMonthsToRun);
            Assert.AreEqual(ThirdMondayCron, cron);
        }

        [Test]
        public void it_can_run_on_the_third_monday_of_the_month_int()
        {
            var cron = CronEspressoGenerator.GenerateSetDayMonthlyCronExpression(_midDayTime, _thirdOfTheMonth, ValidDayOfTheWeekInt, ValidMonthsToRun);
            Assert.AreEqual(ThirdMondayCron, cron);
        }

        [Test]
        public void it_can_run_on_the_fourth_monday_of_the_month_enum()
        {
            var cron = CronEspressoGenerator.GenerateSetDayMonthlyCronExpression(_midDayTime, _forthOfTheMonth, _validDayOfTheWeekEnum, ValidMonthsToRun);
            Assert.AreEqual(FourthMondayCron, cron);
        }

        [Test]
        public void it_can_run_on_the_fourth_monday_of_the_month_int()
        {
            var cron = CronEspressoGenerator.GenerateSetDayMonthlyCronExpression(_midDayTime, _forthOfTheMonth, ValidDayOfTheWeekInt, ValidMonthsToRun);
            Assert.AreEqual(FourthMondayCron, cron);
        }

        [Test]
        public void it_can_run_on_the_last_monday_of_the_month_enum()
        {
            var cron = CronEspressoGenerator.GenerateSetDayMonthlyCronExpression(_midDayTime, _lastOfTheMonth, _validDayOfTheWeekEnum, ValidMonthsToRun);
            Assert.AreEqual(LastMondayCron, cron);
        }

        [Test]
        public void it_can_run_on_the_last_monday_of_the_month_int()
        {
            var cron = CronEspressoGenerator.GenerateSetDayMonthlyCronExpression(_midDayTime, _lastOfTheMonth, ValidDayOfTheWeekInt, ValidMonthsToRun);
            Assert.AreEqual(LastMondayCron, cron);
        }
    }
}
