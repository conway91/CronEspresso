﻿using CronEspresso.Resources;
using CronEspresso.Utils;
using NUnit.Framework;

namespace CronEspresso.Test.ValidateCron.DayOfWeekValueValidation.StringSlashSeparatedValue
{
    [TestFixture]
    public class when_a_user_passes_in_a_slash_dow_string_value_with_invalid_left
    {
        private const string CronValue = "* * * * * GIBBERISH/MON";
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
