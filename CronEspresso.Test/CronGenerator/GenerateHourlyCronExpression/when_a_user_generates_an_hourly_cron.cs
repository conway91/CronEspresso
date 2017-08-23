using NUnit.Framework;
using CronEspressoGenerator = CronEspresso.CronGenerator;

namespace CronEspresso.Test.CronGenerator.GenerateHourlyCronExpression
{
    [TestFixture]
    public class when_a_user_generates_an_hourly_cron
    {
        private const string RunEveryHourCron = "0 0 0/1 1/1 * ? *";
        private const string RunEvery12HoursCron = "0 0 0/12 1/1 * ? *";
        private const string RunEvery23HoursCron = "0 0 0/23 1/1 * ? *";
        private const int OneHour = 1;
        private const int TwelveHours = 12;
        private const int TwentyThreeHours = 23;

        [Test]
        public void it_can_run_every_hour()
        {
            var cron = CronEspressoGenerator.GenerateHourlyCronExpression(OneHour);
            Assert.AreEqual(RunEveryHourCron, cron);
        }

        [Test]
        public void it_can_run_every_twelve_hours()
        {
            var cron = CronEspressoGenerator.GenerateHourlyCronExpression(TwelveHours);
            Assert.AreEqual(RunEvery12HoursCron, cron);
        }

        [Test]
        public void it_can_run_every_twenty_three_hours()
        {
            var cron = CronEspressoGenerator.GenerateHourlyCronExpression(TwentyThreeHours);
            Assert.AreEqual(RunEvery23HoursCron, cron);
        }
    }
}
