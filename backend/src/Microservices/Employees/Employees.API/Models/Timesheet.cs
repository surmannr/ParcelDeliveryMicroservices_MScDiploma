using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using TypeGen.Core.TypeAnnotations;

namespace Employees.API.Models
{
    [ExportTsInterface(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_models")]
    public class Timesheet
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Days { get; set; }
        [NotMapped]
        public int[] DaysArray
        {
            get
            {
                if (string.IsNullOrEmpty(Days))
                {
                    return new int[] { } ;
                }
                return Array.ConvertAll(Days.Split(';') ?? new string[0], int.Parse);
            }
            set
            {
                Days = String.Join(";", value.Select(p => p.ToString() ?? "").ToArray()) ?? "";
            }
        }
        public string Note { get; set; }

        [TsIgnore]
        public Employee User { get; set; }
    }
}
