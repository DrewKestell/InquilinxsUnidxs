using DataAccess.Model;
using System;

namespace Services.DTO
{
    public abstract class CommentDTO
    {
        public int ID { get; }
        public DateTime DateCreated { get; }
        public DateTime LastUpdated { get; }
        public string Value { get; }
        public UserDTO CreatedBy { get; }
        public UserDTO LastUpdatedBy { get; }

        public CommentDTO(Comment comment)
        {
            ID = comment.ID;
            DateCreated = comment.DateCreated;
            LastUpdated = comment.LastUpdated;
            Value = comment.Value;
            CreatedBy = new UserDTO(comment.CreatedBy);
            LastUpdatedBy = new UserDTO(comment.LastUpdatedBy);
        }
    }
}