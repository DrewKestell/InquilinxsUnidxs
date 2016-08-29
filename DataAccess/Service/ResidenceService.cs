using DataAccess.Context;
using DataAccess.DTO;
using DataAccess.FormObject;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Service
{
    public class ResidenceService : Service
    {
        protected List<Building> GetBuildings()
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Buildings
                    .Include("State")
                    .ToList();
            }
        }

        protected PaginationDTO<Residence> GetResidences(int page, int pageSize)
        {
            using (var context = this.GetApplicationContext())
            {
                var model = context.Residences
                    .Include("Building.State")
                    .Include("Renters")
                    .Include("ResidenceComments")
                    .OrderBy(r => r.Building.Address)
                    .ThenBy(r => r.Name)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var totalRecords = context.Residences.Count();
                var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize); // FIXME: this feels ugly

                return new PaginationDTO<Residence>(model, totalRecords, totalPages);
            }
        }

        protected Residence GetResidence(int residenceID)
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Residences
                    .Include("Building.State")
                    .Include("Renters")
                    .Include("ResidenceComments")
                    .Single(r => r.ID == residenceID);
            }
        }

        // TODO: share code with Update
        protected void Create(ResidenceFormObject formObject, User currentUser)
        {
            using (var context = this.GetApplicationContext())
            {
                var newResidence = new Residence
                {
                    Name = formObject.Name,
                    BuildingID = formObject.BuildingID
                };
                context.Residences.Add(newResidence);

                UpdateResidenceComments(formObject, newResidence, context, currentUser);

                context.SaveChanges();
            }
        }

        // TODO: share code with Create
        protected void Update(ResidenceFormObject formObject, User currentUser)
        {
            using (var context = this.GetApplicationContext())
            {
                var residence = context.Residences.Single(r => r.ID == formObject.ID);
                residence.Name = formObject.Name;
                residence.BuildingID = formObject.BuildingID;

                UpdateResidenceComments(formObject, residence, context, currentUser);

                context.SaveChanges();
            }
        }

        private void UpdateResidenceComments(ResidenceFormObject formObject, Residence residence, ApplicationContext context, User currentUser)
        {
            var existingCommentIds = residence.ResidenceComments.Select(b => b.ID);
            var postedCommentIds = formObject.ResidenceComments.Select(b => b.ID);
            var commentsToRemove = residence.ResidenceComments.Where(b => !postedCommentIds.Contains(b.ID));

            context.ResidenceComments.RemoveRange(commentsToRemove);

            foreach (var comment in formObject.ResidenceComments)
            {
                ResidenceComment residenceComment;
                if (comment.ID == 0)
                {
                    residenceComment = new ResidenceComment
                    {
                        DateCreated = DateTime.Now
                    };
                    residence.ResidenceComments.Add(residenceComment);
                }
                else
                    residenceComment = residence.ResidenceComments.Single(c => c.ID == comment.ID);

                residenceComment.Comment = comment.Comment;
                residenceComment.LastUpdated = DateTime.Now;
                residenceComment.UserID = currentUser.ID;
            }
        }

        protected void Delete(int residenceID)
        {
            using (var context = this.GetApplicationContext())
            {
                var residence = context.Residences.Single(r => r.ID == residenceID);
                context.Residences.Remove(residence);
                context.SaveChanges();
            }
        }
    }
}