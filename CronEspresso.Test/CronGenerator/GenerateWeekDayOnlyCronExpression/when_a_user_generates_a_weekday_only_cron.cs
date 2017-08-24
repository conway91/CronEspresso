using System;
using NUnit.Framework;
using CronEspressoGenerator = CronEspresso.CronGenerator;

namespace CronEspresso.Test.CronGenerator.GenerateWeekDayOnlyCronExpression
{
    [TestFixture]
    public class when_a_user_generates_a_weekday_only_cron
    {
        private readonly TimeSpan _midDayTime = TimeSpan.Parse("12:00:00");
        private const string RunEveryWeekdayCron = "0 0 12 ? * MON-FRI *";


        [Test]
        public void it_can_run_on_every_weekday()
        {
            var cron = CronEspressoGenerator.GenerateWeekDayOnlyCronExpression(_midDayTime);
            Assert.AreEqual(RunEveryWeekdayCron, cron);
        }
    }
}
