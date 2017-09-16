﻿using System;
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

            return ValidateIntegerValues(timeValue, 0, maxValue);
        }

        private static bool ValidateDayOfMonthValue(string dayOfMonthValue)
        {
            var formatedFayOfMonthValue = dayOfMonthValue.ToUpper();

            if (dayOfMonthValue == "*" || dayOfMonthValue == "?" || dayOfMonthValue == "L" || dayOfMonthValue == "LW")
                return true;

            if (formatedFayOfMonthValue.Contains("L"))
                return false;   //// Since we have already checked for a sinle 'L' or 'LW', any other is invalid

            if (formatedFayOfMonthValue.Contains("W"))
            {
                if (!formatedFayOfMonthValue.EndsWith("W"))
                    return false;
                
                try
                {
                    var weekdayValue = int.Parse(formatedFayOfMonthValue.TrimEnd(formatedFayOfMonthValue[formatedFayOfMonthValue.Length - 1]));
                    return weekdayValue >= 1 && weekdayValue <= 32;
                }
                catch (FormatException)
                {
                    return false;
                }
            }

            return ValidateIntegerValues(dayOfMonthValue, 1, 31);
        }

        private static bool ValidateMonthValue(string monthValue)
        {
            if (monthValue == "*")
                return true;

            return monthValue.Any(char.IsDigit) ? ValidateIntegerValues(monthValue, 1, 12) : ValidateMonthStringValues(monthValue);
        }

        private static bool ValidateDayOfWeekValue(string dayOfWeekValue)
        {
            return true;
        }

        private static bool ValidateYearValue(string yearValue)
        {
            if (yearValue == "*")
                return true;

            return ValidateIntegerValues(yearValue, 1970, 2099);
        }

        private static bool ValidateIntegerValues(string intValues, int minValue, int maxValue)
        {
            int parsedtimeValue;
            if (int.TryParse(intValues, out parsedtimeValue))
                return parsedtimeValue >= minValue && parsedtimeValue <= maxValue;

            if (intValues.Contains("-"))
                return ValidateCharcterSeperatedIntValues(intValues, minValue, maxValue, '-');

            if (intValues.Contains("/"))
            {
                if (intValues[0] == '/')
                {
                    try
                    {
                        var value = int.Parse(intValues.Substring(1, intValues.Length - 1));
                        return value >= minValue && value <= maxValue;
                    }
                    catch (FormatException)
                    {
                        return false;
                    }
                }

                return ValidateCharcterSeperatedIntValues(intValues, minValue, maxValue, '/');
            }

            if (intValues.Contains(","))
            {
                var timeValues = intValues.Split(',');

                return !timeValues.Any(string.IsNullOrWhiteSpace) && timeValues.Select(int.Parse).All(parsedValue => parsedValue >= minValue && parsedValue <= maxValue);
            }

            return false;
        }

        private static bool ValidateMonthStringValues(string monthValues)
        {
            if (monthValues.Contains("-"))
                return ValidateCharcterSeperatedStringMonthValues(monthValues, '-');

            if (monthValues.Contains("/"))
            {
                if (monthValues[0] == '/')
                {
                    try
                    {
                        var value = monthValues.Substring(1, monthValues.Length - 1);
                        return ValidateMonthStringValue(value);
                    }
                    catch (FormatException)
                    {
                        return false;
                    }
                }

                return ValidateCharcterSeperatedStringMonthValues(monthValues, '/');
            }

            if (monthValues.Contains(","))
            {
                var monthValuesSplit = monthValues.Split(',');

                return monthValuesSplit.All(ValidateMonthStringValue);
            }

            return ValidateMonthStringValue(monthValues);
        }

        private static bool ValidateCharcterSeperatedIntValues(string values, int minValue, int maxValue, char seperator)
        {
            if (values.Count(c => c == seperator) > 1)
                return false;

            try
            {
                var firstValue = int.Parse(values.Substring(0, values.IndexOf(seperator)));
                var secondValue = int.Parse(values.Substring(values.IndexOf(seperator) + 1));

                return firstValue <= secondValue && firstValue >= minValue && secondValue <= maxValue;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private static bool ValidateCharcterSeperatedStringMonthValues(string values, char seperator)
        {
            if (values.Count(c => c == seperator) > 1)
                return false;

            var firstValue = values.Substring(0, values.IndexOf(seperator));
            var secondValue = values.Substring(values.IndexOf(seperator) + 1);

            return ValidateMonthStringValue(firstValue) && ValidateMonthStringValue(secondValue);
        }

        private static bool ValidateDayOfWeekStringValue(string value)
        {
            switch (value)
            {
                case "SUN":
                    return true;
                case "MON":
                    return true;
                case "TUE":
                    return true;
                case "WED":
                    return true;
                case "THU":
                    return true;
                case "FRI":
                    return true;
                case "SAT":
                    return true;
                default:
                    return false;
            }
        }

        private static bool ValidateMonthStringValue(string value)
        {
            switch (value)
            {
                case "JAN":
                    return true;
                case "FEB":
                    return true;
                case "MAR":
                    return true;
                case "APR":
                    return true;
                case "MAY":
                    return true;
                case "JUN":
                    return true;
                case "JUL":
                    return true;
                case "AUG":
                    return true;
                case "SEP":
                    return true;
                case "OCT":
                    return true;
                case "NOV":
                    return true;
                case "DEC":
                    return true;
                default:
                    return false;
            }
        }
    }
}