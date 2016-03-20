using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace EXPEDIA
{
    public partial class index : System.Web.UI.Page
    {  
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Bt_Ingresar_Click(object sender, EventArgs e){
            String cedula, pass;
            cedula = this.username.Text;
            pass = this.password.Text;

            String nombre = Login(cedula, pass);
            if (nombre!=null)
            {
                Response.Redirect("mainAdministrador.aspx?rid=" + Server.HtmlEncode(nombre));
            }
            else
                Response.Redirect("index.aspx?rid=" + Server.HtmlEncode(cedula));
        }
        public string Login(String ced, string contra)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_cedula, bd_contrasena, bd_nombre, bd_apellido1, bd_apellido2 FROM Usuarios WHERE bd_cedula = @user AND bd_contrasena = @pass";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@user", ced); //enviamos los parametros
            cmd.Parameters.AddWithValue("@pass", contra);
            String nombre="";
            String apellido1 = "";
            String apellido2 = "";
            String NombreCompleto = "";
            string count = Convert.ToString(cmd.ExecuteScalar()); //devuelve la fila afectada
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows){
                while (reader.Read()){
                    nombre = reader.GetString(2);
                    apellido1 = reader.GetString(3);
                    apellido2 = reader.GetString(4);
                    NombreCompleto = nombre + " " + apellido1 + " " + apellido2;
                }
            }
            if (count == ""){
                c.Desconectar(Conexion);
                return null;
            }else{
                c.Desconectar(Conexion);
                return NombreCompleto;
            }
        }
    }
}
