using Common.Paging;
using TypeGen.Core.TypeAnnotations;

namespace Common.Filter
{
    [ExportTsClass(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_filters")]
    public abstract class BaseFilter<T> : PagingParameter
    {
        public string OrderBy { get; set; }
        public bool OrderAscending { get; set; } = true;
    }
}
