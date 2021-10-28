using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Prueba
    {
        CD_Conexion con = new CD_Conexion();

        SqlCommand cmd = new SqlCommand();

        public void traerDatos()
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "DosDatos";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
    }
}
