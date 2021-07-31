using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    class CD_Conexion
    {
        //Creamos la cadena de conexion 
        private SqlConnection conex = new SqlConnection(@"Data Source=LAPTOP-M0HDS4L2\DBSEGUNDO;Initial Catalog=SuperMercado;Integrated Security=True");

        //Metodos de apertura y Cierre de Conexion 
        public SqlConnection abrir_conexion()
        {
            if (conex.State == ConnectionState.Closed)
            {
                conex.Open();
            }
            return conex;
        }

        public SqlConnection cerrar_conexion()
        {
            if (conex.State == ConnectionState.Open)
            {
                conex.Close();
            }
            return conex;
        }
    }
}
