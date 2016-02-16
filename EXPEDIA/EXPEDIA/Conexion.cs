using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace EXPEDIA
{
    public class Conexion
    {
        public SqlConnection Conectar(){
            try{
                SqlConnection Conect;
                Conect = new SqlConnection("Data Source=ROJAS-PC\\SQLEXPRESS;Initial Catalog=BD_EXPEDIA;User ID=Administrador;Password=123456");
                return Conect;
            }catch(Exception ){
                return null;
            }
        }
        
        public void Desconectar(SqlConnection Conect){
           Conect.Close();
        }
        
    }
}

