

namespace Framework.Web.Models
{
    public class PaginationMetadata
    {
        public long? TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string PreviousePageLink { get; set; }
        public string NextPageLink { get; set; }
            
    }
}
