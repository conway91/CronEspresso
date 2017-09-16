using CronEspresso.Resources;
using CronEspresso.Utils;
using NUnit.Framework;

namespace CronEspresso.Test.ValidateCron.MonthValue.StringDashSeparatedValue
{
    [TestFixture]
    public class when_a_user_passes_in_a_dashed_month_string_value_with_multiple_dashed
    {
        private const string CronValue = "* * * * JAN--DEC *";
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
            Assert.AreEqual(string.Format(ValidationMessages.InvalidMonth, CronValue), _validationResult.ValidationMessage);
        }
    }
}
