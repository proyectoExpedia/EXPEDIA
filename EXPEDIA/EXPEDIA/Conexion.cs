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
                Conect = new SqlConnection("Data Source=CHARLIE-PC\\SQLEXPRESS;Initial Catalog=BD_EXPEDIA;User ID=root;Password=root1234");
                return Conect;
            }catch(Exception ex){
                return null;
            }
        }
        
        public void Desconectar(SqlConnection Conect){
           Conect.Close();
        }
        
    }
}

