using NUnit.Framework;
using CronEspressoGenerator = CronEspresso.NETCore.CronGenerator;

namespace CronEspresso.NETCore.Test.CronGenerator.GenerateMinutesCronExpression
{
    [TestFixture]
    public class when_a_user_generates_a_minute_cron
    {
        private const string RunEveryMinuteCron = "0 0/1 * 1/1 * ? *";
        private const string RunEvery30MinutesCron = "0 0/30 * 1/1 * ? *";
        private const string RunEvery59MinutesCron = "0 0/59 * 1/1 * ? *";
        private const int OneMinute = 1;
        private const int ThirtyMinutes = 30;
        private const int FiftyNineMinutes = 59;

        [Test]
        public void it_can_run_every_minute()
        {
            var cron = CronEspressoGenerator.GenerateMinutesCronExpression(OneMinute);
            Assert.AreEqual(RunEveryMinuteCron, cron);
        }

        [Test]
        public void it_can_run_every_thirty_minutes()
        {
            var cron = CronEspressoGenerator.GenerateMinutesCronExpression(ThirtyMinutes);
            Assert.AreEqual(RunEvery30MinutesCron, cron);
        }

        [Test]
        public void it_can_run_every_fifty_nine_minutes()
        {
            var cron = CronEspressoGenerator.GenerateMinutesCronExpression(FiftyNineMinutes);
            Assert.AreEqual(RunEvery59MinutesCron, cron);
        }
    }
}
