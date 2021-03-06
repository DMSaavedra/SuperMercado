using CapaRNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMercado
{
    public partial class Form1 : Form
    {
        private CN_Usuarios objetoCN = new CN_Usuarios();

        //Creamos la Conexion
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-M0HDS4L2\DBSEGUNDO;Initial Catalog=SuperMercado;Integrated Security=True");


        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new RegistrarUs().ShowDialog();
            this.Close();
        }

        public void limpiar()
        {
            txtCedula.Text = txtContraseña.Text = "";
        }

        public void Logueo(string UsuCedula, string UsuContrasenia)
        {
            con.Open();
            SqlCommand query = new SqlCommand("SELECT * FROM tblUsuarios WHERE UsuCedula = @ced", con);
            query.Parameters.AddWithValue("ced", UsuCedula);
            SqlDataAdapter sda = new SqlDataAdapter(query);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            if (dt.Rows.Count == 1)
            {
                con.Open();
                SqlCommand query2 = new SqlCommand("SELECT UsuCedula, UsuContrasenia, idTusu FROM tblUsuarios WHERE UsuCedula = @ced and UsuContrasenia = @passw", con);
                query2.Parameters.AddWithValue("ced", UsuCedula);
                query2.Parameters.AddWithValue("passw", UsuContrasenia);
                SqlDataAdapter sda1 = new SqlDataAdapter(query2);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                con.Close();

                if (dt1.Rows.Count == 1)
                {
                    //Buscar Datos
                    SqlCommand query3 = new SqlCommand("SELECT * FROM tblUsuarios WHERE UsuCedula = @ced", con);
                    query3.Parameters.AddWithValue("ced", UsuCedula);
                    con.Open();
                    SqlDataReader registro = query3.ExecuteReader();

                    if (dt1.Rows[0][2].ToString() == "1")
                    {
                        if (registro.Read())
                        {
                            string nom = registro["UsuNombreComp"].ToString();
                            MessageBox.Show("Bienvenido al Sistema Administrador: \n" + nom);

                            this.Hide();
                            new Administrador().ShowDialog();
                            this.Close();

                        }
                        con.Close();
                    }
                    else if (dt1.Rows[0][2].ToString() == "3")
                    {
                        if (registro.Read())
                        {
                            string nom = registro["UsuNombreComp"].ToString();
                            MessageBox.Show("Bienvenido al Sistema Usuario: \n" + nom);

                            this.Hide();
                            new DetalleCompra().ShowDialog();
                            this.Close();
                        }
                        con.Close();
                    }  
                }
                else
                {
                    MessageBox.Show("Datos Incorrectos!!");
                }
            }
            else
            {
                MessageBox.Show("Usuario No Encontrado");
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCedula.Text) || string.IsNullOrEmpty(txtContraseña.Text))
            {
                MessageBox.Show("No puede dejar campos vacios");
            }
            else
            {
                Logueo(txtCedula.Text, txtContraseña.Text);
                limpiar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Dashboard().ShowDialog();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (txtContraseña.PasswordChar == '*')
                {
                    txtContraseña.PasswordChar = '\0';
                }
            }
            else
            {
                txtContraseña.PasswordChar = '*';
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new RegistrarUs().ShowDialog();
            this.Close();
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Digite Unicamente NÚMEROS", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }
    }
}
