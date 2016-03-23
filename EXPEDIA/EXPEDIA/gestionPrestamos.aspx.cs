
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EXPEDIA
{
    public partial class gestionPrestamos : System.Web.UI.Page
    {

        private string departamento;
        private string descripcion1;
        private bool bandera = false;
        private int id;

       static DataTable dt = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
         
                if (Session["Usuario"] == "Inicio")
                {
                    Session["Usuario"] = "Anonimo";
                    Response.Redirect("index.aspx");
                }
            
            if (!IsPostBack)
            {


                cargar_descripcion(descripcion);
                //Limpiar();
                cargar();
            }

        }
        protected void Bt_Ingresar_Click(object sender, EventArgs e)
        {
            if (corroborarExistenciaDatos("Usuarios", "bd_cedula", cedula_usuario.Text, Bt_Ingresar))
            {


                Crear_Prestamo(cedula_usuario.Text);
                if (bandera == false)
                {
                    Cargar_Id_Prestamo(cedula_usuario.Text);
                    Cargar_Activos();
                    excelente(Bt_Ingresar);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Bt_Ingresar ", "imprimePanel()", true);
                    limpiarIngresar();
           

                }
                else { error(Bt_Ingresar, "Disculpa", "Se tuvo un problema a la hora de crear el prestamo"); }


                //System.Threading.Thread.Sleep(9000);


            }
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

        protected void cargar_descripcion(DropDownList dropdown)
        {

            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_id_descripcion, Descripcion FROM Descripcion";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String id = reader.GetString(0);
                String descripcion = reader.GetString(1);
                // Crea un nuevo Item
                ListItem oItem = new ListItem(descripcion, id);
                // Lo agrega a la colección de Items del DropDownList
                dropdown.Items.Add(oItem);
            }
            Conexion.Close();
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

        protected void notificacionCampos(Control boton)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script>");
            sb.Append(@"$(document).ready(function () {");
            sb.Append(@"$('#notificacionDatosConsulta').show(2000, 'swing')});");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(boton, this.GetType(), "Holi", sb.ToString(), false);
        }

        protected void limpiarIngresar()
        {
            try
            {
                //nombre_usuario.Text = "";
                //apellido_usuario1.Text = "";
                //apellido_usuario2.Text = "";
                //telefono_usuario.Text = "";
                //correo_usuario.Text = "";
                //contrasena_usuario.Text = "";
                //cedula_usuario.Text = "";
                //area.SelectedIndex = 0;
                //puesto.SelectedIndex = 0;
                //tipo_usuario.SelectedIndex = 0;
            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }


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
            if (respuesta != 0)
            {
                Conexion.Close();
                return true;
            }
            else
            {
                error(btn, "Disculpa", "No se encontro ningun usuario con la cedula  " + valor + "  en el sistema");
                Conexion.Close();
                return false;
            }


        }



        protected void Retornar_Departamento(string que)
        {
            try
            {

                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT bd_descripcion FROM Areas  WHERE  bd_id_area= @num ";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@num", que); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        departamento = reader.GetString(0);
                    }


                }

            }
            catch (Exception a) { Response.Write(a); }

        }
        protected void Retornar_Descripcion(string que)
        {




            try
            {

                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT Descripcion FROM Descripcion  WHERE   bd_id_descripcion= @num ";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@num", que); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        descripcion1 = reader.GetString(0);
                    }


                }

            }
            catch (Exception a) { Response.Write(a); }



        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[7] {

                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),




            });


            try
            {

                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT * FROM Activos  WHERE bd_descripcion_activo=@num AND bd_estado=1";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("num", descripcion.SelectedValue); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        Retornar_Departamento(reader.GetString(5));
                        Retornar_Descripcion(reader.GetString(4));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), descripcion1, reader.GetString(0), departamento, reader.GetString(6), reader.GetString(7));
                    }

                    tabla.DataSource = dt;
                    tabla.DataBind();
                }
                else
                {
                    error(Button1, "Disculpa", "No se encuentran activos con la descripcion " + descripcion.SelectedItem + " disponibles en el sistema");
                }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void cargar()
        {
            dt.Columns.AddRange(new DataColumn[7] {

                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),




            });
        }
        protected void Limpiar()
        {
           
            dt.Columns.Remove("Número de  Placa");
            dt.Columns.RemoveAt(1);
            dt.Columns.Remove("Número de Serie");
            dt.Columns.RemoveAt(2);
            dt.Columns.Remove(" Descripcion");
            dt.Columns.RemoveAt(3);
            dt.Columns.Remove("Tipo");
            dt.Columns.RemoveAt(4);
            dt.Columns.Remove("Departamento");
            dt.Columns.RemoveAt(5);
            dt.Columns.Remove("Proveedor");
            dt.Columns.RemoveAt(6);
            dt.Columns.Remove("Especificaciones");
            dt.Columns.RemoveAt(7);

        }

        protected void tabla_SelectedIndexChanged(object sender, GridViewDeleteEventArgs e)
        {



            Cambiar_Estado(3, tabla.Rows[e.RowIndex].Cells[1].Text);

            dt.Rows.Add(tabla.Rows[e.RowIndex].Cells[1].Text, tabla.Rows[e.RowIndex].Cells[2].Text, tabla.Rows[e.RowIndex].Cells[3].Text, tabla.Rows[e.RowIndex].Cells[4].Text, tabla.Rows[e.RowIndex].Cells[5].Text, tabla.Rows[e.RowIndex].Cells[6].Text, tabla.Rows[e.RowIndex].Cells[7].Text);
            tabla1.DataSource = dt;
            tabla1.DataBind();


            tabla.DataBind();


        }

        protected void tabla1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            TableCell cell = tabla1.Rows[e.RowIndex].Cells[1];
            Cambiar_Estado(1, cell.Text);
            dt.Rows.RemoveAt(e.RowIndex);
            tabla1.DataSource = dt;
            tabla1.DataBind();

        }

        protected void Cambiar_Estado(int y, string placa)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"UPDATE Activos SET bd_estado=" + y + " WHERE bd_numero_placa=" + placa + "";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.ExecuteNonQuery();


        }





        protected void Crear_Prestamo(String val)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"INSERT INTO Prestamos (bd_id_solicitante,bd_fecha_emision, bd_fecha_recepcion) values (@id_solicitante, @fecha_emision, @fecha_recepcion)";

            Conexion.Open();//abrimos conexion    
            try
            {
                SqlCommand cmd = new SqlCommand(Sql, Conexion);


                cmd.Parameters.AddWithValue("@id_solicitante", val);
                cmd.Parameters.AddWithValue("@fecha_emision", fecha_entreg.Text);
                cmd.Parameters.AddWithValue("@fecha_recepcion", fecha_regres.Text);

                cmd.ExecuteNonQuery();

                c.Desconectar(Conexion);

            }
            catch (Exception e) { Response.Write(e); bandera = true; }
        }

        protected bool Login(String ced)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_cedula FROM Usuarios WHERE bd_cedula = @user";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@user", ced); //enviamos los parametros

            int count = Convert.ToInt32(cmd.ExecuteScalar()); //devuelve la fila afectada
            SqlDataReader reader = cmd.ExecuteReader();

            if (count == 0)
            {
                c.Desconectar(Conexion);
                return false;
            }
            else
            {
                c.Desconectar(Conexion);
                return true;
            }
        }

        protected void Cargar_Id_Prestamo(String cd)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT * FROM Prestamos  WHERE  bd_id_solicitante= @num ";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@num", cd); //enviamos los paramet

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = reader.GetInt32(0);

                    Agregar_Activos_Prestamo(reader.GetInt32(0));
                    TextBox2.Text = reader.GetInt32(0).ToString();
                    TextBox3.Text = reader.GetDateTime(2).ToString();
                    TextBox1.Text = reader.GetString(1);
                    fecha_conclucion.Text = reader.GetDateTime(3).ToString();


                }


            }
        }

        protected void Agregar_Activos_Prestamo(int y)
        {
            foreach (GridViewRow row in tabla1.Rows)
            {

                string placa = row.Cells[1].Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"UPDATE Activos SET bd_id_prestamo=" + y + " WHERE bd_numero_placa=" + placa + "";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.ExecuteNonQuery();


            }
        }


        protected void Cargar_Activos()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[3] {

                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
});


            try
            {

                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT bd_numero_placa,bd_descripcion_activo,bd_especificacion_tecnica FROM Activos  WHERE bd_id_prestamo=@num ";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("num", id); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        dt.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                    }

                    tab_logic_hover.DataSource = dt;
                    tab_logic_hover.DataBind();
                }
            }
            catch (Exception a) { Response.Write(a); }
        }

        protected void descargar_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "descargar", "imprSelec()", true);
        }

        //****************** METODOS PARA LA PARTE DE CONTROL DE PRESTAMOS**********************************

        protected void Consulta_prestamo_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[2] {

                            new DataColumn("Identificador del préstamo", typeof(int)),
                            new DataColumn("Identificacíon del solicitante asosiado ",typeof(string)),







            });

            int g = int.Parse(id_prestamo.Text);

            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT * FROM Prestamos  WHERE bd_id_prestamo= @num ";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@num", g); //enviamos los paramet

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    dt.Rows.Add(reader.GetInt32(0), reader.GetString(1));

                }

                tabla2.DataSource = dt;
                tabla2.DataBind();

            }

            else { error(Consulta_prestamo, "Disculpa", "No se encuentran prestamos con el id " + id_prestamo.Text + "  en el sistema"); }

        }


        protected void tabla2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


    }
}