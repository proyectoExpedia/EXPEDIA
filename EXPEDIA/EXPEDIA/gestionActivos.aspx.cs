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
            cargar_area(area);
            cargar_descripcion(descripcion);
            cargar_proveedor(proveedor);


        }
        protected void Bt_Ingresar_Click(object sender, EventArgs e)
        {



            if (RadioButton2.Checked)
            {
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"INSERT INTO Activos (bd_tipo_activo, bd_numero_placa, bd_numero_serie, bd_fecha_garantia_activo, bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica,bd_fecha_compra, bd_costo_activo) values (@tipo_activo, @placa, @serie, @garantia, @descripcion,@departamento,@proveedor,@especificacion_tecnica,@fecha_compra, @costo)";

                Conexion.Open();//abrimos conexion    
                try
                {
                    SqlCommand cmd = new SqlCommand(Sql, Conexion);


                    cmd.Parameters.AddWithValue("@tipo_activo", "");
                    cmd.Parameters.AddWithValue("@fecha_compra", fecha_compra.Text);
                    cmd.Parameters.AddWithValue("@costo", precio.Text);
                    cmd.Parameters.AddWithValue("@placa", numero_placa.Text);
                    cmd.Parameters.AddWithValue("@serie", numero_serie.Text);
                    cmd.Parameters.AddWithValue("@garantia", inicio_garantia.Text);
                    cmd.Parameters.AddWithValue("@garantia", final_garantia.Text);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion.SelectedValue);
                    cmd.Parameters.AddWithValue("@departamento", area.SelectedValue);
                    cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedValue);
                    cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica.Text);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("gestionActivos.aspx");
                    c.Desconectar(Conexion);

                }
                catch (Exception t) { Response.Write("error" + t); }


            }






            if (RadioButton3.Checked)
            {
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"INSERT INTO Activos (bd_tipo_activo, bd_numero_placa, bd_numero_serie, bd_fecha_garantia_activo, bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica,bd_fecha_compra, bd_costo_activo) values (@tipo_activo, @placa, @serie, @garantia, @descripcion,@departamento,@proveedor,@especificacion_tecnica,@fecha_compra, @costo)";

                Conexion.Open();//abrimos conexion    
                try
                {
                    SqlCommand cmd = new SqlCommand(Sql, Conexion);
                    cmd.Parameters.AddWithValue("@tipo_activo", "");
                    cmd.Parameters.AddWithValue("@fecha_compra", fecha_entrega3.Text);
                    cmd.Parameters.AddWithValue("@costo", precio2.Text);
                    cmd.Parameters.AddWithValue("@placa", numero_placa2.Text);
                    cmd.Parameters.AddWithValue("@serie", numero_serie2.Text);
                    cmd.Parameters.AddWithValue("@garantia", inicio_garantia3.Text);
                    cmd.Parameters.AddWithValue("@garantia", final_garantia3.Text);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion.SelectedValue);
                    cmd.Parameters.AddWithValue("@departamento", descripcion.SelectedValue);
                    cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedValue);
                    cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica2.Text);

                    cmd.ExecuteNonQuery();
                    Response.Redirect("gestionActivos.aspx");
                    c.Desconectar(Conexion);
                }
                catch (Exception t) { Response.Write("error" + t); }
            }

            if (RadioButton4.Checked)
            {
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"INSERT INTO Activos (bd_tipo_activo, bd_numero_placa, bd_numero_serie, bd_fecha_garantia_activo, bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica,bd_duracion_de_contrato,bd_fecha_compra, bd_costo_activo) values (@tipo_activo, @placa, @serie, @garantia, @descripcion,@departamento,@proveedor,@especificacion_tecnica,@duracion_contrato,@fecha_compra, @costo)";

                Conexion.Open();//abrimos conexion    
                try
                {
                    SqlCommand cmd = new SqlCommand(Sql, Conexion);

                    cmd.Parameters.AddWithValue("@tipo_activo", RadioButton4.Text);
                    cmd.Parameters.AddWithValue("@placa", numero_placa.Text);
                    cmd.Parameters.AddWithValue("@serie", numero_serie.Text);
                    cmd.Parameters.AddWithValue("@garantia", inicio_garantia.ToString());
                    cmd.Parameters.AddWithValue("@garantia", final_garantia.ToString());
                    cmd.Parameters.AddWithValue("@descripcion", descripcion.SelectedValue);
                    cmd.Parameters.AddWithValue("@departamento", area.SelectedValue);
                    cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedValue);
                    cmd.Parameters.AddWithValue("@especificacion_tecnica", especificacion_tecnica.Text);
                    cmd.Parameters.AddWithValue("@duracion_contrato", finalizacion_contrato.ToString());
                    cmd.Parameters.AddWithValue("@fecha_compra", fecha_compra.ToString());
                    cmd.Parameters.AddWithValue("@costo", precio.Text);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("gestionActivos.aspx");
                    c.Desconectar(Conexion);
                }
                catch (Exception t) { Response.Write("error" + t); }


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

        protected void btn_Registrar_Descripcion_Click(object sender, EventArgs e)
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
                Response.Redirect("gestionActivos.aspx");

                cargar_descripcion(descripcion);

            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }

        }
        protected void btn_Registrar_Area_Click(object sender, EventArgs e)
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
                Response.Redirect("gestionActivos.aspx");

                cargar_descripcion(descripcion);

            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }

        }



    }

}
