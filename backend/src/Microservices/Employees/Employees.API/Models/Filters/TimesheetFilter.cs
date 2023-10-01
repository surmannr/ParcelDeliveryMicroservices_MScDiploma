using Common.Filter;
using TypeGen.Core.TypeAnnotations;

namespace Employees.API.Models.Filters
{
    [ExportTsClass(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_filters")]
    public class TimesheetFilter : SqlBaseFilter<Timesheet>
    {
        public string UserId { get; set; }
        public DateTime? MinDateFrom { get; set; }
        public DateTime? MaxDateFrom { get; set; }
        public DateTime? MinDateTo { get; set; }
        public DateTime? MaxDateTo { get; set; }
        public string Day { get; set; }
        public string Note { get; set; }

        public override IQueryable<Timesheet> ExecuteFiltering(IQueryable<Timesheet> toFilter)
        {
            var query = toFilter.AsQueryable();

            query = !string.IsNullOrEmpty(UserId) ? query.Where(a => a.UserId.Contains(UserId)) : query;
            query = !string.IsNullOrEmpty(Note) ? query.Where(a => a.Note.Contains(Note)) : query;
            query = !string.IsNullOrEmpty(Day) ? query.Where(a => a.Days.Contains(Day)) : query;

            query = MinDateFrom != null ? query.Where(a => a.DateFrom >= MinDateFrom) : query;
            query = MaxDateFrom != null ? query.Where(a => a.DateFrom <= MaxDateFrom) : query;

            query = MinDateTo != null ? query.Where(a => a.DateTo >= MinDateTo) : query;
            query = MaxDateTo != null ? query.Where(a => a.DateTo <= MaxDateTo) : query;

            return query;
        }
    }
}
