using CronEspresso.Resources;
using CronEspresso.Utils;
using NUnit.Framework;

namespace CronEspresso.Test.ValidateCron.DayOfMonthValue.SlashSeparatedValue
{
    [TestFixture]
    public class when_a_user_passes_in_a_slash_dom_value_with_a_higher_left_value
    {
        private const string CronValue = "* * * 11/10 * *";
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
            Assert.AreEqual(string.Format(ValidationMessages.InvalidDayOfMonth, CronValue), _validationResult.ValidationMessage);
        }
    }
}
