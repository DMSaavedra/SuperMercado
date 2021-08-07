using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Categorias
    {
        CD_Conexion con = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public DataTable mostrar()
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "ListaCategoriaActivos";
            //cmd.CommandText = "ListaCategoria"; Todos los Usuarios A & I 
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            con.cerrar_conexion();

            return tabla;
        }

        public void insertar(string CartPrdNombre)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "CrearCategoria";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CartPrdNombre", CartPrdNombre);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
        public void editar(string CartPrdNombre, int idCatPrd)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "EditarCategoria";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CartPrdNombre", CartPrdNombre);
            cmd.Parameters.AddWithValue("@idCatPrd", idCatPrd);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
        public void eliminar(int idCatPrd)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "EliminarCategoria";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCatPrd", idCatPrd);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
    }
}
