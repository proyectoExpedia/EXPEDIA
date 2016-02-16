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
            //String dir = "Data Source=ROJAS-PC\\SQLEXPRESS;Initial Catalog=BD_EXPEDIA;User ID=Administrador;Password=123456";
            //SqlConnection conexion = new SqlConnection(dir);
            //conexion.Open();
            ////try
            ////{
            ////    Response.Write("ok");
            ////}
            ////catch (Exception)
            ////{
            ////    Response.Write("no!!!!");
            ////}


        }
   protected void Bt_Ingresar_Click(object sender, EventArgs e)
        {
            String cedula, pass;
            cedula = this.username.Text;
            pass = this.password.Text;
            if (Login(cedula, pass))
            {
                
                Response.Redirect("mainAdministrador.aspx?rid="+ Server.HtmlEncode(cedula));

            }
            else
                   Response.Redirect("index.aspx?rid=" + Server.HtmlEncode(cedula));
        }


        public bool Login(String ced, string contra)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_cedula, bd_contrasena, bd_nombre FROM Usuarios WHERE bd_cedula = @user AND bd_contrasena = @pass";
            
            Conexion.Open();//abrimos conexion

            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@user", ced); //enviamos los parametros
            cmd.Parameters.AddWithValue("@pass", contra);


            int count = Convert.ToInt32(cmd.ExecuteScalar()); //devuelve la fila afectada

            if (count == 0)
            {
                c.Desconectar(Conexion);
                return false;
            }else{
                c.Desconectar(Conexion);
                return true;
            }

        }
    }

}
