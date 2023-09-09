using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.EventObjects
{
    public class EmployeeEO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NamePrefix { get; set; }
        public DateTime BirthDate { get; set; }
        public AddressEO Address { get; set; }

        public ICollection<TimesheetEO> Timesheets { get; set; }
    }
}
