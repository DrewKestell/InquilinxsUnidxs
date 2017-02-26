using DataAccess.Context;
using DataAccess.FormObject;
using DataAccess.Model;
using Services.DTO;
using System;
using System.Linq;

namespace Services
{
    public class BuildingService : IBuildingService
    {
        readonly IGenericRepository<Building> buildingRepository;
        readonly IGenericRepository<BuildingComment> buildingCommentRepository;
        readonly IUnitOfWork unitOfWork;

        public BuildingService(IGenericRepository<Building> buildingRepository, IGenericRepository<BuildingComment> buildingCommentRepository, 
            IUnitOfWork unitOfWork)
        {
            this.buildingRepository = buildingRepository;
            this.buildingCommentRepository = buildingCommentRepository;
            this.unitOfWork = unitOfWork;
        }

        public PaginationDTO<BuildingDTO> GetBuildings(int page, int pageSize)
        {
            var model = buildingRepository
                .Get(b => b.State, b => b.Landlord, b => b.Neighborhood, b => b.Residences, b => b.BuildingComments)
                .OrderBy(b => b.State.Name)
                .ThenBy(b => b.City)
                .ThenBy(b => b.Address)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList()
                .Select(b => new BuildingDTO(b));

            var totalRecords = buildingRepository.Get().Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize); // FIXME: this feels ugly

            return new PaginationDTO<BuildingDTO>(model, totalRecords, totalPages);
        }

        public BuildingDTO GetBuilding(int buildingID) =>
            new BuildingDTO(buildingRepository
                .Get(b => b.State, b => b.Landlord, b => b.Neighborhood, b => b.Residences, b => b.BuildingComments)
                .Single(r => r.ID == buildingID));

        // TODO: share code with Update
        public void Create(BuildingFormObject formObject, int userID)
        {
            var newBuilding = new Building
            {
                Latitude = 0, // handled by Google Geocoding API on front end
                Longitude = 0, // handled by Google Geocoding API on front end
                Address = formObject.Address,
                City = formObject.City,
                ZIP = formObject.ZIP,
                StateID = formObject.StateID,
                LandlordID = formObject.LandlordID,
                NeighborhoodID = formObject.NeighborhoodID
            };
            buildingRepository.Add(newBuilding);

            UpdateBuildingComments(formObject, newBuilding, userID);

            unitOfWork.Save();
        }

        // TODO: share code with Create
        public void Update(BuildingFormObject formObject, int userID)
        {
            var building = buildingRepository.Single(r => r.ID == formObject.ID);
            building.Address = formObject.Address;
            building.City = formObject.City;
            building.ZIP = formObject.ZIP;
            building.StateID = formObject.StateID;
            building.LandlordID = formObject.LandlordID;
            building.NeighborhoodID = formObject.NeighborhoodID;

            UpdateBuildingComments(formObject, building, userID);

            unitOfWork.Save();
        }

        public void Delete(int buildingID)
        {
            buildingRepository.Remove(buildingRepository.Single(r => r.ID == buildingID));
            unitOfWork.Save();
        }

        void UpdateBuildingComments(BuildingFormObject formObject, Building building, int userID)
        {
            var existingCommentIds = building.BuildingComments.Select(b => b.ID);
            var postedCommentIds = formObject.BuildingComments.Select(b => b.ID);
            var commentsToRemove = building.BuildingComments.Where(b => !postedCommentIds.Contains(b.ID));

            buildingCommentRepository.RemoveRange(commentsToRemove);

            foreach (var comment in formObject.BuildingComments)
            {
                BuildingComment buildingComment;
                if (comment.ID == 0)
                {
                    buildingComment = new BuildingComment
                    {
                        DateCreated = DateTime.Now,
                        CreatedByID = userID
                    };
                    building.BuildingComments.Add(buildingComment);
                }
                else
                    buildingComment = building.BuildingComments.Single(c => c.ID == comment.ID);

                if (buildingComment.Value != comment.Value)
                {
                    buildingComment.Value = comment.Value;
                    buildingComment.LastUpdated = DateTime.Now;
                    buildingComment.LastUpdatedByID = userID;
                }  
            }
        }
    }
}