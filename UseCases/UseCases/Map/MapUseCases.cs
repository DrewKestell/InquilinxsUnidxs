namespace UseCases
{
    public class MapUseCases : IMapUseCases
    {
        public IGetMap GetMap { get; }
        public IUpdateGeolocation UpdateGeolocation { get; }

        public MapUseCases(IGetMap getMap, IUpdateGeolocation updateGeolocation)
        {
            GetMap = getMap;
            UpdateGeolocation = updateGeolocation;
        }
    }
}