using Common.Paging;

namespace Common.Filter
{
    public abstract class BaseFilter<T> : PagingParameter
    {
        public string OrderBy { get; set; }
        public bool OrderAscending { get; set; } = true;
    }
}
