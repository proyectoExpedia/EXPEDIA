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
    public partial class Prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void Consultar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
           
            dt.Columns.AddRange(new DataColumn[11] {
                               new DataColumn("_proveedor", typeof(string)),
                               new DataColumn("_descripcion_activo", typeof(string)),
                            new DataColumn("Placa", typeof(string)),
                            new DataColumn("Serie",typeof(string)),
                             new DataColumn("bd_tipo_activo",typeof(string)),
                              new DataColumn("fecha_garantia_activo",typeof(string)),
                               new DataColumn("departamento",typeof(string)),
                                new DataColumn("especificacion_tecnica",typeof(string)),
                                 new DataColumn("duracion_de_contrato",typeof(string)),
                                  new DataColumn("fecha_compra",typeof(string)),
                                   new DataColumn("costo_activo",typeof(string)),



            });
            

            try
            {
                string num = numero.Text;
                Conexion c = new Conexion();
                SqlConnection Conexion = c.Conectar();
                string Sql = @"SELECT * FROM Activos  WHERE bd_numero_placa= @num OR bd_numero_serie = @num";
                Conexion.Open();//abrimos conexion
                SqlCommand cmd = new SqlCommand(Sql, Conexion); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@num", num); //enviamos los paramet

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                   
                        dt.Rows.Add(reader.GetInt16(0).ToString(), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3).ToString(), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetDateTime(8).ToString(), reader.GetDateTime(9).ToString(), reader.GetInt32(10).ToString());
                    }

                    lista.DataSource = dt;
                    lista.DataBind();
                }
            }
            catch (Exception a) { Response.Write(a); }
        }
    }

    }
