using Employees.API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.API.Dto
{
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
