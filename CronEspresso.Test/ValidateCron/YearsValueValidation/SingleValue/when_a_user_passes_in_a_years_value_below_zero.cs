using CronEspresso.Resources;
using CronEspresso.Utils;
using NUnit.Framework;

namespace CronEspresso.Test.ValidateCron.MonthValue.StringSingleValue
{
    [TestFixture]
    public class when_a_user_passes_in_a_years_value_below_zero
    {
        private const string CronValue = "* * * * * * -1970";
        private CronValidationResults _validationResult;

        [SetUp]
        public void SetUp()
        {
            _validationResult = CronHelpers.ValidateCron(CronValue);
        }

        [Test]
        public void it_gives_the_correct_result()
        {
            Assert.IsFalse(_validationResult.IsValidCron);
        }

        [Test]
        public void it_gives_the_correct_validation_message()
        {
            Assert.AreEqual(string.Format(ValidationMessages.InvalidYear, CronValue), _validationResult.ValidationMessage);
        }
    }
}
