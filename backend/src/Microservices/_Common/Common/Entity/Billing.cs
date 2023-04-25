using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class Billing
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public double TotalDistance { get; set; }
        public double TotalAmount { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public ShippingRequest ShippingRequest { get; set; }
    }
}
