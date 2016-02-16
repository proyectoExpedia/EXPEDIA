using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EXPEDIA
{
    public class ValidarUsuario
    {

        public bool ValidarUs(string cedula, string password)
        {
            String dir = "Data Source=ROJAS-PC\\SQLEXPRESS;Initial Catalog=BD_EXPEDIA;User ID=Administrador;Password=123456";
            SqlConnection conexion = new SqlConnection(dir);
            conexion.Open();

            //consulta a la base de datos
            string sql = "SELECT * FROM Usuarios WHERE bd_cedula = @cedula AND bd_contrasena = @pass";
            //cadena conexion

            {


                SqlCommand cmd = new SqlCommand(sql, conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@cedula", cedula); //enviamos los parametros
                cmd.Parameters.AddWithValue("@pass", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar()); //devuelve la fila afectada

                if (count == 0)
                    return false;
                else
                    return true;

            }
        }
        
    }
}