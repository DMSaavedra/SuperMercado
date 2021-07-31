using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaRNegocio
{
    public class CRN_Usuarios
    {
        //Instanciar Capa Datos
        private CD_Usuarios objCD = new CD_Usuarios();

        public DataTable mostrarUs()
        {
            DataTable tabla = new DataTable();
            tabla = objCD.mostrar();
            return tabla;
        }

        public void insertarUs(string nombreC, string cedula, string usuario, string contrasenia, string correo, string telefono, string TipoUsu)
        {
            objCD.insertar(nombreC, Convert.ToInt32(cedula), usuario, contrasenia, correo, Convert.ToInt32(telefono), Convert.ToInt32(TipoUsu));
        }
        public void editarUs(string nombreC, string cedula, string usuario, string contrasenia, string correo, string telefono, string id)
        {
            objCD.editar(nombreC, Convert.ToInt32(cedula), usuario, contrasenia, correo, Convert.ToInt32(telefono), Convert.ToInt32(id));
        }
        public void eliminarUs(string id)
        {
            objCD.eliminar(Convert.ToInt32(id));
        }
    }
}
