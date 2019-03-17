using System;
using NUnit.Framework;
using CronEspressoGenerator = CronEspresso.NETCore.CronGenerator;

namespace CronEspresso.NETCore.Test.CronGenerator.GenerateSetDayCronExpression
{
    [TestFixture]
    public class when_a_user_generates_a_set_day_cron
    {
        private readonly TimeSpan _midDayTime = TimeSpan.Parse("12:00:00");
        private const string RunEverySundayCron = "0 0 12 ? * SUN *";
        private const string RunEveryMondayCron = "0 0 12 ? * MON *";
        private const string RunEveryTuesdayCron = "0 0 12 ? * TUE *";
        private const string RunEveryWednesdayCron = "0 0 12 ? * WED *";
        private const string RunEveryThursdayCron = "0 0 12 ? * THU *";
        private const string RunEveryFridayCron = "0 0 12 ? * FRI *";
        private const string RunEverySaturdayCron = "0 0 12 ? * SAT *";

        [Test]
        public void it_can_run_on_a_sunday_enum_param()
        {
            var cron = CronEspressoGenerator.GenerateSetDayCronExpression(_midDayTime, DayOfWeek.Sunday);
            Assert.AreEqual(RunEverySundayCron, cron);
        }

        [Test]
        public void it_can_run_on_a_sunday_int_param()
        {
            var cron = CronEspressoGenerator.GenerateSetDayCronExpression(_midDayTime, 0);
            Assert.AreEqual(RunEverySundayCron, cron);
        }

        [Test]
        public void it_can_run_on_a_monday_enum_param()
        {
            var cron = CronEspressoGenerator.GenerateSetDayCronExpression(_midDayTime, DayOfWeek.Monday);
            Assert.AreEqual(RunEveryMondayCron, cron);
        }

        [Test]
        public void it_can_run_on_a_monday_int_param()
        {
            var cron = CronEspressoGenerator.GenerateSetDayCronExpression(_midDayTime, 1);
            Assert.AreEqual(RunEveryMondayCron, cron);
        }

        [Test]
        public void it_can_run_on_a_tuesday_enum_param()
        {
            var cron = CronEspressoGenerator.GenerateSetDayCronExpression(_midDayTime, DayOfWeek.Tuesday);
            Assert.AreEqual(RunEveryTuesdayCron, cron);
        }

        [Test]
        public void it_can_run_on_a_tuesday_int_param()
        {
            var cron = CronEspressoGenerator.GenerateSetDayCronExpression(_midDayTime, 2);
            Assert.AreEqual(RunEveryTuesdayCron, cron);
        }

        [Test]
        public void it_can_run_on_a_wednesday_enum_param()
        {
            var cron = CronEspressoGenerator.GenerateSetDayCronExpression(_midDayTime, DayOfWeek.Wednesday);
            Assert.AreEqual(RunEveryWednesdayCron, cron);
        }

        [Test]
        public void it_can_run_on_a_wednesday_int_param()
        {
            var cron = CronEspressoGenerator.GenerateSetDayCronExpression(_midDayTime, 3);
            Assert.AreEqual(RunEveryWednesdayCron, cron);
        }

        [Test]
        public void it_can_run_on_a_thursday_enum_param()
        {
            var cron = CronEspressoGenerator.GenerateSetDayCronExpression(_midDayTime, DayOfWeek.Thursday);
            Assert.AreEqual(RunEveryThursdayCron, cron);
        }

        [Test]
        public void it_can_run_on_a_thursday_int_param()
        {
            var cron = CronEspressoGenerator.GenerateSetDayCronExpression(_midDayTime, 4);
            Assert.AreEqual(RunEveryThursdayCron, cron);
        }

        [Test]
        public void it_can_run_on_a_friday_enum_param()
        {
            var cron = CronEspressoGenerator.GenerateSetDayCronExpression(_midDayTime, DayOfWeek.Friday);
            Assert.AreEqual(RunEveryFridayCron, cron);
        }

        [Test]
        public void it_can_run_on_a_friday_int_param()
        {
            var cron = CronEspressoGenerator.GenerateSetDayCronExpression(_midDayTime, 5);
            Assert.AreEqual(RunEveryFridayCron, cron);
        }

        [Test]
        public void it_can_run_on_a_saturday_enum_param()
        {
            var cron = CronEspressoGenerator.GenerateSetDayCronExpression(_midDayTime, DayOfWeek.Saturday);
            Assert.AreEqual(RunEverySaturdayCron, cron);
        }

        [Test]
        public void it_can_run_on_a_saturday_int_param()
        {
            var cron = CronEspressoGenerator.GenerateSetDayCronExpression(_midDayTime, 6);
            Assert.AreEqual(RunEverySaturdayCron, cron);
        }
    }
}
