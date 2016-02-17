using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EXPEDIA
{
    public partial class gestionUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_area();
            cargar_puesto();
        }
        protected void insertar_usuario(object sender, EventArgs e) {
            
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                //string Sql = @"INSERT INTO Usuarios (bd_tipo_usuario, bd_nombre, bd_apellido1, bd_apellido2, bd_telefono, bd_correo_electronico, bd_contrasena, bd_cedula, bd_id_puesto, bd_id_area) values (@tipo_usuario, @nombre, @apellido, @apellido2, @telefono, @correo, @contrasena, @cedula, @puesto, @area)";
                string Sql = "INSERT INTO [dbo].[Usuarios]([bd_tipo_usuario],[bd_nombre],[bd_apellido1],[bd_apellido2],[bd_telefono],[bd_correo_electronico],[bd_contrasena],[bd_cedula],[bd_id_puesto],[bd_id_area])VALUES(0,'benito','camelas','porfavor',22222,'solo@mamada','puta','sorra','01' ,'01')";
                //Conexion.Open();//abrimos conexion
                //int tipo_usuariobd = Convert.ToInt32(tipo_usuario);
                
              //ejecutamos la instruccion
                                                                //cmd.Parameters.AddWithValue("@tipo_usuario", tipo_usuariobd); //enviamos los parametros
                                                                //cmd.Parameters.AddWithValue("@nombre", nombre_usuario.Text);
                                                                //cmd.Parameters.AddWithValue("@apellido", apellido_usuario1.Text);
                                                                //cmd.Parameters.AddWithValue("@apellido2", apellido_usuario2.Text);
                                                                //cmd.Parameters.AddWithValue("@telefono", telefono_usuario.Text);
                                                                //cmd.Parameters.AddWithValue("@correo", correo_usuario.Text);
                                                                //cmd.Parameters.AddWithValue("@contrasena", contrasena_usuario.Text);
                                                                //cmd.Parameters.AddWithValue("@cedula", cedula_usuario.Text);
                                                                //cmd.Parameters.AddWithValue("@puesto", puesto.Text);
                                                                //cmd.Parameters.AddWithValue("@area", area.Text);
            try
            {
                SqlCommand cmd = new SqlCommand(Sql, Conexion);
                cmd.ExecuteNonQuery();
                c.Desconectar(Conexion);
            }
            catch
            {
//                INSERT INTO Customers([Customer ID], [Company Name], Country, Phone)
//VALUES('WWI', 'Wide World Importers', 'USA', '206-555-0165');
    }



        }

        protected void cargar_puesto()
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_descripcion FROM Puestos";

            Conexion.Open();//abrimos conexion

            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion

           
            SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    String nombre = reader.GetString(0);
                    //// Crea un nuevo Item
                    //ListItem oItem = new ListItem(nombre, nombre);
                    // Lo agrega a la colección de Items del DropDownList
                    puesto.Items.Add(nombre);
                }
            
            Conexion.Close();
        }
        protected void cargar_area()
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_id_area, bd_descripcion FROM Areas";

            Conexion.Open();//abrimos conexion

            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion



            SqlDataReader reader = cmd.ExecuteReader();

           
                while (reader.Read())
                {
                    String nombre = reader.GetString(1);
                String id = reader.GetString(0);
                // Crea un nuevo Item
                ListItem oItem = new ListItem(nombre, id);
                // Lo agrega a la colección de Items del DropDownList
                area.Items.Add(oItem);
                }
            
            Conexion.Close();
        }
    }

}