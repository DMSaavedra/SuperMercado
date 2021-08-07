using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Proveedores
    {
        CD_Conexion con = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public DataTable mostrar()
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "ListaProveedoresActivos";
            //cmd.CommandText = "ListaProveedores"; //Todos los Usuarios A & I 
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            con.cerrar_conexion();

            return tabla;
        }
        public void insertar(string ProvNombre, int ProvCedula)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "CrearProveedor";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProvNombre", ProvNombre);
            cmd.Parameters.AddWithValue("@ProvCedula", ProvCedula);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
        public void editar(string ProvNombre, int ProvCedula, int idProveedor)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "EditarProveedor";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProvNombre", ProvNombre);
            cmd.Parameters.AddWithValue("@ProvCedula", ProvCedula);
            cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
        public void eliminar(int idProveedor)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "EliminarProveedor";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
    }
}
