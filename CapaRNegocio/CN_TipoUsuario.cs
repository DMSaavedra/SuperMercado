using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaRNegocio
{
    public class CN_TipoUsuario
    {
        private CD_TipoUsuario objetoCD = new CD_TipoUsuario();

        public DataTable mostrar_tusu()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.mostrar();
            return tabla;
        }
        public void crear_tusu(string nombre)
        {
            objetoCD.insertar(nombre);
        }
        public void editar_tusu(string nombre, string id)
        {
            objetoCD.editar(nombre, Convert.ToInt32(id));
        }
        public void eliminar_tusu(string id)
        {
            objetoCD.eliminar(Convert.ToInt32(id));
        }
    }
}
