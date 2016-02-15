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
            String dir = "Data Source=ROJAS-PC\\SQLEXPRESS;Initial Catalog=BD_EXPEDIA;User ID=Administrador;Password=123456";
            SqlConnection conexion = new SqlConnection(dir);
            conexion.Open();
            //try
            //{
            //    Response.Write("ok");
            //}
            //catch (Exception)
            //{
            //    Response.Write("no!!!!");
            //}


        }
        protected void Bt_Ingresar_Click(object sender, EventArgs e)
        {
            String cedula, pass;
            cedula = this.username.Text;
            pass = this.password.Text;
            ValidarUsuario Vu = new ValidarUsuario();
            if (Vu.ValidarUs(cedula, pass))
            {

                Response.Write("Ingresó");
                
                Response.Redirect("mainAdministrador.aspx");

            }
            else
                Response.Write("no ingresó");
        }

    }

   
}