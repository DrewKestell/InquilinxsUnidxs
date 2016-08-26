using DataAccess.Model;

namespace InquilinxsUnidxs.Presenters
{
    public class BuildingCommentPresenter
    {
        public int ID { get; private set; }
        public string Comment { get; private set; }

        public BuildingCommentPresenter(BuildingComment buildingComment)
        {
            ID = buildingComment.ID;
            Comment = buildingComment.Comment;
        }
    }
}