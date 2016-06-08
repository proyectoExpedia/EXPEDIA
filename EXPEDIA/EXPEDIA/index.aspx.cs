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
        protected static Boolean tipo;
        protected void Page_Load(object sender, EventArgs e)
        {
            username.Focus();
        }
        protected void Bt_Ingresar_Click(object sender, EventArgs e){
            String cedula, pass;
            cedula = this.username.Text;
            pass = this.password.Text;

            String nombre = Login(cedula, pass);
            if (nombre != null){
                if (nombre == "desactivado")
                {
                    Session["Usuario"] = "Desactivado";  
                    Response.Redirect("index.aspx");

                }
                else
                {
                    Session["Usuario"] = nombre.ToString();
                    if (tipo== true){Response.Redirect("mainAdministrador.aspx");}
                    if (tipo== false) { Response.Redirect("mainConsulta.aspx"); }
                }
            }
            else{
                Session["Usuario"] = "Desconocido";
                Response.Redirect("index.aspx");
            }
       }
        public string Login(String ced, string contra)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_cedula, bd_contrasena, bd_nombre, bd_apellido1, bd_apellido2, bd_estado, bd_tipo_usuario FROM Usuarios WHERE bd_cedula = @user AND bd_contrasena = @pass";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@user", ced); //enviamos los parametros
            cmd.Parameters.AddWithValue("@pass", contra);
            String nombre="";
            String apellido1 = "";
            String apellido2 = "";
            String NombreCompleto = "";
            string estado="";
            string count = Convert.ToString(cmd.ExecuteScalar()); //devuelve la fila afectada
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows){
                while (reader.Read()){
                    nombre = reader.GetString(2);
                    apellido1 = reader.GetString(3);
                    apellido2 = reader.GetString(4);
                    estado = reader.GetInt16(5).ToString();
                    NombreCompleto = nombre + " " + apellido1 + " " + apellido2;
                    tipo = reader.GetBoolean(6);
                }
            }

            if (count == ""){
                c.Desconectar(Conexion);
                return null;
            }else{
                if (estado == "1"||estado== "2"){
                    c.Desconectar(Conexion);
                    return NombreCompleto;
                }
                if (estado == "3") {
                    c.Desconectar(Conexion);
                    return "desactivado";
                }
            }
            return null;
        }
    }
}
