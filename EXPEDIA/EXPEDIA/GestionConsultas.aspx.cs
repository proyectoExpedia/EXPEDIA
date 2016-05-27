using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EXPEDIA
{
    public partial class GestionConsultas : System.Web.UI.Page
    {
        private string tipo;
        private string departamento;
        private string descripcion;
        private string provedor;
        private string num;
        private string id_des;
        private string id_dep;
        private int y;
        private List<String> Bitacora_Activos_Leasing = new List<string>();
        private List<String> Bitacora_Activos_Corporativos = new List<string>();
        private List<String> Bitacora_Usuarios = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
      
                if (Session["Usuario"] == "Inicio")
                {
                    Session["Usuario"] = "Anonimo";
                    Response.Redirect("index.aspx");
                }
            
            y = 0;
            if (!IsPostBack)
            {
                
                cargar_area(departamento_activo);
                cargar_descripcion(descripcion_activo);
                cargar_proveedor(proveedor);
                Crear_Bitacoras();
            }

        }

        //** METODOS ESPECIFICOS PARA BOTONES*****
        protected void Consultar_Click(object sender, EventArgs e)
        {

            if (RadioButton2.Checked) { tipo = RadioButton2.Text; }
            if (RadioButton3.Checked) {tipo = RadioButton3.Text;}
          

            if (!RadioButton2.Checked && !RadioButton3.Checked && !RadioButton4.Checked)
            { error(Button1, "Disculpa", "Debe de selecionar un tipo de activo para una mejor consulta"); }


            if (RadioButton2.Checked || RadioButton3.Checked)
            {
                RadioButton2.Checked = false;
                RadioButton3.Checked = false;
                

                num = numero.Text;
                departamento = Seleciono_Departamento();
                descripcion = Seleciono_Descripcion();
                provedor = Seleciono_proveedor();
                if ((departamento == null) && (numero.Text == "") && (descripcion == null) && (provedor == null)) { Consultar_todo(); }
                if ((departamento != null) && (numero.Text != "") && (descripcion == null) && (provedor == null)) { Consulta_Despartamento_Numero("bd_numero_placa", y, tipo); }
                if ((departamento != null) && (numero.Text == "") && (descripcion == null) && (provedor == null)) { Consulta_Despartamento(tipo); }
                if ((departamento != null) && (numero.Text != "") && (descripcion != null) && (provedor == null)) { Consulta_Despartamento_Numero_descripcion("bd_numero_placa", y, tipo); }
                if ((departamento == null) && (numero.Text == "") && (descripcion != null) && (provedor == null)) { Consulta_Descripcion(tipo); }
                if ((departamento == null) && (numero.Text != "") && (descripcion != null) && (provedor == null)) { Consulta_Descripcion_Numero("bd_numero_placa", y, tipo); }
                if ((departamento != null) && (numero.Text != "") && (descripcion != null) && (provedor != null)) { Consulta_Despartamento_Numero_descripcion_proveedor("bd_numero_placa", y, tipo); }
                if ((departamento != null) && (numero.Text == "") && (descripcion != null) && (provedor != null)) { Consulta_Despartamento_descripcion_proveedor(tipo); }
                if ((departamento == null) && (numero.Text == "") && (descripcion != null) && (provedor != null)) { Consulta_Descripcion_proveedor(tipo); }
                if ((departamento != null) && (numero.Text == "") && (descripcion == null) && (provedor != null)) { Consulta_Despartamento_proveedor(tipo); }
                if ((departamento == null) && (numero.Text != "") && (descripcion == null) && (provedor != null)) { Consulta_Proveedor_Numero("bd_numero_placa", y, tipo); }
                if ((departamento == null) && (numero.Text == "") && (descripcion == null) && (provedor != null)) { Consulta_Proveedor(tipo); }
                if ((departamento == null) && (numero.Text != "") && (descripcion == null) && (provedor == null)) { Consulta_Numero("bd_numero_placa", y, tipo); }
                if ((departamento != null) && (numero.Text == "") && (descripcion != null) && (provedor == null)) { Consulta_Despartamento_descripcion(tipo); }
            }



            if (RadioButton4.Checked)
            {
                
                RadioButton4.Checked = false;
                num = numero.Text;
                departamento = Seleciono_Departamento();
                descripcion = Seleciono_Descripcion();
                provedor = Seleciono_proveedor();
                if ((departamento == null) && (numero.Text == "") && (descripcion == null) && (provedor == null)) { Consultar_todo_leasing(); }
                if ((departamento != null) && (numero.Text != "") && (descripcion == null) && (provedor == null)) { Consulta_Despartamento_Numero_leasing("bd_numero_placa", y); }
                if ((departamento != null) && (numero.Text == "") && (descripcion == null) && (provedor == null)) { Consulta_Despartamento_leasing(); }
                if ((departamento != null) && (numero.Text != "") && (descripcion != null) && (provedor == null)) { Consulta_Despartamento_Numero_descripcion_leasing("bd_numero_placa", y); }
                if ((departamento == null) && (numero.Text == "") && (descripcion != null) && (provedor == null)) { Consulta_Descripcion_leasing(); }
                if ((departamento == null) && (numero.Text != "") && (descripcion != null) && (provedor == null)) { Consulta_Descripcion_Numero_leasing("bd_numero_placa", y); }
                if ((departamento != null) && (numero.Text != "") && (descripcion != null) && (provedor != null)) { Consulta_Despartamento_Numero_descripcion_proveedor_leasing("bd_numero_placa", y); }
                if ((departamento != null) && (numero.Text == "") && (descripcion != null) && (provedor != null)) { Consulta_Despartamento_descripcion_proveedor_leasing(); }
                if ((departamento == null) && (numero.Text == "") && (descripcion != null) && (provedor != null)) { Consulta_Descripcion_proveedor_leasing(); }
                if ((departamento != null) && (numero.Text == "") && (descripcion == null) && (provedor != null)) { Consulta_Despartamento_proveedor_leasing(); }
                if ((departamento == null) && (numero.Text != "") && (descripcion == null) && (provedor != null)) { Consulta_Proveedor_Numero_leasing("bd_numero_placa", y); }
                if ((departamento == null) && (numero.Text == "") && (descripcion == null) && (provedor != null)) { Consulta_Proveedor_leasing(); }
                if ((departamento == null) && (numero.Text != "") && (descripcion == null) && (provedor == null)) { Consulta_Numero_leasing("bd_numero_placa", y); }
                if ((departamento != null) && (numero.Text == "") && (descripcion != null) && (provedor == null)) { Consulta_Despartamento_descripcion_leasing(); }
            }

        }
        protected void exportar_Click(object sender, EventArgs e)
        {
            ExportToExcel("Informe.xls", lista);
        }
        private void ExportToExcel(string nameReport, GridView wControl)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            form.Controls.Add(wControl);
            pageToRender.Controls.Add(form);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport);
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            response.Write(sw.ToString());
            response.End();
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

        //****** CONSULTAS DE TIPO SOFTWARE Y HARDWARE*********************
        protected void Consultar_todo()
        {

            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[12] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de inicio de garantia ",typeof(string)),
                            new DataColumn(" Fecha de duracion de garantia ",typeof(string)),
                           new DataColumn(" Fecha  de compra ",typeof(string)),
                          new DataColumn(" Costo del activo ",typeof(string)),
                          new DataColumn(" Estado del activo ",typeof(string)),



            });


            try
            {

                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT   bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia , bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica , bd_fecha_compra, bd_costo_activo, bd_estado  FROM Activos  WHERE  bd_tipo_activo=@num";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@num", tipo); //enviamos los paramet



                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(5));
                        Retornar_Departamento(reader.GetString(6));
                        string estado = "";
                        if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                        if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                        if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                        if (reader.GetInt16(11) == 4) { estado = "Donado"; }


                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(7), reader.GetString(8), reader.GetDateTime(3).ToString("yyyy/MM/dd"), reader.GetDateTime(4).ToString("yyyy/MM/dd"), reader.GetDateTime(9).ToString("yyyy/MM/dd"), reader.GetInt32(10).ToString(), estado);
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
                else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }

            }
            catch (Exception a){ Response.Write(a); }
            }
        
        protected void Consulta_Despartamento_Numero(string quien, int cuantas,string tip)
        {
          

            if (cuantas < 2)
            {

                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[12] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de inicio de garantia ",typeof(string)),
                            new DataColumn(" Fecha de duracion de garantia ",typeof(string)),
                           new DataColumn(" Fecha  de compra ",typeof(string)),
                          new DataColumn(" Costo del activo ",typeof(string)),
                          new DataColumn(" Estado del activo ",typeof(string)),



            });


                try
                {

                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT   bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia , bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica , bd_fecha_compra, bd_costo_activo, bd_estado  FROM Activos  WHERE " + quien + "= @num  AND bd_departamento = @dpt  AND bd_tipo_activo=@tip";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@tip", tip); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Retornar_Descripcion(reader.GetString(5));
                            Retornar_Departamento(reader.GetString(6));
                            string estado = "";
                            
                            if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                            if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                            if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                            if (reader.GetInt16(11) == 4) { estado = "Donado"; }


                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(7), reader.GetString(8), reader.GetDateTime(3).ToString("yyyy/MM/dd"), reader.GetDateTime(4).ToString("yyyy/MM/dd"), reader.GetDateTime(9).ToString("yyyy/MM/dd"), reader.GetInt32(10).ToString(),estado);
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero("bd_numero_serie", cuantas,tip); }
                }
                catch (Exception a) { Response.Write(a); }
            }

            else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }


        }
        protected void Consulta_Descripcion_Numero(string quien, int cuantas, string tip)
        {

            if (cuantas < 2)
            {

                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[12] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de inicio de garantia ",typeof(string)),
                            new DataColumn(" Fecha de duracion de garantia ",typeof(string)),
                           new DataColumn(" Fecha  de compra ",typeof(string)),
                          new DataColumn(" Costo del activo ",typeof(string)),
                          new DataColumn(" Estado del activo ",typeof(string)),



            });


                try
                {

                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT   bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia , bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica , bd_fecha_compra, bd_costo_activo, bd_estado  FROM Activos WHERE " + quien + "= @num  AND bd_descripcion_activo = @dpt AND bd_tipo_activo=@tip";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", descripcion); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@tip", tip); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Retornar_Descripcion(reader.GetString(5));
                            Retornar_Departamento(reader.GetString(6));
                            string estado = "";
                            if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                            if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                            if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                            if (reader.GetInt16(11) == 4) { estado = "Donado"; }


                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(7), reader.GetString(8), reader.GetDateTime(3).ToString("yyyy/MM/dd"), reader.GetDateTime(4).ToString("yyyy/MM/dd"), reader.GetDateTime(9).ToString("yyyy/MM/dd"), reader.GetInt32(10).ToString(), estado);
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero("bd_numero_serie", cuantas,tip); }
                }
                catch (Exception a) { Response.Write(a); }
            }
            else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }


        }
        protected void Consulta_Proveedor_Numero(string quien, int cuantas, string tip)
        {

            if (cuantas < 2)
            {

                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[12] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de inicio de garantia ",typeof(string)),
                            new DataColumn(" Fecha de duracion de garantia ",typeof(string)),
                           new DataColumn(" Fecha  de compra ",typeof(string)),
                          new DataColumn(" Costo del activo ",typeof(string)),
                          new DataColumn(" Estado del activo ",typeof(string)),



            });


                try
                {

                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT SELECT   bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia , bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica , bd_fecha_compra, bd_costo_activo, bd_estado  FROM Activos  WHERE " + quien + "= @num  AND bd_proveedor = @dpt AND bd_tipo_activo=@tip";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", provedor); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@tip", tip); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Retornar_Descripcion(reader.GetString(5));
                            Retornar_Departamento(reader.GetString(6));
                            string estado = "";
                            if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                            if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                            if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                            if (reader.GetInt16(11) == 4) { estado = "Donado"; }


                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(7), reader.GetString(8), reader.GetDateTime(3).ToString("yyyy/MM/dd"), reader.GetDateTime(4).ToString("yyyy/MM/dd"), reader.GetDateTime(9).ToString("yyyy/MM/dd"), reader.GetInt32(10).ToString(), estado);
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero("bd_numero_serie", cuantas,tip); }
                }
                catch (Exception a) { Response.Write(a); }
            }
            else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }


        }
        protected void Consulta_Despartamento_Numero_descripcion(string quien, int cuantas, string tip)
        {

            if (cuantas < 2)
            {

                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[12] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de inicio de garantia ",typeof(string)),
                            new DataColumn(" Fecha de duracion de garantia ",typeof(string)),
                           new DataColumn(" Fecha  de compra ",typeof(string)),
                          new DataColumn(" Costo del activo ",typeof(string)),
                          new DataColumn(" Estado del activo ",typeof(string)),



            });


                try
                {

                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT   bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia , bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica , bd_fecha_compra, bd_costo_activo, bd_estado  FROM Activos WHERE " + quien + "= @num  AND bd_departamento=@dpt AND bd_descripcion_activo=@desc AND bd_tipo_activo=@tip";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@desc", descripcion); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@tip", tip); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Retornar_Descripcion(reader.GetString(5));
                            Retornar_Departamento(reader.GetString(6));
                            string estado = "";
                            if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                            if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                            if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                            if (reader.GetInt16(11) == 4) { estado = "Donado"; }


                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(7), reader.GetString(8), reader.GetDateTime(3).ToString("yyyy/MM/dd"), reader.GetDateTime(4).ToString("yyyy/MM/dd"), reader.GetDateTime(9).ToString("yyyy/MM/dd"), reader.GetInt32(10).ToString(), estado);
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero("bd_numero_serie", cuantas,tip); }
                }
                catch (Exception a) { Response.Write(a); }
            }

            else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }


        }
        protected void Consulta_Despartamento_Numero_descripcion_proveedor(string quien, int cuantas, string tip)
        {

            if (cuantas < 2)
            {

                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[12] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de inicio de garantia ",typeof(string)),
                            new DataColumn(" Fecha de duracion de garantia ",typeof(string)),
                           new DataColumn(" Fecha  de compra ",typeof(string)),
                          new DataColumn(" Costo del activo ",typeof(string)),
                          new DataColumn(" Estado del activo ",typeof(string)),



            });


                try
                {

                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT   bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia , bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica , bd_fecha_compra, bd_costo_activo, bd_estado  FROM Activos  WHERE " + quien + "=@num  AND bd_departamento =@dpt AND bd_descripcion_activo=@desc AND bd_proveedor=@pro AND bd_tipo_activo=@tip";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@desc", descripcion); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@pro", provedor); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@tip", tip); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Retornar_Descripcion(reader.GetString(5));
                            Retornar_Departamento(reader.GetString(6));
                            string estado = "";
                            if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                            if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                            if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                            if (reader.GetInt16(11) == 4) { estado = "Donado"; }


                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(7), reader.GetString(8), reader.GetDateTime(3).ToString("yyyy/MM/dd"), reader.GetDateTime(4).ToString("yyyy/MM/dd"), reader.GetDateTime(9).ToString("yyyy/MM/dd"), reader.GetInt32(10).ToString(), estado);
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero("bd_numero_serie", cuantas,tip); }
                }
                catch (Exception a) { Response.Write(a); }
            }

            else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }

        }
        protected void Consulta_Despartamento(string tip)
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[12] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de inicio de garantia ",typeof(string)),
                            new DataColumn(" Fecha de duracion de garantia ",typeof(string)),
                           new DataColumn(" Fecha  de compra ",typeof(string)),
                          new DataColumn(" Costo del activo ",typeof(string)),
                          new DataColumn(" Estado del activo ",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT   bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia , bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica , bd_fecha_compra, bd_costo_activo, bd_estado  FROM Activos WHERE  bd_departamento=@dpt AND bd_tipo_activo=@tip ";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                cmd.Parameters.AddWithValue("@tip", tip); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(5));
                        Retornar_Departamento(reader.GetString(6));
                        string estado = "";
                        int x = reader.GetInt16(11);
                        if ( x == 1) { estado = "Alta"; }
                        if (x == 2) { estado = "Baja"; }
                        if (x == 3) { estado = "Prestado"; }
                        if (x == 4) { estado = "Donado"; }


                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(7), reader.GetString(8), reader.GetDateTime(3).ToString("yyyy/MM/dd"), reader.GetDateTime(4).ToString("yyyy/MM/dd"), reader.GetDateTime(9).ToString("yyyy/MM/dd"), reader.GetInt32(10).ToString(), estado);
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
                else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Proveedor(string tip)
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[12] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de inicio de garantia ",typeof(string)),
                            new DataColumn(" Fecha de duracion de garantia ",typeof(string)),
                           new DataColumn(" Fecha  de compra ",typeof(string)),
                          new DataColumn(" Costo del activo ",typeof(string)),
                          new DataColumn(" Estado del activo ",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT   bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia , bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica , bd_fecha_compra, bd_costo_activo, bd_estado  FROM Activos  WHERE  bd_proveedor=@dpt AND bd_tipo_activo=@tip";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", provedor); //enviamos los paramet
                cmd.Parameters.AddWithValue("@tip", tip); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(5));
                        Retornar_Departamento(reader.GetString(6));
                        string estado = "";
                        if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                        if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                        if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                        if (reader.GetInt16(11) == 4) { estado = "Donado"; }


                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(7), reader.GetString(8), reader.GetDateTime(3).ToString("yyyy/MM/dd"), reader.GetDateTime(4).ToString("yyyy/MM/dd"), reader.GetDateTime(9).ToString("yyyy/MM/dd"), reader.GetInt32(10).ToString(), estado);
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
                else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Despartamento_descripcion_proveedor(string tip)
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[12] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de inicio de garantia ",typeof(string)),
                            new DataColumn(" Fecha de duracion de garantia ",typeof(string)),
                           new DataColumn(" Fecha  de compra ",typeof(string)),
                          new DataColumn(" Costo del activo ",typeof(string)),
                          new DataColumn(" Estado del activo ",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT   bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia , bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica , bd_fecha_compra, bd_costo_activo, bd_estado  FROM Activos WHERE  bd_departamento=@dpt AND bd_descripcion_activo=@des  AND bd_proveedor=@pro AND bd_tipo_activo=@tip";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                cmd.Parameters.AddWithValue("@des", descripcion); //enviamos los paramet
                cmd.Parameters.AddWithValue("@pro", provedor); //enviamos los paramet
                cmd.Parameters.AddWithValue("@tip", tip); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(5));
                        Retornar_Departamento(reader.GetString(6));
                        string estado = "";
                        if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                        if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                        if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                        if (reader.GetInt16(11) == 4) { estado = "Donado"; }


                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(7), reader.GetString(8), reader.GetDateTime(3).ToString("yyyy/MM/dd"), reader.GetDateTime(4).ToString("yyyy/MM/dd"), reader.GetDateTime(9).ToString("yyyy/MM/dd"), reader.GetInt32(10).ToString(), estado);
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
                else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Despartamento_descripcion(string tip)
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[12] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de inicio de garantia ",typeof(string)),
                            new DataColumn(" Fecha de duracion de garantia ",typeof(string)),
                           new DataColumn(" Fecha  de compra ",typeof(string)),
                          new DataColumn(" Costo del activo ",typeof(string)),
                          new DataColumn(" Estado del activo ",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT   bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia , bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica , bd_fecha_compra, bd_costo_activo, bd_estado  FROM Activos WHERE  bd_departamento=@dpt AND bd_descripcion_activo=@des AND bd_tipo_activo=@tip ";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                cmd.Parameters.AddWithValue("@des", descripcion); //enviamos los paramet
                cmd.Parameters.AddWithValue("@tip", tip); //enviamos los paramet


                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(5));
                        Retornar_Departamento(reader.GetString(6));
                        string estado = "";
                        if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                        if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                        if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                        if (reader.GetInt16(11) == 4) { estado = "Donado"; }


                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(7), reader.GetString(8), reader.GetDateTime(3).ToString("yyyy/MM/dd"), reader.GetDateTime(4).ToString("yyyy/MM/dd"), reader.GetDateTime(9).ToString("yyyy/MM/dd"), reader.GetInt32(10).ToString(), estado);
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
                else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Descripcion(string tip)
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[12] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de inicio de garantia ",typeof(string)),
                            new DataColumn(" Fecha de duracion de garantia ",typeof(string)),
                           new DataColumn(" Fecha  de compra ",typeof(string)),
                          new DataColumn(" Costo del activo ",typeof(string)),
                          new DataColumn(" Estado del activo ",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT   bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia , bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica , bd_fecha_compra, bd_costo_activo, bd_estado  FROM Activos WHERE bd_descripcion_activo=@dpt AND bd_tipo_activo=@tip";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", descripcion); //enviamos los paramet
                cmd.Parameters.AddWithValue("@tip", tip); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(5));
                        Retornar_Departamento(reader.GetString(6));
                        string estado = "";
                        if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                        if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                        if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                        if (reader.GetInt16(11) == 4) { estado = "Donado"; }


                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(7), reader.GetString(8), reader.GetDateTime(3).ToString("yyyy/MM/dd"), reader.GetDateTime(4).ToString("yyyy/MM/dd"), reader.GetDateTime(9).ToString("yyyy/MM/dd"), reader.GetInt32(10).ToString(), estado);
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
                else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Numero(string quien,int cuantas ,string tip)
        {
            if (cuantas < 2)
            {
                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[12] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de inicio de garantia ",typeof(string)),
                            new DataColumn(" Fecha de duracion de garantia ",typeof(string)),
                           new DataColumn(" Fecha  de compra ",typeof(string)),
                          new DataColumn(" Costo del activo ",typeof(string)),
                          new DataColumn(" Estado del activo ",typeof(string)),



            });


                try
                {
                    string num = numero.Text;
                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT   bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia , bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica , bd_fecha_compra, bd_costo_activo, bd_estado  FROM Activos WHERE " + quien + "=@num  AND bd_tipo_activo=@tip";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@tip", tip); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Retornar_Descripcion(reader.GetString(5));
                            Retornar_Departamento(reader.GetString(6));
                            string estado = "";
                            if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                            if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                            if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                            if (reader.GetInt16(11) == 4) { estado = "Donado"; }


                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(7), reader.GetString(8), reader.GetDateTime(3).ToString("yyyy/MM/dd"), reader.GetDateTime(4).ToString("yyyy/MM/dd"), reader.GetDateTime(9).ToString("yyyy/MM/dd"), reader.GetInt32(10).ToString(), estado);
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                    else { cuantas++; Consulta_Numero("bd_numero_serie", cuantas,tip); }
                }
                catch (Exception a) { Response.Write(a); }

            }
            else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }
        }
        protected void Consulta_Descripcion_proveedor(string tip)
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[12] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de inicio de garantia ",typeof(string)),
                            new DataColumn(" Fecha de duracion de garantia ",typeof(string)),
                           new DataColumn(" Fecha  de compra ",typeof(string)),
                          new DataColumn(" Costo del activo ",typeof(string)),
                          new DataColumn(" Estado del activo ",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT   bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia , bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica , bd_fecha_compra, bd_costo_activo, bd_estado  FROM Activos WHERE bd_descripcion_activo=@dpt AND bd_proveedor=@pro AND bd_tipo_activo=@tip";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", descripcion); //enviamos los paramet
                cmd.Parameters.AddWithValue("@pro", provedor); //enviamos los paramet
                cmd.Parameters.AddWithValue("@tip", tip); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(5));
                        Retornar_Departamento(reader.GetString(6));
                        string estado = "";
                        if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                        if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                        if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                        if (reader.GetInt16(11) == 4) { estado = "Donado"; }


                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(7), reader.GetString(8), reader.GetDateTime(3).ToString("yyyy/MM/dd"), reader.GetDateTime(4).ToString("yyyy/MM/dd"), reader.GetDateTime(9).ToString("yyyy/MM/dd"), reader.GetInt32(10).ToString(), estado);
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
                else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Despartamento_proveedor(string tip)
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[12] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de inicio de garantia ",typeof(string)),
                            new DataColumn(" Fecha de duracion de garantia ",typeof(string)),
                           new DataColumn(" Fecha  de compra ",typeof(string)),
                          new DataColumn(" Costo del activo ",typeof(string)),
                          new DataColumn(" Estado del activo ",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT   bd_tipo_activo, bd_numero_placa , bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia , bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica , bd_fecha_compra, bd_costo_activo, bd_estado  FROM Activos  WHERE  bd_departamento=@dpt AND bd_proveedor=@pro AND bd_tipo_activo=@tip";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                cmd.Parameters.AddWithValue("@pro", provedor); //enviamos los paramet
                cmd.Parameters.AddWithValue("@tip", tip); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(5));
                        Retornar_Departamento(reader.GetString(6));
                        string estado = "";
                        if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                        if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                        if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                        if (reader.GetInt16(11) == 4) { estado = "Donado"; }


                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(7), reader.GetString(8), reader.GetDateTime(3).ToString("yyyy/MM/dd"), reader.GetDateTime(4).ToString("yyyy/MM/dd"), reader.GetDateTime(9).ToString("yyyy/MM/dd"), reader.GetInt32(10).ToString(), estado);
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
                else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }
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


        //*******CONSULTAS DE TIPO LEASING**************************


        protected void Consultar_todo_leasing()
        {


            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de adquisición ",typeof(string)),
                            new DataColumn(" Fecha de finalizacion ",typeof(string)),
                           new DataColumn(" Costo del activo",typeof(string)),
                          new DataColumn("Estado del activo",typeof(string)),



            });


            try
            {

                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT  bd_tipo_activo,   bd_numero_placa , bd_numero_serie,  bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica ,bd_aquisicion_ac,bd_finalizacion_contrato, bd_costo_activo, bd_estado  FROM Activos WHERE  bd_tipo_activo=@num";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@num", "Leasing"); //enviamos los paramet




                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(3));
                        Retornar_Departamento(reader.GetString(4));
                        string estado = "";
                        if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                        if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                        if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                        if (reader.GetInt16(11) == 4) { estado = "Donado"; }
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6), reader.GetDateTime(7).ToString("yyyy/MM/dd"), reader.GetDateTime(8).ToString("yyyy/MM/dd"), reader.GetInt32(9).ToString(), estado);
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
                error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind();

            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Despartamento_Numero_leasing(string quien, int cuantas)
        {

            if (cuantas < 2)
            {

                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de adquisición ",typeof(string)),
                            new DataColumn(" Fecha de finalizacion ",typeof(string)),
                           new DataColumn(" Costo del activo",typeof(string)),
                          new DataColumn("Estado del activo",typeof(string)),



            });


                try
                {
                   

                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa ,bd_numero_serie, bd_descripcion_activo,bd_departamento,bd_proveedor, bd_especificacion_tecnica ,bd_aquisicion_ac, bd_finalizacion_contrato, bd_costo_activo, bd_estado  FROM Activos  WHERE " + quien + "= @num  AND bd_departamento = @dpt  AND bd_tipo_activo='Leasing'";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Retornar_Descripcion(reader.GetString(3));
                            Retornar_Departamento(reader.GetString(4));
                            string estado = "";
                            if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                            if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                            if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                            if (reader.GetInt16(11) == 4) { estado = "Donado"; }
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6), reader.GetDateTime(7).ToString("yyyy/MM/dd"), reader.GetDateTime(8).ToString("yyyy/MM/dd"),reader.GetInt32(9).ToString(),estado);
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero_leasing("bd_numero_serie", cuantas); }
                }
                catch (Exception a) { Response.Write(a); }
            }
            else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }


        }
        protected void Consulta_Descripcion_Numero_leasing(string quien, int cuantas)
        {

            if (cuantas < 2)
            {

                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de adquisición ",typeof(string)),
                            new DataColumn(" Fecha de finalizacion ",typeof(string)),
                           new DataColumn(" Costo del activo",typeof(string)),
                          new DataColumn("Estado del activo",typeof(string)),



            });


                try
                {

                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa ,bd_numero_serie, bd_descripcion_activo,bd_departamento,bd_proveedor, bd_especificacion_tecnica ,bd_aquisicion_ac, bd_finalizacion_contrato, bd_costo_activo, bd_estado  FROM Activos  WHERE " + quien + "= @num  AND bd_descripcion_activo = @dpt AND bd_tipo_activo= 'Leasing'";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", descripcion); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Retornar_Descripcion(reader.GetString(3));
                            Retornar_Departamento(reader.GetString(4));
                            string estado = "";
                            if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                            if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                            if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                            if (reader.GetInt16(11) == 4) { estado = "Donado"; }
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6), reader.GetDateTime(7).ToString("yyyy/MM/dd"), reader.GetDateTime(8).ToString("yyyy/MM/dd"), reader.GetInt32(9).ToString(), estado);
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero_leasing("bd_numero_serie", cuantas); }
                }
                catch (Exception a) { Response.Write(a); }
            }

            else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }

        }
        protected void Consulta_Proveedor_Numero_leasing(string quien, int cuantas)
        {

            if (cuantas < 2)
            {

                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de adquisición ",typeof(string)),
                            new DataColumn(" Fecha de finalizacion ",typeof(string)),
                           new DataColumn(" Costo del activo",typeof(string)),
                          new DataColumn("Estado del activo",typeof(string)),



            });


                try
                {

                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa ,bd_numero_serie, bd_descripcion_activo,bd_departamento,bd_proveedor, bd_especificacion_tecnica ,bd_aquisicion_ac, bd_finalizacion_contrato, bd_costo_activo, bd_estado  FROM Activos  WHERE " + quien + "= @num  AND bd_proveedor = @dpt AND bd_tipo_activo='Leasing'";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", provedor); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Retornar_Descripcion(reader.GetString(3));
                            Retornar_Departamento(reader.GetString(4));
                            string estado = "";
                            if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                            if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                            if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                            if (reader.GetInt16(11) == 4) { estado = "Donado"; }
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6), reader.GetDateTime(7).ToString("yyyy/MM/dd"), reader.GetDateTime(8).ToString("yyyy/MM/dd"), reader.GetInt32(9).ToString(), estado);
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero_leasing("bd_numero_serie", cuantas); }
                }
                catch (Exception a) { Response.Write(a); }
            }

            else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }


        }
        protected void Consulta_Despartamento_Numero_descripcion_leasing(string quien, int cuantas)
        {

            if (cuantas < 2)
            {
                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de adquisición ",typeof(string)),
                            new DataColumn(" Fecha de finalizacion ",typeof(string)),
                           new DataColumn(" Costo del activo",typeof(string)),
                          new DataColumn("Estado del activo",typeof(string)),



            });


                try
                {

                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa ,bd_numero_serie, bd_descripcion_activo,bd_departamento,bd_proveedor, bd_especificacion_tecnica ,bd_aquisicion_ac, bd_finalizacion_contrato, bd_costo_activo, bd_estado  FROM Activos  WHERE " + quien + "= @num  AND bd_departamento=@dpt AND bd_descripcion_activo=@desc AND bd_tipo_activo= 'Leasing'";
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

                            Retornar_Descripcion(reader.GetString(3));
                            Retornar_Departamento(reader.GetString(4));
                            string estado = "";
                            if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                            if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                            if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                            if (reader.GetInt16(11) == 4) { estado = "Donado"; }
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6), reader.GetDateTime(7).ToString("yyyy/MM/dd"), reader.GetDateTime(8).ToString("yyyy/MM/dd"), reader.GetInt32(9).ToString(), estado);
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero_leasing("bd_numero_serie", cuantas); }
                }
                catch (Exception a) { Response.Write(a); }
            }
            else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }


        }
        protected void Consulta_Despartamento_Numero_descripcion_proveedor_leasing(string quien, int cuantas)
        {

            if (cuantas < 2)
            {

                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de adquisición ",typeof(string)),
                            new DataColumn(" Fecha de finalizacion ",typeof(string)),
                           new DataColumn(" Costo del activo",typeof(string)),
                          new DataColumn("Estado del activo",typeof(string)),



            });


                try
                {

                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECTSELECT  bd_tipo_activo, bd_numero_placa ,bd_numero_serie, bd_descripcion_activo,bd_departamento,bd_proveedor, bd_especificacion_tecnica ,bd_aquisicion_ac, bd_finalizacion_contrato, bd_costo_activo, bd_estado  FROM Activos  WHERE " + quien + "=@num  AND bd_departamento =@dpt AND bd_descripcion_activo=@desc AND bd_proveedor=@pro AND bd_tipo_activo= 'Leasing'";
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

                            Retornar_Descripcion(reader.GetString(3));
                            Retornar_Departamento(reader.GetString(4));
                            string estado = "";
                            if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                            if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                            if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                            if (reader.GetInt16(11) == 4) { estado = "Donado"; }
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6), reader.GetDateTime(7).ToString("yyyy/MM/dd"), reader.GetDateTime(8).ToString("yyyy/MM/dd"), reader.GetInt32(9).ToString(), estado);
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero_leasing("bd_numero_serie", cuantas); }
                }
                catch (Exception a) { Response.Write(a); }
            }
            else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }

        }
        protected void Consulta_Despartamento_leasing()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de adquisición ",typeof(string)),
                            new DataColumn(" Fecha de finalizacion ",typeof(string)),
                           new DataColumn(" Costo del activo",typeof(string)),
                          new DataColumn("Estado del activo",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa ,bd_numero_serie, bd_descripcion_activo,bd_departamento,bd_proveedor, bd_especificacion_tecnica ,bd_aquisicion_ac, bd_finalizacion_contrato, bd_costo_activo, bd_estado  FROM Activos WHERE  bd_departamento=@dpt AND bd_tipo_activo= 'Leasing'";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(3));
                        Retornar_Departamento(reader.GetString(4));
                        string estado = "";
                        if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                        if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                        if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                        if (reader.GetInt16(11) == 4) { estado = "Donado"; }
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6), reader.GetDateTime(7).ToString("yyyy/MM/dd"), reader.GetDateTime(8).ToString("yyyy/MM/dd"), reader.GetInt32(9).ToString(), estado);

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                }
                else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }
            }

            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Proveedor_leasing()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de adquisición ",typeof(string)),
                            new DataColumn(" Fecha de finalizacion ",typeof(string)),
                           new DataColumn(" Costo del activo",typeof(string)),
                          new DataColumn("Estado del activo",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa ,bd_numero_serie, bd_descripcion_activo,bd_departamento,bd_proveedor, bd_especificacion_tecnica ,bd_aquisicion_ac, bd_finalizacion_contrato, bd_costo_activo, bd_estado  FROM Activos  WHERE  bd_proveedor=@dpt AND bd_tipo_activo= 'Leasing'";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", provedor); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(3));
                        Retornar_Departamento(reader.GetString(4));
                        string estado = "";
                        if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                        if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                        if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                        if (reader.GetInt16(11) == 4) { estado = "Donado"; }
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6), reader.GetDateTime(7).ToString("yyyy/MM/dd"), reader.GetDateTime(8).ToString("yyyy/MM/dd"), reader.GetInt32(9).ToString(), estado);
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
                else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Despartamento_descripcion_proveedor_leasing()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de adquisición ",typeof(string)),
                            new DataColumn(" Fecha de finalizacion ",typeof(string)),
                           new DataColumn(" Costo del activo",typeof(string)),
                          new DataColumn("Estado del activo",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT SELECT  bd_tipo_activo, bd_numero_placa ,bd_numero_serie, bd_descripcion_activo,bd_departamento,bd_proveedor, bd_especificacion_tecnica ,bd_aquisicion_ac, bd_finalizacion_contrato, bd_costo_activo, bd_estado  FROM Activos WHERE  bd_departamento=@dpt AND bd_descripcion_activo=@des  AND bd_proveedor=@pro AND bd_tipo_activo= 'Leasing'";
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
                        Retornar_Descripcion(reader.GetString(3));
                        Retornar_Departamento(reader.GetString(4));
                        string estado = "";
                        if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                        if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                        if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                        if (reader.GetInt16(11) == 4) { estado = "Donado"; }
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6), reader.GetDateTime(7).ToString("yyyy/MM/dd"), reader.GetDateTime(8).ToString("yyyy/MM/dd"), reader.GetInt32(9).ToString(), estado);
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
                else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Despartamento_descripcion_leasing()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de adquisición ",typeof(string)),
                            new DataColumn(" Fecha de finalizacion ",typeof(string)),
                           new DataColumn(" Costo del activo",typeof(string)),
                          new DataColumn("Estado del activo",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT SELECT  bd_tipo_activo, bd_numero_placa ,bd_numero_serie, bd_descripcion_activo,bd_departamento,bd_proveedor, bd_especificacion_tecnica ,bd_aquisicion_ac, bd_finalizacion_contrato, bd_costo_activo, bd_estado  FROM Activos  WHERE  bd_departamento=@dpt AND bd_descripcion_activo=@des AND bd_tipo_activo= Leasing ";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                cmd.Parameters.AddWithValue("@des", descripcion); //enviamos los paramet


                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(3));
                        Retornar_Departamento(reader.GetString(4));
                        string estado = "";
                        if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                        if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                        if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                        if (reader.GetInt16(11) == 4) { estado = "Donado"; }
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6), reader.GetDateTime(7).ToString("yyyy/MM/dd"), reader.GetDateTime(8).ToString("yyyy/MM/dd"), reader.GetInt32(9).ToString(), estado);
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
                else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Descripcion_leasing()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de adquisición ",typeof(string)),
                            new DataColumn(" Fecha de finalizacion ",typeof(string)),
                           new DataColumn(" Costo del activo",typeof(string)),
                          new DataColumn("Estado del activo",typeof(string)),



            });

            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa ,bd_numero_serie, bd_descripcion_activo,bd_departamento,bd_proveedor, bd_especificacion_tecnica ,bd_aquisicion_ac, bd_finalizacion_contrato, bd_costo_activo, bd_estado  FROM Activos  WHERE bd_descripcion_activo=@dpt AND bd_tipo_activo= 'Leasing'";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", descripcion); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(3));
                        Retornar_Departamento(reader.GetString(4));
                        string estado = "";
                        if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                        if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                        if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                        if (reader.GetInt16(11) == 4) { estado = "Donado"; }
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6), reader.GetDateTime(7).ToString("yyyy/MM/dd"), reader.GetDateTime(8).ToString("yyyy/MM/dd"), reader.GetInt32(9).ToString(), estado);
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
                else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Numero_leasing(string quien, int cuantas)
        {
            if (cuantas < 2)
            {
                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de adquisición ",typeof(string)),
                            new DataColumn(" Fecha de finalizacion ",typeof(string)),
                           new DataColumn(" Costo del activo",typeof(string)),
                          new DataColumn("Estado del activo",typeof(string)),



            });


                try
                {
                    string num = numero.Text;
                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa ,bd_numero_serie, bd_descripcion_activo,bd_departamento,bd_proveedor, bd_especificacion_tecnica ,bd_aquisicion_ac, bd_finalizacion_contrato, bd_costo_activo, bd_estado  FROM Activos  WHERE bd_numero_placa=@num OR bd_numero_serie=@num AND bd_tipo_activo= 'Leasing'";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("num", num); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Retornar_Descripcion(reader.GetString(3));
                            Retornar_Departamento(reader.GetString(4));
                            string estado = "";
                            if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                            if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                            if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                            if (reader.GetInt16(11) == 4) { estado = "Donado"; }
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6), reader.GetDateTime(7).ToString("yyyy/MM/dd"), reader.GetDateTime(8).ToString("yyyy/MM/dd"), reader.GetInt32(9).ToString(), estado);
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                    else { cuantas++; Consulta_Numero_leasing("bd_numero_serie", cuantas); }
                }
                catch (Exception a) { Response.Write(a); }
            }
            else { error(Button1, "Disculpa", "No se encuentran activos con la informacion solicitada  disponibles en el sistema"); lista.DataBind(); }
        }
        protected void Consulta_Descripcion_proveedor_leasing()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de adquisición ",typeof(string)),
                            new DataColumn(" Fecha de finalizacion ",typeof(string)),
                           new DataColumn(" Costo del activo",typeof(string)),
                          new DataColumn("Estado del activo",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT SELECT  bd_tipo_activo, bd_numero_placa ,bd_numero_serie, bd_descripcion_activo,bd_departamento,bd_proveedor, bd_especificacion_tecnica ,bd_aquisicion_ac, bd_finalizacion_contrato, bd_costo_activo, bd_estado  FROM Activos WHERE bd_descripcion_activo=@dpt AND bd_proveedor=@pro AND bd_tipo_activo= 'Leasing'";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", descripcion); //enviamos los paramet
                cmd.Parameters.AddWithValue("@pro", provedor); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(3));
                        Retornar_Departamento(reader.GetString(4));
                        string estado = "";
                        if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                        if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                        if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                        if (reader.GetInt16(11) == 4) { estado = "Donado"; }
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6), reader.GetDateTime(7).ToString("yyyy/MM/dd"), reader.GetDateTime(8).ToString("yyyy/MM/dd"), reader.GetInt32(9).ToString(), estado);
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Despartamento_proveedor_leasing()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de adquisición ",typeof(string)),
                            new DataColumn(" Fecha de finalizacion ",typeof(string)),
                           new DataColumn(" Costo del activo",typeof(string)),
                          new DataColumn("Estado del activo",typeof(string)),



            });

            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT  bd_tipo_activo, bd_numero_placa ,bd_numero_serie, bd_descripcion_activo,bd_departamento,bd_proveedor, bd_especificacion_tecnica ,bd_aquisicion_ac, bd_finalizacion_contrato, bd_costo_activo, bd_estado  FROM Activos  WHERE  bd_departamento=@dpt AND bd_proveedor=@pro AND bd_tipo_activo= 'Leasing'";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                cmd.Parameters.AddWithValue("@pro", provedor); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(3));
                        Retornar_Departamento(reader.GetString(4));
                        string estado = "";
                        if (reader.GetInt16(11) == 1) { estado = "Alta"; }
                        if (reader.GetInt16(11) == 2) { estado = "Baja"; }
                        if (reader.GetInt16(11) == 3) { estado = "Prestado"; }
                        if (reader.GetInt16(11) == 4) { estado = "Donado"; }
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(5), reader.GetString(6), reader.GetDateTime(7).ToString("yyyy/MM/dd"), reader.GetDateTime(8).ToString("yyyy/MM/dd"), reader.GetInt32(9).ToString(), estado);
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
            }
            catch (Exception a) { Response.Write(a); }
        }

        //*************************GENERACION DE BITACORAS**************************

        protected void Crear_Bitacoras() {
            Bitacora_Consultar_Activos();
            Bitacora_Activos_Corp();
            Bitacora_Activos_Lea();
            Bitacora_Consultar_Usuarios();
            Bitacora_Usuario();

        
        }
        protected void Bitacora_Activos_Corp() {
            String tablaCorporativos = "<h1 style=\"text-align:center\">Hardware & Software</h1><table id=\"actiCorp\" class=\"table table-striped table-bordered\"> <thead> <tr><th>Fecha de acción</th><th>Tipo de activo</th><th>Número de placa</th><th>Número de serie</th><th>Fecha de compra</th><th>Fecha de finalización de garantía</th><th>Descripción del activo</th><th>Departamento del activo</th><th>Proveedor</th><th>Especificaciones tecnicas</th><th>Costo</th><th>Estado</th></tr></thead>";
           
               for(int i=0; i< this.Bitacora_Activos_Corporativos.Count;i++){
                    tablaCorporativos += this.Bitacora_Activos_Corporativos[i];
               }
                
            tablaCorporativos+="</table>";

             this.activosCorp.InnerHtml = tablaCorporativos;
        }
        protected void Bitacora_Activos_Lea()
        {
            String tablaLeasing = "<h1 style=\"text-align:center\">Leasing</h1><table id=\"actiLeasing\" class=\"table table-striped table-bordered\"> <thead> <tr><th>Fecha de acción</th><th>Tipo de activo</th><th>Número de placa</th><th>Número de serie</th><th>Fecha adqusicion</th><th>Fecha de finalización del contrato</th><th>Descripción del activo</th><th>Departamento del activo</th><th>Proveedor</th><th>Especificaciones tecnicas</th><th>Costo</th><th>Estado</th></tr></thead>";

            for (int i = 0; i < this.Bitacora_Activos_Leasing.Count; i++)
            {
                tablaLeasing += this.Bitacora_Activos_Leasing[i];
            }

            tablaLeasing += "</table>";

            this.activosLeasing.InnerHtml = tablaLeasing;
        }
        protected void Bitacora_Usuario() {
            String tablaUsuarios = "<h1 style=\"text-align:center\">Usuarios</h1><table id=\"usua\" class=\"table table-striped table-bordered\"> <thead> <tr><th>Fecha de acción</th><th>Tipo de usuarios</th><th>Cédula</th><th>Nombre</th><th>Primer apellido</th><th>Segundo apellido</th><th>Teléfono</th><th>Correo electronico</th><th>Contraseña</th><th>Puesto</th><th>Departamento</th><th>Motivos</th><th>Estado</th</tr></thead>";
            for (int i = 0; i < this.Bitacora_Usuarios.Count; i++)
            {
                tablaUsuarios += this.Bitacora_Usuarios[i];
            }

            tablaUsuarios += "</table>";

            this.usuarios.InnerHtml = tablaUsuarios;
        }
        protected void Bitacora_Consultar_Activos()
        {
            //Generar 2 tablas 1 leasing y otra por otros tipos
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_fecha_accion,bd_tipo_activo_nuevo,bd_numero_placa_nuevo,bd_numero_serie_nuevo,bd_fecha_final_garantia_nuevo,bd_descripcion_activo_nuevo,bd_departamento_nuevo,bd_proveedor_nuevo,bd_especificacion_tecnica_nuevo,bd_aquisicion_ac_nuevo,bd_finalizacion_contrato_nuevo,bd_fecha_compra_nuevo,bd_costo_activo_nuevo,bd_estado_nuevo FROM Bitacora_Activos where bd_accion != 'Eliminó datos' AND bd_tipo_activo_nuevo != 'NULL'";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); 
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                String row = "<tr>";
                String fecha_accion = reader.GetDateTime(0).ToString("dd/MM/yyyy");
                String tipo_activo = reader.GetString(1);
                String numero_placa = reader.GetString(2);
                String numero_serie = reader.GetString(3);
                String fecha_final_Garantia = reader.GetDateTime(4).ToString("dd/MM/yyyy");
                String descripcion_activo = reader.GetString(5);
                String departamento_activo = reader.GetString(6);
                String proveedor = reader.GetString(7);
                String especificacion_tecnica = reader.GetString(8);
                String fecha_adquision = reader.GetDateTime(9).ToString("dd/MM/yyyy");
                String fecha_final_contrato = reader.GetDateTime(10).ToString("dd/MM/yyyy");
                String fecha_compra = reader.GetDateTime(11).ToString("dd/MM/yyyy");
                int costo = reader.GetInt32(12);
                String estado = obtener_estado_activos(reader.GetInt32(13));

                if (tipo_activo != "Leasing")
                {
                    row += "<td>" + fecha_accion + "</td>" + "<td>" + tipo_activo + "</td>" + "<td>" + numero_placa + "</td> " + "<td>" + numero_serie + "</td>" + "<td>" + fecha_compra + "</td>" + "<td>" + fecha_final_Garantia + 
                   "</td>"+"<td>"+Obtener_Descripcion_Bitacora(descripcion_activo)+"</td>"+"<td>"+Obtener_Departamento_Bitacora(departamento_activo)+"</td>"+"<td>"+proveedor+"</td>"+"<td>"+especificacion_tecnica
                   +"</td>"+"<td>"+costo+"</td>"+"<td>"+estado+"</td>";
                    row += "</tr>";
                    Bitacora_Activos_Corporativos.Add(row);
                }
                else
                {

                    row += "<td>" + fecha_accion + "</td>" + "<td>" + tipo_activo + "</td>" + "<td>" + numero_placa + "</td>" + "<td>" + numero_serie + "</td>" + "<td>" + fecha_adquision + "</td>" + "<td>" + fecha_final_contrato
                            + "</td>" + "<td>" + Obtener_Descripcion_Bitacora(descripcion_activo) + "</td>" + "<td>" + Obtener_Departamento_Bitacora(departamento_activo) + "</td>"
                            + "<td>" + proveedor + "</td>" + "<td>" + especificacion_tecnica+ "</td>" + "<td>" + costo + "</td>" + "<td>" + estado + "</td>";
                        row += "</tr>";
                        Bitacora_Activos_Leasing.Add(row);
                    
                }

            }


        }
        protected void Bitacora_Consultar_Usuarios() {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_fecha_accion,bd_tipo_usuario_nuevo,bd_nombre_nuevo,bd_apellido1_nuevo,bd_apellido2_nuevo,bd_telefono_nuevo,bd_correo_electronico_nuevo,bd_contrasena_nuevo,bd_cedula_nuevo,bd_id_puesto_nuevo,bd_id_area_nuevo,bd_motivos_nuevo,bd_estado_nuevo FROM Bitacora_Usuario WHERE bd_accion != 'Eliminó datos'";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                String row = "<tr>";
                String fecha_accion = reader.GetDateTime(0).ToString("dd/MM/yyyy");
                bool tipo_usuario = reader.GetBoolean(1);
                String cedula = reader.GetString(8);
                String nombre_usuario = reader.GetString(2);
                String apellido1_usuario = reader.GetString(3);
                String apellido2_usuario = reader.GetString(4);
                String telefono = reader.GetString(5);
                String correo_electronico = reader.GetString(6);
                String contraseña = reader.GetString(7);
                String puesto = reader.GetString(9);
                String area = reader.GetString(10);
                String motivos = reader.GetString(11);
                String estado = obtener_estado_usuarios(reader.GetInt32(12));

                row += "<td>" + fecha_accion + "</td>" + "<td>" + (tipo_usuario ? "Administror" : "Consultas") + "</td>" + "<td>" + cedula + "</td>" + "<td>" + nombre_usuario + "</td> " + 
                "<td>" + apellido1_usuario + "</td>" + "<td>" + apellido2_usuario + "</td>" + "<td>" + telefono +
                "</td>"+"<td>"+correo_electronico+"</td>"+"<td>"+contraseña+"</td>"+"<td>" + Obtener_Puesto_Bitacora(puesto) + "</td>" 
                + "<td>" + Obtener_Departamento_Bitacora(area) + "</td>" + "<td>" + motivos + "</td>" + "<td>" + estado + "</td>";
                 row += "</tr>";
                 Bitacora_Usuarios.Add(row);
                

            }
        
        }
        protected void Bitacora_Consultar_Prestamos()
        {


        }
        protected void Bitacora_Consultar_Donaciones()
        {


        }
        protected String obtener_estado_activos(int valor) { 
            switch(valor){
                case 1:
                    return "Alta";
                case 2:
                    return "Baja";
                case 3:
                    return "Prestado";
                case 4:
                    return "Donado";
                default:
                    return "Indefinido";
            
            }
        }
        protected String obtener_estado_usuarios(int valor)
        {
            switch (valor)
            {
                case 1:
                    return "Activo";
                case 2:
                    return "Con prestamos";
                case 3:
                    return "Inhabilitado";
                default:
                    return "Indefinido";

            }
        }
        protected String Obtener_Departamento_Bitacora(string id) {
            
            for (int i = 0; i < departamento_activo.Items.Count; i++) {
                if (departamento_activo.Items[i].Value == id){
                    return departamento_activo.Items[i].Text;
                }
            }
            return "";

        }
        protected String Obtener_Puesto_Bitacora(string id)
        {
            String puesto = "";
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_descripcion FROM Areas WHERE bd_id_area = @id";

            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
               puesto = reader.GetString(0);
            }

            return puesto;

        }
        protected String Obtener_Descripcion_Bitacora(string id)
        {
            for (int i = 0; i < descripcion_activo.Items.Count; i++)
            {
                if (descripcion_activo.Items[i].Value == id)
                {
                    return descripcion_activo.Items[i].Text;
                }
            }
            return "";
           
        }
    }
}
