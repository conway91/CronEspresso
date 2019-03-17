using System;
using System.Collections.Generic;
using System.Linq;
using CronEspresso.NETCore.Resources;

namespace CronEspresso.NETCore.Utils
{
    internal static class CronGenerationValueValidator
    {
        internal static void ValidateDays(List<int> days)
        {
            if (days.Count != days.Distinct().Count())
                throw new ArgumentOutOfRangeException(nameof(days), days, ExceptionMessages.DuplicateDaysException);
        }

        internal static void ValidateMonthsToRunAfter(int amountOfMonthsToRunAfter)
        {
            if (amountOfMonthsToRunAfter < 1 || amountOfMonthsToRunAfter > 12)
                throw new ArgumentOutOfRangeException(nameof(amountOfMonthsToRunAfter), amountOfMonthsToRunAfter, ExceptionMessages.InvalidAmountOfMonthsToRunAfterException);
        }

        internal static void ValidateMonthToRunOn(int month)
        {
            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException(nameof(month), month, ExceptionMessages.InvalidMonthParameterException);
        }

        internal static void ValidateDayOfMonthForShorterMonth(int month, int dayToRunOn)
        {
            if ((month == 4 || month == 6 || month == 9 || month == 11) && dayToRunOn > 30)
                throw new ArgumentOutOfRangeException(nameof(dayToRunOn), dayToRunOn, ExceptionMessages.InvalidShorterMonthParameterException);
        }

        internal static void ValidateDayOfMonthForFebrary(int month, int dayToRunOn)
        {
            if (month == 2 && dayToRunOn > 29)
                throw new ArgumentOutOfRangeException(nameof(dayToRunOn), dayToRunOn, ExceptionMessages.InvalidFebruaryDateParameterException);
        }

        internal static void ValidateDayOfMonthToRunOn(int dayOfTheMonth)
        {
            if (dayOfTheMonth < 1 || dayOfTheMonth > 31)
                throw new ArgumentOutOfRangeException(nameof(dayOfTheMonth), dayOfTheMonth, ExceptionMessages.InvalidDayOfTheMonthException);
        }

        internal static void ValidateHours(int hours)
        {
            if (hours < 1 || hours > 23)
                throw new ArgumentOutOfRangeException(nameof(hours), hours, ExceptionMessages.InvalidHourParameterException);
        }

        internal static void ValidateMinutes(int minutes)
        {
            if (minutes < 1 || minutes > 59)
                throw new ArgumentOutOfRangeException(nameof(minutes), minutes, ExceptionMessages.InvalidMinuteParameterException);
        }
    }
}
