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





    }
}
