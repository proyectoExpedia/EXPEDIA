using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security;


namespace EXPEDIA
{
    public class Conexion
    {
        public SqlConnection Conectar(){
            try{
                SqlConnection Conect;
                //Conect = new SqlConnection("Data Source=ROJAS-PC\\SQLEXPRESS;Initial Catalog=BD_EXPEDIA;Persist Security Info=True;User ID=Administrador;Password=123456");
                Conect = new SqlConnection("Data Source=DARUWARCHIEF-PC\\SQLEXPRESS;Initial Catalog=BD_EXPEDIA;User ID=root;Password=root123");
                 //Conect = new SqlConnection("Data Source=PERSONAL-PC\\CHUZ;Initial Catalog=BD_EXPEDIA;User ID=root;Password=root123");
                //Conect = new SqlConnection("Data Source=CHARLIE\\SQLEXPRESS; Initial Catalog=BD_EXPEDIA;User ID=root;Password=root123");
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

