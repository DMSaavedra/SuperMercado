using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_TipoUsuario
    {
        CD_Conexion con = new CD_Conexion();

        //---Propiedades del SQL
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand cmd = new SqlCommand();

        //---Metodos para la Programacion del CRUD
        public DataTable mostrar()
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "ListaTipoUsuarioActivos";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            con.cerrar_conexion();

            return tabla;
        }
        public void insertar(string TusuNombre)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "CrearTipoUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TusuNombre", TusuNombre);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
        public void editar(string TusuNombre, int idTusu)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "EditarTipoUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TusuNombre", TusuNombre);
            cmd.Parameters.AddWithValue("@idTusu", idTusu);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
        public void eliminar(int idTusu)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "EliminarTipoUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idTusu", idTusu);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
    }
}
