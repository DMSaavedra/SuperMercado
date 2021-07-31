using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Usuarios
    {
        //---Instancias la Clase
        CD_Conexion con = new CD_Conexion();

        //---Propiedades del SQL
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand cmd = new SqlCommand();

        //---Metodos para la Programacion del CRUD
        public DataTable mostrar()
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "MostrarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            con.cerrar_conexion();

            return tabla;
        }
        public void insertar(string UsuNombreComp, int UsuCedula, string UsuUsuario, string UsuContrasenia, string UsuCorreo, int UsuTelefono,int idTusu)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "IngresarUsuarios";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsuNombreComp", UsuNombreComp);
            cmd.Parameters.AddWithValue("@UsuCedula", UsuCedula);
            cmd.Parameters.AddWithValue("@UsuUsuario", UsuUsuario);
            cmd.Parameters.AddWithValue("@UsuContrasenia", UsuContrasenia);
            cmd.Parameters.AddWithValue("@UsuCorreo", UsuCorreo);
            cmd.Parameters.AddWithValue("@UsuTelefono", UsuTelefono);
            //UsuEstado
            cmd.Parameters.AddWithValue("@idTusu", idTusu);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
        public void editar(string UsuNombreComp, int UsuCedula, string UsuUsuario, string UsuContrasenia, string UsuCorreo, int UsuTelefono, int idUsuario)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "ActualizarUsuarios";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsuNombreComp", UsuNombreComp);
            cmd.Parameters.AddWithValue("@UsuCedula", UsuCedula);
            cmd.Parameters.AddWithValue("@UsuUsuario", UsuUsuario);
            cmd.Parameters.AddWithValue("@UsuContrasenia", UsuContrasenia);
            cmd.Parameters.AddWithValue("@UsuCorreo", UsuCorreo);
            cmd.Parameters.AddWithValue("@UsuTelefono", UsuTelefono);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
        public void eliminar(int idUsuario)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "EliminarUsuarios";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
    }
}
