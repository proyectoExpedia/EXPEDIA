
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
    public partial class gestionPrestamos : System.Web.UI.Page
    {

        private string departamento;
        private string descripcion;
        private string provedor;
        private string num;
        private string id_des;
        private string id_dep;
        private  static int id_finalizar;
        private static int id_prolongar;
        private static bool tiene=false;
        private static bool no_puede=false;
        private static bool atrasado = false;
        private static string ced;



        private bool bandera = false;
        private int id;

        static DataTable dt;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                cargar_area(departamento_activo);
                cargar_descripcion(descripcion_activo);
                cargar_proveedor(proveedor);
                dt = new DataTable();
                cargar();
                RangeValidator1.MinimumValue = DateTime.Now.ToString("yyyy/MM/dd");
                RangeValidator1.MaximumValue = "99/99/9999";

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
            if (!no_puede)
            {
                if (!tiene)
                {
                    if (tabla1.Rows.Count != 0)
                    {
                        if (corroborarExistenciaDatos("Usuarios", "bd_cedula", cedula_usuario.Text, Bt_Ingresar))
                        {


                            Crear_Prestamo(cedula_usuario.Text);
                            if (bandera == false)
                            {
                                Cargar_Id_Prestamo(cedula_usuario.Text);
                                Cargar_Activos(id, tab_logic_hover);
                                excelente(Bt_Ingresar);
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "Bt_Ingresar", "imprimePanel()", true);
                                Cambiar_Estado_usuario(2, cedula_usuario.Text);
                                limpiarIngresar();



                            }
                            else { error(Bt_Ingresar, "Disculpa", "Se tuvo un problema a la hora de crear el prestamo"); }


                            //System.Threading.Thread.Sleep(9000);


                        }
                    }
                    else { error(Bt_Ingresar, "Disculpa", "No hay ningun activos selecionados el prestamo"); }

                }
                else { Pendiente_detalle(cedula_usuario.Text); pendiente.Visible = true; }
            }
            else { error(Bt_Ingresar, "Disculpa", "El usuario esta inhabilitado, para más infomarcion vaya a gestion de usuarios en consultar"); }
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

                    if (reader.GetInt16(2) == 2) { Info.InnerText = "" + reader.GetString(0) + " " + reader.GetString(1) + " tiene prestamos pendientes"; Info.Style.Add("color", "red"); tiene = true; Pendiente_detalle(cedula_usuario.Text); pendiente.Visible = true; }
                    if (reader.GetInt16(2) == 1) { Info.InnerText = "" + reader.GetString(0) + " " + reader.GetString(1) + " no tiene prestamos pendientes "; Info.Style.Add("color", "green"); }
                    if (reader.GetInt16(2) == 3) { Info.InnerText = "" + reader.GetString(0) + " " + reader.GetString(1) + "se encuentra inhabilitado "; Info.Style.Add("color", "red");  no_puede = true; }


                }
            }
            else
            {
                Info.InnerText = "No existe ningun usuario con esa cedula"; Info.Style.Add("color", "red");

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



            Cambiar_Estado(3, tabla.Rows[e.RowIndex].Cells[1].Text.ToString());

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
            string Sql = @"UPDATE Activos SET bd_estado=" +y+ " WHERE bd_numero_placa='" +placa + "'";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.ExecuteNonQuery();


        }

        protected void Cambiar_Estado_usuario(int y, string placa)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"UPDATE Usuarios SET bd_estado=" + y + " WHERE bd_cedula='" + placa +"'";
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
                Fecha_regreso.Text = "";
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
                    string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE " + quien + "= @num  AND bd_departamento = @dpt AND bd_estado=1 AND bd_tipo_activo='Hardware'";
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
                    string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos WHERE " + quien + "= @num  AND bd_descripcion_activo = @dpt AND bd_estado=1 AND bd_tipo_activo='Hardware'";
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
                    string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE " + quien + "= @num  AND bd_proveedor = @dpt  AND bd_estado=1 AND bd_tipo_activo='Hardware'";
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
                    string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos WHERE " + quien + "= @num  AND bd_departamento=@dpt AND bd_descripcion_activo=@desc  AND bd_estado=1 AND bd_tipo_activo='Hardware'";
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
                    string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE " + quien + "=@num  AND bd_departamento =@dpt AND bd_descripcion_activo=@desc AND bd_proveedor=@pro  AND bd_estado=1 AND bd_tipo_activo='Hardware'";
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
                string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE  bd_departamento=@dpt  AND bd_estado=1 AND bd_tipo_activo='Hardware'";
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
                string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos WHERE  bd_proveedor=@dpt  AND bd_estado=1 AND bd_tipo_activo='Hardware'";
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
                string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE  bd_departamento=@dpt AND bd_descripcion_activo=@des  AND bd_proveedor=@pro  AND bd_estado=1 AND bd_tipo_activo='Hardware'";
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
                string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE  bd_departamento=@dpt AND bd_descripcion_activo=@des  AND bd_estado=1 AND bd_tipo_activo='Hardware' ";
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
                string Sql = @"SELECT bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE bd_descripcion_activo=@dpt  AND bd_estado=1 AND bd_tipo_activo='Hardware'";
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
                    string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE " + que + "=@num  AND bd_estado=1 AND bd_tipo_activo='Hardware'";
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
                string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE bd_descripcion_activo=@dpt AND bd_proveedor=@pro AND bd_estado=1 AND bd_tipo_activo='Hardware'";
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
                string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_descripcion_activo, bd_departamento,bd_proveedor, bd_especificacion_tecnica FROM Activos  WHERE  bd_departamento=@dpt AND bd_proveedor=@pro  AND bd_estado=1 AND bd_tipo_activo='Hardware'";
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



        //**** METODOS PARA REALIZAR LOS PRESTAMOS ********************


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
                cmd.Parameters.AddWithValue("@fecha_emision", Fecha_entrega.Text);
                cmd.Parameters.AddWithValue("@fecha_recepcion", Fecha_regreso.Text);

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

                string placa = row.Cells[1].Text.ToString();
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"UPDATE Activos SET bd_id_prestamo=" +y+ "WHERE bd_numero_placa='"+placa+"'";
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
                string Sql = @"SELECT bd_numero_placa,bd_descripcion_activo,bd_especificacion_tecnica FROM Activos  WHERE bd_id_prestamo=@num ";
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

        //****************** METODOS PARA LA PARTE DE CONTROL DE PRESTAMOS**********************************


        protected void cedula_consulta_TextChanged(object sender, EventArgs e)
        {

         
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();



            string Sql = @"SELECT bd_nombre, bd_apellido1, bd_estado FROM Usuarios WHERE bd_cedula = @user";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@user", cedula_consulta.Text); //enviamos los parametros


            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    if (reader.GetInt16(2) == 2) { Info2.InnerText = "" + reader.GetString(0) + " " + reader.GetString(1) + " tiene prestamos pendientes"; Info2.Style.Add("color", "red"); tiene = true;  }
                    if (reader.GetInt16(2) == 1) { Info2.InnerText = "" + reader.GetString(0) + " " + reader.GetString(1) + " no tiene prestamos pendientes "; Info2.Style.Add("color", "green"); }
                    if (reader.GetInt16(2) == 3) { Info2.InnerText = "" + reader.GetString(0) + " " + reader.GetString(1) + "se encuentra inhabilitado "; Info2.Style.Add("color", "red"); no_puede = true; }


                }
            }
            else
            {
                Info.InnerText = "No existe ningun usuario con esa cedula"; Info.Style.Add("color", "red");

            }


        }
        protected void Consulta_prestamo_Click(object sender, EventArgs e)
        {
            tiene = false;
            if (cedula_consulta.Text == "_-____-____" &&  id_prestamo.Text == "") { error(Consulta_prestamo, "Disculpa", "Utilice los filtros de busqueda para una mejor consulta"); }
            if (cedula_consulta.Text != "" && id_prestamo.Text == "") { Consultar_cedula(); }
            if (cedula_consulta.Text == "_-____-____" && id_prestamo.Text != "") { Consultar_id(); }
            if (cedula_consulta.Text != "" && id_prestamo.Text != "") { Consultar_cedula_id(); }

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
                case "Al_día":
                    {

                        string rowIndex = e.CommandArgument.ToString();

                        int index = Convert.ToInt32(rowIndex);
                        TableCell cell = tabla2.Rows[index].Cells[3];
                        TableCell cell1 = tabla2.Rows[index].Cells[4];
                        string cd = cell1.Text;

                        string pap = cell.Text;

                        int row = Convert.ToInt32(pap);
                        calcular(row,Faltan,TextBox8);
                        id_finalizar = row;
                        ced = cd;
                        finalizar.Visible = true;
                        tabla2.DataBind();

                        break;
                    }
                case "Prolongar": {

                        string rowIndex = e.CommandArgument.ToString();

                        int index = Convert.ToInt32(rowIndex);
                        TableCell cell = tabla2.Rows[index].Cells[3];
                       
                        string pap = cell.Text;

                        int row = Convert.ToInt32(pap);
                        id_prolongar = row;
                        validar_prolongar(row);
                        if (atrasado) { calcular(row,Label1, TextBox9); prolongar.Visible = true; }
                        else { error(prolongar1, "Disculpa", "Este prestamo ya esta retrasado por favor finalice y realice un prestamo nuevo"); }



                        break; }
            }




        }

        private void Consultar_cedula()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[3] {

                            new DataColumn("Identificador del préstamo", typeof(int)),
                            new DataColumn("Identificacíon del solicitante asosiado ",typeof(string)),
                            new DataColumn("Estado ",typeof(string)),








            });

            

            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT * FROM Prestamos  WHERE bd_id_solicitante= @num ";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@num", cedula_consulta.Text); //enviamos los paramet

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    DateTime date = reader.GetDateTime(3);
                    string t = DateTime.Now.ToString("yyyy/MM/dd");
                    string al = System.Drawing.Color.Green.ToString();
                    al = "Al día";
                    string at = System.Drawing.Color.Red.ToString();
                    at = "Atrasado";

                    DateTime date2 = DateTime.Parse(t);


                    int y = DateTime.Compare(date, date2);

                    if (y > 0 || y == 0)
                    { dt.Rows.Add(reader.GetInt32(0), reader.GetString(1), al); }
                    else { dt.Rows.Add(reader.GetInt32(0), reader.GetString(1), at); }




                }

                tabla2.DataSource = dt;
                tabla2.DataBind();

            }

            else { error(Consulta_prestamo, "Disculpa", "No se encuentran prestamos con el id solicitado  en el sistema"); }
        }
    
        private void Consultar_id()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[3] {

                            new DataColumn("Identificador del préstamo", typeof(int)),
                            new DataColumn("Identificacíon del solicitante asosiado ",typeof(string)),
                            new DataColumn("Estado ",typeof(string)),








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
                    DateTime date = reader.GetDateTime(3);
                    string t = DateTime.Now.ToString("yyyy/MM/dd");
                    string al = System.Drawing.Color.Green.ToString();
                    al = "Al día";
                    string at = System.Drawing.Color.Red.ToString();
                    at = "Atrasado";

                    DateTime date2 = DateTime.Parse(t);


                    int y = DateTime.Compare(date, date2);

                    if (y > 0 || y == 0)
                    { dt.Rows.Add(reader.GetInt32(0), reader.GetString(1), al); }
                    else { dt.Rows.Add(reader.GetInt32(0), reader.GetString(1), at); }




                }

                tabla2.DataSource = dt;
                tabla2.DataBind();

            }

            else { error(Consulta_prestamo, "Disculpa", "No se encuentran prestamos con la informacion solicitado  en el sistema"); }
        }
        private void Consultar_cedula_id()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[3] {

                            new DataColumn("Identificador del préstamo", typeof(int)),
                            new DataColumn("Identificacíon del solicitante asosiado ",typeof(string)),
                            new DataColumn("Estado ",typeof(string)),








            });

            int g = int.Parse(id_prestamo.Text);

            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT * FROM Prestamos  WHERE bd_id_prestamo= @num AND bd_id_solicitante= @ced ";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@num", g); //enviamos los paramet
            cmd.Parameters.AddWithValue("@ced", cedula_consulta.Text); //enviamos los paramet

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    DateTime date = reader.GetDateTime(3);
                    string t = DateTime.Now.ToString("yyyy/MM/dd");
                    string al = System.Drawing.Color.Green.ToString();
                    al = "Al día";
                    string at = System.Drawing.Color.Red.ToString();
                    at = "Atrasado";

                    DateTime date2 = DateTime.Parse(t);


                    int y = DateTime.Compare(date, date2);

                    if (y > 0 || y == 0)
                    { dt.Rows.Add(reader.GetInt32(0), reader.GetString(1), al); }
                    else { dt.Rows.Add(reader.GetInt32(0), reader.GetString(1), at); }




                }

                tabla2.DataSource = dt;
                tabla2.DataBind();

            }

            else { error(Consulta_prestamo, "Disculpa", "No se encuentran prestamos con la informacion solicitado  en el sistema"); }
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
            string Sql = @"SELECT * FROM Prestamos  WHERE bd_id_prestamo= @num ";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@num", y); //enviamos los paramet

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {


                    TextBox4.Text = reader.GetInt32(0).ToString(); 
                    TextBox5.Text = reader.GetString(1).ToString();
                    TextBox6.Text = reader.GetDateTime(2).ToString("dd/MM/yyyy");
                    TextBox7.Text = reader.GetDateTime(3).ToString("dd/MM/yyyy");


                }



            }

            else { error(Consulta_prestamo, "Disculpa", "No se pudo cargar el detalle  en el sistema"); }

        }

        //***FUNCIONES PARA LA MODAL FINALIZAR****************************

        protected void calcular(int x , HtmlGenericControl l , TextBox tx)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_fecha_recepcion FROM Prestamos  WHERE bd_id_prestamo= @num ";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@num", x); //enviamos los paramet

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {


                    DateTime date = reader.GetDateTime(0);
                    tx.Text = date.ToString("yyyy/MM/dd");
                    string t = DateTime.Now.ToString("yyyy/MM/dd");

                    DateTime date2 = DateTime.Parse(t);

                    
                    
                    int y = DateTime.Compare(date, date2);

                    if (y > 0) { l.InnerText = "Faltan " + y + " dias restantes para finalizar préstamo"; l.Style.Add("color", "green"); }

                    if (y == 0) { l.InnerText = "Faltan " + y + " dias restantes para finalizar préstamo"; l.Style.Add("color", "green"); }
                    if (y < 0) { l.InnerText = "Entrega del prestamo tarde por  " + y + " dias "; l.Style.Add("color", "red"); }



                }



            }

            else { error(Consulta_prestamo, "Disculpa", "No se pudo realizar la accion de finalizar"); }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            finalizar.Visible = false;
        }

        protected void Finalizar1_Click(object sender, EventArgs e)
        {
            try
            {
                regresar_ativos();
                eliminar_prestamo();
                Cambiar_Estado_usuario(1, ced);
                excelente(Finalizar1);
                
          
            }
            catch{ error(Finalizar1, "Disculpa", "no se pudo realizar la accion "); }
        }

        protected void regresar_ativos()
        {

            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"UPDATE Activos SET bd_id_prestamo=NULL , bd_estado= 1   WHERE bd_id_prestamo=@fech";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@fech", id_finalizar);
            cmd.ExecuteNonQuery();
        }

        protected void eliminar_prestamo()
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"DELETE FROM Prestamos WHERE bd_id_prestamo=@fin";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@fin",id_finalizar);
            cmd.ExecuteNonQuery();
        }

        //***FUNCIONES PARA LA MODAL PROLONGAR****************************

        protected void validar_prolongar(int y)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_fecha_recepcion FROM Prestamos  WHERE bd_id_prestamo= @num ";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@num", y); //enviamos los paramet

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {


                    DateTime date = reader.GetDateTime(0);
                    TextBox8.Text = date.ToString("dd/MM/yyyy");
                    string t = DateTime.Now.ToString("yyyy/MM/dd");

                    DateTime date2 = DateTime.Parse(t);


                    int x = DateTime.Compare(date, date2);

                    if (x > 0) { atrasado = true; }

                    if (x == 0) { atrasado = true; }
                    if (x < 0) { atrasado =false; }



                }

            }
            

           

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            prolongar.Visible = false;
        }

        protected void prolongar1_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"UPDATE Prestamos SET  bd_fecha_recepcion=@fech    WHERE bd_id_prestamo=" + id_prolongar + "";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@fech", TextBox10.Text);
                cmd.ExecuteNonQuery();
                excelente(prolongar1);

            }
            catch
            {       error(prolongar1, "Disculpa", "no se pudo realizar la accion "); }
        }


    }
}