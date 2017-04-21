using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Model;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Repository
{
    public class UserRepository
    {
        public async Task<UserDTO> GetUser(int userId)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = await context.Users
               .Where(p => p.UserId == userId)
               .Select(q => new UserDTO
               {
                   UserId = q.UserId,
                   DocumentNo = q.DocumentNo,
                   FirstName = q.FirstName,
                   LastName = q.LastName,
                   Email = q.Email,
                   Address = q.Address,
                   PhoneNumber = q.PhoneNumber,
                   RoleId = q.RoleId,
                   RoleName = q.Role.Name,
                   IsActive = q.IsActive
               })
               .FirstOrDefaultAsync();

                return result;
            }
        }

        public async Task<UserDTO> InsertUser(UserRegistrationDTO user)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var newUser = new User
                {
                    UserId = -1,
                    DocumentNo = user.DocumentNo,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Address = user.Address,
                    PhoneNumber = user.PhoneNumber,
                    RoleId = 3,
                    IsActive = 1,
                    Password = HashPassword(user.Password)
                };

                 context.Users.Add(newUser);
                 context.SaveChanges();
                 return await GetUser(newUser.UserId);
            };
        }

        public async Task<UserDTO> UpdateUser(UserRegistrationDTO user)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var currentUser = context.Users.Find(user.UserId);
                currentUser.Address = user.Address;
                currentUser.PhoneNumber = user.PhoneNumber;
                if (!string.IsNullOrWhiteSpace(user.Password)) currentUser.Password = HashPassword(user.Password);
                context.SaveChanges();
                return await GetUser(currentUser.UserId);
            }
        }

        public async Task<UserDTO> LoginUser(UserLoginDTO user)
        {
            var password = HashPassword(user.Password);
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = await context.Users
                .Where(p => p.Email == user.Email && p.Password == user.Password)
                .Select(q => new UserDTO
                {
                    UserId = q.UserId,
                    DocumentNo = q.DocumentNo,
                    FirstName = q.FirstName,
                    LastName = q.LastName,
                    Email = q.Email,
                    Address = q.Address,
                    PhoneNumber = q.PhoneNumber,
                    RoleId = q.RoleId,
                    RoleName = q.Role.Name,
                    IsActive = q.IsActive
                })
                .FirstOrDefaultAsync();
                return result;
            }
        }

        private string HashPassword(string password)
        {
            SHA256Managed crypt = new SHA256Managed();
            string result = string.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password), 0, Encoding.ASCII.GetByteCount(password));
            foreach (byte theByte in crypto)
            {
                result += theByte.ToString("x2");
            }
            return result;
        }
    }
}