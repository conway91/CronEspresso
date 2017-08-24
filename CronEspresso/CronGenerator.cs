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
        /// Example : A cron that will run every 5 minutes
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
        /// Example : A cron that will run every 2 hours
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
        /// <returns>Cron experssion</returns>
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
        /// <returns>Cron experssion</returns>
        public static string GenerateSetDayCronExpression(TimeSpan runTime, int dayToRun)
        {
            return $"{ParseCronTimeSpan(runTime)} ? * {ParseDayOfWeek(dayToRun)} *";
        }

        /// <summary>
        /// Generate a cron expression that runs at a given time only on weekdays (Monday-Friday)
        /// Example : A cron that will run at 13:00 every Monday to Friday
        /// </summary>
        /// <param name="runTime">Time that the cron will run each weekday</param>
        /// <returns>Cron experssion</returns>
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
        /// <returns>Cron experssion</returns>
        public static string GenerateMultiDayCronExpression(TimeSpan runTime, List<DayOfWeek> daysToRun)
        {
            var castedDaysToRun = daysToRun.Cast<int>().ToList();
            return ValidateMultiDayValues(runTime, castedDaysToRun);
        }

        /// <summary>
        /// Generate a cron expression that runs at a given time multiple times a week
        /// Example : A cron that will run at 13:00 every Monday, Wednesday, and Saturday
        /// </summary>
        /// <param name="runTime">Time that the cron will run</param>
        /// <param name="daysToRun">Days that the cron will run (0-6)</param>
        /// <returns>Cron experssion</returns>
        public static string GenerateMultiDayCronExpression(TimeSpan runTime, List<int> daysToRun)
        {
            return ValidateMultiDayValues(runTime, daysToRun);
        }

        /// <summary>
        /// Generate a cron expression that runs at a given day every x amount of months
        /// Example : A cron that will run at 13:00 on the 30th every 3 months
        /// </summary>
        /// <param name="runTime">Time that the cron will run</param>
        /// <param name="dayofTheMonthToRunOn">The day that the cron will run on (1-31)</param>
        /// <param name="monthsToRunOn">Time between months that the cron will run on (1-12)</param>
        /// <returns>Cron experssion</returns>
        public static string GenerateMonthlyCronExpression(TimeSpan runTime, int dayofTheMonthToRunOn, int monthsToRunOn)
        {
            if (dayofTheMonthToRunOn < 1 || dayofTheMonthToRunOn > 31)
                throw new ArgumentOutOfRangeException(nameof(dayofTheMonthToRunOn), dayofTheMonthToRunOn, ExceptionMessages.InvalidDayofTheMonthException);

            if (monthsToRunOn < 1 || monthsToRunOn > 12)
                throw new ArgumentOutOfRangeException(nameof(monthsToRunOn), monthsToRunOn, ExceptionMessages.InvalidMonthToRunOnException);

            return $"{ParseCronTimeSpan(runTime)} {dayofTheMonthToRunOn} 1/{monthsToRunOn} ? *";
        }

        /// <summary>
        /// Generate a cron expression that runs at a set time of the month every x months
        /// Example : A cron that will run run at 13:00 on the second Friday every 3 months
        /// </summary>
        /// <param name="runTime">Time that the cron will run</param>
        /// <param name="timeOfMonthToRun">Period of the month the cron will run (Frst, Second, Thrid, Fourth, or Last)</param>
        /// <param name="dayToRun">Day that the cron will run (Sunday - Monday)</param>
        /// <param name="monthsToRunOn">Time between months that the cron will run on (1-12)</param>
        /// <returns>Cron experssion</returns>
        public static string GenerateSetDayMonthlyCronExpression(TimeSpan runTime, TimeOfMonthToRun timeOfMonthToRun, DayOfWeek dayToRun, int monthsToRunOn)
        {
            return ValidateTimeOfMonthValue(runTime, timeOfMonthToRun, (int)dayToRun, monthsToRunOn);
        }

        /// <summary>
        /// Generate a cron expression that runs at a set time of the month every x months
        /// Example : A cron that will run run at 13:00 on the second Friday every 3 months
        /// </summary>
        /// <param name="runTime">Time that the cron will run</param>
        /// <param name="timeOfMonthToRun">Period of the month the cron will run (Frst, Second, Thrid, Fourth, or Last)</param>
        /// <param name="dayToRun">Day that the cron will run (0 - 6)</param>
        /// <param name="monthsToRunOn">Time between months that the cron will run on (1-12)</param>
        /// <returns>Cron experssion</returns>
        public static string GenerateSetDayMonthlyCronExpression(TimeSpan runTime, TimeOfMonthToRun timeOfMonthToRun, int dayToRun, int monthsToRunOn)
        {
            return ValidateTimeOfMonthValue(runTime, timeOfMonthToRun, dayToRun, monthsToRunOn);
        }

        public static string GenerateYearlyCronExpression()
        {
            throw new NotImplementedException();
        }

        private static string ValidateTimeOfMonthValue(TimeSpan runTime, TimeOfMonthToRun timeOfMonthToRun, int dayToRun, int monthsToRunOn)
        {
            if (monthsToRunOn < 1 || monthsToRunOn > 12)
                throw new ArgumentOutOfRangeException(nameof(monthsToRunOn), monthsToRunOn, ExceptionMessages.InvalidMonthToRunOnException);

            if (timeOfMonthToRun != TimeOfMonthToRun.Last)
            {
                var day = ParseDayOfWeek(dayToRun);
                var timeOfMonuthToRunIntValue = (int) timeOfMonthToRun;
                return $"{ParseCronTimeSpan(runTime)} ? 1/{monthsToRunOn} {day}#{timeOfMonuthToRunIntValue} *";
            }
            else
            {
                var day = dayToRun + 1;
                return $"{ParseCronTimeSpan(runTime)} ? 1/{monthsToRunOn} {day}L *";
            }
        }

        private static string ValidateMultiDayValues(TimeSpan runTime, List<int> days)
        {
            if (days.Count != days.Distinct().Count())
                throw new ArgumentOutOfRangeException(nameof(days), days, ExceptionMessages.DuplicateDaysException);

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
                    throw new ArgumentOutOfRangeException(nameof(dayOfTheWeek), dayOfTheWeek, ExceptionMessages.InvalidDayofTheWeekParameterException);
            }
        }
    }
}
