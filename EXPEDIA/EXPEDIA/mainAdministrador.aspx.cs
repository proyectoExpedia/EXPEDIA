using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                executeProcedimientosAlmacenados();
                notificacionesActivos();
                notificacionesPrestamos();
                Session["Inhabilitado"] = "";
                
        }

        protected void executeProcedimientosAlmacenados() {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            String Sql1 = @"EXEC crearNotificacionFinalGarantia";
            String Sql2 = @"EXEC crearNotificacionPrestamos";
            String Sql3 = @"EXEC crearNotificacionFinalContrato";
            String Sql4 = @"EXEC desecharNotificaciones";
            Conexion.Open();
            SqlCommand cmd = new SqlCommand(Sql1, Conexion);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand(Sql2, Conexion);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand(Sql3, Conexion);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand(Sql4, Conexion);
            cmd.ExecuteNonQuery();
            
        }

        protected void notificacionesPrestamos() {
            int contadorNot = 0;
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            String Sql = @"SELECT * from Notificaciones where bd_estado_notificacion = 1 and bd_campo_tabla = 'bd_fecha_recepcion'";
            Conexion.Open();
            SqlCommand cmd = new SqlCommand(Sql, Conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                String placa = reader.GetString(0);
                String campo = reader.GetString(1);
                String descripcion = reader.GetString(2);
                String fecha = reader.GetDateTime(3).ToString("yyyy/MM/dd");
                String fechaGeneracion = reader.GetDateTime(5).ToString("yyyy/MM/dd");
                String serie = reader.GetString(6);
                crearNotificacionPrestamo(placa, campo, descripcion, fecha, fechaGeneracion, serie);
                contadorNot++;
            }
            asignarContadorPrestamos(contadorNot);
            Conexion.Close();
        
        }

        protected void notificacionesActivos()
        {
            int contadorNot = 0;
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            String Sql = @"SELECT * from Notificaciones where bd_estado_notificacion = 1 and (bd_campo_tabla= 'bd_fecha_final_garantia' OR bd_campo_tabla='bd_finalizacion_contrato')";
            Conexion.Open();
            SqlCommand cmd = new SqlCommand(Sql, Conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                String placa = reader.GetString(0);
                String campo = reader.GetString(1);
                String descripcion = reader.GetString(2);
                String fecha = reader.GetDateTime(3).ToString("yyyy/MM/dd");
                String fechaGeneracion = reader.GetDateTime(5).ToString("yyyy/MM/dd");
                String serie = reader.GetString(6);
                crearNotificacionActivos(placa, campo, descripcion, fecha, fechaGeneracion, serie);
                contadorNot++;
            }
            asignarContadorActivos(contadorNot);
            Conexion.Close();

        }

        protected void crearNotificacionActivos(string placa, String campo, String descripcion, String fecha, String fechaGen, String serie)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl Div = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            Div.ID = "notificacion " + placa;
            Div.Attributes.Add("class", "alert alert-success");
            Div.Attributes.Add("role", "alert");
            Div.InnerHtml = placa + " " + campo + " " + descripcion + " " + fecha + " " + fechaGen + " " + serie;
            this.poolNotificaciones.Controls.Add(Div);
            // this.Controls.Add(createDiv);

        }

        protected void crearNotificacionPrestamo(string placa, String campo, String descripcion, String fecha, String fechaGen, String serie)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl Div = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            Div.ID = "notificacion " + placa;
            Div.Attributes.Add("class", "alert alert-success");
            Div.Attributes.Add("role", "alert");
            Div.InnerHtml = placa + " " + campo + " " + descripcion + " " + fecha + " " + fechaGen + " " + serie;
            this.poolnotificacionesP.Controls.Add(Div);
            // this.Controls.Add(createDiv);

        }

        protected void asignarContadorActivos(int cont)
        {
            this.contador.InnerHtml = cont.ToString();
           
        }

        protected void asignarContadorPrestamos(int cont)
        {
         
            this.contador2.InnerHtml = cont.ToString();
        }
     
     
    }
}