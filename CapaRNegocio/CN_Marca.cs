using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaRNegocio
{
    public class CN_Marca
    {
        private CD_Marca objetoCD = new CD_Marca();

        public DataTable mostrar_mrc()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.mostrar();
            return tabla;
        }

        public void crear_mrc(string marca)
        {
            objetoCD.insertar(marca);
        }
        public void editar_mrc(string marca, string id)
        {
            objetoCD.editar(marca, Convert.ToInt32(id));
        }
        public void eliminar_mrc(string id)
        {
            objetoCD.eliminar(Convert.ToInt32(id));
        }
    }
}
