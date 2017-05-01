using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Repository;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Services
{
    
    public class UserService : IUserService
    {

        public UserDTO GetUserInformation(int userId)
        {
            var userRepository = new UserRepository();
            return userRepository.GetUser(userId);
        }

        public UserDTO InsertUserInformation(UserRegistrationDTO user)
        {
            var userRepository = new UserRepository();
            var userId = userRepository.InsertUser(user);
            return userRepository.GetUser(userId);
        }

        public UserDTO UpdateUserInformation(UserRegistrationDTO user)
        {
            var userRepository = new UserRepository();
            var userId = userRepository.UpdateUser(user);
            return userRepository.GetUser(userId);
        }

        public UserDTO LoginUserInformation(UserLoginDTO user)
        {
            var userRepository = new UserRepository();
            return userRepository.LoginUser(user);
        }


    }
}
