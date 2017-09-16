using CronEspresso.Resources;
using CronEspresso.Utils;
using NUnit.Framework;

namespace CronEspresso.Test.ValidateCron.MinutesValueValidation.DashSeperatedValue
{
    [TestFixture]
    public class when_a_user_passes_in_a_dashed_minutes_value_with_multiple_dashed
    {
        private const string CronValue = "* 0--59 * * * *";
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
            Assert.AreEqual(string.Format(ValidationMessages.InvalidMinutesValue, CronValue), _validationResult.ValidationMessage);
        }
    }
}
