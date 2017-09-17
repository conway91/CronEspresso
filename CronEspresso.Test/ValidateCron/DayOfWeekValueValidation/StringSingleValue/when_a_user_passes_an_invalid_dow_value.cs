using CronEspresso.Resources;
using CronEspresso.Utils;
using NUnit.Framework;

namespace CronEspresso.Test.ValidateCron.DayOfWeekValueValidation.StringSingleValue
{
    [TestFixture]
    public class when_a_user_passes_an_invalid_dow_value
    {
        private const string CronValue = "* * * * * MONDAY*";
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
