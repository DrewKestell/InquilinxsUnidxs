using UseCases.Presenters;

namespace UseCases
{
    public interface IEditResidence
    {
        ResidencePresenter Execute(int residenceID);
    }
}