using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaRNegocio
{
    public class CN_Categorias
    {
        private CD_Categorias objetoCD = new CD_Categorias();

        public DataTable mostrar_cat()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.mostrar();
            return tabla;
        }
        public void crear_cat(string nombre)
        {
            objetoCD.insertar(nombre);
        }
        public void editar_cat(string nombre, string id)
        {
            objetoCD.editar(nombre, Convert.ToInt32(id));
        }
        public void eliminar_cat(string id)
        {
            objetoCD.eliminar(Convert.ToInt32(id));
        }
    }
}
