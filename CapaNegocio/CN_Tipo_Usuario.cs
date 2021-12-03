using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    class CN_Tipo_Usuario
    {
        //metodo Insertar que llama al metodo insertar de la clase cd_tipo_usuario de la capa de datos
        public static string insertar(string cargo, string descripcion)
        {
            CD_Tipo_Usuario obj = new CD_Tipo_Usuario();
            obj.Cargo = cargo;
            obj.Descripcion = descripcion;
            return obj.Insertar(obj);
        }
        //metodo Editar que llama al metodo insertar de la clase cd_tipo_usuario de la capa de datos
        public static string editar(int idTipoUsuario, string cargo, string descripcion)
        {
            CD_Tipo_Usuario obj = new CD_Tipo_Usuario();
            obj.Id_TipoUsuario = idTipoUsuario;
            obj.Cargo = cargo;
            obj.Descripcion = descripcion;
            return obj.Editar(obj);
        }
        //metodo Eliminar que llama al metodo insertar de la clase cd_tipo_usuario de la capa de datos

        public static string eliminar(int idTipoUsuario)
        {
            CD_Tipo_Usuario obj = new CD_Tipo_Usuario();
            obj.Id_TipoUsuario = idTipoUsuario;
            return obj.Editar(obj);
        }
        //metodo Mostrar que llama al metodo insertar de la clase cd_tipo_usuario de la capa de datos
        public static DataTable mostrar()
        {
            return new CD_Tipo_Usuario().Mostar();
        }
        //metodo Buscar que llama al metodo insertar de la clase cd_tipo_usuario de la capa de datos
        public static DataTable buscar(string textobuscar)
        {
            CD_Tipo_Usuario obj = new CD_Tipo_Usuario();
            obj.Texto = textobuscar;
            return obj.Buscar(obj);
        }
    }
}
