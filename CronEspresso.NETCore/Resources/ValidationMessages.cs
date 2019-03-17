namespace CronEspresso.NETCore.Resources
{
    public static class ValidationMessages
    {
        public static string EmptyString = "The cron expression entered was an empty string, please supply a string for validation";
        public static string InvalidCronFormat = "The cron expression entered is not in a correct cron format. The correct format is 6 (or 7 if you included the year values) values separated by a single space character (e.g. '* * * * ? *'). The value provided was '{0}'";
        public static string InvalidDayOfMonth = "The day of month value is invalid. Allowed values are '1 to 31 , - * ? / L W'. The value provided was '{0}'";
        public static string InvalidDayOfWeek = "The day of week value is invalid. Allowed values are '1 to 7 SUN to SAT , - * ? / L #'. The value provided was '{0}'";
        public static string InvalidHoursValue = "The hour value is invalid. Allowed values are '0 to 24 , - * /'. The value provided was '{0}'";
        public static string InvalidMinutesValue = "The minute value is invalid. Allowed values are '0 to 59 , - * /'. The value provided was '{0}'";
        public static string InvalidMonth = "The month value is invalid. Allowed values are '1 to 12 JAN to DEC , - * /'. The value provided was '{0}'";
        public static string InvalidSecondsValue = "The seconds value is invalid. Allowed values are '0 to 59 , - * /'. The value provided was '{0}'";
        public static string InvalidYear = "The year value is invalid. Allowed values are 'empty 1970-2099 , - * /'. The value provided was '{0}'";
        public static string ValidExpression = "The cron format provided '{0}' is a valid cron expression";
    }
}