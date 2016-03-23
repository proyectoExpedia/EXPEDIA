using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EXPEDIA
{
    public partial class gestionUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
       
                if (Session["Usuario"] == "Inicio")
                {
                    Session["Usuario"] = "Anonimo";
                    Response.Redirect("index.aspx");
                }

            cargar_puesto(puesto);
            cargar_area(area);
            cargar_area(area_actualizar);
            cargar_puesto(puesto_actualizar);

        }
        protected void Bt_Ingresar_Click(object sender, EventArgs e)
        {
            Session["Inhabilitado"] = "";
            if (corroborarExistenciaDatos("Usuarios", "bd_cedula", cedula_usuario.Text, Bt_Ingresar))
            {
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"INSERT INTO Usuarios (bd_tipo_usuario, bd_nombre, bd_apellido1, bd_apellido2, bd_telefono, bd_correo_electronico, bd_contrasena, bd_cedula, bd_id_puesto, bd_id_area, bd_motivos, bd_estado) values (@tipo_usuario, @nombre, @apellido, @apellido2, @telefono,@correo,@contrasena,@cedula,@puesto,@area,@motivos,@estado)";

                // Evaluar si existe...
                Conexion.Open();//abrimos conexion
                int tipo_usuariobd = Convert.ToInt32(tipo_usuario.SelectedValue);
                try
                {
                    SqlCommand cmd = new SqlCommand(Sql, Conexion);
                    cmd.Parameters.AddWithValue("@tipo_usuario", tipo_usuariobd); //enviamos los parametros
                    cmd.Parameters.AddWithValue("@nombre", nombre_usuario.Text);
                    cmd.Parameters.AddWithValue("@apellido", apellido_usuario1.Text);
                    cmd.Parameters.AddWithValue("@apellido2", apellido_usuario2.Text);
                    cmd.Parameters.AddWithValue("@telefono", telefono_usuario.Text);
                    cmd.Parameters.AddWithValue("@correo", correo_usuario.Text);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena_usuario.Text);
                    cmd.Parameters.AddWithValue("@cedula", cedula_usuario.Text);
                    cmd.Parameters.AddWithValue("@puesto", puesto.SelectedValue);
                    cmd.Parameters.AddWithValue("@area", area.SelectedValue);
                    cmd.Parameters.AddWithValue("@motivos", "Activo");
                    cmd.Parameters.AddWithValue("@estado", 1);
                    cmd.ExecuteNonQuery();
                    excelente(Bt_Ingresar);
                    //System.Threading.Thread.Sleep(9000);
                }
                catch (Exception a)
                {
                    Response.Write("error" + a.ToString());
                }
                finally
                {
                    Conexion.Close();
                    limpiarIngresar();
                }
            }
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

        protected void cargar_area(DropDownList dropdown)
        {
            if (dropdown.Items.Count < 2)
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
        }

        protected void cargar_puesto(DropDownList dropdown)
        {
            if (dropdown.Items.Count < 2)
            {
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT bd_id_puesto, bd_descripcion FROM Puestos";
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
        }
        protected void Btn_habilitar_Click(object sender, EventArgs e)
        {
            habilitarCampos();
        }
        protected void Btn_consultar_Click(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            int estado = 0;
            string motivos = "";
            Session["Inhabilitado"] = "";
            string Sql = @"SELECT * FROM Usuarios WHERE bd_cedula = @ced";
            Conexion.Open();//abrimos conexion
            SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion            
            cmd.Parameters.AddWithValue("@ced", cedula_consulta.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    bool tipo = reader.GetBoolean(0);
                    if (tipo) tipo_actualizar.SelectedValue = "1";
                    else tipo_actualizar.SelectedValue = "0";
                    nombre_actualizar.Text = reader.GetString(1);
                    apellido_actualizar1.Text = reader.GetString(2);
                    apellido_actualizar2.Text = reader.GetString(3);
                    telefono_actualizar.Text = reader.GetString(4);
                    correo_actualizar.Text = reader.GetString(5);
                    contrasena_actualizar.Text = reader.GetString(6);
                    rcontrasena_actualizar.Text = contrasena_actualizar.Text.ToString();
                    puesto_actualizar.SelectedValue = reader.GetString(8);
                    area_actualizar.SelectedValue = reader.GetString(9);
                    motivos = reader.GetString(10);
                    estado = reader.GetInt16(11);
                }
                if (estado == 3)
                {
                    mostrarInhabilitacion(Btn_consultar, motivos, cedula_consulta.Text);
                    inhabilitarCampos();
                    mostrarConsulta();
                }
                else
                {
                    this.controles.Style.Add("display", "block");
                    excelente(Btn_consultar);
                    inhabilitarCampos();
                    mostrarConsulta();
                }
            }
            else
            {
                error(Btn_consultar, " Usuario no encontrado", "");
                ocultarConsulta();
            }

            Conexion.Close();


        }
        public void inhabilitarCampos()
        {
            apellido_actualizar1.ReadOnly = true;
            tipo_actualizar.Enabled = false;
            nombre_actualizar.ReadOnly = true;
            apellido_actualizar1.ReadOnly = true;
            apellido_actualizar2.ReadOnly = true;
            telefono_actualizar.ReadOnly = true;
            correo_actualizar.ReadOnly = true;
            contrasena_actualizar.ReadOnly = true;
            rcontrasena_actualizar.ReadOnly = true;
            contrasena_actualizar.Attributes.Add("type", "password");
            rcontrasena_actualizar.Attributes.Add("type", "password");
            puesto_actualizar.Enabled = false;
            area_actualizar.Enabled = false;
            Btn_actualizar.Enabled = false;
            llaveAreas.Style.Add("display", "none");
            llavePuestos.Style.Add("display", "none");
        }
        public void habilitarCampos()
        {
            apellido_actualizar1.ReadOnly = false;
            tipo_actualizar.Enabled = true;
            nombre_actualizar.ReadOnly = false;
            apellido_actualizar1.ReadOnly = false;
            apellido_actualizar2.ReadOnly = false;
            telefono_actualizar.ReadOnly = false;
            correo_actualizar.ReadOnly = false;
            contrasena_actualizar.ReadOnly = false;
            rcontrasena_actualizar.ReadOnly = false;
            contrasena_actualizar.Attributes.Add("type", "password");
            rcontrasena_actualizar.Attributes.Add("type", "password");
            puesto_actualizar.Enabled = true;
            area_actualizar.Enabled = true;
            Btn_actualizar.Enabled = true;
            llaveAreas.Style.Add("display", "inline");
            llavePuestos.Style.Add("display", "inline");
            notificacionCampos(Btn_habilitar);

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
        protected void mostrarConsulta()
        {
            divOcultoConsulta.Style.Add("display", "block");
        }

        protected void ocultarConsulta()
        {
            divOcultoConsulta.Style.Add("display", "none");
            limpiarConsulta();

        }
        protected void limpiarConsulta()
        {
            try
            {
                nombre_actualizar.Text = "";
                apellido_actualizar1.Text = "";
                apellido_actualizar2.Text = "";
                telefono_actualizar.Text = "";
                correo_actualizar.Text = "";
                contrasena_actualizar.Text = "";
                rcontrasena_actualizar.Text = "";
                area_actualizar.SelectedIndex = 0;
                puesto_actualizar.SelectedIndex = 0;
                tipo_actualizar.SelectedIndex = 0;
                cedula_consulta.Text = "";
                TextArea1.Text = "";
            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }


        }

        protected void limpiarIngresar()
        {
            try
            {
                nombre_usuario.Text = "";
                apellido_usuario1.Text = "";
                apellido_usuario2.Text = "";
                telefono_usuario.Text = "";
                correo_usuario.Text = "";
                contrasena_usuario.Text = "";
                cedula_usuario.Text = "";
                area.SelectedIndex = 0;
                puesto.SelectedIndex = 0;
                tipo_usuario.SelectedIndex = 0;
            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }


        }
        protected void Bt_actualizar_Click(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"UPDATE Usuarios SET bd_tipo_usuario=@tipo_usuario, bd_nombre=@nombre, bd_apellido1=@apellido, bd_apellido2=@apellido2, bd_telefono=@telefono, bd_correo_electronico=@correo, bd_contrasena=@contrasena, bd_id_puesto=@puesto, bd_id_area=@area WHERE bd_cedula=@cedula";
            Conexion.Open();
            try
            {
                int tipo_usuarioac = Convert.ToInt32(tipo_actualizar.SelectedValue);
                SqlCommand cmd = new SqlCommand(Sql, Conexion);
                cmd.Parameters.AddWithValue("@tipo_usuario", true); //enviamos los parametros
                cmd.Parameters.AddWithValue("@nombre", nombre_actualizar.Text);
                cmd.Parameters.AddWithValue("@cedula", cedula_consulta.Text);
                cmd.Parameters.AddWithValue("@apellido", apellido_actualizar1.Text);
                cmd.Parameters.AddWithValue("@apellido2", apellido_actualizar2.Text);
                cmd.Parameters.AddWithValue("@telefono", telefono_actualizar.Text);
                cmd.Parameters.AddWithValue("@correo", correo_actualizar.Text);
                cmd.Parameters.AddWithValue("@contrasena", contrasena_actualizar.Text);
                cmd.Parameters.AddWithValue("@puesto", puesto_actualizar.SelectedValue);
                cmd.Parameters.AddWithValue("@area", area_actualizar.SelectedValue);
                cmd.ExecuteNonQuery();
                c.Desconectar(Conexion);

            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }


            ocultarConsulta();
            excelente(Btn_actualizar);

        }
        protected void Btn_ocupacion_Click(object sender, EventArgs e)
        {
            if (corroborarExistenciaDatos("Puestos", "bd_id_puesto", idocupacion.Text, Btn_ocupacion))
            {
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"INSERT INTO Puestos (bd_id_puesto, bd_descripcion) values (@id, @descripcion)";

                Conexion.Open();//abrimos conexion

                try
                {
                    SqlCommand cmd = new SqlCommand(Sql, Conexion);
                    cmd.Parameters.AddWithValue("@id", idocupacion.Text); //enviamos los parametros
                    cmd.Parameters.AddWithValue("@descripcion", ocupacion.Text);
                    cmd.ExecuteNonQuery();
                    c.Desconectar(Conexion);
                    ListItem item = new ListItem(ocupacion.Text, idocupacion.Text, true);
                    puesto.Items.Add(item);
                    puesto_actualizar.Items.Add(item);
                    excelente(Btn_ocupacion);
                    idocupacion.Text = "";
                    ocupacion.Text = "";

                }
                catch (Exception a)
                {
                    Response.Write("error" + a.ToString());
                }
            }

        }

        protected void Btn_areas_Click(object sender, EventArgs e)
        {
            if (corroborarExistenciaDatos("Areas", "bd_id_area", idareas.Text, Btn_areas))
            {
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"INSERT INTO Areas (bd_id_area, bd_descripcion) values (@id, @descripcion)";

                Conexion.Open();//abrimos conexion

                try
                {
                    SqlCommand cmd = new SqlCommand(Sql, Conexion);
                    cmd.Parameters.AddWithValue("@id", idareas.Text); //enviamos los parametros
                    cmd.Parameters.AddWithValue("@descripcion", areas.Text);
                    //Response.Redirect("gestionUsuarios.aspx");
                    cmd.ExecuteNonQuery();
                    c.Desconectar(Conexion);
                    ListItem item = new ListItem(areas.Text, idareas.Text, true);
                    area.Items.Add(item);
                    area_actualizar.Items.Add(item);
                    excelente(Btn_areas);
                    idareas.Text = "";
                    areas.Text = "";
                }
                catch (Exception a)
                {
                    Response.Write("error" + a.ToString());
                }
            }
        }

        protected void Btn_inhabilitar_Click(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"UPDATE Usuarios SET bd_estado=@usuario_estado, bd_motivos=@motivos WHERE bd_cedula=@cedula";
            Conexion.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(Sql, Conexion);
                cmd.Parameters.AddWithValue("@usuario_Estado", 3);
                cmd.Parameters.AddWithValue("@cedula", cedula_consulta.Text);
                cmd.Parameters.AddWithValue("@motivos", TextArea1.Text);
                cmd.ExecuteNonQuery();
                c.Desconectar(Conexion);

            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }
            excelente(Btn_inhabilitar);
            ocultarConsulta();
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

        protected void mostrarInhabilitacion(Control boton, string motivos, string cedula)
        {
            Session["Inhabilitado"] = cedula + "*" + motivos;
            this.controles.Style.Add("display", "none");
        }


        protected void btn_habilitarUsuario_Click(object sender, EventArgs e) {
            string[] separadores = { "*" };
            string[] final = Session["Inhabilitado"].ToString().Split(separadores, StringSplitOptions.RemoveEmptyEntries);
            Conexion c = new Conexion();
            SqlConnection Conexion = c.Conectar();
            string Sql = @"UPDATE Usuarios SET bd_estado=@usuario_estado, bd_motivos=@motivos WHERE bd_cedula=@cedula";
            Conexion.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(Sql, Conexion);
                cmd.Parameters.AddWithValue("@usuario_Estado", 1);
                cmd.Parameters.AddWithValue("@cedula", final[0]);
                cmd.Parameters.AddWithValue("@motivos", "Activo");
                cmd.ExecuteNonQuery();
                excelente(Btn_inhabilitar);
                this.controles.Style.Add("display", "block");
            }
            catch (Exception a)
            {
                Response.Write("error" + a.ToString());
            }
            finally {
                c.Desconectar(Conexion);
                Session["Inhabilitado"] = "";
            }
        
        }
    }

}