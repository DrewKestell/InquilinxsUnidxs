namespace UseCases
{
    public interface IBuildingUseCases
    {
        IGetBuildings GetBuildings { get; }
        INewBuilding NewBuilding { get; }
        IViewBuilding ViewBuilding { get; }
        IEditBuilding EditBuilding { get; }
        ICreateBuilding CreateBuilding { get; }
        IUpdateBuilding UpdateBuilding { get; }
        IDeleteBuilding DeleteBuilding { get; }
    }
}