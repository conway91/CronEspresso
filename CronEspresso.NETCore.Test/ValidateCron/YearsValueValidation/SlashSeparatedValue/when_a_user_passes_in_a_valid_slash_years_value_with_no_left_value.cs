﻿using CronEspresso.NETCore.Resources;
using CronEspresso.NETCore.Utils;
using NUnit.Framework;

namespace CronEspresso.NETCore.Test.ValidateCron.YearsValueValidation.SlashSeparatedValue
{
    [TestFixture]
    public class when_a_user_passes_in_a_valid_slash_years_value_with_no_left_value
    {
        private const string CronValue = "* * * * * * /2012";
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
