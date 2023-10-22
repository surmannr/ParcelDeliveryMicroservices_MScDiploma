using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageSending.BL.Dto
{
    public class NewBillingDto
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public double TotalDistance { get; set; }
        public double TotalAmount { get; set; }
        public int CurrencyId { get; set; }
    }
}
