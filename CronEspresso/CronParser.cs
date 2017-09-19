using System;
using System.Collections.Generic;

namespace CronEspresso
{
    ////public static class CronParser
    ////{
    ////    private const string AllValues = "*";
    ////    private const string NoSpecificValue = "?";

    ////    /// <summary>
    ////    /// TODO fill this out
    ////    /// </summary>
    ////    /// <param name="cronExpression">The expression that is to be parsed</param>
    ////    /// <param name="startTime">The start time that the expression would be initially trigger at</param>
    ////    /// <param name="amountOfDates">The amount of upcomming trigger dates to be returned (max 1000)</param>
    ////    /// <returns>A list of upcoming trigger dates</returns>
    ////    public static List<DateTime> ParseCronExpressionTriggerDates(string cronExpression, DateTime startTime, int amountOfDates)
    ////    {
    ////        var cron = cronExpression.Split(' ');
    ////        var time = new TimeSpan(int.Parse(cron[2]), int.Parse(cron[1]), int.Parse(cron[0]));
    ////        var dayOfTheMonth = cron[3];
    ////        var month = cron[4];
    ////        var daysOfWeek = cron[5];
    ////        var years = cron[6];

    ////        return new List<DateTime>();
    ////    }
    ////}
}
