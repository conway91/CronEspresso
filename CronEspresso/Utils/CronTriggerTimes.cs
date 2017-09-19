using System;
using System.Collections.Generic;

namespace CronEspresso.Utils
{
    public class CronTriggerDates
    {
        public DateTime InitialTriggerTime { get; set; }
        public List<DateTime> TriggerDates { get; set; }
    }
}
