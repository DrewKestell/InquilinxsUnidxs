namespace UseCases
{
    public interface IResidenceUseCases
    {
        ICreateResidence CreateResidence { get; }
        IDeleteResidence DeleteResidence { get; }
        IEditResidence EditResidence { get; }
        IGetResidences GetResidences { get; }
        INewResidence NewResidence { get; }
        IUpdateResidence UpdateResidence { get; }
        IViewResidence ViewResidence { get; }
    }
}