using System;
using System.Collections.Generic;
using NUnit.Framework;
using CronEspressoGenerator = CronEspresso.NETCore.CronGenerator;

namespace CronEspresso.NETCore.Test.CronGenerator.GenerateMultiDayCronExpression
{
    [TestFixture]
    public class when_a_user_generates_a_multi_day_cron
    {
        private readonly TimeSpan _midDayTime = TimeSpan.Parse("12:00:00");
        private readonly List<DayOfWeek> _runOneDayEnum = new List<DayOfWeek> { DayOfWeek.Sunday };
        private readonly List<DayOfWeek> _runMultiDaysEnum = new List<DayOfWeek> { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday };
        private readonly List<DayOfWeek> _ruAllDaysEnum = new List<DayOfWeek> { DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday };
        private readonly List<int> _runOneDayInt = new List<int> { 0 };
        private readonly List<int> _runMultiDaysInt = new List<int> { 0,2,4,6 };
        private readonly List<int> _ruAllDaysInt = new List<int> { 0,1,2,3,4,5,6 };
        private const string RunOneDayCron = "0 0 12 ? * SUN *";
        private const string RunMultiDaysCron = "0 0 12 ? * SUN,TUE,THU,SAT *";
        private const string RunAllDaysCron = "0 0 12 ? * SUN,MON,TUE,WED,THU,FRI,SAT *";

        [Test]
        public void it_can_run_on_one_day_enum_param()
        {
            var cron = CronEspressoGenerator.GenerateMultiDayCronExpression(_midDayTime, _runOneDayEnum);
            Assert.AreEqual(RunOneDayCron, cron);
        }

        [Test]
        public void it_can_run_on_one_day_int_param()
        {
            var cron = CronEspressoGenerator.GenerateMultiDayCronExpression(_midDayTime, _runOneDayInt);
            Assert.AreEqual(RunOneDayCron, cron);
        }

        [Test]
        public void it_can_run_on_multi_days_enum_param()
        {
            var cron = CronEspressoGenerator.GenerateMultiDayCronExpression(_midDayTime, _runMultiDaysEnum);
            Assert.AreEqual(RunMultiDaysCron, cron);
        }

        [Test]
        public void it_can_run_on_multi_days_int_param()
        {
            var cron = CronEspressoGenerator.GenerateMultiDayCronExpression(_midDayTime, _runMultiDaysInt);
            Assert.AreEqual(RunMultiDaysCron, cron);
        }

        [Test]
        public void it_can_run_on_all_days_enum_param()
        {
            var cron = CronEspressoGenerator.GenerateMultiDayCronExpression(_midDayTime, _ruAllDaysEnum);
            Assert.AreEqual(RunAllDaysCron, cron);
        }

        [Test]
        public void it_can_run_on_all_days_int_param()
        {
            var cron = CronEspressoGenerator.GenerateMultiDayCronExpression(_midDayTime, _ruAllDaysInt);
            Assert.AreEqual(RunAllDaysCron, cron);
        }
    }
}
