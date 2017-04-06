using PizzeriaMasterpiece.Model;
using PizzeriaMasterpiece.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UsuarioService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UsuarioService.svc or UsuarioService.svc.cs at the Solution Explorer and start debugging.
    public class UsuarioService : IUsuarioService
    {

        public async Task<UsuarioDTO> GetUserInformation(int usuarioId)
        {
            var usurioRepository = new UsuarioRepository();
            return await usurioRepository.GetUserInformation(usuarioId);
        }

        public async Task<UsuarioDTO> InsertUserInformation(UsuarioRegistroDTO usuario)
        {
            var usurioRepository = new UsuarioRepository();
            return await usurioRepository.InsertUserInformation(usuario);
        }
    }
}
