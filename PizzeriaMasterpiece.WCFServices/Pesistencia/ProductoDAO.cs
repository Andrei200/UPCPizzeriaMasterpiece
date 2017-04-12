using PizzeriaMasterpiece.WCFServices.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PizzeriaMasterpiece.WCFServices.Pesistencia
{
    public class ProductoDAO
    {

        public string CadenaDeConexion = "Data Source=PCADMIN;Initial Catalog=BDCliente;User ID=sa ;Password=Andrei87";

        public Producto Crear(Producto ProductoACrear)
        {
            Producto prodcutoCreado = null;
            string sql = "INSERT INTO Cliente VALUES ( @nom_cli,@direccion,@telefono,@ruc)";
            using (SqlConnection con = new SqlConnection(CadenaDeConexion))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod_cli", ProductoACrear.IdProducto));
                    com.Parameters.Add(new SqlParameter("@nom_cli", ProductoACrear.TipoProducto_IdTipoProducto));
                    com.Parameters.Add(new SqlParameter("@direccion", ProductoACrear.NombreProducto));
                    com.Parameters.Add(new SqlParameter("@telefono", ProductoACrear.Activo));
                    com.Parameters.Add(new SqlParameter("@ruc", ProductoACrear.Precio));
                    com.Parameters.Add(new SqlParameter("@ruc", ProductoACrear.Descripcion));

                    com.ExecuteNonQuery();
                }
            }
            // socioCreado = Obtener(socioACrear.id);
            return prodcutoCreado;
        }

        public Producto Obtener(int cod_cli)
        {
            Producto productoEncontrado = null;
            string sql = "SELECT * FROM Cliente WHERE cod_cli=@cod_cli";
            using (SqlConnection con = new SqlConnection(CadenaDeConexion))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod_cli", cod_cli));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            productoEncontrado = new Producto()
                            {
                                IdProducto = Int32.Parse(resultado["cod_cli"].ToString()),
                                TipoProducto_IdTipoProducto = (string)resultado["nom_cli"],
                                NombreProducto = (string)resultado["direccion"],
                                Activo = (string)resultado["telefono"],


                                Descripcion = (string)resultado["ruc"],


                                ruc = (string)resultado["ruc"]
                            };
                        }
                    }
                }
            }
            return productoEncontrado;
        }


    }
}