using DataAccess.Model;

namespace Services.DTO
{
    public class ResidenceCommentDTO : CommentDTO
    {
        public ResidenceDTO Residence { get; }

        public ResidenceCommentDTO(ResidenceComment residenceComment) : base(residenceComment)
        {
            Residence = new ResidenceDTO(residenceComment.Residence);
        }
    }
}