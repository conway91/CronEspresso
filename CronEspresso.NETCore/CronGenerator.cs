using System;
using System.Collections.Generic;
using System.Linq;
using CronEspresso.NETCore.Enums;
using CronEspresso.NETCore.Resources;
using CronEspresso.NETCore.Utils;

namespace CronEspresso.NETCore
{
    public static class CronGenerator
    {
        /// <summary>
        /// Generate a cron expression that runs every x minutes(s)
        /// Example : A cron that will run every 5 minutes
        /// </summary>
        /// <param name="minutes">Amount of minutes to wait before running</param>
        /// <returns>Cron expression</returns>
        public static string GenerateMinutesCronExpression(int minutes)
        {
            CronGenerationValueValidator.ValidateMinutes(minutes);

            return $"0 0/{minutes} * 1/1 * ? *"; 
        }

        /// <summary>
        /// Generate a cron expression that runs every x hour(s)
        /// Example : A cron that will run every 2 hours
        /// </summary>
        /// <param name="hours">Amount of hours to wait before running</param>
        /// <returns>Cron expression</returns>
        public static string GenerateHourlyCronExpression(int hours)
        {
            CronGenerationValueValidator.ValidateHours(hours);

            return $"0 0 0/{hours} 1/1 * ? *";
        }

        /// <summary>
        /// Generate a cron expression that runs at a given time every day of the week
        /// Example : A cron that will run at 13:00 every day
        /// </summary>
        /// <param name="runTime">Time that the cron will run every day</param>
        /// <returns>Cron experssion</returns>
        public static string GenerateDailyCronExpression(TimeSpan runTime)
        {
            return $"{ParseCronTimeSpan(runTime)} ? * * *";
        }

        /// <summary>
        /// Generate a cron expression that runs at a given time every given day
        /// Example : A cron that will run at 13:00 every Wednesday
        /// </summary>
        /// <param name="runTime">Time that the cron will run</param>
        /// <param name="dayToRun">Day that the cron will run (Sunday - Monday)</param>
        /// <returns>Cron expression</returns>
        public static string GenerateSetDayCronExpression(TimeSpan runTime, DayOfWeek dayToRun)
        {
            return $"{ParseCronTimeSpan(runTime)} ? * {ParseDayOfWeek((int)dayToRun)} *";
        }

        /// <summary>
        /// Generate a cron expression that runs at a given time every given day
        /// Example : A cron that will run at 13:00 every Wednesday
        /// </summary>
        /// <param name="runTime">Time that the cron will run</param>
        /// <param name="dayToRun">Day that the cron will run (0-6)</param>
        /// <returns>Cron expression</returns>
        public static string GenerateSetDayCronExpression(TimeSpan runTime, int dayToRun)
        {
            return $"{ParseCronTimeSpan(runTime)} ? * {ParseDayOfWeek(dayToRun)} *";
        }

        /// <summary>
        /// Generate a cron expression that runs at a given time only on weekdays (Monday-Friday)
        /// Example : A cron that will run at 13:00 every Monday to Friday
        /// </summary>
        /// <param name="runTime">Time that the cron will run each weekday</param>
        /// <returns>Cron expression</returns>
        public static string GenerateWeekDayOnlyCronExpression(TimeSpan runTime)
        {
            return $"{ParseCronTimeSpan(runTime)} ? * MON-FRI *";
        }

        /// <summary>
        /// Generate a cron expression that runs at a given time multiple times a week
        /// Example : A cron that will run at 13:00 every Monday, Wednesday, and Saturday
        /// </summary>
        /// <param name="runTime">Time that the cron will run</param>
        /// <param name="daysToRun">Days that the cron will run (Sunday-Monday)</param>
        /// <returns>Cron expression</returns>
        public static string GenerateMultiDayCronExpression(TimeSpan runTime, List<DayOfWeek> daysToRun)
        {
            var castedDaysToRun = daysToRun.Cast<int>().ToList();
            return CreateMultiDayValue(runTime, castedDaysToRun);
        }

