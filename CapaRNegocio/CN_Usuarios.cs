using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaRNegocio
{
    public class CN_Usuarios
    {
        private CD_Usuarios objetoCD = new CD_Usuarios();

        public DataTable mostrar_user()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.mostrar();
            return tabla;
        }
        public DataTable cargar_tusus()
        {
            DataTable tabla2 = new DataTable();
            tabla2 = objetoCD.CargarCmbTipoUsario();
            return tabla2;
        }
        public void crear_user(string nombre, string cedula, string user, string pssw, string email, string telf, string tusu)
        {
            objetoCD.insertar(nombre, Convert.ToInt32(cedula), user, pssw, email, Convert.ToInt32(telf), Convert.ToInt32(tusu));
        }
        public void editar_user(string nombre, string cedula, string user, string pssw, string email, string telf, string tusu, string id)
        {
            objetoCD.editar(nombre, Convert.ToInt32(cedula), user, pssw, email, Convert.ToInt32(telf), Convert.ToInt32(tusu), Convert.ToInt32(id));
        }
        public void eliminar_user(string id)
        {
            objetoCD.eliminar(Convert.ToInt32(id));
        }
    }
}
