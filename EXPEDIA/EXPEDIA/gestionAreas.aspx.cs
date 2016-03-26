using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EXPEDIA
{
    public partial class gestionAreas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] == "Inicio")
            {
                Session["Usuario"] = "Anonimo";
                Response.Redirect("index.aspx");
            }

                cargar_area();


          

        } 

        protected void error(Control btn, String titulo, String texto)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script language='javascript'>");
            sb.Append(@"swal({");
            sb.Append(@"title: ' " + titulo + " ',");
            sb.Append(@"text: ' " + texto + "',");
            sb.Append(@"type: 'error',");
            sb.Append(@"confirmButtonText: 'Continuar'");
            sb.Append(@"})");
            sb.Append(@"</script>");

            ScriptManager.RegisterStartupScript(btn, this.GetType(), "Holi", sb.ToString(), false);
            //http://limonte.github.io/sweetalert2/

        }

        protected void cargar_area(){
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT bd_id_area, bd_descripcion, bd_motivos, bd_estado FROM Areas";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    String nombre = reader.GetString(1);
                    String id = reader.GetString(0);
                    String motivos = reader.GetString(2);
                    int estado= reader.GetInt16(3);
                    insertarRow(id, nombre,motivos, estado);
                }
                Conexion.Close();
        }

        void insertarRow(String id, String nombre,String motivos, int estado) {
            TableRow row = new TableRow();
            row.ID = id.ToString();
            row.ClientIDMode = ClientIDMode.Static;
            TableCell ide = new TableCell();
            TableCell descripcion = new TableCell();
            TableCell btn = new TableCell();
            TableCell motivo = new TableCell();
            ide.ColumnSpan = 1;
            ide.Text = id;
            descripcion.Text = nombre;
            descripcion.ColumnSpan = 1;
            motivo.Text = motivos;
            if (estado == 1)
            {
                btn.Text = "<input type=\"button\" id=\"hola\" value=\"Modificar\" class=\"btn btn-primary\" onclick=\"modificar('" + id + "')\" data-toggle=\"modal\" data-target=\"#modalAreas\" /> " +
                            "<input type=\"button\" id=\"hola\" value=\"Inhabilitar\" class=\"btn btn-danger\" onclick=\"inhabilitar('" + id + "')\" data-toggle=\"modal\" data-target=\"#modalInhabilitar\" /> ";
            }
            else {
                btn.Text = "<input type=\"button\" id=\"hola\" value=\"Habilitar\" onclick=\"habilitar('" + id + "')\" class=\"btn btn-success\" data-toggle=\"modal\" data-target=\"#exampleModa\" /> ";   
            }
            motivo.Style.Add("display","none");
            row.Cells.Add(ide);
            row.Cells.Add(descripcion);
            row.Cells.Add(btn);
            row.Cells.Add(motivo);
            Table2.Rows.Add(row);

        }

        void eliminarRow(string id)
        {
            for (int i = 0; i < Table2.Rows.Count; i++)
            {
                if (Table2.Rows[i].ID == id)
                {
                    Table2.Rows.Remove(Table2.Rows[i]);
                }

            }
        }

        protected void excelente(Control boton)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script language='javascript'>");
            sb.Append(@"swal({");
            sb.Append(@"title: 'Solicitudes realizadas correctamente',");
            sb.Append(@"timer: 2000,");
            sb.Append(@"type: 'success'");
            sb.Append(@"})");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(boton, this.GetType(), "Holi", sb.ToString(), false);
            //http://limonte.github.io/sweetalert2/


        }

        protected void limpiarIngresar()
        {
            try
            {
                idareas.Text = "";
                areas.Text = "";
            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }


        }
        
        protected void Btn_areas_Click(object sender, EventArgs e)
        {
            if (corroborarExistenciaDatos("Areas", "bd_id_area", idareas.Text, Btn_areas))
            {
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"INSERT INTO Areas (bd_id_area, bd_descripcion, bd_estado,bd_motivos) values (@id, @descripcion,@estado,@motivos)";

                Conexion.Open();//abrimos conexion

                try
                {
                    SqlCommand cmd = new SqlCommand(Sql, Conexion);
                    cmd.Parameters.AddWithValue("@id", idareas.Text);
                    cmd.Parameters.AddWithValue("@descripcion", areas.Text);
                    cmd.Parameters.AddWithValue("@estado", 1);
                    cmd.Parameters.AddWithValue("@motivos", "Activo");
                    cmd.ExecuteNonQuery();
                    c.Desconectar(Conexion);
                    insertarRow(idareas.Text,areas.Text,"Activo",1);
                    limpiarIngresar();
                    excelente(Btn_areas);
                }
                catch (Exception a)
                {
                    Response.Write("error" + a.ToString());
                }
            }
        }

        protected void Btn_modificar_areas_Click(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"UPDATE Areas SET bd_descripcion=@descripcion WHERE bd_id_area=@area";
            Conexion.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(Sql, Conexion);
                cmd.Parameters.AddWithValue("@descripcion", mDescripcion.Text);
                cmd.Parameters.AddWithValue("@area", midAreas.Text);
                cmd.ExecuteNonQuery();
                eliminarRow(midAreas.Text);
                insertarRow(midAreas.Text, mDescripcion.Text,"Activo",1);
                c.Desconectar(Conexion);
                excelente(Button1);

            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }
        }

        protected void Btn_inhabilitar_Click(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"UPDATE Areas SET bd_estado=@area_estado, bd_motivos=@motivos WHERE bd_id_area=@id_area";
            Conexion.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(Sql, Conexion);
                cmd.Parameters.AddWithValue("@area_estado", 2);
                cmd.Parameters.AddWithValue("@id_area", midAreas.Text);
                cmd.Parameters.AddWithValue("@motivos", TextArea1.Text);
                cmd.ExecuteNonQuery();
                c.Desconectar(Conexion);
                eliminarRow(midAreas.Text);
                insertarRow(midAreas.Text, mDescripcion.Text, TextArea1.Text, 2);

            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }
            excelente(Btn_inhabilitar);
            
        }
        
        protected bool corroborarExistenciaDatos(String tabla, String id, String valor, Control btn)
        {

            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT COUNT(*) FROM " + tabla + " where " + id + "=@valor";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion 
            cmd.Parameters.AddWithValue("@valor", valor);
            int respuesta = Convert.ToInt32(cmd.ExecuteScalar());
            if (respuesta == 0)
            {
                Conexion.Close();
                return true;
            }
            else
            {
                error(btn, "Disculpa", "El valor " + valor + " ya fue registrado en el sistema");
                Conexion.Close();
                return false;
            }


        }

        protected void btn_habilitarUsuario_Click(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"UPDATE Areas SET bd_estado=@area_estado, bd_motivos=@motivos WHERE bd_id_area=@area";
            Conexion.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(Sql, Conexion);
                cmd.Parameters.AddWithValue("@area_estado", 1);
                cmd.Parameters.AddWithValue("@area", midAreas.Text);
                cmd.Parameters.AddWithValue("@motivos", "Activo");
                cmd.ExecuteNonQuery();
                eliminarRow(midAreas.Text);
                insertarRow(midAreas.Text, mDescripcion.Text, "Activo", 1);
                excelente(btn_habilitarUsuario);
            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }
            finally
            {
                c.Desconectar(Conexion);
            }

        }

    }
}