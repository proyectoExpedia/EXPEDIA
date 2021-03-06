﻿using System;
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
        //Page_Load carga la sesion, en caso de no tener actividad sera dirigido al index,
        //se carga los datos de las diferentes opciones de uso en el formulario         
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["Usuario"].Equals("Inicio"))
            {
                Session["Usuario"] = "Anonimo";
                Response.Redirect("index.aspx");
            }

            if (!IsPostBack)
            {
                cargar_area(area);
                cargar_descripcion(descripcion);
                cargar_proveedor(proveedor);
                cargar_area(area2);
                cargar_descripcion(descripcion2);
                cargar_proveedor(proveedor2);
            }

            bny.Style.Add("display", "none");


        }
        //el ingresar procede a validar si existe los datos en la base, de no existir registra los datos en la base segun sea:
        protected void Bt_Ingresar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //validate is successful.
            }

            if (corroborarExistenciaDatos("Activos", "bd_numero_placa", numero_placa.Text, Button1) && corroborarExistenciaDatos("Activos", "bd_numero_serie", numero_serie.Text, Button1))
            {
                
                // si se seleciono sofawre registra los datos correspondientes del formulario 
                if (RadioButton2.Checked)
                {
                    //crea la concexion para ejecutar la insercion
                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"INSERT INTO Activos (bd_tipo_activo, bd_numero_placa, bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia, bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica, bd_aquisicion_ac, bd_finalizacion_contrato, bd_fecha_compra, bd_costo_activo, bd_id_prestamo, bd_estado,bd_motivos) values (@tipo_activo, @placa, @serie, @garantia_inicio, @garantia_final, @descripcion, @departamento, @proveedor, @especificacion_tecnica, @aquisicion_ac, @finalizacion_contrato,  @fecha_compra, @costo , @id_prestamo, @estado, @motivos)";

                    Conexion.Open();//abrimos conexion    
                    try
                    {
                        SqlCommand cmd = new SqlCommand(Sql, Conexion);
                        cmd.Parameters.AddWithValue("@tipo_activo", "Software");
                        cmd.Parameters.AddWithValue("@fecha_compra", (Convert.ToDateTime(fecha_compra.Text).ToString("yyyy/MM/dd")).ToString());
                        cmd.Parameters.AddWithValue("@costo", precio.Text);
                        cmd.Parameters.AddWithValue("@placa", numero_placa.Text);
                        cmd.Parameters.AddWithValue("@serie", numero_serie.Text);
                        cmd.Parameters.AddWithValue("@garantia_inicio", (Convert.ToDateTime(fecha_compra.Text).ToString("yyyy/MM/dd")).ToString());
                        cmd.Parameters.AddWithValue("@garantia_final", (Convert.ToDateTime(final_garantia.Text).ToString("yyyy/MM/dd")).ToString());
                        cmd.Parameters.AddWithValue("@descripcion", descripcion.SelectedValue);
                        cmd.Parameters.AddWithValue("@departamento", area.SelectedValue);
                        cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica.Text);
                        cmd.Parameters.AddWithValue("@estado", 1);
                        //invalidos
                        cmd.Parameters.AddWithValue("@aquisicion_ac", "");
                        cmd.Parameters.AddWithValue("@finalizacion_contrato", "");
                        cmd.Parameters.AddWithValue("@id_prestamo", 0);
                        cmd.Parameters.AddWithValue("@motivos", "Activo");
                        cmd.ExecuteNonQuery();

                        c.Desconectar(Conexion);
                        excelente(Button1);
                        //System.Threading.Thread.Sleep(9000);

                        limpiar1();



                    }
                    catch (Exception t) { Response.Write("error" + t); }


                }
                // si se seleciono hardware registra los datos correspondientes del formulario 
                if (RadioButton3.Checked)
                {
                    //crea la concexion para ejecutar la insercion
                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();
                    string Sql = @"INSERT INTO Activos (bd_tipo_activo, bd_numero_placa, bd_numero_serie, bd_fecha_inicio_garantia, bd_fecha_final_garantia, bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica, bd_aquisicion_ac, bd_finalizacion_contrato, bd_fecha_compra, bd_costo_activo, bd_id_prestamo, bd_estado,bd_motivos) values (@tipo_activo, @placa, @serie, @garantia_inicio, @garantia_final, @descripcion, @departamento, @proveedor, @especificacion_tecnica, @aquisicion_ac, @finalizacion_contrato,  @fecha_compra, @costo , @id_prestamo, @estado, @motivos)";

                    Conexion.Open();//abrimos conexion    
                    try
                    {
                        SqlCommand cmd = new SqlCommand(Sql, Conexion);
                        cmd.Parameters.AddWithValue("@tipo_activo", "Hardware");
                        cmd.Parameters.AddWithValue("@fecha_compra", (Convert.ToDateTime(fecha_compra.Text).ToString("yyyy/MM/dd")).ToString());
                        cmd.Parameters.AddWithValue("@costo", precio.Text);
                        cmd.Parameters.AddWithValue("@placa", numero_placa.Text);
                        cmd.Parameters.AddWithValue("@serie", numero_serie.Text);
                        cmd.Parameters.AddWithValue("@garantia_inicio", (Convert.ToDateTime(fecha_compra.Text).ToString("yyyy/MM/dd")).ToString());
                        cmd.Parameters.AddWithValue("@garantia_final", (Convert.ToDateTime(final_garantia.Text).ToString("yyyy/MM/dd")).ToString());
                        cmd.Parameters.AddWithValue("@descripcion", descripcion.SelectedValue);
                        cmd.Parameters.AddWithValue("@departamento", area.SelectedValue);
                        cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica.Text);
                        cmd.Parameters.AddWithValue("@estado", 1);
                        //invalidos
                        cmd.Parameters.AddWithValue("@aquisicion_ac", "");
                        cmd.Parameters.AddWithValue("@finalizacion_contrato", "");
                        cmd.Parameters.AddWithValue("@id_prestamo", 0);
                        cmd.Parameters.AddWithValue("@motivos", "Activo");
                        cmd.ExecuteNonQuery();
                        excelente(Button1);
                        c.Desconectar(Conexion);

                        limpiar1();

                    }
                    catch (Exception t) { Response.Write("error" + t); }
                }
                // si se seleciono hardware registra los datos correspondientes del formulario 
                if (RadioButton4.Checked)
                {
                    //crea la concexion para ejecutar la insercion
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
                        cmd.Parameters.AddWithValue("@aquisicion_ac",(Convert.ToDateTime(fecha_adquisicion.Text).ToString("yyyy/MM/dd")).ToString());
                        cmd.Parameters.AddWithValue("@finalizacion_contrato", (Convert.ToDateTime(finalizacion_contrato.Text).ToString("yyyy/MM/dd")).ToString());
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
        //metodo que verifica que no exista un activo con ese id
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

        //carga los valores alojados en la base de datos de area para mostrar en el dropdown de areas disponibles
        protected void cargar_area(DropDownList dropdown)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_id_area, bd_descripcion FROM Areas WHERE bd_estado = 1";
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
        //carga los valores alojados en la base de datos de proveedor para mostrar en el dropdown de proveedor disponibles
        protected void cargar_proveedor(DropDownList dropdown)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_id_proveedor, bd_nombre_proveedor FROM Proveedores WHERE bd_estado = 1";
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
        //carga los valores alojados en la base de datos de descripcion para mostrar en el dropdown de descripcion disponibles
        protected void cargar_descripcion(DropDownList dropdown)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_id_descripcion, Descripcion FROM Descripcion where bd_estado = 1 ";
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

        //se registra los datos de una nueva area
        protected void btn_Registrar_Area_Click(object sender, EventArgs e)
        {
            if (corroborarExistenciaDatos("Areas", "bd_id_area", id_areas.Text, Registrar_Area))
            {

                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"INSERT INTO Areas (bd_id_area, bd_descripcion, bd_estado,bd_motivos) values (@idA, @descripcionA,@estado,@motivos)";

                Conexion.Open();//abrimos conexion

                try
                {
                    SqlCommand cmd = new SqlCommand(Sql, Conexion);
                    cmd.Parameters.AddWithValue("@idA", id_areas.Text); //enviamos los parametros
                    cmd.Parameters.AddWithValue("@descripcionA", descripcion_area.Text);
                    cmd.Parameters.AddWithValue("@estado", 1);
                    cmd.Parameters.AddWithValue("@motivos", "Activo");
                    cmd.ExecuteNonQuery();
                    c.Desconectar(Conexion);
                    ListItem item = new ListItem(descripcion_area.Text, id_areas.Text, true);
                    area.Items.Add(item);
                    // Cuando lo ingresa tiene que meterlos en los 2 dropdown Antes estaba solo el de arriba, yo agregue el de abajo
                    area2.Items.Add(item);
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
        //se registra los datos de una nueva descripcion
        protected void btn_Registrar_Descripcion_Ac_Click(object sender, EventArgs e)
        {
            if (corroborarExistenciaDatos("Descripcion", "bd_id_descripcion", id_descripcion_nueva.Text, Registar_Descripcion_Ac))
            {

                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"INSERT INTO Descripcion (bd_id_descripcion, Descripcion, bd_motivos, bd_estado) values (@id, @descripcion,@motivos,@estado)";

                Conexion.Open();//abrimos conexion

                try
                {
                    SqlCommand cmd = new SqlCommand(Sql, Conexion);
                    cmd.Parameters.AddWithValue("@id", id_descripcion_nueva.Text); //enviamos los parametros
                    cmd.Parameters.AddWithValue("@descripcion", descripcion_nueva.Text);
                    cmd.Parameters.AddWithValue("@estado", 1);
                    cmd.Parameters.AddWithValue("@motivos", "Activo");
                    cmd.ExecuteNonQuery();
                    c.Desconectar(Conexion);
                    ListItem item2 = new ListItem(descripcion_nueva.Text, id_descripcion_nueva.Text, true);
                    descripcion.Items.Add(item2);
                    descripcion2.Items.Add(item2);
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
        //se registra los datos de una nuevo proveedor
        protected void btn_Registrar_Proveedor_Click(object sender, EventArgs e)
        {
            if (corroborarExistenciaDatos("Proveedores", "bd_nombre_proveedor", nproveedor.Text, Resgistrar_Proveedor))
            {
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"INSERT INTO Proveedores (bd_id_proveedor, bd_nombre_proveedor, bd_correo_electronico_prov, bd_numero_telefonico_empresa, bd_numero_contacto, bd_motivos, bd_estado) values (@idProv, @nombProv, @CorreoProv, @telProv, @telCont,@motivos,@estado)";

                Conexion.Open();//abrimos conexion

                try
                {
                    SqlCommand cmd = new SqlCommand(Sql, Conexion);
                    cmd.Parameters.AddWithValue("@idProv", idp.Text); //enviamos los parametros
                    cmd.Parameters.AddWithValue("@nombProv", nproveedor.Text);
                    cmd.Parameters.AddWithValue("@CorreoProv", correo.Text);
                    cmd.Parameters.AddWithValue("@telProv", telefono1.Text);
                    cmd.Parameters.AddWithValue("@telCont", telefono.Text);
                    cmd.Parameters.AddWithValue("@motivos", "Activo");
                    cmd.Parameters.AddWithValue("@estado", 1);
                    cmd.ExecuteNonQuery();
                    ListItem item3 = new ListItem(nproveedor.Text, idp.Text, true);
                    proveedor.Items.Add(item3);
                    proveedor2.Items.Add(item3);
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
        //mensaje mostrado si los datos son correctos
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
        //si algunos de los datos son erroneos se muestra este mensaje
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
        //protected void Bt_Modificar_Click(object sender, EventArgs e)
        //{
        //    if (Page.IsValid)
        //    {
        //        //validate is successful.
        //    }

        //    if (corroborarExistenciaDatos("Activos", "bd_numero_placa", numero_placa.Text, Button1) && corroborarExistenciaDatos("Activos", "bd_numero_serie", numero_serie.Text, Button1))
        //    {
        //        if (RadioButton2.Checked)
        //        {
        //            Conexion c = new Conexion();
        //            SqlConnection Conexion = c.Conectar();
        //            string Sql = @"UPDATE Activos SET (bd_tipo_activo = @tipo_activo, bd_numero_placa = @placa, bd_numero_serie = @serie, bd_fecha_inicio_garantia = @garantia_inicio, bd_fecha_final_garantia = @garantia_final, bd_descripcion_activo = @descripcion, bd_departamento = @departamento, bd_proveedor = @proveedor, bd_especificacion_tecnica = @especificacion_tecnica, bd_fecha_compra = @fecha_compra, bd_costo_activo = @costo, bd_estado = @estado) 
        //                            WHERE (bd_numero_placa = @placa)";

        //            Conexion.Open();//abrimos conexion    
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand(Sql, Conexion);
        //                cmd.Parameters.AddWithValue("@tipo_activo", "Software");
        //                cmd.Parameters.AddWithValue("@fecha_compra", fecha_compra.Text);
        //                cmd.Parameters.AddWithValue("@costo", precio.Text);
        //                cmd.Parameters.AddWithValue("@placa", numero_placa.Text);
        //                cmd.Parameters.AddWithValue("@serie", numero_serie.Text);
        //                cmd.Parameters.AddWithValue("@garantia_inicio", inicio_garantia.Text);
        //                cmd.Parameters.AddWithValue("@garantia_final", final_garantia.Text);
        //                cmd.Parameters.AddWithValue("@descripcion", descripcion.SelectedValue);
        //                cmd.Parameters.AddWithValue("@departamento", area.SelectedValue);
        //                cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedItem.Text);
        //                cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica.Text);
        //                cmd.Parameters.AddWithValue("@estado", 1);
        //                cmd.ExecuteNonQuery();

        //                c.Desconectar(Conexion);
        //                excelente(Button1);
        //                //System.Threading.Thread.Sleep(9000);

        //                Response.Redirect("gestionActivos.aspx");
        //            }
        //            catch (Exception t) { Response.Write("error" + t); }
        //        }
        //        if (RadioButton3.Checked)
        //        {
        //            Conexion c = new Conexion();
        //            SqlConnection Conexion = c.Conectar();

        //            string Sql = @"UPDATE Activos SET (bd_tipo_activo = @tipo_activo, bd_numero_placa = @placa, bd_numero_serie = @serie, bd_fecha_inicio_garantia = @garantia_inicio, bd_fecha_final_garantia = @garantia_final, bd_descripcion_activo = @descripcion, bd_departamento = @departamento, bd_proveedor = @proveedor, bd_especificacion_tecnica = @especificacion_tecnica, bd_fecha_compra = @fecha_compra, bd_costo_activo = @costo, bd_estado = @estado) 
        //                            WHERE (bd_numero_placa = @placa)";
        //            Conexion.Open();//abrimos conexion    
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand(Sql, Conexion);
        //                cmd.Parameters.AddWithValue("@tipo_activo", "Hardware");
        //                cmd.Parameters.AddWithValue("@placa", numero_placa.Text);
        //                cmd.Parameters.AddWithValue("@serie", numero_serie.Text);
        //                cmd.Parameters.AddWithValue("@garantia_inicio", inicio_garantia.Text);
        //                cmd.Parameters.AddWithValue("@garantia_final", final_garantia.Text);
        //                cmd.Parameters.AddWithValue("@descripcion", descripcion.SelectedValue);
        //                cmd.Parameters.AddWithValue("@departamento", area.SelectedValue);
        //                cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedValue);
        //                cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica.Text);
        //                cmd.Parameters.AddWithValue("@fecha_compra", fecha_compra.Text);
        //                cmd.Parameters.AddWithValue("@costo", precio.Text);
        //                cmd.Parameters.AddWithValue("@estado", 1);
        //                cmd.ExecuteNonQuery();
        //                excelente(Button1);
        //                c.Desconectar(Conexion);

        //                Response.Redirect("gestionActivos.aspx");

        //            }
        //            catch (Exception t) { Response.Write("error" + t); }
        //        }
        //        if (RadioButton4.Checked)
        //        {
        //            Conexion c = new Conexion();
        //            SqlConnection Conexion = c.Conectar();

        //            string Sql = @"UPDATE Activos SET (bd_tipo_activo = @tipo_activo, bd_numero_placa = @placa, bd_numero_serie = @serie, bd_aquisicion_ac = @adquiscion, bd_finalizacion_contrato = @finalizacion,, bd_costo_activo = @costo, bd_descripcion_activo = @descripcion, bd_departamento = @departamento, bd_proveedor = @proveedor, bd_especificacion_tecnica = @especificacion_tecnica) 
        //                            WHERE (bd_numero_placa = @placa)";
        //            Conexion.Open();//abrimos conexion    
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand(Sql, Conexion);

        //                cmd.Parameters.AddWithValue("@tipo_activo", "Leasing");
        //                cmd.Parameters.AddWithValue("@placa", numero_placa.Text);
        //                cmd.Parameters.AddWithValue("@serie", numero_serie.Text);
        //                cmd.Parameters.AddWithValue("@adquiscion", fecha_adquisicion.Text);
        //                cmd.Parameters.AddWithValue("@finalizacion", finalizacion_contrato.Text);
        //                cmd.Parameters.AddWithValue("@costo", precio.Text);
        //                cmd.Parameters.AddWithValue("@descripcion", descripcion.SelectedValue);
        //                cmd.Parameters.AddWithValue("@departamento", area.SelectedValue);
        //                cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedValue);
        //                cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica.Text);
        //                cmd.ExecuteNonQuery();
        //                c.Desconectar(Conexion);
        //                excelente(Button1);
        //                Response.Redirect("gestionActivos.aspx");
        //            }
        //            catch (Exception t) { Response.Write("error" + t); }
        //        }
        //    }
        //}
        // ----------- Modificar, deberíamos crear un boton en la tuerca que permita consultar área, proveedor y descripción ----------//
        
        //al habilitar la modificaciones de provedor se puede cambiar todos los atributos correspondientes 
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
        //modificacion de todos los atributos de una descripcion registrada
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
        //modificacion de todos los atributos de una area registrada
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
        //metodo que muestra las opciones segun los privilegios
        protected void mostrarConsultaAC()
        {
            ocultoAC.Style.Add("display", "block");

        }
        //da la posibilidades de habilitar los campos para modificacion
        protected void habilitarCampos()
        {
            numero_placa2.ReadOnly = true;
            numero_serie2.ReadOnly = true;
            precio2.ReadOnly = false;
            fecha_compra2.ReadOnly = false;
            //inicio_garantia2.ReadOnly = false;
            final_garantia2.ReadOnly = false;
            descripcion2.Enabled = true;
            area2.Enabled = true;
            proveedor2.Enabled = true;
            especificacion_tecnica2.ReadOnly = false;
            bny.Style.Add("display", "block");
            RadioButton5.Enabled = true;
            RadioButton6.Enabled = true;
            notificacionCampos(habilitarMA);
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
        //metodo para no poder digitar los campos 
        protected void inhabilitarCampos()
        {
            numero_placa2.ReadOnly = true;
            numero_serie2.ReadOnly = true;
            precio2.ReadOnly = true;
            fecha_compra2.ReadOnly = true;
            //inicio_garantia2.ReadOnly = true;
            final_garantia2.ReadOnly = true;
            descripcion2.Enabled = false;
            area2.Enabled = false;
            proveedor2.Enabled = false;
            especificacion_tecnica2.ReadOnly = true;
            RadioButton5.Enabled = false;
            RadioButton6.Enabled = false;

        }
        //carga desde base de datos todas la descripciones disponibles
        protected String cargaridDescrip(String descrip)
        {
            String i = "";
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT Descripcion FROM Descripcion WHERE bd_id_descripcion = '" + descrip + "'";
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
        //carga desde base de datos todas la areas disponibles
        protected String cargaridArea(String AuxArea)
        {
            String x = "";
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT bd_descripcion FROM Areas WHERE bd_id_area = '" + AuxArea + "'";
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
        //metodo para mostrar si existe el activo consultado
        protected void bt_consultarAC_Click(object sender, EventArgs e)
        {

            int validacion=0;
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            try
            {
                string Sql = @"SELECT * FROM Activos WHERE bd_numero_placa = @placa OR bd_numero_serie =@placa";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion            
                cmd.Parameters.AddWithValue("@placa", placa_buscar.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetInt16(14) != 2)
                        {

                            if (reader.GetInt16(14) == 4)
                            {
                                controles.Style.Add("display", "none");
                                error(btn_consultarAc, "Disculpa", "El activo número de placa: " + placa_buscar.Text + " ha sido donado, no podrás realizar acciones sobre este activo");
                            }
                            else {
                                if (reader.GetInt16(14) == 3) {
                                    controles.Style.Add("display", "none");
                                    error(btn_consultarAc, "Disculpa", "El activo número de placa " + placa_buscar.Text + " se encuentra prestado, debes dirigirte a la gestión de préstamos y finalizarlo");
                                }
                                else { 
                                    controles.Style.Add("display", "block");
                                }
                            }

                            if (reader.GetString(0) == "Software")
                            {
                                this.RadioButton5.Checked = true;
                                //this.btn5.Style.Add("background-color", "#204d74");
                                this.RadioButton6.Checked = false;
                                //this.btn6.Style.Add("background-color", "#337ab7");
                                numero_placa2.Text = reader.GetString(1);
                                numero_serie2.Text = reader.GetString(2);
                                precio2.Text = reader.GetInt32(12).ToString();
                                String fechaC = reader.GetDateTime(11).ToString("dd/MM/yyyy");

                                fecha_compra2.Text = fechaC;
                                /*
                                String fechaIG = reader.GetDateTime(3).ToString("dd/MM/yyyy");*/


                                /* inicio_garantia2.Text = fechaIG;*/
                                String fechaFG = reader.GetDateTime(4).ToString("dd/MM/yyyy");

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
                                        validacion++;
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
                                        validacion++;
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
                                        validacion++;
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
                                String fechaC = reader.GetDateTime(11).ToString("dd/MM/yyyy");

                                fecha_compra2.Text = fechaC;
                                /* String fechaIG = reader.GetDateTime(3).ToString("dd/MM/yyyy");

                                 inicio_garantia2.Text = fechaIG;*/
                                String fechaFG = reader.GetDateTime(4).ToString("dd/MM/yyyy");

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
                                        validacion++;
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
                                        validacion++;
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
                                        validacion++;
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

                        else {
                            if (reader.GetInt16(14) == 2)
                            {
                                Habilitar_Activo(reader.GetString(1),reader.GetString(16));
                            }
                            else {
                                if (reader.GetInt16(14) == 4) { 
                                    //donacion; alertar y no tirar la info
                                }
                            }
                        
                        }
                    }
                    if (validacion == 3)
                    {
                        excelente(btn_consultarAc);
                        mostrarConsultaAC();
                        inhabilitarCampos();
                    }
                    else {
                        if (validacion > 0)
                        {
                            error(btn_consultarAc, "Disculpa", "Los datos del activo no pueden ser accedidos debido a que el departamento, proveedor o descripción se encuentran inhabilitados");
                        } 
                   }
                }
                else
                {
                    ocultarConsulta();
                    error(btn_consultarAc, "Disculpa", "El valor " + placa_buscar.Text + " no existe en el sistema");
                }
            }
            catch (Exception ex)
            {
                error(btn_consultarAc, "Disculpa", "Los datos del activo no pueden ser accedidos debido a que el departamento, proveedor o descripción se encuentran inhabilitados");
                ex.ToString();
            }
            finally {
                Conexion.Close();
            }
        }
        //metodo para ocultar bloques segun privilegios
        protected void ocultarConsulta()
        {
            ocultoAC.Style.Add("display", "none");

        }

        protected void bt_Habilitar_Modif_Click(object sender, EventArgs e)
        {

            habilitarCampos();


        }
        //guarda los datos modificados del activo
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
                    String Sql = @"UPDATE Activos SET  bd_tipo_activo = @tipo_activo, bd_descripcion_activo = @descripcion, bd_fecha_final_garantia = @garantia_final, bd_fecha_inicio_garantia = @garantia_inicio, bd_numero_serie = @serie,  bd_departamento = @departamento, bd_proveedor = @proveedor, bd_especificacion_tecnica = @especificacion_tecnica, bd_aquisicion_ac = @aquisicion_ac, bd_finalizacion_contrato = @finalizacion_contrato, bd_fecha_compra = @fecha_compra, bd_costo_activo = @costo  WHERE bd_numero_placa = @placa";

                    Conexion.Open();//abrimos conexion    
                    try
                    {
                        SqlCommand cmd = new SqlCommand(Sql, Conexion);
                        cmd.Parameters.AddWithValue("@tipo_activo", "Software");
                        cmd.Parameters.AddWithValue("@fecha_compra", (Convert.ToDateTime(fecha_compra2.Text).ToString("yyyy/MM/dd")).ToString());
                        cmd.Parameters.AddWithValue("@costo", precio2.Text);
                        cmd.Parameters.AddWithValue("@placa", numero_placa2.Text);
                        cmd.Parameters.AddWithValue("@serie", numero_serie2.Text);
                        cmd.Parameters.AddWithValue("@garantia_inicio", (Convert.ToDateTime(fecha_compra2.Text).ToString("yyyy/MM/dd")).ToString());
                        cmd.Parameters.AddWithValue("@garantia_final", (Convert.ToDateTime(final_garantia2.Text).ToString("yyyy/MM/dd")).ToString());
                        cmd.Parameters.AddWithValue("@descripcion", descripcion2.SelectedValue);
                        cmd.Parameters.AddWithValue("@departamento", area2.SelectedValue);
                        cmd.Parameters.AddWithValue("@proveedor", proveedor2.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica2.Text);
                        //cmd.Parameters.AddWithValue("@estado", 1);
                        //invalidos
                        cmd.Parameters.AddWithValue("@aquisicion_ac", "");
                        cmd.Parameters.AddWithValue("@finalizacion_contrato", "");
                        //cmd.Parameters.AddWithValue("@id_prestamo", 0);
                        cmd.ExecuteNonQuery();
                        excelente(actualizaDatosAC);
                        c.Desconectar(Conexion);
                        limpiar2();


                    }
                    catch (Exception t) { Response.Write("error" + t); }
                    finally {
                        ocultarConsulta();
                    }


                }






                if (RadioButton6.Checked)
                {
                    Conexion c = new Conexion();
                    SqlConnection Conexion = c.Conectar();

                    String Sql = @"UPDATE Activos SET  bd_tipo_activo = @tipo_activo, bd_descripcion_activo = @descripcion, bd_fecha_final_garantia = @garantia_final, bd_fecha_inicio_garantia = @garantia_inicio, bd_numero_serie = @serie,  bd_departamento = @departamento, bd_proveedor = @proveedor, bd_especificacion_tecnica = @especificacion_tecnica, bd_aquisicion_ac = @aquisicion_ac, bd_finalizacion_contrato = @finalizacion_contrato, bd_fecha_compra = @fecha_compra, bd_costo_activo = @costo  WHERE bd_numero_placa = @placa";
                    Conexion.Open();//abrimos conexion    
                    try
                    {
                        SqlCommand cmd = new SqlCommand(Sql, Conexion);
                        cmd.Parameters.AddWithValue("@tipo_activo", "Hardware");
                        cmd.Parameters.AddWithValue("@fecha_compra", (Convert.ToDateTime(fecha_compra2.Text).ToString("yyyy/MM/dd")).ToString());
                        cmd.Parameters.AddWithValue("@costo", precio2.Text);
                        cmd.Parameters.AddWithValue("@placa", numero_placa2.Text);
                        cmd.Parameters.AddWithValue("@serie", numero_serie2.Text);
                        cmd.Parameters.AddWithValue("@garantia_inicio", (Convert.ToDateTime(fecha_compra2.Text).ToString("yyyy/MM/dd")).ToString());
                        cmd.Parameters.AddWithValue("@garantia_final", (Convert.ToDateTime(final_garantia2.Text).ToString("yyyy/MM/dd")).ToString());
                        cmd.Parameters.AddWithValue("@descripcion", descripcion2.SelectedValue);
                        cmd.Parameters.AddWithValue("@departamento", area2.SelectedValue);
                        cmd.Parameters.AddWithValue("@proveedor", proveedor2.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica2.Text);
                        //cmd.Parameters.AddWithValue("@estado", 1);
                        //invalidos
                        cmd.Parameters.AddWithValue("@aquisicion_ac", "");
                        cmd.Parameters.AddWithValue("@finalizacion_contrato", "");
                        //cmd.Parameters.AddWithValue("@id_prestamo", 0);
                        //cmd.Parameters.AddWithValue("@motivos", "Activo");
                        cmd.ExecuteNonQuery();
                        cmd.ExecuteNonQuery();
                        excelente(actualizaDatosAC);
                        c.Desconectar(Conexion);
                        limpiar2();


                    }
                    catch (Exception t) { Response.Write("error" + t); }
                    finally
                    {
                        ocultarConsulta();
                    }
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
        //cambia el esto del activo para darlo de baja
        protected void BajaActivo_Click(object sender, EventArgs e) {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"UPDATE Activos SET bd_estado = @estado, bd_motivos = @motivos WHERE bd_numero_placa = @placa ";
            Conexion.Open();//abrimos conexion    
            try
            {
                SqlCommand cmd = new SqlCommand(Sql, Conexion);
                cmd.Parameters.AddWithValue("@placa", numero_placa2.Text);
                cmd.Parameters.AddWithValue("@estado", 2);
                cmd.Parameters.AddWithValue("@motivos", TextArea1.Text);
                cmd.ExecuteNonQuery();
                excelente(Btn_inhabilitar);
                c.Desconectar(Conexion);
                ocultarConsulta();
                



            }
            catch (Exception t) { Response.Write("error" + t); }
        }
        //limpiar los espacios de formulario
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
            //inicio_garantia.Text = "";
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
            //inicio_garantia2.Text = "";
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

        protected void Habilitar_Activo(string placa,string motivos)
        {
            numero_inhabilitado.InnerText = placa;
            motivos_inhabilitacion.Attributes.Add("data-content", motivos);
            detalle.Visible = true;

        }

      

        protected void close_Click(object sender, EventArgs e)
        {
            detalle.Visible = false;
        }

        protected void Habilitar_Click1(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"UPDATE Activos SET bd_estado = @estado, bd_motivos=@motivos WHERE bd_numero_placa = @placa ";
            Conexion.Open();//abrimos conexion    
            try
            {
                string placa = numero_inhabilitado.InnerText;
                SqlCommand cmd = new SqlCommand(Sql, Conexion);
                cmd.Parameters.AddWithValue("@placa", numero_inhabilitado.InnerText);
                cmd.Parameters.AddWithValue("@motivos", TextBox2.Text);
                cmd.Parameters.AddWithValue("@estado", 1);
                //invalidos
                cmd.ExecuteNonQuery();
                excelente(Btn_inhabilitar);
                c.Desconectar(Conexion);



            }
            catch (Exception t) { Response.Write("error" + t); }
            finally { numero_inhabilitado.InnerText = ""; }
                detalle.Visible = false;
            }


    
    }
        
}



