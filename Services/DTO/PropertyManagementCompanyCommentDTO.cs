using DataAccess.Model;

namespace Services.DTO
{
    public class PropertyManagementCompanyCommentDTO : CommentDTO
    {
        public PropertyManagementCompanyDTO PropertyManagementCompany { get; }

        public PropertyManagementCompanyCommentDTO(PropertyManagementCompanyComment comment) : base(comment)
        {
            PropertyManagementCompany = new PropertyManagementCompanyDTO(comment.PropertyManagementCompany);
        }
    }
}