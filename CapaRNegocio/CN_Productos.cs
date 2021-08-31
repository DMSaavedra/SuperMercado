using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaRNegocio
{
    public class CN_Productos
    {
        private CD_Productos objeoCD = new CD_Productos();

        public DataTable mostrar_products()
        {
            DataTable tabla = new DataTable();
            tabla = objeoCD.mostrar();
            return tabla;
        }

        public DataTable mostrar_products_activos()
        {
            DataTable tabla = new DataTable();
            tabla = objeoCD.mostrarActivos();
            return tabla;
        }

        public DataTable cargar_marcas()
        {
            DataTable tabla2 = new DataTable();
            tabla2 = objeoCD.CargarCmbMarcas();
            return tabla2;
        }
        public DataTable cargar_categoria()
        {
            DataTable tabla3 = new DataTable();
            tabla3 = objeoCD.CargarCmbCategorias();
            return tabla3;
        }

        public void crear_prod(string nom, string cant, string pvp, string fechaUn, string fechaDos, byte[] imagePrd, string marc, string catg)
        {
            objeoCD.insertar(nom, Convert.ToInt32(cant), Convert.ToDecimal(pvp), Convert.ToDateTime(fechaUn), Convert.ToDateTime(fechaDos), imagePrd, Convert.ToInt32(marc), Convert.ToInt32(catg));
        }

        public void editar_prod(string nom, string cant, string pvp, string fechaUn, string fechaDos, byte[] imagePrd, string marc, string catg, string id)
        {
            objeoCD.editar(nom, Convert.ToInt32(cant), Convert.ToDecimal(pvp), Convert.ToDateTime(fechaUn), Convert.ToDateTime(fechaDos), imagePrd, Convert.ToInt32(marc), Convert.ToInt32(catg), Convert.ToInt32(id));
        }
        public void eliminar_prod(string id)
        {
            objeoCD.eliminar(Convert.ToInt32(id));
        }
    }
}
