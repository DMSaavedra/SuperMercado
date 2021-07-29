using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMercado
{
    public partial class Form1 : Form
    {

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
            txtUsuario.Text = txtContraseña.Text = "";
        }

        public void logeo(string usu, string psswd)
        {
            string nombre = txtUsuario.Text;
            string contra = txtContraseña.Text;

            if (nombre == "diego" && contra == "12345")
            {
                MessageBox.Show("Bienvenido ADMINISTRADOR  \n" + nombre);

                this.Hide();
                new Administrador().ShowDialog();
                this.Close();

            }
            else if (nombre == "dams" && contra == "54321")
            {
                MessageBox.Show("Bienvenido USUARIO  \n" + nombre);

                this.Hide();
                new Dashboard().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrectas", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiar();
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtContraseña.Text))
            {
                MessageBox.Show("No puede dejar campos vacios");
            }
            else
            {
                logeo(txtUsuario.Text, txtContraseña.Text);
                limpiar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Dashboard().ShowDialog();
        }
    }
}
