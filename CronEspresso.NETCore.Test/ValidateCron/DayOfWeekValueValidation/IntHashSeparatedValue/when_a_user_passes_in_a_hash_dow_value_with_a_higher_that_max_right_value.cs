using CronEspresso.NETCore.Resources;
using CronEspresso.NETCore.Utils;
using NUnit.Framework;

namespace CronEspresso.NETCore.Test.ValidateCron.DayOfWeekValueValidation.IntHashSeparatedValue
{
    [TestFixture]
    public class when_a_user_passes_in_a_hash_dow_value_with_a_higher_left_value
    {
        private const string CronValue = "* * * * * 87#32";
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
