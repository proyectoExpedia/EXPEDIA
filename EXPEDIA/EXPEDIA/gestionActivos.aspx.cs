using System;
using System.Collections.Generic;
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
            cargar_area(departamento_activo);
            cargar_descripcion(descripcion_activo);
           
            cargar_proveedor(proveedor);
          
            
        }
        protected void Bt_Ingresar_Click(object sender, EventArgs e)
        {

            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"INSERT INTO Activos (bd_tipo_activo, bd_numero_placa, bd_numero_serie, bd_fecha_garantia_activo, bd_descripcion_activo, bd_departamento, bd_proveedor, bd_especificacion_tecnica, bd_duracion_de_contrato, bd_fecha_compra, bd_costo_activo) values (@tipo_activo, @placa, @serie, @garantia @descripcion,@departamento,@proveedor,@especificacion_tecnica,@duracion_contrato,@fecha_compra, @costo)";

            Conexion.Open();//abrimos conexion            
            try
            {
                SqlCommand cmd = new SqlCommand(Sql, Conexion);
                if (option1.Checked)
                {
                     
                    cmd.Parameters.AddWithValue("@tipo_activo", option1.Text);
                    cmd.Parameters.AddWithValue("@fecha_compra", "2016-02-16");
                    cmd.Parameters.AddWithValue("@costo", costo.Text);
                    cmd.Parameters.AddWithValue("@placa", nplaca.Text);
                    cmd.Parameters.AddWithValue("@serie", nserie.Text);
                    cmd.Parameters.AddWithValue("@garantia", "2016-02-16");
                    cmd.Parameters.AddWithValue("@descripcion", descripcion_activo.SelectedValue);
                    cmd.Parameters.AddWithValue("@departamento", descripcion_activo.SelectedValue);
                    cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedValue);
                    cmd.Parameters.AddWithValue("@especificacion_tecnica", especificaciones_tecnicas.Text);
                    cmd.Parameters.AddWithValue("@duracion_contrato", "2016-02-16");





                }





                if (option2.Checked)
                {
                    cmd.Parameters.AddWithValue("@tipo_activo", option2.Text);
                    cmd.Parameters.AddWithValue("@fecha_compra",  "2016-02-16");
                    cmd.Parameters.AddWithValue("@costo", costo.Text);
                    cmd.Parameters.AddWithValue("@placa", nplaca.Text);
                    cmd.Parameters.AddWithValue("@serie", nserie.Text);
                    cmd.Parameters.AddWithValue("@garantia", "2016-02-16");
                    cmd.Parameters.AddWithValue("@descripcion", descripcion_activo.SelectedValue);
                    cmd.Parameters.AddWithValue("@departamento", descripcion_activo.SelectedValue);
                    cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedValue);
                    cmd.Parameters.AddWithValue("@especificacion_tecnica", especificaciones_tecnicas.Text);
                    cmd.Parameters.AddWithValue("@duracion_contrato", "2016-02-16");
                }
                if (option3.Checked)
                {
                    cmd.Parameters.AddWithValue("@tipo_activo", option3.Text);
                    cmd.Parameters.AddWithValue("@placa", nplaca.Text);
                    cmd.Parameters.AddWithValue("@serie", nserie.Text);
                    cmd.Parameters.AddWithValue("@garantia", "2016-02-16");
                    cmd.Parameters.AddWithValue("@descripcion", descripcion_activo.SelectedValue);
                    cmd.Parameters.AddWithValue("@departamento", descripcion_activo.SelectedValue);
                    cmd.Parameters.AddWithValue("@proveedor", proveedor.SelectedValue);
                    cmd.Parameters.AddWithValue("@especificacion_tecnica", especificaciones_tecnicas.Text);
                    cmd.Parameters.AddWithValue("@duracion_contrato", "2016-02-16");
                    cmd.Parameters.AddWithValue("@fecha_compra", "2016-02-16");
                    cmd.Parameters.AddWithValue("@costo",int.Parse( costo.Text));
                }
                //enviamos los parametros

                cmd.ExecuteNonQuery();
                c.Desconectar(Conexion);
                Response.Write("error");
            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
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
            string Sql = @"SELECT bd_descripcion_activo FROM Activos";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String id = reader.GetString(0);
                // Crea un nuevo Item
                ListItem oItem = new ListItem(id, id);
                // Lo agrega a la colección de Items del DropDownList
                dropdown.Items.Add(oItem);
            }
            Conexion.Close();
        }
       


    }

    }
