namespace CronEspresso.Utils
{
    internal static class StringValidators
    {
        internal static bool ValidateDayOfWeekStringValue(string value)
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

        internal static bool ValidateMonthStringValue(string value)
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
