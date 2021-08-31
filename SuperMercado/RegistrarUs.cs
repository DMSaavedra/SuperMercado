using CapaRNegocio;
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
    public partial class RegistrarUs : Form
    {
        private CN_Usuarios objetoCN = new CN_Usuarios();
        //private string idTusu = null;
        private bool editar = false;

        public RegistrarUs()
        {
            InitializeComponent();
        }

        public void limpiar()
        {
            txtNombresComp.Text = txtCedula.Text = txtContrasenia.Text = txtTelefono.Text = "";
            //cmbTipoUsuario.Text = "Seleccione";
            editar = false;
        }
        private void RegistrarUs_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombresComp.Text) || string.IsNullOrEmpty(txtCedula.Text) ||
                string.IsNullOrEmpty(txtContrasenia.Text) || string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("No puede dejar campos vacios");
            }
            else
            {
                if (editar == false)
                {
                    try
                    {
                        objetoCN.crear_userUS(txtNombresComp.Text, txtCedula.Text, txtContrasenia.Text, txtTelefono.Text);
                        //objetoCN.crear_userUS(txtNombresComp.Text, txtCedula.Text, txtUsuario.Text, txtContrasenia.Text, txtCorreo.Text, txtTelefono.Text);
                        MessageBox.Show("Usuario Creado con Exito!!");
                        limpiar();
                        //this.Hide();
                        //new Form1().ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Datos no Guardados" + ex.Message);
                        throw;
                    }
                }
                
            }    
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
        }

        private void txtNombresComp_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Digite Unicamente LETRAS", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txtCedula_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Digite Unicamente NÚMEROS", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress_1(object sender, KeyPressEventArgs e)
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
