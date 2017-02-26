using DataAccess.Model;

namespace Services.DTO
{
    public class UserDTO
    {
        public int ID { get; }
        public string UserName { get; }
        public string Email { get; }

        public UserDTO(User user)
        {
            ID = user.ID;
            UserName = user.Username;
            Email = user.Email;
        }
    }
}