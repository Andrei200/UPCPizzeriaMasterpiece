using PizzeriaMasterpiece.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsuarioService" in both code and config file together.
    [ServiceContract]
    public interface IUsuarioService
    {
        [OperationContract]
        Task<UsuarioDTO> GetUserInformation(int usuarioId);

        [OperationContract]
        Task<UsuarioDTO> InsertUserInformation(UsuarioRegistroDTO usuario);


        [OperationContract]
        Task<UsuarioDTO> UpdateUserInformation(UsuarioRegistroDTO usuario);

        [OperationContract]
        Task<UsuarioDTO> LoginUserInformation(string correo, string contrasena);

    }
}
