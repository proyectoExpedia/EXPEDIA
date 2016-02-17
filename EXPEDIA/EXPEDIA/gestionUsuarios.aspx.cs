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
        protected void Bt_Ingresar_Click(object sender, EventArgs e) {
            
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"INSERT INTO Usuarios (bd_tipo_usuario, bd_nombre, bd_apellido1, bd_apellido2, bd_telefono, bd_correo_electronico, bd_contrasena, bd_cedula, bd_id_puesto, bd_id_area) values (@tipo_usuario, @nombre, @apellido, @apellido2, @telefono,@correo,@contrasena,@cedula,@puesto,@area)";

            Conexion.Open();//abrimos conexion
            int tipo_usuariobd = Convert.ToInt32(tipo_usuario.SelectedValue);
            try
            {
                SqlCommand cmd = new SqlCommand(Sql, Conexion);
            cmd.Parameters.AddWithValue("@tipo_usuario", tipo_usuariobd); //enviamos los parametros
            cmd.Parameters.AddWithValue("@nombre", nombre_usuario.Text);
            cmd.Parameters.AddWithValue("@apellido", apellido_usuario1.Text);
            cmd.Parameters.AddWithValue("@apellido2", apellido_usuario2.Text);
            cmd.Parameters.AddWithValue("@telefono", telefono_usuario.Text);
            cmd.Parameters.AddWithValue("@correo", correo_usuario.Text);
            cmd.Parameters.AddWithValue("@contrasena", contrasena_usuario.Text);
            cmd.Parameters.AddWithValue("@cedula", cedula_usuario.Text);
            cmd.Parameters.AddWithValue("@puesto", puesto.SelectedValue);
            cmd.Parameters.AddWithValue("@area", area.SelectedValue);    
            cmd.ExecuteNonQuery();
            c.Desconectar(Conexion);
            }
            catch(Exception a)
            {
                Response.Write("error" + a.ToString());
             }
        }
        protected void cargar_puesto()
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_id_puesto, bd_descripcion FROM Puestos";
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
                puesto.Items.Add(oItem);
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