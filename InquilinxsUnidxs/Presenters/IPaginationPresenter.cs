using System;

namespace InquilinxsUnidxs.Presenters
{
    public interface IPaginationPresenter
    {
        int Page { get; }
        int PageSize { get; }
        int TotalRecords { get; }
        int TotalPages { get; }

        string Url(Uri uri, int page, int pageSize);
    }
}