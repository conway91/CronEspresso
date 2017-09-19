using CronEspresso.Utils;
using NUnit.Framework;

namespace CronEspresso.Test.RemoveYearValue
{
    [TestFixture]
    public class when_a_user_removes_the_year_from_a_cron
    {
        private const string CronWithYear = "0 0 0 * * ? *";
        private const string CronWithoutYear = "0 0 0 * * ?";

        [Test]
        public void it_returns_the_correct_value()
        {
            var yearlessCron = CronHelpers.RemoveCronYearValue(CronWithYear);
            Assert.AreEqual(CronWithoutYear, yearlessCron);
        }
    }
}
