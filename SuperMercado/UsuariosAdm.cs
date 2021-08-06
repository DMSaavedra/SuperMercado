using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaRNegocio;

namespace SuperMercado
{
    public partial class UsuariosAdm : Form
    {
        //Instanciar Capa Reglas del Negocio
        private CRN_Usuarios objCRN = new CRN_Usuarios();
        private string idUsuario = null;
        private bool editar = false;

        public UsuariosAdm()
        {
            InitializeComponent();
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }

        private void limpiaCampos()
        {
            txtNombresComp.Clear();
            txtCedula.Clear();
            txtUsuario.Clear();
            txtContrasenia.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            cmbTipoUsuario.Text = "-- Seleccione --";
        }

        private void UsuariosAdm_Load(object sender, EventArgs e)
        {
            mostrarUsuarios();
        }

        private void mostrarUsuarios()
        {
            CRN_Usuarios objeto = new CRN_Usuarios();
            dgvUsuarios.DataSource = objeto.mostrar_user();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombresComp.Text) || string.IsNullOrEmpty(txtCedula.Text) ||
                string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtContrasenia.Text) ||
                string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrEmpty(txtTelefono.Text)) 
            {
                MessageBox.Show("Debe Llenar todos los Campos");
            }
            else if (cmbTipoUsuario.Text == "-- Seleccione --")
            {
                MessageBox.Show("Seleccione un Tipo de Usuario");
            }
            else
            {
                if (editar == false)
                {
                    try
                    {
                        objCRN.insertar_user(txtNombresComp.Text, txtCedula.Text, txtUsuario.Text, txtContrasenia.Text, txtCorreo.Text, txtTelefono.Text, cmbTipoUsuario.Text);
                        MessageBox.Show("Se Guardo Correctamente!");
                        mostrarUsuarios();
                        limpiaCampos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Datos No Guardados" + ex.Message);
                        throw;
                    }
                }
            }
        }
    }
}
