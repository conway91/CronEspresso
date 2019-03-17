using System;
using NUnit.Framework;
using CronEspressoGenerator = CronEspresso.NETCore.CronGenerator;

namespace CronEspresso.NETCore.Test.CronGenerator.GenerateMonthlyCronExpression
{
    [TestFixture]
    public class when_a_user_generates_a_monthly_cron
    {
        private readonly TimeSpan _midDayTime = TimeSpan.Parse("12:00:00");
        private const int LowestDayOfTheMonth = 1;
        private const int MidDayOfTheMonth = 15;
        private const int HighestDayOfTheMonth = 31;
        private const int LowestMonth = 1;
        private const int MidMonth = 6;
        private const int HighestMonth = 12;
        private const string LowestCron = "0 0 12 1 1/1 ? *";
        private const string MidCron = "0 0 12 15 1/6 ? *";
        private const string HighestCron = "0 0 12 31 1/12 ? *";

        [Test]
        public void it_can_run_on_the_first_day_of_the_first_month()
        {
            var cron = CronEspressoGenerator.GenerateMonthlyCronExpression(_midDayTime, LowestDayOfTheMonth, LowestMonth);
            Assert.AreEqual(LowestCron, cron);
        }

        [Test]
        public void it_can_run_on_the_middle_day_of_the_middle_month()
        {
            var cron = CronEspressoGenerator.GenerateMonthlyCronExpression(_midDayTime, MidDayOfTheMonth, MidMonth);
            Assert.AreEqual(MidCron, cron);
        }

        [Test]
        public void it_can_run_on_the_last_day_of_the_last_month()
        {
            var cron = CronEspressoGenerator.GenerateMonthlyCronExpression(_midDayTime, HighestDayOfTheMonth, HighestMonth);
            Assert.AreEqual(HighestCron, cron);
        }
    }
}
