using System;
using System.Collections.Generic;
using CronEspresso.NETCore.Utils;

namespace CronEspresso.NETCore
{
    public static class CronParser
    {
        public static string GetCronDescription(string cronExpression)
        {
            Validate(cronExpression);
            return "";
        }

        public static DateTime GetNextCronTriggerDate(string cronExpression)
        {
            Validate(cronExpression);
            return new DateTime();
        }
        
        public static DateTime GetNextCronTriggerDate(string cronExpression, DateTime startDate)
        {
            Validate(cronExpression);
            return new DateTime();
        }

        public static List<DateTime> GetFutureCronTriggerDates(string cronExpression, int futureDataCount = 5)
        {
            Validate(cronExpression);
            return new List<DateTime>();
        }
        
        public static List<DateTime> GetFutureCronTriggerDates(string cronExpression, DateTime startDate, int futureDataCount = 5)
        {
            Validate(cronExpression);
            return new List<DateTime>();
        }

        private static void Validate(string cronExpression)
        {
            var validateResult = CronHelpers.ValidateCron(cronExpression);
            if (!validateResult.IsValidCron)
                throw new ArgumentException(validateResult.ValidationMessage);
        }
    }
}