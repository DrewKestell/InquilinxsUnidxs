using DataAccess.Context;
using DataAccess.DTO;
using DataAccess.FormObject;
using DataAccess.Model;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DataAccess.Service
{
    public class BuildingService : Service
    {
        protected List<State> GetStates()
        {
            using (var context = this.GetApplicationContext())
            {
                return context.States.ToList();
            }
        }

        protected List<Landlord> GetLandlords()
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Landlords.ToList();
            }
        }

        protected List<Neighborhood> GetNeighborhoods()
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Neighborhoods.ToList();
            }
        }

        protected PaginationDTO<Building> GetBuildings(int page, int pageSize)
        {
            using (var context = this.GetApplicationContext())
            {
                var model = context.Buildings
                    .Include("State")
                    .Include("Landlord")
                    .Include("Neighborhood")
                    .Include("Residences")
                    .Include("BuildingComments")
                    .OrderBy(b => b.State.Name)
                    .ThenBy(b => b.City)
                    .ThenBy(b => b.Address)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var totalRecords = context.Buildings.Count();
                var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize); // FIXME: this feels ugly

                return new PaginationDTO<Building>(model, totalRecords, totalPages);
            }
        }

        protected Building GetBuilding(int buildingID)
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Buildings
                    .Include("State")
                    .Include("Landlord")
                    .Include("Neighborhood")
                    .Include("Residences")
                    .Include("BuildingComments")
                    .Single(r => r.ID == buildingID);
            }
        }

        // TODO: share code with Update
        protected void Create(BuildingFormObject formObject, User currentUser)
        {
            using (var context = this.GetApplicationContext())
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
                context.Buildings.Add(newBuilding);

                UpdateBuildingComments(formObject, newBuilding, context, currentUser);

                context.SaveChanges();
            }
        }

        // TODO: share code with Create
        protected void Update(BuildingFormObject formObject, User currentUser)
        {
            using (var context = this.GetApplicationContext())
            {
                var building = context.Buildings.Single(r => r.ID == formObject.ID);
                building.Address = formObject.Address;
                building.City = formObject.City;
                building.ZIP = formObject.ZIP;
                building.StateID = formObject.StateID;
                building.LandlordID = formObject.LandlordID;
                building.NeighborhoodID = formObject.NeighborhoodID;

                UpdateBuildingComments(formObject, building, context, currentUser);

                context.SaveChanges();
            }
        }

        private void UpdateBuildingComments(BuildingFormObject formObject, Building building, ApplicationContext context, User currentUser)
        {
            var existingCommentIds = building.BuildingComments.Select(b => b.ID);
            var postedCommentIds = formObject.BuildingComments.Select(b => b.ID);
            var commentsToRemove = building.BuildingComments.Where(b => !postedCommentIds.Contains(b.ID));

            context.BuildingComments.RemoveRange(commentsToRemove);

            foreach (var comment in formObject.BuildingComments)
            {
                BuildingComment buildingComment;
                if (comment.ID == 0)
                {
                    buildingComment = new BuildingComment
                    {
                        DateCreated = DateTime.Now
                    };
                    building.BuildingComments.Add(buildingComment);
                }
                else
                    buildingComment = building.BuildingComments.Single(c => c.ID == comment.ID);

                buildingComment.Comment = comment.Comment;
                buildingComment.LastUpdated = DateTime.Now;
                buildingComment.UserID = currentUser.ID;
            }
        }

        protected void Delete(int buildingID)
        {
            using (var context = this.GetApplicationContext())
            {
                var building = context.Buildings.Single(r => r.ID == buildingID);
                context.Buildings.Remove(building);
                context.SaveChanges();
            }
        }

        protected void UploadFile(HttpPostedFileBase file)
        {
            using (var context = this.GetApplicationContext())
            {
                var connectionString = ConfigurationManager.AppSettings["StorageConnectionString"];
                var storageAccount = CloudStorageAccount.Parse(connectionString);
                var blobClient = storageAccount.CreateCloudBlobClient();
                var blobContainer = blobClient.GetContainerReference("inquilinxsunidxs");
                var blockBlob = blobContainer.GetBlockBlobReference("testblob");

                blockBlob.UploadFromStream(file.InputStream);
            }
        }
    }
}