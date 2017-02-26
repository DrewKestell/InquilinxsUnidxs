namespace UseCases
{
    public class ResidenceUseCases : IResidenceUseCases
    {
        public ICreateResidence CreateResidence { get; }
        public IDeleteResidence DeleteResidence { get; }
        public IEditResidence EditResidence { get; }
        public IGetResidences GetResidences { get; }
        public INewResidence NewResidence { get; }
        public IUpdateResidence UpdateResidence { get; }
        public IViewResidence ViewResidence { get; }

        public ResidenceUseCases(ICreateResidence createResidence, IDeleteResidence deleteResidence, IEditResidence editResidence,
            IGetResidences getResidences, INewResidence newResidence, IUpdateResidence updateResidence,
            IViewResidence viewResidence)
        {
            CreateResidence = createResidence;
            DeleteResidence = deleteResidence;
            EditResidence = editResidence;
            GetResidences = getResidences;
            NewResidence = newResidence;
            UpdateResidence = updateResidence;
            ViewResidence = viewResidence;
        }
    }
}