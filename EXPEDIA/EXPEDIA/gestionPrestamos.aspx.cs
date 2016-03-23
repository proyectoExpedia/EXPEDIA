
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
        private string descripcion;
        private string provedor;
        private string num;
        private string id_des;
        private string id_dep;
 
      
        
        private bool bandera = false;
        private int id;

       static DataTable dt ;


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

            if (Session["Usuario"] == "Inicio")
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

            if (tabla1.Rows.Count != 0)
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
            else { error(Bt_Ingresar, "Disculpa", "No hay ningun activos selecionados el prestamo"); }
        }

        protected void cedula_usuario_TextChanged(object sender, EventArgs e)
        {
            string ced = cedula_usuario.Text;
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();



            string Sql = @"SELECT bd_nombre, bd_apellido1,  bd_telefono  FROM Usuarios WHERE bd_cedula = @user";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            cmd.Parameters.AddWithValue("@user", ced); //enviamos los parametros

           
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    Info.InnerText = "" + reader.GetString(0) + " " + reader.GetString(1) + "  Tel: " + reader.GetString(2);

                }


            }
            else
            {
                Info.InnerText = "No existe ningun usuario con esa cedula";

            }


        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            idiv.Visible = true;
            theDiv.Visible = false;
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



            Cambiar_Estado(3, tabla.Rows[e.RowIndex].Cells[1].Text);

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
                    string Sql = @"SELECT * FROM Activos  WHERE " + quien + "= @num  AND bd_departamento = @dpt AND bd_estado=1";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Retornar_Departamento(reader.GetString(5));
                            Retornar_Descripcion(reader.GetString(4));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7));
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
                    string Sql = @"SELECT * FROM Activos  WHERE " + quien + "= @num  AND bd_descripcion_activo = @dpt AND bd_estado=1";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", descripcion); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Retornar_Departamento(reader.GetString(5));
                            Retornar_Descripcion(reader.GetString(4));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7));
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
                    string Sql = @"SELECT * FROM Activos  WHERE " + quien + "= @num  AND bd_proveedor = @dpt  AND bd_estado=1";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", provedor); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Retornar_Departamento(reader.GetString(5));
                            Retornar_Descripcion(reader.GetString(4));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7));
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
                    string Sql = @"SELECT * FROM Activos  WHERE " + quien + "= @num  AND bd_departamento=@dpt AND bd_descripcion_activo=@desc  AND bd_estado=1";
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

                            Retornar_Departamento(reader.GetString(5));
                            Retornar_Descripcion(reader.GetString(4));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7));
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
                    string Sql = @"SELECT * FROM Activos  WHERE " + quien + "=@num  AND bd_departamento =@dpt AND bd_descripcion_activo=@desc AND bd_proveedor=@pro  AND bd_estado=1";
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

                            Retornar_Departamento(reader.GetString(5));
                            Retornar_Descripcion(reader.GetString(4));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7));
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
                string Sql = @"SELECT * FROM Activos  WHERE  bd_departamento=@dpt  AND bd_estado=1";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Departamento(reader.GetString(5));
                        Retornar_Descripcion(reader.GetString(4));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7));
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
                string Sql = @"SELECT * FROM Activos  WHERE  bd_proveedor=@dpt  AND bd_estado=1";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", provedor); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Departamento(reader.GetString(5));
                        Retornar_Descripcion(reader.GetString(4));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7));
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
                string Sql = @"SELECT * FROM Activos  WHERE  bd_departamento=@dpt AND bd_descripcion_activo=@des  AND bd_proveedor=@pro  AND bd_estado=1";
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

                        Retornar_Departamento(reader.GetString(5));
                        Retornar_Descripcion(reader.GetString(4));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7));
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
                string Sql = @"SELECT * FROM Activos  WHERE  bd_departamento=@dpt AND bd_descripcion_activo=@des  AND bd_estado=1 ";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                cmd.Parameters.AddWithValue("@des", descripcion); //enviamos los paramet


                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Departamento(reader.GetString(5));
                        Retornar_Descripcion(reader.GetString(4));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7));
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
                string Sql = @"SELECT * FROM Activos  WHERE bd_descripcion_activo=@dpt  AND bd_estado=1";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", descripcion); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Departamento(reader.GetString(5));
                        Retornar_Descripcion(reader.GetString(4));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7));
                    }

                    tabla.DataSource = dt;
                    tabla.DataBind();
                }
                else { error(Consultar1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Numero(string que , int cuantas)
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
                    string Sql = @"SELECT * FROM Activos  WHERE " + que + "=@num  AND bd_estado=1";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("num", num); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Retornar_Departamento(reader.GetString(5));
                            Retornar_Descripcion(reader.GetString(4));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7));
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
                string Sql = @"SELECT * FROM Activos  WHERE bd_descripcion_activo=@dpt AND bd_proveedor=@pro AND bd_estado=1";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", descripcion); //enviamos los paramet
                cmd.Parameters.AddWithValue("@pro", provedor); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Departamento(reader.GetString(5));
                        Retornar_Descripcion(reader.GetString(4));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7));
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
                string Sql = @"SELECT * FROM Activos  WHERE  bd_departamento=@dpt AND bd_proveedor=@pro  AND bd_estado=1";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                cmd.Parameters.AddWithValue("@pro", provedor); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Departamento(reader.GetString(5));
                        Retornar_Descripcion(reader.GetString(4));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7));
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

            dt.Columns.AddRange(new DataColumn[5] {

                            new DataColumn("Identificador del préstamo", typeof(int)),
                            new DataColumn("Identificacíon del solicitante asosiado ",typeof(string)),
                            new DataColumn("Detalle ",typeof(Button)),
                            new DataColumn("Al día ",typeof(Button)),
                            new DataColumn("¿Finalizo?",typeof(Button)),







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

            else { error(Consulta_prestamo, "Disculpa", "No se encuentran prestamos con el id solicitado  en el sistema"); }

        }


        protected void tabla2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            switch (e.CommandName)
            {
                case "Detalle": {  break; }
                case "Al_día": { break; }
                case "Finalizo": { break; }
                case "Prolongar": {Panel5 .Visible = true; break; }

            }

        }

      


    }
}