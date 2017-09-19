﻿using CronEspresso.Resources;
using CronEspresso.Utils;
using NUnit.Framework;

namespace CronEspresso.Test.ValidateCron.MinutesValueValidation.DashSeparatedValue
{
    [TestFixture]
    public class when_a_user_passes_in_a_valid_dashed_minutes_value
    {
        private const string CronValue = "* 0-59 * * * *";
        private CronValidationResults _validationResult;

        [SetUp]
        public void SetUp()
        {
            _validationResult = CronHelpers.ValidateCron(CronValue);
        }

        [Test]
        public void it_gives_the_correct_result()
        {
            Assert.True(_validationResult.IsValidCron);
        }

        [Test]
        public void it_gives_the_correct_validation_message()
        {
            Assert.AreEqual(string.Format(ValidationMessages.ValidExpression, CronValue), _validationResult.ValidationMessage);
        }
    }
}
