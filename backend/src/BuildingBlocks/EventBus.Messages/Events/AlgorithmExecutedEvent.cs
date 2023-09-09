using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class AlgorithmExecutedEvent : IntegrationBaseEvent
    {
        public int NumberOfDriversNeed { get; set; }
        public int DayNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
