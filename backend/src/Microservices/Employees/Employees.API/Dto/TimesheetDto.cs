using Employees.API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using TypeGen.Core.TypeAnnotations;

namespace Employees.API.Dto
{
    [ExportTsInterface(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_dtos")]
    public class TimesheetDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int[] Days { get; set; }
        public string Note { get; set; }
    }
}
