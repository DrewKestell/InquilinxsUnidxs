using DataAccess.Model;

namespace InquilinxsUnidxs.Presenters
{
    public class ResidenceCommentPresenter
    {
        public int ID { get; private set; }
        public string Comment { get; private set; }

        public ResidenceCommentPresenter(ResidenceComment residenceComment)
        {
            ID = residenceComment.ID;
            Comment = residenceComment.Comment;
        }
    }
}