using UseCases.Presenters;

namespace UseCases
{
    public interface IViewResidence
    {
        ResidencePresenter Execute(int residenceID);
    }
}