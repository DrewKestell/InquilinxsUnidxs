using Autofac;
using Autofac.Integration.Mvc;
using DataAccess.Context;
using Services;
using UseCases;

namespace InquilinxsUnidxs.App_Start
{
    public class DIConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // MVC
            builder.RegisterControllers(ThisAssembly).InstancePerDependency().PropertiesAutowired();
            builder.RegisterModelBinders(ThisAssembly);
            builder.RegisterModelBinderProvider();
            builder.RegisterFilterProvider();

            // Data Access
            builder.RegisterType<ApplicationContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterGeneric(typeof(GenericRepository<>)).AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterType<SuperTupleService>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<AuthenticationService>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<BuildingService>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<FileService>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<LandlordService>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<MapService>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<NeighborhoodAssociationService>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<NeighborhoodService>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<PropertyManagementCompanyService>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<RenterService>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<ResidenceService>().AsImplementedInterfaces().InstancePerRequest();

            // UseCase Containers
            builder.RegisterType<AuthenticationUseCases>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<BuildingUseCases>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<FileUseCases>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<LandlordUseCases>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<MapUseCases>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<NeighborhoodAssociationUseCases>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<NeighborhoodUseCases>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<PropertyManagementCompanyUseCases>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<RenterUseCases>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<ResidenceUseCases>().AsImplementedInterfaces().InstancePerRequest();

            // Authentication UseCases
            builder.RegisterType<Authenticate>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<Register>().AsImplementedInterfaces().InstancePerRequest();

            // Building UseCases
            builder.RegisterType<CreateBuilding>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<DeleteBuilding>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<EditBuilding>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<GetBuildings>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<NewBuilding>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<UpdateBuilding>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<ViewBuilding>().AsImplementedInterfaces().InstancePerRequest();

            // File UseCases
            builder.RegisterType<GetFileUrl>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<UploadFile>().AsImplementedInterfaces().InstancePerRequest();

            // Landlord UseCases
            builder.RegisterType<CreateLandlord>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<DeleteLandlord>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<EditLandlord>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<GetLandlords>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<NewLandlord>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<UpdateLandlord>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<ViewLandlord>().AsImplementedInterfaces().InstancePerRequest();

            // Map UseCases
            builder.RegisterType<GetMap>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<UpdateGeolocation>().AsImplementedInterfaces().InstancePerRequest();

            // NeighborhoodAssociation UseCases
            builder.RegisterType<GetNeighborhoodAssociations>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<NewNeighborhoodAssociation>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<ViewNeighborhoodAssociation>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<EditNeighborhoodAssociation>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<CreateNeighborhoodAssociation>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<UpdateNeighborhoodAssociation>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<DeleteNeighborhoodAssociation>().AsImplementedInterfaces().InstancePerRequest();

            // Neighborhood UseCases
            builder.RegisterType<CreateNeighborhood>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<DeleteNeighborhood>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<EditNeighborhood>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<GetNeighborhoods>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<NewNeighborhood>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<UpdateNeighborhood>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<ViewNeighborhood>().AsImplementedInterfaces().InstancePerRequest();

            // Property Management Company UseCases
            builder.RegisterType<CreatePropertyManagementCompany>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<DeletePropertyManagementCompany>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<EditPropertyManagementCompany>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<GetPropertyManagementCompanies>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<NewPropertyManagementCompany>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<ViewPropertyManagementCompany>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<UpdatePropertyManagementCompany>().AsImplementedInterfaces().InstancePerRequest();

            // Renter UseCases
            builder.RegisterType<CreateRenter>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<DeleteRenter>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<EditRenter>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<GetRenterExport>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<GetRenters>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<NewRenter>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<UpdateRenter>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<ViewRenter>().AsImplementedInterfaces().InstancePerRequest();

            // Residence UseCases
            builder.RegisterType<CreateResidence>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<DeleteResidence>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<EditResidence>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<GetResidences>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<NewResidence>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<UpdateResidence>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<ViewResidence>().AsImplementedInterfaces().InstancePerRequest();
        }
    }
}