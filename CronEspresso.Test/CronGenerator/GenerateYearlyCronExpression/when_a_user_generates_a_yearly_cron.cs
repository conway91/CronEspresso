using System;
using CronEspresso.Utils;
using NUnit.Framework;
using CronEspressoGenerator = CronEspresso.CronGenerator;

namespace CronEspresso.Test.CronGenerator.GenerateYearlyCronExpression
{
    public class when_a_user_generates_a_yearly_cron
    {
        private readonly TimeSpan _midDayTime = TimeSpan.Parse("12:00:00");
        private readonly MonthOfYear _januraryEnum = MonthOfYear.January;
        private readonly MonthOfYear _aprilEnum = MonthOfYear.April;
        private readonly MonthOfYear _feburaryEnum = MonthOfYear.Feburary;
        private const int JanuraryInt = 1;
        private const int FebraryInt = 2;
        private const int AprilInt = 4;
        private const int FirstDayOfTheMonth = 1;
        private const int LastDayOfLongerMonth = 31;
        private const int LastDayOfShorterMonth = 30;
        private const int LastDayOfFebrary = 29;
        private const string FirstOfJanuraryCron = "0 0 12 1 1 ? *";
        private const string LastDayOfJanuraryCron = "0 0 12 31 1 ? *";
        private const string LastDayOfAprilCron = "0 0 12 30 4 ? *";
        private const string LastDatOfFebraryCron = "0 0 12 29 2 ? *";

        [Test]
        public void it_can_run_on_the_first_day_of_a_given_month_enum()
        {
            var cron = CronEspressoGenerator.GenerateYearlyCronExpression(_midDayTime, FirstDayOfTheMonth, _januraryEnum);
            Assert.AreEqual(FirstOfJanuraryCron, cron);
        }

        [Test]
        public void it_can_run_on_the_first_day_of_a_given_month_int()
        {
            var cron = CronEspressoGenerator.GenerateYearlyCronExpression(_midDayTime, FirstDayOfTheMonth, JanuraryInt);
            Assert.AreEqual(FirstOfJanuraryCron, cron);
        }

        [Test]
        public void it_can_run_on_the_last_day_of_a_longer_month_enum()
        {
            var cron = CronEspressoGenerator.GenerateYearlyCronExpression(_midDayTime, LastDayOfLongerMonth, _januraryEnum);
            Assert.AreEqual(LastDayOfJanuraryCron, cron);
        }

        [Test]
        public void it_can_run_on_the_last_day_of_a_longer_month_int()
        {
            var cron = CronEspressoGenerator.GenerateYearlyCronExpression(_midDayTime, LastDayOfLongerMonth, JanuraryInt);
            Assert.AreEqual(LastDayOfJanuraryCron, cron);
        }

        [Test]
        public void it_can_run_on_the_last_day_of_a_shorter_month_enum()
        {
            var cron = CronEspressoGenerator.GenerateYearlyCronExpression(_midDayTime, LastDayOfShorterMonth, _aprilEnum);
            Assert.AreEqual(LastDayOfAprilCron, cron);
        }

        [Test]
        public void it_can_run_on_the_last_day_of_a_shorter_month_int()
        {
            var cron = CronEspressoGenerator.GenerateYearlyCronExpression(_midDayTime, LastDayOfShorterMonth, AprilInt);
            Assert.AreEqual(LastDayOfAprilCron, cron);
        }

        [Test]
        public void it_can_run_on_the_last_day_of_febrary_enum()
        {
            var cron = CronEspressoGenerator.GenerateYearlyCronExpression(_midDayTime, LastDayOfFebrary, _feburaryEnum);
            Assert.AreEqual(LastDatOfFebraryCron, cron);
        }

        [Test]
        public void it_can_run_on_the_last_day_of_febrary_int()
        {
            var cron = CronEspressoGenerator.GenerateYearlyCronExpression(_midDayTime, LastDayOfFebrary, FebraryInt);
            Assert.AreEqual(LastDatOfFebraryCron, cron);
        }
    }
}
