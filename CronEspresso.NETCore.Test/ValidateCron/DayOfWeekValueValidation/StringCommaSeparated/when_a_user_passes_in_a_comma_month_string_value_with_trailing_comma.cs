using CronEspresso.NETCore.Resources;
using CronEspresso.NETCore.Utils;
using NUnit.Framework;

namespace CronEspresso.NETCore.Test.ValidateCron.DayOfWeekValueValidation.StringCommaSeparated
{
    [TestFixture]
    public class when_a_user_passes_in_a_comma_month_string_value_with_trailing_comma
    {
        private const string CronValue = "* * * * * MON,WED,SUN,";
        private CronValidationResults _validationResult;

        [SetUp]
        public void SetUp()
        {
            _validationResult = CronHelpers.ValidateCron(CronValue);
        }

        [Test]
        public void it_gives_the_correct_result()
        {
            Assert.False(_validationResult.IsValidCron);
        }

        [Test]
        public void it_gives_the_correct_validation_message()
        {
            Assert.AreEqual(string.Format(ValidationMessages.InvalidDayOfWeek, CronValue), _validationResult.ValidationMessage);
        }
    }
}
