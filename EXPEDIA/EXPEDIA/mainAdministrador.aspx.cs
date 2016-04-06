using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EXPEDIA
{
    public partial class mainAdministrador : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e){
          
                if (Session["Usuario"].Equals("Inicio"))
                {
                    Session["Usuario"] = "Anonimo";
                    Response.Redirect("index.aspx");
                }

                Session["Inhabilitado"] = "";
        }
    }
}