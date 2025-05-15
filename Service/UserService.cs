using Task_Management.Models;
namespace Task_Management.Service
{
    public class UserService
    {
        private readonly List<User> _users = new();
        public User Register(User user) {
            user.Id = _users.Count + 1;
            _users.Add(user);
            return user;
        }
        public User Authenticate(string username, string password) => _users.FirstOrDefault(u=>u.UserName == username && u.Password == password);
    }
}
