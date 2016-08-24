using System;
using System.Collections.Generic;
using System.Web;

namespace InquilinxsUnidxs.Presenters
{
    public class PaginationPresenter<T> : IPaginationPresenter
    {
        public IEnumerable<T> Model { get; private set; }
        public int Page { get; private set; }
        public int PageSize { get; private set; }
        public int TotalRecords { get; private set; }    
        public int TotalPages { get; private set; }    

        public PaginationPresenter(List<T> model, int page, int pageSize, int totalRecords, int totalPages)
        {
            Model = model;
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

            return String.Format("{0}?{1}", uri.AbsolutePath, queryString.ToString());
        }
    }
}