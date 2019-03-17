using System;
using System.Collections.Generic;

namespace CronEspresso.NETCore.Utils
{
    public class CronTriggerDates
    {
        public DateTime InitialTriggerTime { get; set; }
        public List<DateTime> TriggerDates { get; set; }
    }
}
