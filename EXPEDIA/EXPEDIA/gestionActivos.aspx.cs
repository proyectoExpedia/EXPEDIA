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
    public partial class gestionActivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar_area(area);
                cargar_descripcion(descripcion);
                cargar_proveedor(proveedor);
            }     


        }
        protected void Bt_Ingresar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //validate is successful.
            }

            if (corroborarExistenciaDatos("Activos", "bd_numero_placa", numero_placa.Text, Button1) && corroborarExistenciaDatos("Activos", "bd_numero_serie", numero_serie.Text, Button1))
            {
                //{ }
                //if ()
                //{ }

                if (RadioButton2.Checked)
                {
                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"INSERT INTO Activos (bd_tipo_activo, bd_numero_placa, bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia, bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica,bd_fecha_compra, bd_costo_activo, bd_estado) 
                        values (@tipo_activo, @placa, @serie, @garantia_inicio, @garantia_final, @descripcion,@departamento,@proveedor,@especificacion_tecnica,@fecha_compra, @costo , @estado)";

                    Conexion.Open();//abrimos conexion    
                    try
                    {
                        SqlCommand cmd = new SqlCommand(Sql, Conexion);
                        cmd.Parameters.AddWithValue("@tipo_activo", "Software");
                        cmd.Parameters.AddWithValue("@fecha_compra", fecha_compra.Text);
                        cmd.Parameters.AddWithValue("@costo", precio.Text);
                        cmd.Parameters.AddWithValue("@placa", numero_placa.Text);
                        cmd.Parameters.AddWithValue("@serie", numero_serie.Text);
                        cmd.Parameters.AddWithValue("@garantia_inicio", inicio_garantia.Text);
                        cmd.Parameters.AddWithValue("@garantia_final", final_garantia.Text);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion.SelectedValue);
                        cmd.Parameters.AddWithValue("@departamento", area.SelectedValue);
                        cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedValue);
                        cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica.Text);
                        cmd.Parameters.AddWithValue("@estado", 1);
                        cmd.ExecuteNonQuery();
                        
                        c.Desconectar(Conexion);
                        excelente(Button1);
                        //System.Threading.Thread.Sleep(9000);
                        
                        Response.Redirect("gestionActivos.aspx");



                    }
                    catch (Exception t) { Response.Write("error" + t); }


                }






                if (RadioButton3.Checked)
                {
                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"INSERT INTO Activos (bd_tipo_activo, bd_numero_placa, bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia, bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica,bd_fecha_compra, bd_costo_activo, bd_estado) 
                values (@tipo_activo, @placa, @serie, @garantia_inicio, @garantia_final, @descripcion,@departamento,@proveedor,@especificacion_tecnica,@fecha_compra, @costo, @estado)";

                    Conexion.Open();//abrimos conexion    
                    try
                    {
                        SqlCommand cmd = new SqlCommand(Sql, Conexion);
                        cmd.Parameters.AddWithValue("@tipo_activo", "Hardware");
                        cmd.Parameters.AddWithValue("@placa", numero_placa.Text);
                        cmd.Parameters.AddWithValue("@serie", numero_serie.Text);
                        cmd.Parameters.AddWithValue("@garantia_inicio", inicio_garantia.Text);
                        cmd.Parameters.AddWithValue("@garantia_final", final_garantia.Text);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion.SelectedValue);
                        cmd.Parameters.AddWithValue("@departamento", area.SelectedValue);
                        cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedValue);
                        cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica.Text);
                        cmd.Parameters.AddWithValue("@fecha_compra", fecha_compra.Text);
                        cmd.Parameters.AddWithValue("@costo", precio.Text);
                        cmd.Parameters.AddWithValue("@estado", 1);
                        cmd.ExecuteNonQuery();
                        excelente(Button1);
                        c.Desconectar(Conexion);
                        
                        Response.Redirect("gestionActivos.aspx");

                    }
                    catch (Exception t) { Response.Write("error" + t); }
                }

                if (RadioButton4.Checked)
                {
                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"INSERT INTO Activos (bd_tipo_activo, bd_numero_placa, bd_numero_serie, bd_aquisicion_ac, bd_finalizacion_contrato, bd_costo_activo, bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica) 
                    values (@tipo_activo, @placa, @serie, @adquiscion, @finalizacion, @costo, @descripcion, @departamento, @proveedor, @especificacion_tecnica)";

                    Conexion.Open();//abrimos conexion    
                    try
                    {
                        SqlCommand cmd = new SqlCommand(Sql, Conexion);

                        cmd.Parameters.AddWithValue("@tipo_activo", "Leasing");
                        cmd.Parameters.AddWithValue("@placa", numero_placa.Text);
                        cmd.Parameters.AddWithValue("@serie", numero_serie.Text);
                        cmd.Parameters.AddWithValue("@adquiscion", fecha_adquisicion.Text);
                        cmd.Parameters.AddWithValue("@finalizacion", finalizacion_contrato.Text);
                        cmd.Parameters.AddWithValue("@costo", precio.Text);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion.SelectedValue);
                        cmd.Parameters.AddWithValue("@departamento", area.SelectedValue);
                        cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedValue);
                        cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica.Text);
                        cmd.ExecuteNonQuery();
                        c.Desconectar(Conexion);
                        excelente(Button1);
                        Response.Redirect("gestionActivos.aspx");



                    }
                    catch (Exception t) { Response.Write("error" + t); }
                }
                
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

        
        protected void btn_Registrar_Area_Click(object sender, EventArgs e)
        {
            if (corroborarExistenciaDatos("Areas", "bd_id_area", id_areas.Text, Registrar_Area))
            {
            
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"INSERT INTO Areas (bd_id_area, bd_descripcion) values (@idA, @descripcionA)";

            Conexion.Open();//abrimos conexion

            try
            {
                SqlCommand cmd = new SqlCommand(Sql, Conexion);
                cmd.Parameters.AddWithValue("@idA", id_areas.Text); //enviamos los parametros
                cmd.Parameters.AddWithValue("@descripcionA", descripcion_area.Text);
                cmd.ExecuteNonQuery();
                c.Desconectar(Conexion);
                ListItem item = new ListItem(descripcion_area.Text, id_areas.Text, true);
                area.Items.Add(item);
                excelente(Registrar_Area);
                    Response.Redirect("gestionActivos.aspx");
                    //area_actualizar.Items.Add(item);
                    //descripcion.Controls.Add(new ListItem());
                    //cargar_descripcion(descripcion);

                }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }
            }

        }

        protected void btn_Registrar_Descripcion_Ac_Click(object sender, EventArgs e)
        {
            if (corroborarExistenciaDatos("Descripcion", "bd_id_descripcion", id_descripcion_nueva.Text, Registar_Descripcion_Ac)) { 

            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"INSERT INTO Descripcion (bd_id_descripcion, Descripcion) values (@id, @descripcion)";

            Conexion.Open();//abrimos conexion

            try
            {
                SqlCommand cmd = new SqlCommand(Sql, Conexion);
                cmd.Parameters.AddWithValue("@id", id_descripcion_nueva.Text); //enviamos los parametros
                cmd.Parameters.AddWithValue("@descripcion", descripcion_nueva.Text);
                cmd.ExecuteNonQuery();
                c.Desconectar(Conexion);
                ListItem item2 = new ListItem(id_descripcion_nueva.Text, descripcion_nueva.Text, true);
                descripcion.Items.Add(item2);
                excelente(Registar_Descripcion_Ac);
                    Response.Redirect("gestionActivos.aspx");
                    //Response.Redirect("gestionActivos.aspx");
                    //cargar_descripcion(descripcion);

                }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }
            }
        }

        protected void btn_Registrar_Proveedor_Click(object sender, EventArgs e)
        {
            if (corroborarExistenciaDatos("Proveedores", "bd_nombre_proveedor", nproveedor.Text, Resgistrar_Proveedor))
            {
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"INSERT INTO Proveedores (bd_id_proveedor, bd_nombre_proveedor, bd_correo_electronico_prov, bd_numero_telefonico_empresa, bd_numero_contacto) values (@idProv, @nombProv, @CorreoProv, @telProv, @telCont)";

                Conexion.Open();//abrimos conexion

                try
                {
                    SqlCommand cmd = new SqlCommand(Sql, Conexion);
                    cmd.Parameters.AddWithValue("@idProv", idp.Text); //enviamos los parametros
                    cmd.Parameters.AddWithValue("@nombProv", nproveedor.Text);
                    cmd.Parameters.AddWithValue("@CorreoProv", correo.Text);
                    cmd.Parameters.AddWithValue("@telProv", telefono1.Text);
                    cmd.Parameters.AddWithValue("@telCont", telefono.Text);
                    cmd.ExecuteNonQuery();
                    ListItem item3 = new ListItem(idp.Text, nproveedor.Text, true);
                    proveedor.Items.Add(item3);
                    c.Desconectar(Conexion);
                    excelente(Resgistrar_Proveedor);
                    Response.Redirect("gestionActivos.aspx");
                    //Response.Redirect("gestionActivos.aspx");


                }
                catch (Exception a)
                {
                    Response.Write("error" + a.ToString());
                }
            }
        }

        protected void excelente(Control boton)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script language='javascript'>");
            sb.Append(@"swal({");
            sb.Append(@"title: 'Solicitudes realizadas correctamente',");
            //sb.Append(@"timer: 2000,");
            sb.Append(@"type: 'success'");
            sb.Append(@"})");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(boton, this.GetType(), "Holi", sb.ToString(), false);
            //http://limonte.github.io/sweetalert2/


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



    }

}
