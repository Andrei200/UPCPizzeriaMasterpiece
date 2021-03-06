﻿using PizzeriaMasterpiece.DTO;
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
    public interface IUserService
    {
        //[OperationContract]
        //UserDTO GetUserInformation(int userId);

        [OperationContract]
        UserDTO InsertUserInformation(UserRegistrationDTO user);

        [OperationContract]
        UserDTO UpdateUserInformation(UserRegistrationDTO user);

        [OperationContract]
        UserDTO LoginUserInformation(UserLoginDTO user);

        [OperationContract]
        ResponseDTO ValidateUserEmail(string email);

    }

}
