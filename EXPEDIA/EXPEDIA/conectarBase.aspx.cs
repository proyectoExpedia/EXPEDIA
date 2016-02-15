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
    public partial class conectarBase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            

        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            String dir = "Data Source=ROJAS-PC\\SQLEXPRESS;Initial Catalog=BD_EXPEDIA;User ID=Administrador;Password=123456";
            SqlConnection conexion = new SqlConnection(dir);
            conexion.Open();
            try
            {
                Response.Write(@"ok");
            }
            catch (Exception)
            {
                Response.Write(@"no!!!!");
            }


        }
    }
}