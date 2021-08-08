using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Usuarios
    {
        CD_Conexion con = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public DataTable mostrar()
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "ListaUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            con.cerrar_conexion();

            return tabla;
        }

        public DataTable CargarCmbTipoUsario()
        {
            SqlDataAdapter sda = new SqlDataAdapter("CargarCmbTipoUsuario", con.abrir_conexion());
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt;
        }
        public void insertar(string UsuNombreComp, int UsuCedula, string UsuUsuario, string UsuContrasenia, string UsuCorreo, int UsuTelefono, int idTusu)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "CrearUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsuNombreComp", UsuNombreComp);
            cmd.Parameters.AddWithValue("@UsuCedula", UsuCedula);
            cmd.Parameters.AddWithValue("@UsuUsuario", UsuUsuario);
            cmd.Parameters.AddWithValue("@UsuContrasenia", UsuContrasenia);
            cmd.Parameters.AddWithValue("@UsuCorreo", UsuCorreo);
            cmd.Parameters.AddWithValue("@UsuTelefono", UsuTelefono);
            cmd.Parameters.AddWithValue("@idTusu", idTusu);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
        public void editar(string UsuNombreComp, int UsuCedula, string UsuUsuario, string UsuContrasenia, string UsuCorreo, int UsuTelefono, int idTusu, int idUsuario)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "EditarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsuNombreComp", UsuNombreComp);
            cmd.Parameters.AddWithValue("@UsuCedula", UsuCedula);
            cmd.Parameters.AddWithValue("@UsuUsuario", UsuUsuario);
            cmd.Parameters.AddWithValue("@UsuContrasenia", UsuContrasenia);
            cmd.Parameters.AddWithValue("@UsuCorreo", UsuCorreo);
            cmd.Parameters.AddWithValue("@UsuTelefono", UsuTelefono);
            cmd.Parameters.AddWithValue("@idTusu", idTusu);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
        public void eliminar(int idUsuario)
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "EliminarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.cerrar_conexion();
        }
    }
}
