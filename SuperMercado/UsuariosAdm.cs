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
    }
}
