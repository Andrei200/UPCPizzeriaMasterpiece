using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Repository;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Services
{
    
    public class UserService : IUserService
    {

        public async Task<UserDTO> GetUserInformation(int userId)
        {
            var userRepository = new UserRepository();
            return await userRepository.GetUser(userId);
        }

        public async Task<UserDTO> InsertUserInformation(UserRegistrationDTO user)
        {
            var userRepository = new UserRepository();
            return await userRepository.InsertUser(user);
        }

        public async Task<UserDTO> UpdateUserInformation(UserRegistrationDTO user)
        {
            var userRepository = new UserRepository();
            return await userRepository.UpdateUser(user);
        }

        public async Task<UserDTO> LoginUserInformation(UserLoginDTO user)
        {
            var userRepository = new UserRepository();
            return await userRepository.LoginUser(user);
        }


    }
}
