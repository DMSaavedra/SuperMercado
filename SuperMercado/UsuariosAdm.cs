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
            dgvUsuarios.DataSource = objeto.mostrarUs();
        }
    }
}
