namespace CronEspresso.Utils
{
    public class CronValidationResults
    {
        public CronValidationResults(bool isCronValid, string validationMessage)
        {
            IsValidCron = isCronValid;
            ValidationMessage = validationMessage;
        }

        public bool IsValidCron { get; set; }
        public string ValidationMessage { get; set; }
    }
}