        /// <summary>
        /// Generate a cron expression that runs at a given time multiple times a week
        /// Example : A cron that will run at 13:00 every Monday, Wednesday, and Saturday
        /// </summary>
        /// <param name="runTime">Time that the cron will run</param>
        /// <param name="daysToRun">Days that the cron will run (0-6)</param>
        /// <returns>Cron expression</returns>
        public static string GenerateMultiDayCronExpression(TimeSpan runTime, List<int> daysToRun)
        {
            return CreateMultiDayValue(runTime, daysToRun);
        }

        /// <summary>
        /// Generate a cron expression that runs at a given day every x amount of months
        /// Example : A cron that will run at 13:00 on the 30th every 3 months
        /// </summary>
        /// <param name="runTime">Time that the cron will run</param>
        /// <param name="dayofTheMonthToRunOn">The day that the cron will run on (1-31)</param>
        /// <param name="monthsToRunOn">Time between months that the cron will run on (1-12)</param>
        /// <returns>Cron expression</returns>
        public static string GenerateMonthlyCronExpression(TimeSpan runTime, int dayofTheMonthToRunOn, int monthsToRunOn)
        {
            CronGenerationValueValidator.ValidateDayOfMonthToRunOn(dayofTheMonthToRunOn);
            CronGenerationValueValidator.ValidateMonthsToRunAfter(monthsToRunOn);

            return $"{ParseCronTimeSpan(runTime)} {dayofTheMonthToRunOn} 1/{monthsToRunOn} ? *";
        }

        /// <summary>
        /// Generate a cron expression that runs at a set time of the month every x months
        /// Example : A cron that will run run at 13:00 on the second Friday every 3 months
        /// </summary>
        /// <param name="runTime">Time that the cron will run</param>
        /// <param name="timeOfMonthToRun">Period of the month the cron will run (Frst, Second, Thrid, Fourth, or Last)</param>
        /// <param name="dayToRun">Day that the cron will run (Sunday - Monday)</param>
        /// <param name="amountOfMonthsToRunAfter">Time between months that the cron will run on (1-12)</param>
        /// <returns>Cron expression</returns>
        public static string GenerateSetDayMonthlyCronExpression(TimeSpan runTime, TimeOfMonthToRun timeOfMonthToRun, DayOfWeek dayToRun, int amountOfMonthsToRunAfter)
        {
            return CreateTimeOfMonthValue(runTime, timeOfMonthToRun, (int)dayToRun, amountOfMonthsToRunAfter);
        }

        /// <summary>
        /// Generate a cron expression that runs at a set time of the month every x months
        /// Example : A cron that will run run at 13:00 on the second Friday every 3 months
        /// </summary>
        /// <param name="runTime">Time that the cron will run</param>
        /// <param name="timeOfMonthToRun">Period of the month the cron will run (Frst, Second, Thrid, Fourth, or Last)</param>
        /// <param name="dayToRun">Day that the cron will run (0 - 6)</param>
        /// <param name="amountOfMonthsToRunAfter">Time between months that the cron will run on (1-12)</param>
        /// <returns>Cron experssion</returns>
        public static string GenerateSetDayMonthlyCronExpression(TimeSpan runTime, TimeOfMonthToRun timeOfMonthToRun, int dayToRun, int amountOfMonthsToRunAfter)
        {
            return CreateTimeOfMonthValue(runTime, timeOfMonthToRun, dayToRun, amountOfMonthsToRunAfter);
        }

        /// <summary>
        /// Generate a cron expression that runs at a set day on a set month once a year
        /// Example : A cron that will run on the 13th of March every year
        /// </summary>
        /// <param name="runTime">Time that the cron will run</param>
        /// <param name="dayOfMonthToRunOn">Day of the month the cron will run on (1-31 (29 for Feburary))</param>
        /// <param name="monthToRunOn">Month of the year the cron will run on (Janurary - December)</param>
        /// <returns>Cron expression</returns>
        public static string GenerateYearlyCronExpression(TimeSpan runTime, int dayOfMonthToRunOn, MonthOfYear monthToRunOn)
        {
            return CreateYearlyValue(runTime, dayOfMonthToRunOn, (int)monthToRunOn);
        }

