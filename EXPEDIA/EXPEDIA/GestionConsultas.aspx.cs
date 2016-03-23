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
            num = numero.Text;


            departamento = Seleciono_Departamento();
            descripcion = Seleciono_Descripcion();
            provedor = Seleciono_proveedor();
            if ((departamento == null) && (numero.Text == "") && (descripcion == null) && (provedor == null)) { Consultar_todo(); }
            if ((departamento != null) && (numero.Text != "") && (descripcion == null) && (provedor == null)) { Consulta_Despartamento_Numero("bd_numero_placa", y); }
            if ((departamento != null) && (numero.Text == "") && (descripcion == null) && (provedor == null)) { Consulta_Despartamento(); }
            if ((departamento != null) && (numero.Text != "") && (descripcion != null) && (provedor == null)) { Consulta_Despartamento_Numero_descripcion("bd_numero_placa", y); }
            if ((departamento == null) && (numero.Text == "") && (descripcion != null) && (provedor == null)) { Consulta_Descripcion(); }
            if ((departamento == null) && (numero.Text != "") && (descripcion != null) && (provedor == null)) { Consulta_Descripcion_Numero("bd_numero_placa", y); }
            if ((departamento != null) && (numero.Text != "") && (descripcion != null) && (provedor != null)) { Consulta_Despartamento_Numero_descripcion_proveedor("bd_numero_placa", y); }
            if ((departamento != null) && (numero.Text == "") && (descripcion != null) && (provedor != null)) { Consulta_Despartamento_descripcion_proveedor(); }
            if ((departamento == null) && (numero.Text == "") && (descripcion != null) && (provedor != null)) { Consulta_Descripcion_proveedor(); }
            if ((departamento != null) && (numero.Text == "") && (descripcion == null) && (provedor != null)) { Consulta_Despartamento_proveedor(); }
            if ((departamento == null) && (numero.Text != "") && (descripcion == null) && (provedor != null)) { Consulta_Proveedor_Numero("bd_numero_placa", y); }
            if ((departamento == null) && (numero.Text == "") && (descripcion == null) && (provedor != null)) { Consulta_Proveedor(); }
            if ((departamento == null) && (numero.Text != "") && (descripcion == null) && (provedor == null)) { Consulta_Numero(); }
            if ((departamento != null) && (numero.Text == "") && (descripcion != null) && (provedor == null)) { Consulta_Despartamento_descripcion(); }


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
            

                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("Número de  Placa ", typeof(string)),
                            new DataColumn("Número de Serie ",typeof(string)),
                            new DataColumn(" Descripcion ", typeof(string)),
                            new DataColumn(" Tipo ",typeof(string)),
                            new DataColumn(" Departamento ",typeof(string)),
                            new DataColumn(" Proveedor ", typeof(string)),
                            new DataColumn(" Especificaciones ",typeof(string)),
                            new DataColumn(" Fecha de garantia ",typeof(string)),
                            new DataColumn(" Duracion de contrato ",typeof(string)),
                           new DataColumn(" Fecha compra ",typeof(string)),
                          new DataColumn(" Costo ",typeof(string)),



            });


                try
                {

                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT bd_tipo_activo,bd_numero_placa,bd_numero_serie,bd_fecha_garantia_activo,bd_descripcion_activo,bd_departamento,bd_proveedor,bd_especificacion_tecnica,bd_duracion_de_contrato,bd_fecha_compra,bd_costo_activo FROM Activos ";

            
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion


                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Retornar_Descripcion(reader.GetString(4));
                            Retornar_Departamento(reader.GetString(5));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7), reader.GetDateTime(3).ToString(), reader.GetDateTime(8).ToString(), reader.GetDateTime(9).ToString(), reader.GetInt32(10).ToString());
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    
                    
                }
                }
                catch (Exception a) { Response.Write(a); }
            }
        
        protected void Consulta_Despartamento_Numero(string quien, int cuantas)
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
                            new DataColumn(" Fecha de garantia ",typeof(string)),
                            new DataColumn(" Duracion de contrato ",typeof(string)),
                           new DataColumn(" Fecha compra ",typeof(string)),
                          new DataColumn(" Costo ",typeof(string)),



            });


                try
                {

                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT * FROM Activos  WHERE " + quien + "= @num  AND bd_departamento = @dpt";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Retornar_Descripcion(reader.GetString(4));
                            Retornar_Departamento(reader.GetString(5));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7), reader.GetDateTime(3).ToString(), reader.GetDateTime(8).ToString(), reader.GetDateTime(9).ToString(), reader.GetInt32(10).ToString());
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero("bd_numero_serie", cuantas); }
                }
                catch (Exception a) { Response.Write(a); }
            }


        }
        protected void Consulta_Descripcion_Numero(string quien, int cuantas)
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
                            new DataColumn(" Fecha de garantia ",typeof(string)),
                            new DataColumn(" Duracion de contrato ",typeof(string)),
                           new DataColumn(" Fecha compra ",typeof(string)),
                          new DataColumn(" Costo ",typeof(string)),



            });


                try
                {

                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT * FROM Activos  WHERE " + quien + "= @num  AND bd_descripcion_activo = @dpt";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", descripcion); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Retornar_Descripcion(reader.GetString(4));
                            Retornar_Departamento(reader.GetString(5));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7), reader.GetDateTime(3).ToString(), reader.GetDateTime(8).ToString(), reader.GetDateTime(9).ToString(), reader.GetInt32(10).ToString());
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero("bd_numero_serie", cuantas); }
                }
                catch (Exception a) { Response.Write(a); }
            }


        }
        protected void Consulta_Proveedor_Numero(string quien, int cuantas)
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
                            new DataColumn(" Fecha de garantia ",typeof(string)),
                            new DataColumn(" Duracion de contrato ",typeof(string)),
                           new DataColumn(" Fecha compra ",typeof(string)),
                          new DataColumn(" Costo ",typeof(string)),



            });


                try
                {

                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT * FROM Activos  WHERE " + quien + "= @num  AND bd_proveedor = @dpt";
                    Conexion.Open();//abrimos conexion
                    SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                    cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet
                    cmd.Parameters.AddWithValue("@dpt", provedor); //enviamos los paramet

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Retornar_Descripcion(reader.GetString(4));
                            Retornar_Departamento(reader.GetString(5));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7), reader.GetDateTime(3).ToString(), reader.GetDateTime(8).ToString(), reader.GetDateTime(9).ToString(), reader.GetInt32(10).ToString());
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero("bd_numero_serie", cuantas); }
                }
                catch (Exception a) { Response.Write(a); }
            }


        }
        protected void Consulta_Despartamento_Numero_descripcion(string quien, int cuantas)
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
                            new DataColumn(" Fecha de garantia ",typeof(string)),
                            new DataColumn(" Duracion de contrato ",typeof(string)),
                           new DataColumn(" Fecha compra ",typeof(string)),
                          new DataColumn(" Costo ",typeof(string)),



            });


                try
                {

                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT * FROM Activos  WHERE " + quien + "= @num  AND bd_departamento=@dpt AND bd_descripcion_activo=@desc";
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

                            Retornar_Descripcion(reader.GetString(4));
                            Retornar_Departamento(reader.GetString(5));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7), reader.GetDateTime(3).ToString(), reader.GetDateTime(8).ToString(), reader.GetDateTime(9).ToString(), reader.GetInt32(10).ToString());
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero("bd_numero_serie", cuantas); }
                }
                catch (Exception a) { Response.Write(a); }
            }


        }
        protected void Consulta_Despartamento_Numero_descripcion_proveedor(string quien, int cuantas)
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
                            new DataColumn(" Fecha de garantia ",typeof(string)),
                            new DataColumn(" Duracion de contrato ",typeof(string)),
                           new DataColumn(" Fecha compra ",typeof(string)),
                          new DataColumn(" Costo ",typeof(string)),



            });


                try
                {

                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"SELECT * FROM Activos  WHERE " + quien + "=@num  AND bd_departamento =@dpt AND bd_descripcion_activo=@desc AND bd_proveedor=@pro";
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

                            Retornar_Descripcion(reader.GetString(4));
                            Retornar_Departamento(reader.GetString(5));
                            dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7), reader.GetDateTime(3).ToString(), reader.GetDateTime(8).ToString(), reader.GetDateTime(9).ToString(), reader.GetInt32(10).ToString());
                        }

                        lista.DataSource = dt;
                        lista.DataBind();
                    }
                    else { cuantas++; Consulta_Despartamento_Numero("bd_numero_serie", cuantas); }
                }
                catch (Exception a) { Response.Write(a); }
            }


        }
        protected void Consulta_Despartamento()
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
                            new DataColumn(" Fecha de garantia ",typeof(string)),
                            new DataColumn(" Duracion de contrato ",typeof(string)),
                           new DataColumn(" Fecha compra ",typeof(string)),
                          new DataColumn(" Costo ",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT * FROM Activos  WHERE  bd_departamento=@dpt";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(4));
                        Retornar_Departamento(reader.GetString(5));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7), reader.GetDateTime(3).ToString(), reader.GetDateTime(8).ToString(), reader.GetDateTime(9).ToString(), reader.GetInt32(10).ToString());
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Proveedor()
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
                            new DataColumn(" Fecha de garantia ",typeof(string)),
                            new DataColumn(" Duracion de contrato ",typeof(string)),
                           new DataColumn(" Fecha compra ",typeof(string)),
                          new DataColumn(" Costo ",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT * FROM Activos  WHERE  bd_proveedor=@dpt";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", provedor); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(4));
                        Retornar_Departamento(reader.GetString(5));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7), reader.GetDateTime(3).ToString(), reader.GetDateTime(8).ToString(), reader.GetDateTime(9).ToString(), reader.GetInt32(10).ToString());
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Despartamento_descripcion_proveedor()
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
                            new DataColumn(" Fecha de garantia ",typeof(string)),
                            new DataColumn(" Duracion de contrato ",typeof(string)),
                           new DataColumn(" Fecha compra ",typeof(string)),
                          new DataColumn(" Costo ",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT * FROM Activos  WHERE  bd_departamento=@dpt AND bd_descripcion_activo=@des  AND bd_proveedor=@pro";
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

                        Retornar_Descripcion(reader.GetString(4));
                        Retornar_Departamento(reader.GetString(5));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7), reader.GetDateTime(3).ToString(), reader.GetDateTime(8).ToString(), reader.GetDateTime(9).ToString(), reader.GetInt32(10).ToString());
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Despartamento_descripcion()
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
                            new DataColumn(" Fecha de garantia ",typeof(string)),
                            new DataColumn(" Duracion de contrato ",typeof(string)),
                           new DataColumn(" Fecha compra ",typeof(string)),
                          new DataColumn(" Costo ",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT * FROM Activos  WHERE  bd_departamento=@dpt AND bd_descripcion_activo=@des  ";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                cmd.Parameters.AddWithValue("@des", descripcion); //enviamos los paramet


                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(4));
                        Retornar_Departamento(reader.GetString(5));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7), reader.GetDateTime(3).ToString(), reader.GetDateTime(8).ToString(), reader.GetDateTime(9).ToString(), reader.GetInt32(10).ToString());
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Descripcion()
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
                            new DataColumn(" Fecha de garantia ",typeof(string)),
                            new DataColumn(" Duracion de contrato ",typeof(string)),
                           new DataColumn(" Fecha compra ",typeof(string)),
                          new DataColumn(" Costo ",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT * FROM Activos  WHERE bd_descripcion_activo=@dpt";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", descripcion); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(4));
                        Retornar_Departamento(reader.GetString(5));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7), reader.GetDateTime(3).ToString(), reader.GetDateTime(8).ToString(), reader.GetDateTime(9).ToString(), reader.GetInt32(10).ToString());
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Numero()
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
                            new DataColumn(" Fecha de garantia ",typeof(string)),
                            new DataColumn(" Duracion de contrato ",typeof(string)),
                           new DataColumn(" Fecha compra ",typeof(string)),
                          new DataColumn(" Costo ",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT * FROM Activos  WHERE bd_numero_placa=@num OR bd_numero_serie=@num";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("num", num); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(4));
                        Retornar_Departamento(reader.GetString(5));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7), reader.GetDateTime(3).ToString(), reader.GetDateTime(8).ToString(), reader.GetDateTime(9).ToString(), reader.GetInt32(10).ToString());
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Descripcion_proveedor()
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
                            new DataColumn(" Fecha de garantia ",typeof(string)),
                            new DataColumn(" Duracion de contrato ",typeof(string)),
                           new DataColumn(" Fecha compra ",typeof(string)),
                          new DataColumn(" Costo ",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT * FROM Activos  WHERE bd_descripcion_activo=@dpt AND bd_proveedor=@pro";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", descripcion); //enviamos los paramet
                cmd.Parameters.AddWithValue("@pro", provedor); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(4));
                        Retornar_Departamento(reader.GetString(5));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7), reader.GetDateTime(3).ToString(), reader.GetDateTime(8).ToString(), reader.GetDateTime(9).ToString(), reader.GetInt32(10).ToString());
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
            }
            catch (Exception a) { Response.Write(a); }
        }
        protected void Consulta_Despartamento_proveedor()
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
                            new DataColumn(" Fecha de garantia ",typeof(string)),
                            new DataColumn(" Duracion de contrato ",typeof(string)),
                           new DataColumn(" Fecha compra ",typeof(string)),
                          new DataColumn(" Costo ",typeof(string)),



            });


            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT * FROM Activos  WHERE  bd_departamento=@dpt AND bd_proveedor=@pro";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@dpt", departamento); //enviamos los paramet
                cmd.Parameters.AddWithValue("@pro", provedor); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retornar_Descripcion(reader.GetString(4));
                        Retornar_Departamento(reader.GetString(5));
                        dt.Rows.Add(reader.GetString(1), reader.GetString(2), id_des, reader.GetString(0), id_dep, reader.GetString(6), reader.GetString(7), reader.GetDateTime(3).ToString(), reader.GetDateTime(8).ToString(), reader.GetDateTime(9).ToString(), reader.GetInt32(10).ToString());
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
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

    }
}
