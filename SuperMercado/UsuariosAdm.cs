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
        private CN_Usuarios objetoCN = new CN_Usuarios();
        private string idUsuario = null;
        private bool editar = false;

        public UsuariosAdm()
        {
            InitializeComponent();
        }
        private void UsuariosAdm_Load(object sender, EventArgs e)
        {
            verUsuarios();
            verCmbTusu();
        }

        private void verUsuarios()
        {
            CN_Usuarios objeto = new CN_Usuarios();
            dgvUsuarios.DataSource = objeto.mostrar_user();
        }

        private void verCmbTusu()
        {
            CN_Usuarios objeto2 = new CN_Usuarios();
            cmbTipoUsuario.DataSource = objeto2.cargar_tusus();
            cmbTipoUsuario.DisplayMember = "TusuNombre";
            cmbTipoUsuario.ValueMember = "idTusu";
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int idTusu = Convert.ToInt32(cmbTipoUsuario.SelectedValue.ToString());

            if (string.IsNullOrEmpty(txtNombresComp.Text) && string.IsNullOrEmpty(txtCedula.Text) &&
                string.IsNullOrEmpty(txtContrasenia.Text) && string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("Debe Llenar El Campo!");
            }
            else if (cmbTipoUsuario.Text == "Seleccione")
            {
                MessageBox.Show("Seleccione un Dato..");

            }
            else
            {
                if (editar == false)
                {
                    try
                    {
                        objetoCN.crear_userAdm(txtNombresComp.Text, txtCedula.Text, txtContrasenia.Text, txtTelefono.Text, idTusu.ToString());
                        MessageBox.Show("Se Guardo Correctamente!");
                        verUsuarios();
                        limpiar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Datos no Guardados" + ex.Message);
                        throw;
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            txtNombresComp.Clear();
            txtCedula.Clear();
            txtContrasenia.Clear();
            txtTelefono.Clear();
            cmbTipoUsuario.Text = "Seleccione";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int idTusu = Convert.ToInt32(cmbTipoUsuario.SelectedValue.ToString());

            if (string.IsNullOrEmpty(txtNombresComp.Text) || string.IsNullOrEmpty(txtCedula.Text) || string.IsNullOrEmpty(txtContrasenia.Text) || string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("De Doble Click en una FILA de la tabla, para editar datos");
            }
            else
            {
                if (editar)
                {
                    try
                    {
                        objetoCN.editar_user(txtNombresComp.Text, txtCedula.Text, txtContrasenia.Text, txtTelefono.Text, idTusu.ToString(), idUsuario);
                        MessageBox.Show("Se edito correctamente..!");
                        btnRegistrar.Enabled = true;
                        verUsuarios();
                        limpiar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("NO se edito correctamente! " + ex.Message);
                        throw;
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombresComp.Text) || string.IsNullOrEmpty(txtCedula.Text) ||
                string.IsNullOrEmpty(txtContrasenia.Text) || string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("De Doble Click en una FILA de la tabla, para ELIMINAR datos");
            }
            else
            {
                try
                {
                    objetoCN.eliminar_user(idUsuario);
                    MessageBox.Show("Registro Eliminado!");
                    verUsuarios();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("NO SE Elimino el Registro! " + ex.Message);
                    throw;
                }
            }
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0) 
            {
                editar = true;
                txtNombresComp.Text = dgvUsuarios.CurrentRow.Cells["UsuNombreComp"].Value.ToString();
                txtCedula.Text = dgvUsuarios.CurrentRow.Cells["UsuCedula"].Value.ToString();
                txtContrasenia.Text = dgvUsuarios.CurrentRow.Cells["UsuContrasenia"].Value.ToString();
                txtTelefono.Text = dgvUsuarios.CurrentRow.Cells["UsuTelefono"].Value.ToString();
                cmbTipoUsuario.SelectedValue = dgvUsuarios.CurrentRow.Cells["idTusu"].Value.ToString();
                idUsuario = dgvUsuarios.CurrentRow.Cells["idUsuario"].Value.ToString();
                btnRegistrar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Presione una Fila!");
                limpiar();
            }
        }
    }
}
