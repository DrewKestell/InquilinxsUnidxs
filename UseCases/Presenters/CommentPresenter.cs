using Services.DTO;

namespace UseCases.Presenters
{
    public class CommentPresenter
    {
        public int ID { get; }
        public string Value { get; }
        public string DateUpdated { get; }
        public string TimeUpdated { get; }
        public string CreatedBy { get; }
        public string LastUpdatedBy { get; }

        public CommentPresenter(CommentDTO comment)
        {
            ID = comment.ID;
            Value = comment.Value;
            DateUpdated = comment.LastUpdated.ToShortDateString();
            TimeUpdated = comment.LastUpdated.ToShortTimeString();
            CreatedBy = comment.CreatedBy.UserName;
            LastUpdatedBy = comment.LastUpdatedBy.UserName;
        }
    }
}