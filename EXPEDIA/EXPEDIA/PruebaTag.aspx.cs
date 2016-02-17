using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace EXPEDIA
{
    public partial class PruebaTag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnAceptar.Attributes.Add("OnClick", "javascript:return fnAceptar();");
        }

        protected bool nose(){
            return true;
        }

        protected void BtnBuscar_Click(object sender, EventArgs e){
            ClientScript.RegisterStartupScript(GetType(), "sdfsdfsdf", "fnAceptar()", true);
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT * FROM Usuarios WHERE bd_cedula = @ced";
            Conexion.Open();//abrimos conexion            
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@ced", Ingresa.Text);
            SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //bool tipo = reader.GetBoolean(0);
                    //if (tipo) tipo_actualizar.SelectedValue = "1";
                    //else tipo_actualizar.SelectedValue = "0";

                    Muestra.Text = reader.GetString(1);
                    //apellido_actualizar1.Text = reader.GetString(2);
                    //apellido_actualizar2.Text = reader.GetString(3);
                    //telefono_actualizar.Text = reader.GetInt32(4).ToString();
                    //correo_actualizar.Text = reader.GetString(5);
                    //contrasena_actualizar.Text = reader.GetString(6);
                    //cedula_actualizar.Text = reader.GetString(7);
                    //puesto_actualizar.SelectedValue = reader.GetString(8);
                    //area_actualizar.SelectedValue = reader.GetString(9);
                    //Response.Redirect("gestionUsuarios.aspx?rid=" + Server.HtmlEncode(cedula_Consulta.Text));
                }
            

            Conexion.Close();
        }
    }
}