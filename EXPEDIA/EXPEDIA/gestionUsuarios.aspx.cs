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
            cargar_area(area);
            cargar_puesto(puesto);
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
            Response.Redirect("gestionUsuarios.aspx");
            }
            catch(Exception a)
            {
                Response.Write("error" + a.ToString());
             }
        }
        protected void Bt_actualizar_Click(object sender, EventArgs e)
        {

            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            //string Sql = @"Update Usuarios SET (bd_tipo_usuario, bd_nombre, bd_apellido1, bd_apellido2, bd_telefono, bd_correo_electronico, bd_contrasena, bd_cedula, bd_id_puesto, bd_id_area) WHERE (@tipo_usuario, @nombre, @apellido, @apellido2, @telefono,@correo,@contrasena,@cedula,@puesto,@area)";
            string Sql = @"UPDATE Usuarios SET bd_tipo_usuario=@tipo_usuario, bd_nombre=@nombre, bd_apellido1=@apellido, bd_apellido2=@apellido2, bd_telefono=@telefono, bd_correo_electronico=@correo, bd_contrasena=@contrasena, bd_id_puesto=@puesto, bd_id_area=@area WHERE bd_cedula=@cedula";
            Conexion.Open();//abrimos conexion
            //int tipo_usuarioac = Convert.ToInt32(tipo_actualizar);
            try
            {
                int tipo_usuarioac = Convert.ToInt32(tipo_actualizar.SelectedValue);
                SqlCommand cmd = new SqlCommand(Sql, Conexion);
                cmd.Parameters.AddWithValue("@tipo_usuario", true); //enviamos los parametros
                cmd.Parameters.AddWithValue("@nombre", nombre_actualizar.Text);
                cmd.Parameters.AddWithValue("@cedula", cedula_Consulta.Text);
                cmd.Parameters.AddWithValue("@apellido", apellido_actualizar1.Text);
                cmd.Parameters.AddWithValue("@apellido2", apellido_actualizar2.Text);
                cmd.Parameters.AddWithValue("@telefono", telefono_actualizar.Text);
                cmd.Parameters.AddWithValue("@correo", correo_actualizar.Text);
                cmd.Parameters.AddWithValue("@contrasena", contrasena_actualizar.Text);
                cmd.Parameters.AddWithValue("@puesto", puesto_actualizar.SelectedValue);
                cmd.Parameters.AddWithValue("@area", area_actualizar.SelectedValue);
                cmd.ExecuteNonQuery() ;
                c.Desconectar(Conexion);
               
            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }
        }
        protected void cargar_puesto(DropDownList dropdown)
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
           
                dropdown.Items.Add(oItem);
            }
            
            Conexion.Close();
        }
        protected void cargarUsuario_Click(object sender, EventArgs e)
        {
           cargar_area(area_actualizar);
           cargar_puesto(puesto_actualizar);
            ClientScript.RegisterStartupScript(GetType(), "mostrar", "mostrar();",true);
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT * FROM Usuarios WHERE bd_cedula = @ced";
            Conexion.Open();//abrimos conexion            
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@ced", cedula_Consulta.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    bool tipo = reader.GetBoolean(0);
                    if (tipo) tipo_actualizar.SelectedValue = "1";
                    else tipo_actualizar.SelectedValue = "0";
                    nombre_actualizar.Text = reader.GetString(1);
                    apellido_actualizar1.Text = reader.GetString(2);
                    apellido_actualizar2.Text = reader.GetString(3);
                    telefono_actualizar.Text = reader.GetInt32(4).ToString();
                    correo_actualizar.Text = reader.GetString(5);
                    contrasena_actualizar.Text = reader.GetString(6);
                    puesto_actualizar.SelectedValue = reader.GetString(8);
                    area_actualizar.SelectedValue = reader.GetString(9);
                }
            }
            else {
                Conexion.Close();
            }
         
            Conexion.Close();

        }

   
        protected void cargar_area(DropDownList dropdown)
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
                dropdown.Items.Add(oItem);
                }
            Conexion.Close();
        }

    }

}