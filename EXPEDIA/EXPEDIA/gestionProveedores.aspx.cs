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
    public partial class gestionProveedores : System.Web.UI.Page
    {
        //carga de todos los proveedores en BD
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_provedores();
        }
        //selecciona de Bd todos los proveedores existentes con sus repectivos atributos
        protected void cargar_provedores() {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"SELECT * FROM Proveedores";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {   
                String id = reader.GetString(0);
                String nombre = reader.GetString(1);
                String correo = reader.GetString(2);
                int numero1 = reader.GetInt32(3);
                int numero2 = reader.GetInt32(4);
                String numeros  = numero1.ToString() + "\n" + numero2.ToString();
                String motivos= reader.GetString(5);
                int estado = reader.GetInt16(6);
                insertarRow(id, nombre, correo, numeros, motivos, estado);
            }
            Conexion.Close();
        
        }
        
        //inserta en la tabla todos los datos correspondientes al proveedor en el orden del formulario
        void insertarRow(String id, String nombre, String correo, String numeros, String motivos, int estado)
        {
            TableRow row = new TableRow();
            row.ID = id.ToString();
            row.ClientIDMode = ClientIDMode.Static;
            TableCell ide = new TableCell();
            TableCell nombrep = new TableCell();
            TableCell correop = new TableCell();
            TableCell numerosp = new TableCell();
            TableCell btn = new TableCell();
            TableCell motivo = new TableCell();
            
            ide.ColumnSpan = 1;
            ide.Text = id;
            nombrep.ColumnSpan = 1;
            nombrep.Text = nombre;
            correop.ColumnSpan = 1;
            correop.Text = correo;
            numerosp.Text = numeros;
            numerosp.ColumnSpan = 1;
            motivo.Text = motivos;
            if (estado == 1)
            {
                btn.Text = "<input type=\"button\" id=\"hola\" value=\"Modificar\" class=\"btn btn-primary\" onclick=\"modificar('" + id + "')\" data-toggle=\"modal\" data-target=\"#modalAreas\" /> " +
                            "<input type=\"button\" id=\"hola\" value=\"Inhabilitar\" class=\"btn btn-danger\" onclick=\"inhabilitar('" + id + "')\" data-toggle=\"modal\" data-target=\"#modalInhabilitar\" /> ";
            }
            else
            {
                btn.Text = "<input type=\"button\" id=\"hola\" value=\"Habilitar\" onclick=\"habilitar('" + id + "')\" class=\"btn btn-success\" data-toggle=\"modal\" data-target=\"#exampleModa\" /> ";
            }
            motivo.Style.Add("display", "none");
            row.Cells.Add(ide);
            row.Cells.Add(nombrep);
            row.Cells.Add(correop);
            row.Cells.Add(numerosp);
            row.Cells.Add(btn);
            row.Cells.Add(motivo);
            Table2.Rows.Add(row);

        }
        //metodo para eliminar un proveedor no deseado
        void eliminarRow(string id)
        {
            for (int i = 0; i < Table2.Rows.Count; i++)
            {
                if (Table2.Rows[i].ID == id)
                {
                    Table2.Rows.Remove(Table2.Rows[i]);
                }

            }
        }
        //ejecuta lainstrauccion para ingresar a BD el proveedor nuevo
        protected void btn_Registrar_Proveedor_Click(object sender, EventArgs e)
        {
            //verifica que no exista ya ese proveerdor con el id
            if (corroborarExistenciaDatos("Proveedores", "bd_id_proveedor", idp.Text, Resgistrar_Proveedor))
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
                    String numeros  = telefono1.Text + "\n" + telefono.Text;
                    insertarRow(idp.Text, nproveedor.Text,correo.Text,numeros, "Activo", 1);
                    limpiarIngresar();
                    c.Desconectar(Conexion);
                    excelente(Resgistrar_Proveedor);
                }
                catch (Exception a)
                {
                    Response.Write("error" + a.ToString());
                }
            }
        }
        //limpia el form de los datos ingresados anteriormente
        protected void limpiarIngresar()
        {
            try
            {
                idp.Text = "";
                nproveedor.Text = "";
                correo.Text = "";
                telefono.Text = "";
                telefono1.Text = "";
            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }


        }
        //comprueba en BD que el proveedor no exista antes de ser ingresado
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
        //mensaje modal mostrado si todos los datos son registrados correctamente
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
        //en caso de existir error de registro se muestra esta ventana
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
        //metodo existente para la actualizacion de un proveedor
        protected void Btn_modificar_proveedores_Click(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"UPDATE Proveedores SET bd_nombre_proveedor=@nombre, bd_correo_electronico_prov=@correo, bd_numero_telefonico_empresa=@telefono1, bd_numero_contacto=@telefono WHERE bd_id_proveedor=@id";
            Conexion.Open();//inicio de conexion
            try
            {
                SqlCommand cmd = new SqlCommand(Sql, Conexion);//ejecucion de la instruccion
                cmd.Parameters.AddWithValue("@nombre", nproveedorM.Text);
                cmd.Parameters.AddWithValue("@correo", correoM.Text);
                cmd.Parameters.AddWithValue("@telefono1",telefono1M.Text);
                cmd.Parameters.AddWithValue("@telefono",telefonoM.Text);
                cmd.Parameters.AddWithValue("@id",idpMO.Text);
                cmd.ExecuteNonQuery();
                eliminarRow(idpMO.Text);
                insertarRow(idpMO.Text, nproveedorM.Text, correoM.Text, telefono1M.Text + "\n" + telefonoM.Text, "Activo", 1);
                c.Desconectar(Conexion);
                excelente(Button1);

            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }
        }
        //metodo encargado de cambiar el estado a inhabilitado del proveedor
        protected void Btn_inhabilitar_Click(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"UPDATE Proveedores SET bd_estado=@area_estado, bd_motivos=@motivos WHERE bd_id_proveedor=@id_area";
            Conexion.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(Sql, Conexion);
                cmd.Parameters.AddWithValue("@area_estado", 2);
                cmd.Parameters.AddWithValue("@id_area", idpMO.Text);
                cmd.Parameters.AddWithValue("@motivos", TextArea1.Text);
                cmd.ExecuteNonQuery();
                c.Desconectar(Conexion);
                eliminarRow(idpMO.Text);
                insertarRow(idpMO.Text, nproveedorM.Text,correoM.Text,telefono1M.Text+"\n"+telefonoM.Text, TextArea1.Text, 2);
            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }
            excelente(Btn_inhabilitar);

        }
        //metodo encargado de cambiar el estado a habilitado del proveedor
        protected void btn_habilitarUsuario_Click(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"UPDATE Proveedores SET bd_estado=@area_estado, bd_motivos=@motivos WHERE bd_id_proveedor=@area";
            Conexion.Open();//inicio de la conexion
            try
            {
                SqlCommand cmd = new SqlCommand(Sql, Conexion);//ejecucion la sentencia de actualizar estado
                cmd.Parameters.AddWithValue("@area_estado", 1);
                cmd.Parameters.AddWithValue("@area", idpMO.Text);
                cmd.Parameters.AddWithValue("@motivos", "Activo");
                cmd.ExecuteNonQuery();
                eliminarRow(idpMO.Text);
                insertarRow(idpMO.Text, nproveedorM.Text, correoM.Text, telefono1M.Text + "\n" + telefonoM.Text, "Activo", 1);
                excelente(btn_habilitarUsuario);
            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }
            finally
            {
                c.Desconectar(Conexion);
            }

        }
    }
}