        /// <summary>
        /// Generate a cron expression that runs at a set day on a set month once a year
        /// Example : A cron that will run on the 13th of March every year
        /// </summary>
        /// <param name="runTime">Time that the cron will run</param>
        /// <param name="dayOfMonthToRunOn">Day of the month the cron will run on (1-31 (29 for Feburary))</param>
        /// <param name="monthToRunOn">Month of the year the cron will run on (1 - 12)</param>
        /// <returns>Cron expression</returns>
        public static string GenerateYearlyCronExpression(TimeSpan runTime, int dayOfMonthToRunOn, int monthToRunOn)
        {
            return CreateYearlyValue(runTime, dayOfMonthToRunOn, monthToRunOn);
        }

        #region Private Implementation      
        private static string CreateYearlyValue(TimeSpan runTime, int dayOfMonthToRunOn, int monthToRunOn)
        {
            CronGenerationValueValidator.ValidateDayOfMonthToRunOn(dayOfMonthToRunOn);
            CronGenerationValueValidator.ValidateMonthToRunOn(monthToRunOn);
            CronGenerationValueValidator.ValidateDayOfMonthForFebrary(monthToRunOn, dayOfMonthToRunOn);
            CronGenerationValueValidator.ValidateDayOfMonthForShorterMonth(monthToRunOn, dayOfMonthToRunOn);

            return $"{ParseCronTimeSpan(runTime)} {dayOfMonthToRunOn} {monthToRunOn} ? *";
        }

        private static string CreateTimeOfMonthValue(TimeSpan runTime, TimeOfMonthToRun timeOfMonthToRun, int dayToRun, int amountOfMonthsToRunAfter)
        {
            CronGenerationValueValidator.ValidateMonthsToRunAfter(amountOfMonthsToRunAfter);

            if (timeOfMonthToRun != TimeOfMonthToRun.Last)
            {
                var day = ParseDayOfWeek(dayToRun);
                var timeOfMonuthToRunIntValue = (int) timeOfMonthToRun;
                return $"{ParseCronTimeSpan(runTime)} ? 1/{amountOfMonthsToRunAfter} {day}#{timeOfMonuthToRunIntValue} *";
            }
            else
            {
                var day = dayToRun + 1;
                return $"{ParseCronTimeSpan(runTime)} ? 1/{amountOfMonthsToRunAfter} {day}L *";
            }
        }

        private static string CreateMultiDayValue(TimeSpan runTime, List<int> days)
        {
            CronGenerationValueValidator.ValidateDays(days);

            return $"{ParseCronTimeSpan(runTime)} ? * {ParseMultiDaysList(days)} *";
        }

        private static string ParseCronTimeSpan(TimeSpan timeSpan)
        {
            var seconds = RemoveExtraDigitFromTimeValue(timeSpan.ToString("ss"));
            var minutes = RemoveExtraDigitFromTimeValue(timeSpan.ToString("mm"));
            var hours = RemoveExtraDigitFromTimeValue(timeSpan.ToString("hh"));

            return $"{seconds} {minutes} {hours}";
        }

        private static string RemoveExtraDigitFromTimeValue(string timeValue)
        {
            //// this is used to remove the first digit if it is "0", e.g. "06" becomes "6" to fit cron standards
            return timeValue[0] == '0' ? timeValue[1].ToString() : timeValue;
        }

        private static string ParseMultiDaysList(List<int> daysToRun)
        {
            var cronDays = string.Empty;
            foreach (var day in daysToRun)
            {
                cronDays += ParseDayOfWeek(day);
                if (day != daysToRun.Last())
                    cronDays += ",";
            }
            return cronDays;
        }

        private static string ParseDayOfWeek(int dayOfTheWeek)
        {
            switch (dayOfTheWeek)
            {
                case 0:
                    return "SUN";
                case 1:
                    return "MON";
                case 2:
                    return "TUE";
                case 3:
                    return "WED";
                case 4:
                    return "THU";
                case 5:
                    return "FRI";
                case 6:
                    return "SAT";
                default:
                    throw new ArgumentOutOfRangeException(nameof(dayOfTheWeek), dayOfTheWeek, ExceptionMessages.InvalidDayOfTheWeekParameterException);
            }
        }
        #endregion
    }
}
