using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeGen.Core.TypeAnnotations;

namespace Common.Dto
{
    [ExportTsInterface(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_dtos")]
    public class ShippingOptionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
