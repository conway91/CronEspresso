namespace CronEspresso.NETCore.Resources
{
    public static class ExceptionMessages
    {
        public static string DuplicateDaysException = "Only one of each day of the week value can be passed in";
        public static string InvalidAmountOfMonthsToRunAfterException = "Month to run on parameter must be between 1 and 12";
        public static string InvalidDayOfTheMonthException = "Day of the month parameter must be between 1 and 31";
        public static string InvalidDayOfTheWeekParameterException = "Day of the week parameter should be between 0-6";
        public static string InvalidFebruaryDateParameterException = "February can only have a maximum of 29 days";
        public static string InvalidHourParameterException = "Hours parameter must be between 1 and 23";
        public static string InvalidMinuteParameterException = "Minutes parameter must be between 1 and 59";
        public static string InvalidMonthParameterException = "Month Parameter must be between 1 and 12";
        public static string InvalidShorterMonthParameterException = "The given month cannot have more than 30 days";
    }
}