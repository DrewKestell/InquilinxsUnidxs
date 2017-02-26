namespace UseCases
{
    public class BuildingUseCases : IBuildingUseCases
    {
        public IGetBuildings GetBuildings { get; }
        public INewBuilding NewBuilding { get; }
        public IViewBuilding ViewBuilding { get; }
        public IEditBuilding EditBuilding { get; }
        public ICreateBuilding CreateBuilding { get; }
        public IUpdateBuilding UpdateBuilding { get; }
        public IDeleteBuilding DeleteBuilding { get; }

        public BuildingUseCases(IGetBuildings getBuildings, INewBuilding newBuilding, IViewBuilding viewBuilding, IEditBuilding editBuilding,
            ICreateBuilding createBuilding, IUpdateBuilding updateBuilding, IDeleteBuilding deleteBuilding)
        {
            GetBuildings = getBuildings;
            NewBuilding = newBuilding;
            ViewBuilding = viewBuilding;
            EditBuilding = editBuilding;
            CreateBuilding = createBuilding;
            UpdateBuilding = updateBuilding;
            DeleteBuilding = deleteBuilding;
        }
    }
}