using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Marca
    {
        CD_Conexion con = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public DataTable mostrar()
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "ListaMarcasActivos";
            //cmd.CommandText = "ListaMarcas"; //Todas las Marcas A & I
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            con.cerrar_conexion();

            return tabla;
        }

        public void insertar(string MrcPrdNombre)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "CrearMarca";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MrcPrdNombre", MrcPrdNombre);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
        public void editar(string MrcPrdNombre, int idMarcaPrd)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "EditarMarca";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MrcPrdNombre", MrcPrdNombre);
            cmd.Parameters.AddWithValue("@idMarcaPrd", idMarcaPrd);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
        public void eliminar(int idMarcaPrd)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "EliminarMarca";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idMarcaPrd", idMarcaPrd);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
    }
}
