using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Repository;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Services
{
    
    public class UserService : IUserService
    {

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

        public ResponseDTO ValidateUserEmail(string email)
        {
            var userRepository = new UserRepository();
            var userInDB= userRepository.GetUserByEmail(email);
            if (userInDB != null) {
                return new ResponseDTO()
                {
                    Status = 0,
                    Message = "El email ya esta siendo utilizado"
                };
            }

            return new ResponseDTO()
            {
                Status = 1,
                Message = "Email disponible"
            };
        }

    }
}
