namespace UseCases.Presenters
{
    public class RenterIndexPresenter
    {
        public PaginationPresenter<RenterPresenter> PaginationPresenter { get; }
        public string Filter { get; }

        public RenterIndexPresenter(PaginationPresenter<RenterPresenter> paginationPresenter, string filter)
        {
            PaginationPresenter = paginationPresenter;
            Filter = filter;
        }
    }
}