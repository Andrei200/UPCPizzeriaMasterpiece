﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Model
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
    }

    public class UsuarioRegistrationModel : UsuarioModel
{
        public string Contrasena { get; set; }
    }

}
