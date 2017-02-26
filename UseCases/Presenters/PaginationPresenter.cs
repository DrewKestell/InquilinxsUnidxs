using System.Collections.Generic;

namespace UseCases.Presenters
{
    public class PaginationPresenter<T>
    {
        public IEnumerable<T> Model { get; }
        public PaginationInfo PaginationInfo { get; }

        public PaginationPresenter(IEnumerable<T> model, PaginationInfo paginationInfo)
        {
            Model = model;
            PaginationInfo = paginationInfo;
        }
    }
}