using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;



namespace CapaDatos
{

    public class CD_Productos
    {
        //ATRIBUTOS
        private int Id_Producto; 
        private string Cod_Barra;
        private string Producto;
	    private string Codigo;
        private int Id_Categoria;
	    private int Id_Marca;
        private int Id_TipoPrenda;
	    private int Id_Tela;
	    private int Id_Modelo;
	    private int Id_Talla;
	    private string Descripcion;
        
       
        //CONSTRUCTOR
        public CD_Productos() { 
        }
        public CD_Productos(int pId_Producto, string pCod_Barra, string pProducto, string pCodigo, int pId_Categoria, int pId_Marca, int pId_TipoPrenda, int pId_Tela, int pId_Modelo, int pId_Talla,string pDescripcion) 
        {
            this.Id_Producto = pId_Producto;
            this.Cod_Barra = pCod_Barra;
            this.Codigo = pCodigo;
            this.Producto = pProducto;
            this.Id_Categoria = pId_Categoria;
            this.Id_Marca = pId_Marca;
            this.Id_TipoPrenda = pId_TipoPrenda;
            this.Id_Tela = pId_Tela;
            this.Id_Modelo = pId_Modelo;
            this.Id_Talla = pId_Talla;
            this.Descripcion = pDescripcion;
        }
        //GET Y SET
        public int aId_Producto { get=> Id_Producto; set =>Id_Producto=value; }
        public string aCod_Barra { get => Cod_Barra; set => Cod_Barra = value; }
        public string aCodigo { get => Codigo; set => Codigo = value; }
        public string aProducto { get => Producto; set => Producto = value; }
        public int aId_Categoria { get => Id_Categoria; set => Id_Categoria = value; }
        public int aId_Marca { get => Id_Marca; set => Id_Marca = value; }
        public int aId_TipoPrenda { get => Id_TipoPrenda; set => Id_TipoPrenda = value; }
        public int aId_Tela { get => Id_Tela; set => Id_Tela = value; }
        public int aId_Modelo { get => Id_Modelo; set => Id_Modelo = value; }
        public int aId_Talla { get => Id_Talla; set => Id_Talla = value; }
        public string aDescripcion { get => Descripcion; set => Descripcion = value; }


        //METODO
        //-----------------------------------------------------------------------------------------------------------------
        //metodo mostrar
        public DataTable Mostar()
        {
            DataTable dtResultado = new DataTable("PRODUCTOS");
            try
            {
                ConnectionToSql conexion = new ConnectionToSql();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = conexion.AbrirConexion();
                SqlCmd.CommandText = "SPLISTAR_PRODUCTOS";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(dtResultado);
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                dtResultado = null;
                Console.WriteLine(ex);
            }
            return dtResultado;

        }



    }
}
