using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace CapaDatos
{
    public  class  ConnectionToSql
    {
        //ATRIBUTOS

        public static string cn = "Data Source= DESKTOP-O080QAR/SQLEXPRESS ; Initial Catalog=db_topnevel; Integrated Security=true";

        private SqlConnection conexion= new SqlConnection("Server=PAPASCO; Integrated Security = true; Database=db_topnevel");


        //CONTRUCTOR
        public ConnectionToSql() 
        {
            //conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conector"].ConnectionString);
        }

        //METODOS
        public SqlConnection AbrirConexion() 
        {
            if (conexion.State == ConnectionState.Closed) 
            {
                conexion.Open();
            }
            return conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            return conexion;
        }


    }
}
