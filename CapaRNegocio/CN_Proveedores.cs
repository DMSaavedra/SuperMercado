using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaRNegocio
{
    public class CN_Proveedores
    {
        private CD_Proveedores objetoCD = new CD_Proveedores();

        public DataTable mostrar_prov()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.mostrar();
            return tabla;
        }
        public void crear_prov(string nombre, string cedula)
        {
            objetoCD.insertar(nombre, Convert.ToInt32(cedula));
        }
        public void editar_prov(string nombre, string cedula, string id)
        {
            objetoCD.editar(nombre, Convert.ToInt32(cedula), Convert.ToInt32(id));
        }
        public void eliminar_prov(string id)
        {
            objetoCD.eliminar(Convert.ToInt32(id));
        }
    }
}
