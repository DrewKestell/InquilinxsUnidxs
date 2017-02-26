using System;
using System.Web;

namespace UseCases.Presenters
{
    public class PaginationInfo
    {
        public int Page { get; }
        public int PageSize { get; }
        public int TotalRecords { get; }
        public int TotalPages { get; }

        public PaginationInfo(int page, int pageSize, int totalRecords, int totalPages)
        {
            Page = page;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            TotalPages = totalPages;
        }

        public string Url(Uri uri, int page, int pageSize)
        {
            var queryString = HttpUtility.ParseQueryString(uri.Query);
            queryString["pageSize"] = pageSize.ToString();
            queryString["page"] = page.ToString();

            return string.Format("{0}?{1}", uri.AbsolutePath, queryString.ToString());
        }
    }
}