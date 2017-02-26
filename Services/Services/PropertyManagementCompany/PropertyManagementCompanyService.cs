using DataAccess.Context;
using DataAccess.FormObject;
using DataAccess.Model;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class PropertyManagementCompanyService : IPropertyManagementCompanyService
    {
        readonly IGenericRepository<PropertyManagementCompany> companyRepository;
        readonly IGenericRepository<PropertyManagementCompanyComment> commentRepository;
        readonly IUnitOfWork unitOfWork;

        public PropertyManagementCompanyService(IGenericRepository<PropertyManagementCompany> companyRepository,
            IGenericRepository<PropertyManagementCompanyComment> commentRepository, IUnitOfWork unitOfWork)
        {
            this.companyRepository = companyRepository;
            this.commentRepository = commentRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<PropertyManagementCompanyDTO> GetPropertyManagementCompanies() =>
            companyRepository.Get().ToList().Select(a => new PropertyManagementCompanyDTO(a));

        public PropertyManagementCompanyDTO GetPropertyManagementCompany(int propertyManagementCompanyID) =>
            new PropertyManagementCompanyDTO(companyRepository.Single(r => r.ID == propertyManagementCompanyID));

        // TODO: share code with Update
        public void Create(PropertyManagementCompanyFormObject formObject, int userID)
        {
            var propertyManagementCompany = new PropertyManagementCompany
            {
                Name = formObject.Name,
                Address = formObject.Address,
                City = formObject.City,
                ZIP = formObject.ZIP,
                StateID = formObject.StateID
            };
            companyRepository.Add(propertyManagementCompany);

            UpdateComments(formObject, propertyManagementCompany, userID);

            unitOfWork.Save();
        }

        // TODO: share code with Create
        public void Update(PropertyManagementCompanyFormObject formObject, int userID)
        {
            var propertyManagementCompany = companyRepository.Single(r => r.ID == formObject.ID);

            UpdateComments(formObject, propertyManagementCompany, userID);

            unitOfWork.Save();
        }

        public void Delete(int propertyManagementCompanyID)
        {
            companyRepository.Remove(companyRepository.Single(r => r.ID == propertyManagementCompanyID));
            unitOfWork.Save();
        }

        void UpdateComments(PropertyManagementCompanyFormObject formObject, PropertyManagementCompany company, int userID)
        {
            var existingCommentIds = company.Comments.Select(b => b.ID);
            var postedCommentIds = formObject.Comments.Select(b => b.ID);
            var commentsToRemove = company.Comments.Where(b => !postedCommentIds.Contains(b.ID));

            commentRepository.RemoveRange(commentsToRemove);

            foreach (var comment in formObject.Comments)
            {
                PropertyManagementCompanyComment commentToUpdate;
                if (comment.ID == 0)
                {
                    commentToUpdate = new PropertyManagementCompanyComment
                    {
                        DateCreated = DateTime.Now,
                        CreatedByID = userID
                    };
                    company.Comments.Add(commentToUpdate);
                }
                else
                    commentToUpdate = company.Comments.Single(c => c.ID == comment.ID);

                if (commentToUpdate.Value != comment.Value)
                {
                    commentToUpdate.Value = comment.Value;
                    commentToUpdate.LastUpdated = DateTime.Now;
                    commentToUpdate.LastUpdatedByID = userID;
                }
            }
        }
    }
}