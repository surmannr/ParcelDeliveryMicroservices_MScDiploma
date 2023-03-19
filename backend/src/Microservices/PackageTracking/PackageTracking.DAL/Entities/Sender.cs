using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.DAL.Entities
{
    public class Sender
    {
        public string SenderUserId { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public string SenderNamePrefix { get; set; }
    }
}
