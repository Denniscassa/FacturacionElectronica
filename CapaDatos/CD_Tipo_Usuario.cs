using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Tipo_Usuario
    {
        private int aId_TipoUsuario;
        private string aCargo;
        private string aDescripcion;

        private string aTexto;

        public int Id_TipoUsuario { get => aId_TipoUsuario; set => aId_TipoUsuario = value; }
        public string Cargo { get => aCargo; set => aCargo = value; }
        public string Descripcion { get => aDescripcion; set => aDescripcion = value; }
        public string Texto { get => aTexto; set => aTexto = value; }


        public CD_Tipo_Usuario()
        {
        }

        public CD_Tipo_Usuario(int pId_TipoUsuario, string pCargo, string pDescripcion, string ptextobuscar)
        {
            this.Id_TipoUsuario = pId_TipoUsuario;
            this.Cargo = pCargo;
            this.Descripcion = pDescripcion;
            this.Texto = ptextobuscar;
        }

        //metodo insertar
        public string Insertar(CD_Tipo_Usuario cD_Tipo_Usuario)
        {
            string rpta = "";
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                //codigo
                sqlConnection.ConnectionString = ConnectionToSql.cn;
                sqlConnection.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = sqlConnection;
                SqlCmd.CommandText = "SPINSERTAR_TIPO_USUARIO";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId_TipoUsuario = new SqlParameter();
                parId_TipoUsuario.ParameterName = "@Id_TipoUsuario";
                parId_TipoUsuario.SqlDbType = SqlDbType.Int;
                parId_TipoUsuario.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(parId_TipoUsuario);

                SqlParameter parCargo = new SqlParameter();
                parCargo.ParameterName = "@Cargo";
                parCargo.SqlDbType = SqlDbType.VarChar;
                parCargo.Size = 50;
                parCargo.Value = cD_Tipo_Usuario.Cargo;
                SqlCmd.Parameters.Add(parCargo);

                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@Cargo";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 50;
                parDescripcion.Value = cD_Tipo_Usuario.Descripcion;
                SqlCmd.Parameters.Add(parDescripcion);

                //ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESO REGISTRO";
            }
            catch(Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();               
            }
            return rpta;
        }

        //metodo editar 
        public string Editar(CD_Tipo_Usuario cD_Tipo_Usuario)
        {
            string rpta = "";
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                //codigo
                sqlConnection.ConnectionString = ConnectionToSql.cn;
                sqlConnection.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = sqlConnection;
                SqlCmd.CommandText = "SPEDITAR_TIPO_USUARIO";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId_TipoUsuario = new SqlParameter();
                parId_TipoUsuario.ParameterName = "@Id_TipoUsuario";
                parId_TipoUsuario.SqlDbType = SqlDbType.Int;
                parId_TipoUsuario.Value = cD_Tipo_Usuario.Id_TipoUsuario;   
                SqlCmd.Parameters.Add(parId_TipoUsuario);

                SqlParameter parCargo = new SqlParameter();
                parCargo.ParameterName = "@Cargo";
                parCargo.SqlDbType = SqlDbType.VarChar;
                parCargo.Size = 50;
                parCargo.Value = cD_Tipo_Usuario.Cargo;
                SqlCmd.Parameters.Add(parCargo);

                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@Cargo";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 50;
                parDescripcion.Value = cD_Tipo_Usuario.Descripcion;
                SqlCmd.Parameters.Add(parDescripcion);

                //ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE ACTUALIZÓ  REGISTRO";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }
            return rpta;

        }
        //metodo eliminar
        public string Eliminar (CD_Tipo_Usuario cD_Tipo_Usuario)
        {
            string rpta = "";
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                //codigo
                sqlConnection.ConnectionString = ConnectionToSql.cn;
                sqlConnection.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = sqlConnection;
                SqlCmd.CommandText = "SPELIMINAR_TIPO_USUARIO";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId_TipoUsuario = new SqlParameter();
                parId_TipoUsuario.ParameterName = "@Id_TipoUsuario";
                parId_TipoUsuario.SqlDbType = SqlDbType.Int;
                parId_TipoUsuario.Value = cD_Tipo_Usuario.Id_TipoUsuario;
                SqlCmd.Parameters.Add(parId_TipoUsuario);

                //ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE ELIMINÓ REGISTRO";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }
            return rpta;
        }
        //metodo mostrar
        public DataTable Mostar()
        {
            DataTable dtResultado = new DataTable("TIPO_USUARIO");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = ConnectionToSql.cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "SPMOSTRAR_TIPO_USUARIO";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(dtResultado);
            }
            catch(Exception ex)
            {
                dtResultado = null;
            }
            return dtResultado;

        }

        //metodo buscar
        public DataTable Buscar(CD_Tipo_Usuario cD_Tipo_Usuario)
        {
            DataTable dtResultado = new DataTable("TIPO_USUARIO");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = ConnectionToSql.cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "SPBUSCAR_TIPO_USUARIO";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@Cargo";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                parTextoBuscar.Value = cD_Tipo_Usuario.Texto;
                SqlCmd.Parameters.Add(parTextoBuscar);

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }
            return dtResultado;
        }


    }       
}
