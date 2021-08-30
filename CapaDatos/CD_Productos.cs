using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Productos
    {
        CD_Conexion con = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public DataTable mostrar()
        {
            cmd.Connection = con.abrir_conexion();
            cmd.CommandText = "ListaProductos";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            con.cerrar_conexion();

            return tabla;
        }

        public DataTable CargarCmbMarcas()
        {
            SqlDataAdapter sda = new SqlDataAdapter("CargarCmbMarcas", con.abrir_conexion());
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt;
        }

        public DataTable CargarCmbCategorias()
        {
            SqlDataAdapter sda = new SqlDataAdapter("CargarCmbCategorias", con.abrir_conexion());
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt;
        }

        public void insertar()
        {

        }

        public void editar()
        {

        }

        public void eliminar()
        {

        }
    }
}
