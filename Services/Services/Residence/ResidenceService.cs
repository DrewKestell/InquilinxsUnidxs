using DataAccess.Context;
using DataAccess.FormObject;
using DataAccess.Model;
using Services.DTO;
using System;
using System.Linq;

namespace Services
{
    public class ResidenceService : IResidenceService
    {
        readonly IGenericRepository<Residence> residenceRepository;
        readonly IGenericRepository<ResidenceComment> residenceCommentRepository;
        readonly IUnitOfWork unitOfWork;

        public ResidenceService(IGenericRepository<Residence> residenceRepository, 
            IGenericRepository<ResidenceComment> residenceCommentRepository, IUnitOfWork unitOfWork)
        {
            this.residenceRepository = residenceRepository;
            this.residenceCommentRepository = residenceCommentRepository;
            this.unitOfWork = unitOfWork;
        }
        
        public PaginationDTO<ResidenceDTO> GetResidences(int page, int pageSize)
        {
            var model = residenceRepository
                .Get(r => r.Building.State, r => r.Renters, r => r.ResidenceComments)
                .OrderBy(r => r.Building.Address)
                .ThenBy(r => r.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList()
                .Select(r => new ResidenceDTO(r));

            var totalRecords = residenceRepository.Get().Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize); // FIXME: this feels ugly

            return new PaginationDTO<ResidenceDTO>(model, totalRecords, totalPages);
        }

        public ResidenceDTO GetResidence(int residenceID) =>
            new ResidenceDTO(residenceRepository
                .Get(r => r.Building.State, r => r.Renters, r => r.ResidenceComments)
                .Single(r => r.ID == residenceID));

        // TODO: share code with Update
        public void Create(ResidenceFormObject formObject, int userID)
        {
            var newResidence = new Residence
            {
                Name = formObject.Name,
                BuildingID = formObject.BuildingID
            };
            residenceRepository.Add(newResidence);

            UpdateResidenceComments(formObject, newResidence, userID);

            unitOfWork.Save();
        }

        // TODO: share code with Create
        public void Update(ResidenceFormObject formObject, int userID)
        {
            var residence = residenceRepository.Single(r => r.ID == formObject.ID);
            residence.Name = formObject.Name;
            residence.BuildingID = formObject.BuildingID;

            UpdateResidenceComments(formObject, residence, userID);

            unitOfWork.Save();
        }

        public void Delete(int residenceID)
        {
            residenceRepository.Remove(residenceRepository.Single(r => r.ID == residenceID));
            unitOfWork.Save();
        }

        void UpdateResidenceComments(ResidenceFormObject formObject, Residence residence, int userID)
        {
            var existingCommentIds = residence.ResidenceComments.Select(b => b.ID);
            var postedCommentIds = formObject.ResidenceComments.Select(b => b.ID);
            var commentsToRemove = residence.ResidenceComments.Where(b => !postedCommentIds.Contains(b.ID));

            residenceCommentRepository.RemoveRange(commentsToRemove);

            foreach (var comment in formObject.ResidenceComments)
            {
                ResidenceComment residenceComment;
                if (comment.ID == 0)
                {
                    residenceComment = new ResidenceComment
                    {
                        DateCreated = DateTime.Now,
                        CreatedByID = userID
                    };
                    residence.ResidenceComments.Add(residenceComment);
                }
                else
                    residenceComment = residence.ResidenceComments.Single(c => c.ID == comment.ID);

                if (residenceComment.Value != comment.Value)
                {
                    residenceComment.Value = comment.Value;
                    residenceComment.LastUpdated = DateTime.Now;
                    residenceComment.LastUpdatedByID = userID;
                }  
            }
        } 
    }
}