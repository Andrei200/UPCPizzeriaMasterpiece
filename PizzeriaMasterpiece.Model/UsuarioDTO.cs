namespace PizzeriaMasterpiece.Model
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }


    }

    public class UsuarioRegistroDTO : UsuarioDTO
    {
        public string Contrasena { get; set; }
    }

}
