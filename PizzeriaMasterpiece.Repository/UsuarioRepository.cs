using PizzeriaMasterpiece.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Repository
{
    public class UsuarioRepository
    {

        public async Task<UsuarioDTO> GetUserInformation(int userId){
            using (var context = new PizzeriaMasterpieceEntities()){

                var result =  await context.Usuarios
               .Where(p => p.IdUsuario == userId)
               .Select(q => new UsuarioDTO
               {
                   IdUsuario = q.IdUsuario,
                   DNI = q.DNI,
                   Apellido = q.Apellido,
                   Correo = q.Correo,
                   Nombre = q.Nombre,
                   Direccion = q.Direccion,
                   Telefono = q.Telefono
               })
               .FirstOrDefaultAsync();

                return result;

            }
        }

        public async Task<UsuarioDTO> InsertUserInformation(UsuarioRegistroDTO usuario)
        {           
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var user = new Usuario();
                user.IdUsuario =-1;
                user.Nombre = usuario.Nombre;
                user.Apellido = usuario.Apellido;
                user.DNI = usuario.DNI;
                user.Correo = usuario.Correo;
                user.Direccion = usuario.Direccion;
                user.Telefono = usuario.Telefono;
                user.Contrasena = HashPassword(usuario.Contrasena);
                context.Usuarios.Add(user);
                context.SaveChanges();
                return await GetUserInformation(user.IdUsuario);
            }           
        }

        public async Task<UsuarioDTO> LoginUserInformation(string correo, string contrasena)
        {
            contrasena = HashPassword(contrasena);
            using (var context = new PizzeriaMasterpieceEntities())
            {
               var result = await context.Usuarios
               .Where(p => p.Correo == correo && p.Contrasena == contrasena)
               .Select(q => new UsuarioDTO
               {
                   IdUsuario = q.IdUsuario,
                   DNI = q.DNI,
                   Apellido = q.Apellido,
                   Correo = q.Correo,
                   Nombre = q.Nombre,
                   Direccion = q.Direccion,
                   Telefono = q.Telefono
               })
               .FirstOrDefaultAsync();
                return result;
            }
        }

        private string HashPassword(string password){


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
