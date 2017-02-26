using DataAccess.Model;

namespace Services.DTO
{
    public class BuildingCommentDTO : CommentDTO
    {
        public BuildingDTO Building { get; }

        public BuildingCommentDTO(BuildingComment buildingComment) : base(buildingComment)
        {
            Building = new BuildingDTO(buildingComment.Building);
        }
    }
}