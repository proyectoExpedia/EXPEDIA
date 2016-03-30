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
                    string Sql = @"INSERT INTO Activos (bd_tipo_activo, bd_numero_placa, bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia, bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica, bd_aquisicion_ac, bd_finalizacion_contrato, bd_fecha_compra, bd_costo_activo, bd_id_prestamo, bd_estado) 
                        values (@tipo_activo, @placa, @serie, @garantia_inicio, @garantia_final, @descripcion, @departamento, @proveedor, @especificacion_tecnica, @aquisicion_ac, @finalizacion_contrato,  @fecha_compra, @costo , @id_prestamo, @estado)";

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
                        cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica.Text);
                        cmd.Parameters.AddWithValue("@estado", 1);
                        //invalidos
                        cmd.Parameters.AddWithValue("@aquisicion_ac", "");
                        cmd.Parameters.AddWithValue("@finalizacion_contrato", "");
                        cmd.Parameters.AddWithValue("@id_prestamo", 0);
                        cmd.ExecuteNonQuery();

                        c.Desconectar(Conexion);
                        excelente(Button1);
                        //System.Threading.Thread.Sleep(9000);

                        limpiar1();



                    }
                    catch (Exception t) { Response.Write("error" + t); }


                }






                if (RadioButton3.Checked)
                {
                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"INSERT INTO Activos (bd_tipo_activo, bd_numero_placa, bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia, bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica, bd_aquisicion_ac, bd_finalizacion_contrato, bd_fecha_compra, bd_costo_activo, bd_id_prestamo, bd_estado) 
                        values (@tipo_activo, @placa, @serie, @garantia_inicio, @garantia_final, @descripcion, @departamento, @proveedor, @especificacion_tecnica, @aquisicion_ac, @finalizacion_contrato,  @fecha_compra, @costo , @id_prestamo, @estado)";

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
                        cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica.Text);
                        cmd.Parameters.AddWithValue("@fecha_compra", fecha_compra.Text);
                        cmd.Parameters.AddWithValue("@costo", precio.Text);
                        cmd.Parameters.AddWithValue("@estado", 1);
                        //invalidos
                        cmd.Parameters.AddWithValue("@aquisicion_ac", "");
                        cmd.Parameters.AddWithValue("@finalizacion_contrato", "");
                        cmd.Parameters.AddWithValue("@id_prestamo", 0);
                        cmd.ExecuteNonQuery();
                        excelente(Button1);
                        c.Desconectar(Conexion);

                        limpiar1();

                    }
                    catch (Exception t) { Response.Write("error" + t); }
                }

                if (RadioButton4.Checked)
                {
                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"INSERT INTO Activos (bd_tipo_activo, bd_numero_placa, bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia, bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica, bd_aquisicion_ac, bd_finalizacion_contrato, bd_fecha_compra, bd_costo_activo, bd_id_prestamo, bd_estado) 
                        values (@tipo_activo, @placa, @serie, @garantia_inicio, @garantia_final, @descripcion, @departamento, @proveedor, @especificacion_tecnica, @aquisicion_ac, @finalizacion_contrato,  @fecha_compra, @costo , @id_prestamo, @estado)";

                    Conexion.Open();//abrimos conexion    
                    try
                    {
                        SqlCommand cmd = new SqlCommand(Sql, Conexion);

                        cmd.Parameters.AddWithValue("@tipo_activo", "Leasing");
                        cmd.Parameters.AddWithValue("@placa", numero_placa.Text);
                        cmd.Parameters.AddWithValue("@serie", numero_serie.Text);
                        cmd.Parameters.AddWithValue("@aquisicion_ac", fecha_adquisicion.Text);
                        cmd.Parameters.AddWithValue("@finalizacion_contrato", finalizacion_contrato.Text);
                        cmd.Parameters.AddWithValue("@costo", precio.Text);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion.SelectedValue);
                        cmd.Parameters.AddWithValue("@departamento", area.SelectedValue);
                        cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica.Text);
                        //insertar invalidos
                        cmd.Parameters.AddWithValue("@garantia_inicio", "");
                        cmd.Parameters.AddWithValue("@garantia_final", "");
                        cmd.Parameters.AddWithValue("@fecha_compra", "");
                        cmd.Parameters.AddWithValue("@id_prestamo", 0);
                        cmd.Parameters.AddWithValue("@estado", 1);
                        cmd.ExecuteNonQuery();
                        c.Desconectar(Conexion);
                        excelente(Button1);
                        limpiar1();



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
            string Sql = @"SELECT bd_id_proveedor, bd_nombre_proveedor FROM Proveedores";
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
                    limpiarArea();
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
            if (corroborarExistenciaDatos("Descripcion", "bd_id_descripcion", id_descripcion_nueva.Text, Registar_Descripcion_Ac))
            {

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
                    limpiarDescrip();
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
                    limpiarPro();
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
        protected void Bt_Modificar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //validate is successful.
            }

            if (corroborarExistenciaDatos("Activos", "bd_numero_placa", numero_placa.Text, Button1) && corroborarExistenciaDatos("Activos", "bd_numero_serie", numero_serie.Text, Button1))
            {
                if (RadioButton2.Checked)
                {
                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"UPDATE Activos SET (bd_tipo_activo = @tipo_activo, bd_numero_placa = @placa, bd_numero_serie = @serie, bd_fecha_inicio_garantia = @garantia_inicio, bd_fecha_final_garantia = @garantia_final, bd_descripcion_activo = @descripcion, bd_departamento = @departamento, bd_proveedor = @proveedor, bd_especificacion_tecnica = @especificacion_tecnica, bd_fecha_compra = @fecha_compra, bd_costo_activo = @costo, bd_estado = @estado) 
                                    WHERE (bd_numero_placa = @placa)";

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
                        cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedItem.Text);
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

                    string Sql = @"UPDATE Activos SET (bd_tipo_activo = @tipo_activo, bd_numero_placa = @placa, bd_numero_serie = @serie, bd_fecha_inicio_garantia = @garantia_inicio, bd_fecha_final_garantia = @garantia_final, bd_descripcion_activo = @descripcion, bd_departamento = @departamento, bd_proveedor = @proveedor, bd_especificacion_tecnica = @especificacion_tecnica, bd_fecha_compra = @fecha_compra, bd_costo_activo = @costo, bd_estado = @estado) 
                                    WHERE (bd_numero_placa = @placa)";
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

                    string Sql = @"UPDATE Activos SET (bd_tipo_activo = @tipo_activo, bd_numero_placa = @placa, bd_numero_serie = @serie, bd_aquisicion_ac = @adquiscion, bd_finalizacion_contrato = @finalizacion,, bd_costo_activo = @costo, bd_descripcion_activo = @descripcion, bd_departamento = @departamento, bd_proveedor = @proveedor, bd_especificacion_tecnica = @especificacion_tecnica) 
                                    WHERE (bd_numero_placa = @placa)";
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
        // ----------- Modificar, deberíamos crear un boton en la tuerca que permita consultar área, proveedor y descripción ----------//
        protected void btn_Modificar_Proveedor_Click(object sender, EventArgs e)
        {
            if (corroborarExistenciaDatos("Proveedores", "bd_nombre_proveedor", nproveedor.Text, Resgistrar_Proveedor))
            {
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"UPDATE Proveedores SET (bd_id_proveedor = @idProv, bd_nombre_proveedor = @nombProv, bd_correo_electronico_prov = @CorreoProv, bd_numero_telefonico_empresa = @telProv, bd_numero_contacto = @telCont)
                            WHERE (bd_id_proveedor = @idProv)";

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
        protected void btn_Modificar_Descripcion_Ac_Click(object sender, EventArgs e)
        {
            if (corroborarExistenciaDatos("Descripcion", "bd_id_descripcion", id_descripcion_nueva.Text, Registar_Descripcion_Ac))
            {

                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"UPDATE Descripcion SET (bd_id_descripcion = @id, Descripcion = @descripcion) WHERE (bd_id_descripcion = @id)";

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
        protected void btn_Modificar_Area_Click(object sender, EventArgs e)
        {
            if (corroborarExistenciaDatos("Areas", "bd_id_area", id_areas.Text, Registrar_Area))
            {

                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"UPDATE Areas SET (bd_id_area = @idA, bd_descripcion = @descripcionA) WHERE (bd_id_area = @idA)";

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

        protected void mostrarConsultaAC()
        {
            ocultoAC.Style.Add("display", "block");
            
        }

        protected void habilitarCampos()
        { 
            numero_placa2.ReadOnly = true;
            numero_serie2.ReadOnly = true;
            precio2.ReadOnly = false;
            fecha_compra2.ReadOnly = false;
            inicio_garantia2.ReadOnly = false;
            final_garantia2.ReadOnly = false;
            descripcion2.Enabled = true;
            area2.Enabled = true;
            proveedor2.Enabled = true;
            especificacion_tecnica2.ReadOnly = false;
            bny.Style.Add("display", "block");
            RadioButton5.Enabled = true;
            RadioButton6.Enabled = true;
        }

        protected void inhabilitarCampos()
        {
            numero_placa2.ReadOnly = true;
            numero_serie2.ReadOnly = true;
            precio2.ReadOnly = true;
            fecha_compra2.ReadOnly = true;
            inicio_garantia2.ReadOnly = true;
            final_garantia2.ReadOnly = true;
            descripcion2.Enabled = false;
            area2.Enabled = false;
            proveedor2.Enabled = false;
            especificacion_tecnica2.ReadOnly = true;
            RadioButton5.Enabled = false;
            RadioButton6.Enabled = false;
        }

        protected String cargaridDescrip(String descrip)
        {
            String i = "";
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT Descripcion FROM Descripcion WHERE bd_id_descripcion = '" + descrip+"'";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String descripcion = reader.GetString(0);
                i = descripcion;
            }
            Conexion.Close();
            
            return i;
        }

        protected String cargaridArea(String AuxArea)
        {
            String x = "";
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_descripcion FROM Areas WHERE bd_id_area = '" + AuxArea+ "'";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String descripcion = reader.GetString(0);
                x = descripcion;
            }
            Conexion.Close();

            return x;
        }




        protected void bt_consultarAC_Click(object sender, EventArgs e)
        {
            mostrarConsultaAC();
            inhabilitarCampos();
            cargar_descripcion(descripcion2);
            cargar_area(area2);
            cargar_proveedor(proveedor2);
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT * FROM Activos WHERE bd_numero_placa = @placa";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion            
            cmd.Parameters.AddWithValue("@placa", placa_buscar.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader.GetString(0) == "Software") {
                    this.RadioButton5.Checked = true;
                    //this.btn5.Style.Add("background-color", "#204d74");
                    this.RadioButton6.Checked = false;
                    //this.btn6.Style.Add("background-color", "#337ab7");
                        numero_placa2.Text = reader.GetString(1);
                    numero_serie2.Text = reader.GetString(2);
                        precio2.Text = reader.GetInt32(12).ToString();
                        String fechaC = reader.GetDateTime(11).ToString();
                        fechaC = fechaC.Split(' ')[0];
                    fecha_compra2.Text = fechaC;
                        String fechaIG = reader.GetDateTime(3).ToString();
                        fechaIG = fechaIG.Split(' ')[0];
                    inicio_garantia2.Text = fechaIG;
                        String fechaFG = reader.GetDateTime(4).ToString();
                        fechaFG = fechaFG.Split(' ')[0];
                    final_garantia2.Text = fechaFG;
                        //Cargar descrip para el drop
                        String descrip = reader.GetString(5).ToString();
                        String descripVal = cargaridDescrip(descrip);
                        int i = 0;
                        foreach (var item in descripcion2.Items)
                        {
                            if (item.ToString().Equals(descripVal))
                            {
                                descripcion2.SelectedIndex = i;
                                break;
                            }
                            i++;
                        }
                        //Cargar areas para el drop
                        String AuxArea = reader.GetString(6).ToString();
                        String AreaVal = cargaridArea(AuxArea);
                        int x = 0;
                        foreach (var item in area2.Items)
                        {
                            if (item.ToString().Equals(AreaVal))
                            {
                                area2.SelectedIndex = x;
                                break;
                            }
                            x++;
                        }
                        //Cargar proveedor para el drop
                        String AuxPro = reader.GetString(7).ToString();
                        int y = 0;
                        foreach (var item in proveedor2.Items)
                        {
                            if (item.ToString().Equals(AuxPro))
                            {
                                proveedor2.SelectedIndex = y;
                                break;
                            }
                            y++;
                        }
                        especificacion_tecnica2.Text = reader.GetString(8);

                    }
                    if (reader.GetString(0) == "Hardware")
                    {
                        this.RadioButton5.Checked = false;
                        this.RadioButton6.Checked = true;
                        //this.btn5.Style.Add("background-color", "#337ab7");
                        //this.RadioButton6.Checked = false;
                        //this.btn6.Style.Add("background-color", "#204d74");
                        numero_placa2.Text = reader.GetString(1);
                        numero_serie2.Text = reader.GetString(2);
                        precio2.Text = reader.GetInt32(12).ToString();
                        String fechaC = reader.GetDateTime(11).ToString();
                        fechaC = fechaC.Split(' ')[0];
                        fecha_compra2.Text = fechaC;
                        String fechaIG = reader.GetDateTime(3).ToString();
                        fechaIG = fechaIG.Split(' ')[0];
                        inicio_garantia2.Text = fechaIG;
                        String fechaFG = reader.GetDateTime(4).ToString();
                        fechaFG = fechaFG.Split(' ')[0];
                        final_garantia2.Text = fechaFG;
                        //Cargar descrip para el drop
                        String descrip = reader.GetString(5).ToString();
                        String descripVal = cargaridDescrip(descrip);
                        int i = 0;
                        foreach (var item in descripcion2.Items)
                        {
                            if (item.ToString().Equals(descripVal))
                            {
                                descripcion2.SelectedIndex = i;
                                break;
                            }
                            i++;
                        }
                        //Cargar areas para el drop
                        String AuxArea = reader.GetString(6).ToString();
                        String AreaVal = cargaridArea(AuxArea);
                        int x = 0;
                        foreach (var item in area2.Items)
                        {
                            if (item.ToString().Equals(AreaVal))
                            {
                                area2.SelectedIndex = x;
                                break;
                            }
                            x++;
                        }
                        //Cargar proveedor para el drop
                        String AuxPro = reader.GetString(7).ToString();
                        int y = 0;
                        foreach (var item in proveedor2.Items)
                        {
                            if (item.ToString().Equals(AuxPro))
                            {
                                proveedor2.SelectedIndex = y;
                                break;
                            }
                            y++;
                        }
                        especificacion_tecnica2.Text = reader.GetString(8);
                    }

                    //        apellido_actualizar2.Text = reader.GetString(3);
                    //        telefono_actualizar.Text = reader.GetString(4);
                    //        correo_actualizar.Text = reader.GetString(5);
                    //        contrasena_actualizar.Text = reader.GetString(6);
                    //        rcontrasena_actualizar.Text = contrasena_actualizar.Text.ToString();
                    //        puesto_actualizar.SelectedValue = reader.GetString(8);
                    //        area_actualizar.SelectedValue = reader.GetString(9);
                    //        motivos = reader.GetString(10);
                    //        estado = reader.GetInt16(11);
                    //    }
                    //    if (estado == 3)
                    //    {
                    //        mostrarInhabilitacion(Btn_consultar, motivos, cedula_consulta.Text);
                    //        inhabilitarCampos();
                    //        mostrarConsulta();
                    //    }
                    //    else
                    //    {
                    //        this.controles.Style.Add("display", "block");
                    //        excelente(Btn_consultar);
                    //        inhabilitarCampos();
                    //        mostrarConsulta();
                    //    }
                    //}
                    //else
                    //{
                    //    error(Btn_consultar, " Usuario no encontrado", "");
                    //    ocultarConsulta();
                }

                Conexion.Close();

            }
        }

        protected void bt_Habilitar_Modif_Click(object sender, EventArgs e)
        {
            
            habilitarCampos();


        }

        protected void bt_Guardar_Cambios_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //validate is successful.
            }

            if (corroborarExistenciaDatos("Activos", "bd_numero_placa", numero_placa.Text, actualizaDatosAC) && corroborarExistenciaDatos("Activos", "bd_numero_serie", numero_serie.Text, actualizaDatosAC))
            {
                //{ }
                //if ()
                //{ }

                if (RadioButton5.Checked)
                {
                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    String Sql = @"UPDATE Activos SET  bd_tipo_activo = @tipo_activo, bd_descripcion_activo = @descripcion, bd_fecha_final_garantia = @garantia_final, bd_fecha_inicio_garantia = @garantia_inicio, bd_numero_serie = @serie,  bd_departamento = @departamento, bd_proveedor = @proveedor, bd_especificacion_tecnica = @especificacion_tecnica, bd_aquisicion_ac = @aquisicion_ac, bd_finalizacion_contrato = @finalizacion_contrato, bd_fecha_compra = @fecha_compra, bd_costo_activo = @costo , bd_id_prestamo =  @id_prestamo, bd_estado = @estado WHERE bd_numero_placa = @placa";

                    Conexion.Open();//abrimos conexion    
                    try
                    {
                        SqlCommand cmd = new SqlCommand(Sql, Conexion);
                        cmd.Parameters.AddWithValue("@tipo_activo", "Software");
                        cmd.Parameters.AddWithValue("@placa", numero_placa2.Text);
                        cmd.Parameters.AddWithValue("@serie", numero_serie2.Text);
                        cmd.Parameters.AddWithValue("@garantia_inicio", inicio_garantia2.Text);
                        cmd.Parameters.AddWithValue("@garantia_final", final_garantia2.Text);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion2.SelectedValue);
                        cmd.Parameters.AddWithValue("@departamento", area2.SelectedValue);
                        cmd.Parameters.AddWithValue("@proveedor", proveedor2.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica2.Text);
                        cmd.Parameters.AddWithValue("@fecha_compra", fecha_compra2.Text);
                        cmd.Parameters.AddWithValue("@costo", precio2.Text);
                        cmd.Parameters.AddWithValue("@estado", 1);
                        //invalidos
                        cmd.Parameters.AddWithValue("@aquisicion_ac", "");
                        cmd.Parameters.AddWithValue("@finalizacion_contrato", "");
                        cmd.Parameters.AddWithValue("@id_prestamo", 0);
                        cmd.ExecuteNonQuery();
                        excelente(actualizaDatosAC);
                        c.Desconectar(Conexion);
                        limpiar2();


                    }
                    catch (Exception t) { Response.Write("error" + t); }


                }






                if (RadioButton6.Checked)
                {
                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();

                    String Sql = @"UPDATE Activos SET  bd_tipo_activo = @tipo_activo, bd_descripcion_activo = @descripcion, bd_fecha_final_garantia = @garantia_final, bd_fecha_inicio_garantia = @garantia_inicio, bd_numero_serie = @serie,  bd_departamento = @departamento, bd_proveedor = @proveedor, bd_especificacion_tecnica = @especificacion_tecnica, bd_aquisicion_ac = @aquisicion_ac, bd_finalizacion_contrato = @finalizacion_contrato, bd_fecha_compra = @fecha_compra, bd_costo_activo = @costo , bd_id_prestamo =  @id_prestamo, bd_estado = @estado WHERE bd_numero_placa = @placa";
                    Conexion.Open();//abrimos conexion    
                    try
                    {
                        SqlCommand cmd = new SqlCommand(Sql, Conexion);
                        cmd.Parameters.AddWithValue("@tipo_activo", "Hardware");
                        cmd.Parameters.AddWithValue("@placa", numero_placa2.Text);
                        cmd.Parameters.AddWithValue("@serie", numero_serie2.Text);
                        cmd.Parameters.AddWithValue("@garantia_inicio", inicio_garantia2.Text);
                        cmd.Parameters.AddWithValue("@garantia_final", final_garantia2.Text);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion2.SelectedValue);
                        cmd.Parameters.AddWithValue("@departamento", area2.SelectedValue);
                        cmd.Parameters.AddWithValue("@proveedor", proveedor2.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica2.Text);
                        cmd.Parameters.AddWithValue("@fecha_compra", fecha_compra2.Text);
                        cmd.Parameters.AddWithValue("@costo", precio2.Text);
                        cmd.Parameters.AddWithValue("@estado", 1);
                        //invalidos
                        cmd.Parameters.AddWithValue("@aquisicion_ac", "");
                        cmd.Parameters.AddWithValue("@finalizacion_contrato", "");
                        cmd.Parameters.AddWithValue("@id_prestamo", 0);
                        cmd.ExecuteNonQuery();
                        excelente(actualizaDatosAC);
                        c.Desconectar(Conexion);
                        limpiar2();


                    }
                    catch (Exception t) { Response.Write("error" + t); }
                }

                //if (RadioButton4.Checked)
                //{
                //    Conexion c = new Conexion();
                //    SqlConnection Conexion = c.Conectar();
                //    string Sql = @"INSERT INTO Activos (bd_tipo_activo, bd_numero_placa, bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia, bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica, bd_aquisicion_ac, bd_finalizacion_contrato, bd_fecha_compra, bd_costo_activo, bd_id_prestamo, bd_estado) 
                //        values (@tipo_activo, @placa, @serie, @garantia_inicio, @garantia_final, @descripcion, @departamento, @proveedor, @especificacion_tecnica, @aquisicion_ac, @finalizacion_contrato,  @fecha_compra, @costo , @id_prestamo, @estado)";

                //    Conexion.Open();//abrimos conexion    
                //    try
                //    {
                //        SqlCommand cmd = new SqlCommand(Sql, Conexion);

                //        cmd.Parameters.AddWithValue("@tipo_activo", "Leasing");
                //        cmd.Parameters.AddWithValue("@placa", numero_placa.Text);
                //        cmd.Parameters.AddWithValue("@serie", numero_serie.Text);
                //        cmd.Parameters.AddWithValue("@aquisicion_ac", fecha_adquisicion.Text);
                //        cmd.Parameters.AddWithValue("@finalizacion_contrato", finalizacion_contrato.Text);
                //        cmd.Parameters.AddWithValue("@costo", precio.Text);
                //        cmd.Parameters.AddWithValue("@descripcion", descripcion.SelectedValue);
                //        cmd.Parameters.AddWithValue("@departamento", area.SelectedValue);
                //        cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedValue);
                //        cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica.Text);
                //        //insertar invalidos
                //        cmd.Parameters.AddWithValue("@garantia_inicio", "");
                //        cmd.Parameters.AddWithValue("@garantia_final", "");
                //        cmd.Parameters.AddWithValue("@fecha_compra", "");
                //        cmd.Parameters.AddWithValue("@id_prestamo", 0);
                //        cmd.Parameters.AddWithValue("@estado", 1);
                //        cmd.ExecuteNonQuery();
                //        c.Desconectar(Conexion);
                //        excelente(Button1);
                //        Response.Redirect("gestionActivos.aspx");



                //    }
                //    catch (Exception t) { Response.Write("error" + t); }
                //}

            }
        }

        protected void BajaActivo_Click(object sender, EventArgs e) {
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"UPDATE Activos SET bd_estado = @estado WHERE bd_numero_placa = @placa ";
                Conexion.Open();//abrimos conexion    
                try
                {
                    SqlCommand cmd = new SqlCommand(Sql, Conexion);
                    cmd.Parameters.AddWithValue("@placa", numero_placa2.Text);
                    cmd.Parameters.AddWithValue("@estado", 4);
                    //invalidos
                    cmd.ExecuteNonQuery();
                    //excelente(darBaja);
                    c.Desconectar(Conexion);

                    Response.Redirect("gestionActivos.aspx");

                }
                catch (Exception t) { Response.Write("error" + t); }
        }

        protected void limpiar1() {
            RadioButton2.Checked = false;
            RadioButton3.Checked = false;
            RadioButton4.Checked = false;
            numero_placa.Text = "";
            fecha_compra.Text = "";
            numero_serie.Text = "";
            fecha_adquisicion.Text = "";
            finalizacion_contrato.Text = "";
            precio.Text = "";
            fecha_compra.Text = "";
            inicio_garantia.Text = "";
            final_garantia.Text = "";
            descripcion.SelectedIndex = 0;
            area.SelectedIndex = 0;
            proveedor.SelectedIndex = 0;
            especificacion_tecnica.Text = "";

        }

        protected void limpiar2()
        {
            RadioButton5.Checked = false;
            RadioButton6.Checked = false;
            numero_placa2.Text = "";
            fecha_compra2.Text = "";
            numero_serie2.Text = "";
            //fecha_entrega3.Text = "";
            //finalizacion_contrato3.Text = "";
            precio2.Text = "";
            fecha_compra2.Text = "";
            inicio_garantia2.Text = "";
            final_garantia2.Text = "";
            descripcion2.SelectedIndex = 0;
            area2.SelectedIndex = 0;
            proveedor2.SelectedIndex = 0;
            especificacion_tecnica2.Text = "";

        }

        protected void limpiarArea() {
            id_areas.Text = "";
            descripcion_area.Text = "";
        }

        protected void limpiarDescrip()
        {
            id_descripcion_nueva.Text = "";
            descripcion_nueva.Text = "";
        }

        protected void limpiarPro()
        {
            idp.Text = "";
            nproveedor.Text = "";
            correo.Text = "";
            telefono.Text = "";
            telefono1.Text = "";
        }

    }

        
}



