﻿using System;
using System.Collections.Generic;

namespace CronEspresso.NETCore.Resources
{
    public class CronTriggerDates
    {
        public DateTime InitialTriggerTime { get; set; }
        public List<DateTime> TriggerDates { get; set; }
    }
}