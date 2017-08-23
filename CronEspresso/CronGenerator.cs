using System;
using System.Collections.Generic;
using System.Linq;
using CronEspresso.Utils;

namespace CronEspresso
{
    public static class CronGenerator
    {
        /// <summary>
        /// Generate a cron expression that runs every x minutes(s)
        /// </summary>
        /// <param name="minutes">Amount of minutes to wait before running</param>
        /// <returns>Cron experssion</returns>
        public static string GenerateMinutesCronExpression(int minutes)
        {
            if(minutes < 1 || minutes > 59)
                throw new ArgumentOutOfRangeException(nameof(minutes), minutes, ExceptionMessages.InvalidMinuteParamaterException);

            return $"0 0/{minutes} * 1/1 * ? *"; 
        }

        /// <summary>
        /// Generate a cron expression that runs every x hour(s)
        /// </summary>
        /// <param name="hours">Amount of hours to wait before running</param>
        /// <returns>Cron experssion</returns>
        public static string GenerateHourlyCronExpression(int hours)
        {
            if (hours < 1 || hours > 23)
                throw new ArgumentOutOfRangeException(nameof(hours), hours, ExceptionMessages.InvalidHourParamaterException);

            return $"0 0 0/{hours} 1/1 * ? *";
        }

        /// <summary>
        /// Generate a cron expression that runs at a given time every day of the week
        /// </summary>
        /// <param name="runTime">Time that the cron will run every day</param>
        /// <returns>Cron experssion</returns>
        public static string GenerateDailyCronExpression(TimeSpan runTime)
        {
            return $"{ParseCronTimeSpan(runTime)} ? * * *";
        }

        /// <summary>
        /// Generate a cron expression that runs at a given time every given day
        /// </summary>
        /// <param name="runTime">Time that the cron will run</param>
        /// <param name="dayToRun">Day that the cron will run (Sunday - Monday)</param>
        /// <returns>Cron experssion</returns>
        public static string GenerateSetDayCronExpression(TimeSpan runTime, DayOfWeek dayToRun)
        {
            return $"{ParseCronTimeSpan(runTime)} ? * {ParseDayOfWeek((int)dayToRun)} *";
        }

        /// <summary>
        /// Generate a cron expression that runs at a given time every given day
        /// </summary>
        /// <param name="runTime">Time that the cron will run</param>
        /// <param name="dayToRun">Day that the cron will run (0-6)</param>
        /// <returns>Cron experssion</returns>
        public static string GenerateSetDayCronExpression(TimeSpan runTime, int dayToRun)
        {
            return $"{ParseCronTimeSpan(runTime)} ? * {ParseDayOfWeek(dayToRun)} *";
        }

        /// <summary>
        /// Generate a cron expression that runs at a given time only on weekdays (Monday-Friday)
        /// </summary>
        /// <param name="runTime">Time that the cron will run each weekday</param>
        /// <returns>Cron experssion</returns>
        public static string GenerateWeekDayOnlyCronExpression(TimeSpan runTime)
        {
            return $"{ParseCronTimeSpan(runTime)} ? * MON-FRI *";
        }

        /// <summary>
        /// Generate a cron expression that runs at a given time multiple times a week
        /// </summary>
        /// <param name="runTime">Time that the cron will run</param>
        /// <param name="daysToRun">Days that the cron will run (Sunday-Monday)</param>
        /// <returns>Cron experssion</returns>
        public static string GenerateMultiDayCronExpression(TimeSpan runTime, List<DayOfWeek> daysToRun)
        {
            var castedDaysToRun = daysToRun.Cast<int>().ToList();
            return $"{ParseCronTimeSpan(runTime)} ? * {ParseMultiDaysList(castedDaysToRun)} *";
        }

        /// <summary>
        /// Generate a cron expression that runs at a given time multiple times a week
        /// </summary>
        /// <param name="runTime">Time that the cron will run</param>
        /// <param name="daysToRun">Days that the cron will run (0-6)</param>
        /// <returns>Cron experssion</returns>
        public static string GenerateMultiDayCronExpression(TimeSpan runTime, List<int> daysToRun)
        {
            return $"{ParseCronTimeSpan(runTime)} ? * {ParseMultiDaysList(daysToRun)} *";
        }

        public static string GenerateWeeklySpanCronExpression(TimeSpan runTime, int startDay, int endDay)
        {
            throw new NotImplementedException();
        }

        public static string GenerateWeeklySpanCronExpression(TimeSpan runTime, DayOfWeek startDay, DayOfWeek endDay)
        {
            throw new NotImplementedException();
        }

        public static string GenerateMonthlyCronExpression()
        {
            throw new NotImplementedException();
        }

        public static string GenerateYearlyCronExpression(TimeSpan runTime, MonthOfYear monthToRunOn, int dayOfMonthToRunOn)
        {
            throw new NotImplementedException();
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
            //// this is used to remove the first digit if it is "0", so "06" becomes "6" to fit cron standards
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
                    throw new ArgumentOutOfRangeException(nameof(dayOfTheWeek), dayOfTheWeek, ExceptionMessages.InvalidDayofTheWeekParameterException);
            }
        }
    }
}
