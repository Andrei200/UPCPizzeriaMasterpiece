using PizzeriaMasterpiece.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Repository
{
    public class UsuarioRepository
    {

        public async Task<UsuarioModel> GetUserInformation(int userId){
            using (var context = new PizzeriaMasterpieceEntities()){

                return await context.UsuarioEntities
               .Where(p => p.IdUsuario == userId)
               .Select(q => new UsuarioModel
               {
                   IdUsuario = q.IdUsuario,
                   DNI = q.DNI,
                   Apellido = q.Apellido,
                   Correo = q.Correo,
                   Nombre = q.Nombre
               })
               .FirstOrDefaultAsync();

            }
        }
    }
}
