using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.EventObjects
{
    public class TimesheetEO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Days { get; set; }
    }
}
