using System;
using System.Linq;
using CronEspresso.Resources;

namespace CronEspresso.Utils
{
    public static class CronHelpers
    {
        /// <summary>
        /// Removes the year value of a cron expression
        /// Having no year value can sometimes be required when supplying a cron expression
        /// </summary>
        /// <param name="cronExpression">Full cron expression</param>
        /// <returns>Cron expression minus the year value</returns>
        public static string RemoveCronYearValue(string cronExpression)
        {
            var validateResult = ValidateCron(cronExpression);
            if (!validateResult.IsValidCron)
                throw new ArgumentException(validateResult.ValidationMessage);

            return cronExpression.Split(' ').Length == 6
                ? cronExpression
                : cronExpression.Substring(0, cronExpression.LastIndexOf(' '));
        }

        /// <summary>
        /// Validates a cron expression to ensure it is in the correct stanard format
        /// </summary>
        /// <param name="cronExpression">Full cron expression</param>
        /// <returns>CronValidationResults which contains a bool if validate and a string description of results</returns>
        public static CronValidationResults ValidateCron(string cronExpression)
        {
            if (string.IsNullOrWhiteSpace(cronExpression))
                return new CronValidationResults(false, ValidationMessages.EmptyString);

            var cronValues = cronExpression.Split(' ');

            if (cronValues.Length > 7 || cronValues.Length < 6)
                return new CronValidationResults(false, string.Format(ValidationMessages.InvalidCronFormat, cronExpression));

            if (!ValidateTimeSpanValue(cronValues[0], 59))
                return new CronValidationResults(false, string.Format(ValidationMessages.InvalidSecondsValue, cronExpression));

            if (!ValidateTimeSpanValue(cronValues[1], 59))
                return new CronValidationResults(false, string.Format(ValidationMessages.InvalidMinutesValue, cronExpression));

            if (!ValidateTimeSpanValue(cronValues[2], 23))
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

        private static bool ValidateTimeSpanValue(string timeValue, int maxValue)
        {
            if (timeValue == "*")
                return true;

            int parsedtimeValue;
            if (int.TryParse(timeValue, out parsedtimeValue))
                return parsedtimeValue >= 0 && parsedtimeValue <= maxValue;

            if (timeValue.Contains("-"))
                return ValidateCharcterSeperatedIntValues(timeValue, maxValue, '-');

            if (timeValue.Contains("/"))
            {
                if (timeValue[0] == '/')
                {
                    try
                    {
                        var value = int.Parse(timeValue.Substring(1, timeValue.Length - 1));
                        return value >= 0 && value <= maxValue;
                    }
                    catch (FormatException)
                    {
                        return false;
                    }
                }

                return ValidateCharcterSeperatedIntValues(timeValue, maxValue, '/');
            }

            if (timeValue.Contains(","))
            {
                var timeValues = timeValue.Split(',');

                return !timeValues.Any(string.IsNullOrWhiteSpace) && timeValues.Select(int.Parse).All(parsedValue => parsedValue >= 0 && parsedValue <= maxValue);
            }

            return false;
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

        private static bool ValidateCharcterSeperatedIntValues(string values, int maxValue, char seperator)
        {
            if (values.Count(c => c == seperator) > 1)
                return false;

            try
            {
                var firstValue = int.Parse(values.Substring(0, values.IndexOf(seperator)));
                var secondValue = int.Parse(values.Substring(values.IndexOf(seperator) + 1));

                return firstValue <= secondValue && firstValue >= 0 && secondValue <= maxValue;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
