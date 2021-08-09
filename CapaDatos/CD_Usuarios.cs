using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public void Logueo(string UsuUsuario, string UsuContrasenia)
        {
            cmd.Connection = con.abrir_conexion();
            SqlCommand query = new SqlCommand("SELECT * FROM tblUsuarios WHERE UsuUsuario = @user", con.abrir_conexion());
            query.Parameters.AddWithValue("user", UsuUsuario);
            SqlDataAdapter sda = new SqlDataAdapter(query);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmd.Connection = con.cerrar_conexion();

            if (dt.Rows.Count == 1)
            {
                cmd.Connection = con.abrir_conexion();
                SqlCommand query2 = new SqlCommand("SELECT UsuUsuario, UsuContrasenia, idTusu FROM tblUsuarios WHERE UsuUsuario = @user and UsuContrasenia = @passw", con.abrir_conexion());
                query2.Parameters.AddWithValue("user", UsuUsuario);
                query2.Parameters.AddWithValue("passw", UsuContrasenia);
                SqlDataAdapter sda1 = new SqlDataAdapter(query2);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                cmd.Connection = con.cerrar_conexion();

                if (dt1.Rows.Count == 1)
                {
                    //Buscar Datos
                    SqlCommand query3 = new SqlCommand("SELECT * FROM tblUsuarios WHERE UsuUsuario = @user", con.abrir_conexion());
                    query3.Parameters.AddWithValue("user", UsuUsuario);
                    cmd.Connection = con.abrir_conexion();
                    SqlDataReader registro = query3.ExecuteReader();

                    if (dt1.Rows[0][2].ToString() == "1")
                    {
                        if (registro.Read())
                        {
                            string nom = registro["UsuNombreComp"].ToString();
                            MessageBox.Show("Bienvenido al Sistema Administrador: \n" + nom);
                            
                        }
                        cmd.Connection = con.cerrar_conexion();
                    }
                    else if (dt1.Rows[0][2].ToString() == "3")
                    {
                        if (registro.Read())
                        {
                            string nom = registro["UsuNombreComp"].ToString();
                            MessageBox.Show("Bienvenido al Sistema Usuario: \n" + nom);
                        }
                        cmd.Connection = con.cerrar_conexion();
                    }
                }
            }
            else
            {
                MessageBox.Show("Datos Incorrectos!!");
            }
        }
    }
}
