using System;
using CronEspresso.Resources;

namespace CronEspresso.Utils
{
    public static class CronExtensions
    {
        public static CronValidationResults ValidateCron(this string cronExpression)
        {
            if (string.IsNullOrWhiteSpace(cronExpression))
                return new CronValidationResults(false, ValidationMessages.EmptyString);

            var cronValues = cronExpression.Split(' ');

            if(cronValues.Length > 7 || cronValues.Length < 6)
                return new CronValidationResults(false, string.Format(ValidationMessages.InvalidCronFormat, cronExpression));

            if(!ValidateTimeSpanValue(cronValues[0], TimeSpanValueType.Second))
                return new CronValidationResults(false, string.Format(ValidationMessages.InvalidSecondsValue, cronExpression));

            if (!ValidateTimeSpanValue(cronValues[1], TimeSpanValueType.Minutes))
                return new CronValidationResults(false, string.Format(ValidationMessages.InvalidMinutesValue, cronExpression));

            if (!ValidateTimeSpanValue(cronValues[2], TimeSpanValueType.Hours))
                return new CronValidationResults(false, string.Format(ValidationMessages.InvalidHoursValue, cronExpression));

            if (!ValidateDayOfMonthValue(cronValues[3]))
                return new CronValidationResults(false, string.Format(ValidationMessages.InvalidDayOfMonth, cronExpression));

            if (!ValidateMonthValue(cronValues[4]))
                return new CronValidationResults(false, string.Format(ValidationMessages.InvalidMonth, cronExpression));

            if (!ValidateDayOfWeekValue(cronValues[5]))
                return new CronValidationResults(false, string.Format(ValidationMessages.InvalidMonth, cronExpression));

            if (cronValues.Length == 7)
            {
                if (!ValidateYearValue(cronValues[6]))
                    return new CronValidationResults(false, string.Format(ValidationMessages.InvalidYear, cronExpression));
            }

            return new CronValidationResults(true, string.Format(ValidationMessages.ValidExpression, cronExpression));
        }

        private static bool ValidateTimeSpanValue(string timeValue, TimeSpanValueType valueType)
        {
            int maxValue;
            switch (valueType)
            {
                case TimeSpanValueType.Second:
                case TimeSpanValueType.Minutes:
                    maxValue = 59;
                    break;
                case TimeSpanValueType.Hours:
                    maxValue = 23;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(valueType), valueType, null);
            }

            int parsedtimeValue;
            if (int.TryParse(timeValue, out parsedtimeValue))
            {
                return parsedtimeValue >= 0 && parsedtimeValue <= maxValue;
            }

            return true;
        }

        private static bool ValidateDayOfMonthValue(string dayOfMonthValue)
        {
            return true;
        }

        private static bool ValidateMonthValue(string monthValue)
        {
            return true;
        }

        private static bool ValidateDayOfWeekValue(string dayOfWeekValue)
        {
            return true;
        }

        private static bool ValidateYearValue(string yearValue)
        {
            return true;
        }
    }

    internal enum TimeSpanValueType
    {
        Second,
        Minutes,
        Hours
    }
}
