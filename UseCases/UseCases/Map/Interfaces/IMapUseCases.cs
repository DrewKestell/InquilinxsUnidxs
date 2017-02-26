namespace UseCases
{
    public interface IMapUseCases
    {
        IGetMap GetMap { get; }
        IUpdateGeolocation UpdateGeolocation { get; }
    }
}