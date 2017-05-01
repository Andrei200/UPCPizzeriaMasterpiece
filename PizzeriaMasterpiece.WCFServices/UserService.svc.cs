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
            return userRepository.InsertUser(user);
        }

        public UserDTO UpdateUserInformation(UserRegistrationDTO user)
        {
            var userRepository = new UserRepository();
            return userRepository.UpdateUser(user);
        }

        public UserDTO LoginUserInformation(UserLoginDTO user)
        {
            var userRepository = new UserRepository();
            return userRepository.LoginUser(user);
        }


    }
}
