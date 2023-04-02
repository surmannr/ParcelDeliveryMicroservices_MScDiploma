using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.EventObjects
{
    public class BillingEO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public double TotalDistance { get; set; }
        public double TotalAmount { get; set; }

        public CurrencyEO Currency { get; set; }
    }
}
