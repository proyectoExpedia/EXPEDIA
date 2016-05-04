using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EXPEDIA
{
	public partial class GestionDonaciones : System.Web.UI.Page
	{


        private string departamento;
        private string descripcion;
        private string provedor;
        private string num;
        private string id_des;
        private string id_dep;
        private static int id_prolongar;
        private static bool tiene = false;
        private static string ced;



        private bool bandera = false;
        private int id;

        static DataTable dt;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"].Equals("Inicio"))
            {
                Session["Usuario"] = "Anonimo";
                Response.Redirect("index.aspx");
            }

            if (!IsPostBack)
            {

                cargar_area(departamento_activo);
                cargar_descripcion(descripcion_activo);
                cargar_proveedor(proveedor);
                dt = new DataTable();
                cargar();
                RangeValidator1.MinimumValue = DateTime.Now.ToString("yyyy/MM/dd");
                RangeValidator1.MaximumValue = "9999/99/99";

            }

            if (Session["Usuario"].Equals( "Inicio"))
            {
                Session["Usuario"] = "Anonimo";
                Response.Redirect("index.aspx");
            }


        }





        //** METODOS ESPECIFICOS PARA BOTONES*****
        protected void Consultar1_Click(object sender, EventArgs e)
        {
            num = numero.Text;


            departamento = Seleciono_Departamento();
            descripcion = Seleciono_Descripcion();
            provedor = Seleciono_proveedor();
            if ((departamento == null) && (numero.Text == "") && (descripcion == null) && (provedor == null)) { Consultar_todo(); }
            if ((departamento != null) && (numero.Text != "") && (descripcion == null) && (provedor == null)) { Consulta_Despartamento_Numero("bd_numero_placa", 1); }
            if ((departamento != null) && (numero.Text == "") && (descripcion == null) && (provedor == null)) { Consulta_Despartamento(); }
            if ((departamento != null) && (numero.Text != "") && (descripcion != null) && (provedor == null)) { Consulta_Despartamento_Numero_descripcion("bd_numero_placa", 1); }
            if ((departamento == null) && (numero.Text == "") && (descripcion != null) && (provedor == null)) { Consulta_Descripcion(); }
            if ((departamento == null) && (numero.Text != "") && (descripcion != null) && (provedor == null)) { Consulta_Descripcion_Numero("bd_numero_placa", 1); }
            if ((departamento != null) && (numero.Text != "") && (descripcion != null) && (provedor != null)) { Consulta_Despartamento_Numero_descripcion_proveedor("bd_numero_placa", 1); }
            if ((departamento != null) && (numero.Text == "") && (descripcion != null) && (provedor != null)) { Consulta_Despartamento_descripcion_proveedor(); }
            if ((departamento == null) && (numero.Text == "") && (descripcion != null) && (provedor != null)) { Consulta_Descripcion_proveedor(); }
            if ((departamento != null) && (numero.Text == "") && (descripcion == null) && (provedor != null)) { Consulta_Despartamento_proveedor(); }
            if ((departamento == null) && (numero.Text != "") && (descripcion == null) && (provedor != null)) { Consulta_Proveedor_Numero("bd_numero_placa", 1); }
            if ((departamento == null) && (numero.Text == "") && (descripcion == null) && (provedor != null)) { Consulta_Proveedor(); }
            if ((departamento == null) && (numero.Text != "") && (descripcion == null) && (provedor == null)) { Consulta_Numero("bd_numero_placa", 1); }
            if ((departamento != null) && (numero.Text == "") && (descripcion != null) && (provedor == null)) { Consulta_Despartamento_descripcion(); }


        }
        protected void Bt_Ingresar_Click(object sender, EventArgs e)
        {

                if (!tiene)
                {
                    if (tabla1.Rows.Count != 0)
                    {
                       


                            Crear_Donacion();
                            if (bandera == false)
                            {
                                Cargar_Id_Donacion(cedula_usuario.Text);
                                Cargar_Activos(id, tab_logic_hover);
                                excelente(Bt_Ingresar);
                        Page.ClientScript.RegisterStartupScript(GetType(), "Bt_Ingresar", "imprimePanel()", true);

                        limpiarIngresar();



                            }
                            else { error(Bt_Ingresar, "Disculpa", "Se tuvo un problema a la hora de crear el prestamo"); }


                            //System.Threading.Thread.Sleep(9000);


                        
                    }
                    else { error(Bt_Ingresar, "Disculpa", "No hay ningun activos selecionados en la donación"); }

                }
                else { error(Bt_Ingresar, "Disculpa", "El usuario al cual se va realizar la donacion ya es miembro del sistema si desea realizar un préstamo vaya a Gestion de préstamo"); }
            
            
        }

        protected void cedula_usuario_TextChanged(object sender, EventArgs e)
        {

            string ced = cedula_usuario.Text;
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();



            string Sql = @"SELECT bd_nombre, bd_apellido1, bd_estado FROM Usuarios WHERE bd_cedula = @user";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@user", ced); //enviamos los parametros


            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    Info.InnerText = "" + reader.GetString(0) + " " + reader.GetString(1) + " es un usuario del sistema "; Info.Style.Add("color", "red"); tiene = true;
                    error(Bt_Ingresar, "Disculpa", "El usuario al cual se va realizar la donacion ya es miembro del sistema si desea realizar un préstamo vaya a Gestión de préstamo");
                }
                   
                    


                
            }
            else
            {
                tiene = false;
                Info.InnerText = "No existe ningun usuario con esa cedula"; Info.Style.Add("color", "green");

            }


        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            idiv.Visible = true;
            theDiv.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            idiv.Visible = false;
            theDiv.Visible = true;
        }


        //****** METODOS DE PARA CONTROLES DE INFORMACION*********************
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


        protected void tabla_SelectedIndexChanged(object sender, GridViewDeleteEventArgs e)
        {



            Cambiar_Estado(4, tabla.Rows[e.RowIndex].Cells[1].Text);

            dt.Rows.Add(tabla.Rows[e.RowIndex].Cells[1].Text, tabla.Rows[e.RowIndex].Cells[2].Text, tabla.Rows[e.RowIndex].Cells[3].Text, tabla.Rows[e.RowIndex].Cells[4].Text, tabla.Rows[e.RowIndex].Cells[5].Text, tabla.Rows[e.RowIndex].Cells[6].Text, tabla.Rows[e.RowIndex].Cells[7].Text);
            tabla1.DataSource = dt;
            tabla1.DataBind();


            tabla.DataBind();
            idiv.Visible = false;
            theDiv.Visible = true;


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
                Fecha_entrega.Text = "";
               
                cedula_usuario.Text = "";
                tabla1.DataBind();
                dt = new DataTable();
                cargar();


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


        //****** METODOS PARA HACER LA CONSULTA DE LOS ACTIVOS DISPONIBLES **********


        //***METODOS PARA CARGAR LA INFORMACION DE LOS DROPDOWNLIST ******
        protected void cargar_area(DropDownList dropdown)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_id_area, bd_descripcion FROM Areas";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String nombre = reader.GetString(1);
                String id = reader.GetString(0);
                // Crea un nuevo Item
                ListItem oItem = new ListItem(nombre, id);
                // Lo agrega a la colección de Items del DropDownList

                dropdown.Items.Add(oItem);
            }
            Conexion.Close();
        }
        protected void cargar_proveedor(DropDownList dropdown)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_nombre_proveedor FROM Proveedores";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String nombre = reader.GetString(0);
                // Crea un nuevo Item
                ListItem oItem = new ListItem(nombre, nombre);
                // Lo agrega a la colección de Items del DropDownList
                dropdown.Items.Add(oItem);
            }
            Conexion.Close();
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

        // *** METODOS PARA SABER SI UN DROPDOWNLIST SE SELECIONO****
        protected string Seleciono_Departamento()
        {
            if (departamento_activo.SelectedValue != "0") { return departamento_activo.SelectedValue; }
            else { return null; }
        }
        protected string Seleciono_Descripcion()
        {
            if (descripcion_activo.SelectedValue != "0") { return descripcion_activo.SelectedValue; }
            else { return null; }
        }
        protected string Seleciono_proveedor()
        {
            if (proveedor.SelectedValue != "0") { return proveedor.SelectedValue; }
            else { return null; }
        }

        // ****LAS DIFERENTES CONSULTAS DEPENDIANDO DE LOS FILTROS DE BUSQUEDA****
        protected void Consultar_todo()
        {


            error(Consultar1, "Disculpa", "Utiliaza los filtros de busqueda para una mejor consulta");

        }

        protected void Consulta_Despartamento_Numero(string quien, int cuantas)
        {

            if (cuantas < 2)
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
                    string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE " + quien + "= @num  AND bd_departamento = @dpt AND bd_estado<3 AND bd_tipo_activo='Hardware'";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Retornar_Departamento(reader.GetString(4));
                            Retornar_Descripcion(reader.GetString(3));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6));
                        }

                        tabla.DataSource = dt;
                        tabla.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero("bd_numero_serie", cuantas); }
                }
                catch (Exception a) { Response.Write(a); }
            }

            else { error(Consultar1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); }


        }
        protected void Consulta_Descripcion_Numero(string quien, int cuantas)
        {

            if (cuantas < 2)
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
                    string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos WHERE " + quien + "= @num  AND bd_descripcion_activo = @dpt AND bd_estado<3 AND bd_tipo_activo='Hardware'";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", descripcion); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Retornar_Departamento(reader.GetString(4));
                            Retornar_Descripcion(reader.GetString(3));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6));
                        }

                        tabla.DataSource = dt;
                        tabla.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero("bd_numero_serie", cuantas); }
                }
                catch (Exception a) { Response.Write(a); }
            }
            else { error(Consultar1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); }

        }
        protected void Consulta_Proveedor_Numero(string quien, int cuantas)
        {

            if (cuantas < 2)
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
                    string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE " + quien + "= @num  AND bd_proveedor = @dpt  AND bd_estado<3 AND bd_tipo_activo='Hardware'";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", provedor); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Retornar_Departamento(reader.GetString(4));
                            Retornar_Descripcion(reader.GetString(3));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6));
                        }

                        tabla.DataSource = dt;
                        tabla.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero("bd_numero_serie", cuantas); }
                }
                catch (Exception a) { Response.Write(a); }
            }
            else { error(Consultar1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); }

        }
        protected void Consulta_Despartamento_Numero_descripcion(string quien, int cuantas)
        {

            if (cuantas < 2)
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
                    string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos WHERE " + quien + "= @num  AND bd_departamento=@dpt AND bd_descripcion_activo=@desc  AND bd_estado<3 AND bd_tipo_activo='Hardware'";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@desc", descripcion); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Retornar_Departamento(reader.GetString(4));
                            Retornar_Descripcion(reader.GetString(3));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6));
                        }

                        tabla.DataSource = dt;
                        tabla.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero("bd_numero_serie", cuantas); }
                }
                catch (Exception a) { Response.Write(a); }
            }
            else { error(Consultar1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); }

        }
        protected void Consulta_Despartamento_Numero_descripcion_proveedor(string quien, int cuantas)
        {

            if (cuantas < 2)
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
                    string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE " + quien + "=@num  AND bd_departamento =@dpt AND bd_descripcion_activo=@desc AND bd_proveedor=@pro  AND bd_estado<3 AND bd_tipo_activo='Hardware'";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@desc", descripcion); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@pro", provedor); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Retornar_Departamento(reader.GetString(4));
                            Retornar_Descripcion(reader.GetString(3));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6));
                        }

                        tabla.DataSource = dt;
                        tabla.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero("bd_numero_serie", cuantas); }
                }
                catch (Exception a) { Response.Write(a); }
            }
            else { error(Consultar1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); }

        }
        protected void Consulta_Despartamento()
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
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE  bd_departamento=@dpt  AND bd_estado<3 AND bd_tipo_activo='Hardware'";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Departamento(reader.GetString(4));
                        Retornar_Descripcion(reader.GetString(3));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6));
                    }

                    tabla.DataSource = dt;
                    tabla.DataBind();
                }

                else { error(Consultar1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); }
            }
            catch (Exception a) { Response.Write(a); }

        }
        protected void Consulta_Proveedor()
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
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos WHERE  bd_proveedor=@dpt  AND bd_estado<3 AND bd_tipo_activo='Hardware'";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", provedor); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Departamento(reader.GetString(4));
                        Retornar_Descripcion(reader.GetString(3));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6));
                    }

                    tabla.DataSource = dt;
                    tabla.DataBind();
                }

                else { error(Consultar1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); }
            }
            catch (Exception a) { Response.Write(a); }

        }
        protected void Consulta_Despartamento_descripcion_proveedor()
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
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE  bd_departamento=@dpt AND bd_descripcion_activo=@des  AND bd_proveedor=@pro  AND bd_estado<3 AND bd_tipo_activo='Hardware'";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                cmd.Parameters.AddWithValue("@des", descripcion); //enviamos los paramet
                cmd.Parameters.AddWithValue("@pro", provedor); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Departamento(reader.GetString(4));
                        Retornar_Descripcion(reader.GetString(3));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6));
                    }

                    tabla.DataSource = dt;
                    tabla.DataBind();
                }
                else { error(Consultar1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); }
            }
            catch (Exception a) { Response.Write(a); }



        }
        protected void Consulta_Despartamento_descripcion()
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
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE  bd_departamento=@dpt AND bd_descripcion_activo=@des  AND bd_estado<3 AND bd_tipo_activo='Hardware' ";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                cmd.Parameters.AddWithValue("@des", descripcion); //enviamos los paramet


                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Departamento(reader.GetString(4));
                        Retornar_Descripcion(reader.GetString(3));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6));
                    }

                    tabla.DataSource = dt;
                    tabla.DataBind();
                }
                else { error(Consultar1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Descripcion()
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
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE bd_descripcion_activo=@dpt  AND bd_estado<3 AND bd_tipo_activo='Hardware'";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", descripcion); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Departamento(reader.GetString(4));
                        Retornar_Descripcion(reader.GetString(3));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6));
                    }
                    tabla.DataSource = dt;
                    tabla.DataBind();
                }
                else { error(Consultar1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Numero(string que, int cuantas)
        {

            if (cuantas < 2)
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
                    string num = numero.Text;
                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE " + que + "=@num  AND bd_estado<3 AND bd_tipo_activo='Hardware'";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("num", num); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Retornar_Departamento(reader.GetString(4));
                            Retornar_Descripcion(reader.GetString(3));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6));
                        }

                        tabla.DataSource = dt;
                        tabla.DataBind();
                    }
                    else { cuantas++; Consulta_Numero("bd_numero_serie", cuantas); }

                }
                catch (Exception a) { Response.Write(a); }
            }
            else { error(Consultar1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); }
        }
        protected void Consulta_Descripcion_proveedor()
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
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE bd_descripcion_activo=@dpt AND bd_proveedor=@pro AND bd_estado<3 AND bd_tipo_activo='Hardware'";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", descripcion); //enviamos los paramet
                cmd.Parameters.AddWithValue("@pro", provedor); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Departamento(reader.GetString(4));
                        Retornar_Descripcion(reader.GetString(3));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6));
                    }

                    tabla.DataSource = dt;
                    tabla.DataBind();
                }
                else { error(Consultar1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Despartamento_proveedor()
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
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE  bd_departamento=@dpt AND bd_proveedor=@pro  AND bd_estado<3 AND bd_tipo_activo='Hardware'";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                cmd.Parameters.AddWithValue("@pro", provedor); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Retornar_Departamento(reader.GetString(4));
                        Retornar_Descripcion(reader.GetString(3));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6));
                    }

                    tabla.DataSource = dt;
                    tabla.DataBind();
                }
                else { error(Consultar1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); }
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

                        id_des = reader.GetString(0);
                    }


                }

            }
            catch (Exception a) { Response.Write(a); }



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

                        id_dep = reader.GetString(0);
                    }


                }

            }
            catch (Exception a) { Response.Write(a); }

        }



        //**** METODOS PARA REALIZAR DONACIONES********************


        protected void Crear_Donacion()
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"INSERT INTO Donaciones(bd_fecha_salida, bd_nombre_veneficiado, bd_id_veneficiado, bd_apellido1_veneficiado, bd_apellido2_veneficiado, bd_telefono_veneficiado, bd_descripcion_donaciones) values (@bd_fecha_salida, @bd_nombre_veneficiado,@bd_id_veneficiado, @bd_apellido1_veneficiado, @bd_apellido2_veneficiado,@bd_telefono_veneficiado,@bd_descripcion_donaciones)";
            
    
           

            Conexion.Open();//abrimos conexion    
            try
            {
                SqlCommand cmd = new SqlCommand(Sql, Conexion);


                cmd.Parameters.AddWithValue("@bd_fecha_salida", Fecha_entrega.Text);
                cmd.Parameters.AddWithValue("@bd_nombre_veneficiado", nombre_usuario.Text);
                cmd.Parameters.AddWithValue("@bd_id_veneficiado", cedula_usuario.Text);
                cmd.Parameters.AddWithValue("@bd_apellido1_veneficiado", apellido_usuario1.Text);
                cmd.Parameters.AddWithValue("@bd_apellido2_veneficiado", apellido_usuario2.Text);
                cmd.Parameters.AddWithValue("@bd_telefono_veneficiado", telefono_usuario.Text);
                cmd.Parameters.AddWithValue("@bd_descripcion_donaciones", descripcion_donacion.Text);


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

        protected void Cargar_Id_Donacion(String cd)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT * FROM Donaciones  WHERE  bd_id_veneficiado=@num ";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@num", cd); //enviamos los paramet

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = reader.GetInt32(0);

                    Agregar_Activos_Donacion(reader.GetInt32(0));
                    TextBox2.Text = reader.GetInt32(0).ToString();
                    TextBox3.Text = reader.GetDateTime(1).ToString();
                    TextBox1.Text = reader.GetString(3);
                    fecha_conclucion.Text = reader.GetDateTime(1).ToString();


                }


            }
        }

        protected void Agregar_Activos_Donacion(int y)
        {
            foreach (GridViewRow row in tabla1.Rows)
            {

                string placa = row.Cells[1].Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"UPDATE Activos SET bd_id_donaciones=" + y + " WHERE bd_numero_placa=" + placa + "";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.ExecuteNonQuery();


            }
        }


        protected void Cargar_Activos(int g, GridView j)
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
                string Sql = @"SELECT bd_numero_placa,bd_descripcion_activo,bd_especificacion_tecnica FROM Activos  WHERE bd_id_donaciones=@num ";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("num", g); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        dt.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                    }

                    j.DataSource = dt;
                    j.DataBind();
                }
            }
            catch (Exception a) { Response.Write(a); }
        }

        protected void descargar_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "descargar", "imprSelec()", true);
        }

        //****** VA LIDACION DE PENDIENTES********
        protected void Pendiente_detalle(string y)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT * FROM Prestamos  WHERE bd_id_solicitante= @num ";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@num", y); //enviamos los paramet

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {


                    TextBox11.Text = reader.GetInt32(0).ToString();
                    TextBox12.Text = reader.GetString(1).ToString();
                    TextBox13.Text = reader.GetDateTime(2).ToString("dd/MM/yyyy");
                    TextBox14.Text = reader.GetDateTime(3).ToString("dd/MM/yyyy");
                    Cargar_Activos(reader.GetInt32(0), Gridview2);


                }



            }

            else { error(Consulta_prestamo, "Disculpa", "No se pudo cargar el detalle  en el sistema"); }

        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            pendiente.Visible = false;
        }

        //****************** METODOS PARA LA PARTE DE CONTROL DE Donaciones**********************************


    
        protected void Consulta_prestamo_Click(object sender, EventArgs e)
        {
            tiene = false;
            Consultar_id();     
        }

        protected void tabla2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Detalle":
                    {


                        string rowIndex = e.CommandArgument.ToString();

                        int index = Convert.ToInt32(rowIndex);
                        TableCell cell = tabla2.Rows[index].Cells[3];

                        string pap = cell.Text;

                        int row = Convert.ToInt32(pap);

                        llenar_detalle(row);

                        Cargar_Activos(row, Gridview1);

                        detalle.Visible = true; break;
                    }
                case "Descripcion":
                    {

                        string rowIndex = e.CommandArgument.ToString();

                        int index = Convert.ToInt32(rowIndex);
                        TableCell cell = tabla2.Rows[index].Cells[3];
                        TableCell cell1 = tabla2.Rows[index].Cells[4];
                        string cd = cell1.Text;

                        string pap = cell.Text;

                        int row = Convert.ToInt32(pap);
                        calcular(row);
                        ced = cd;
                        finalizar.Visible = true;

                        break;
                    }
                case "Contactar":
                    {

                        string rowIndex = e.CommandArgument.ToString();

                        int index = Convert.ToInt32(rowIndex);
                        TableCell cell = tabla2.Rows[index].Cells[3];

                        string pap = cell.Text;

                        int row = Convert.ToInt32(pap);
                        id_prolongar = row;
                        validar_prolongar(row);
                        prolongar.Visible = true;





                        break;
                    }
            }




        }

    

        private void Consultar_id()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[3] {

                            new DataColumn("Identificador de la Donacion", typeof(int)),
                            new DataColumn("Identificacíon asociada a la donación ",typeof(string)),
                            new DataColumn("Nombre de la persona  ",typeof(string)),









            });

            int g = int.Parse(id_prestamo.Text);

            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT * FROM Donaciones   WHERE bd_id_donacion= @num ";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@num", g); //enviamos los paramet

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    String nombre = "" + reader.GetString(2) + " " + reader.GetString(4);
                    dt.Rows.Add(reader.GetInt32(0), reader.GetString(3),nombre);




                }

                tabla2.DataSource = dt;
                tabla2.DataBind();

            }

            else { error(Consulta_prestamo, "Disculpa", "No se encuentran donaciones con la informacion solicitado  en el sistema"); }
        }
       




        //******FUNCIONES PARA LA MODAL DE DETALLE****************************
        protected void close_Click(object sender, EventArgs e)
        {
            detalle.Visible = false;
        }

        protected void llenar_detalle(int y)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_id_donacion, bd_id_veneficiado,bd_fecha_salida FROM Donaciones  WHERE bd_id_donacion= @num ";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@num", y); //enviamos los paramet

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {


                    TextBox4.Text = reader.GetInt32(0).ToString();
                    TextBox5.Text = reader.GetString(1);
                    TextBox6.Text = reader.GetDateTime(2).ToString("dd/MM/yyyy");
                   


                }



            }

            else { error(Consulta_prestamo, "Disculpa", "No se pudo cargar el detalle  en el sistema"); }

        }

        //***FUNCIONES PARA LA MODAL DE descripcion****************************

        protected void calcular(int x)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_descripcion_donaciones FROM Donaciones  WHERE bd_id_donacion= @num ";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@num", x); //enviamos los paramet

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {


                    TextBox8.Text = reader.GetString(0);



                }



            }

            else { error(Consulta_prestamo, "Disculpa", "No se pudo realizar la accion de finalizar"); }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            finalizar.Visible = false;
        }



        //***FUNCIONES PARA LA MODAL contactar****************************

        protected void validar_prolongar(int y)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_nombre_veneficiado, bd_apellido1_veneficiado,bd_apellido2_veneficiado,bd_telefono_veneficiado FROM Donaciones  WHERE bd_id_donacion= @num ";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@num", y); //enviamos los paramet

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {


                    Nombre.Text = "" + reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2);
                    Telefono.Text = reader.GetString(3);





                }

            }




        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            prolongar.Visible = false;
        }


    }
}