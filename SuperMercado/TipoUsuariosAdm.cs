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
    public partial class TipoUsuariosAdm : Form
    {
        private CN_TipoUsuario objetoCN = new CN_TipoUsuario();
        private string idTusu = null;
        private bool editar = false;

        public TipoUsuariosAdm()
        {
            InitializeComponent();
        }
        private void TipoUsuariosAdm_Load(object sender, EventArgs e)
        {
            verTipoUsuarios();
        }

        private void verTipoUsuarios()
        {
            CN_TipoUsuario objeto = new CN_TipoUsuario();
            dgvTusu.DataSource = objeto.mostrar_tusu();
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTipoUs.Text))
            {
                MessageBox.Show("Debe Llenar El Campo!");
            }
            else
            {
                if (editar == false)
                {
                    try
                    {
                        objetoCN.crear_tusu(txtTipoUs.Text);
                        MessageBox.Show("Se Guardo Correctamente!");
                        verTipoUsuarios();
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
            txtTipoUs.Clear();
            idTusu = null;
            editar = false;
            btnRegistrar.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTipoUs.Text))
            {
                MessageBox.Show("De Doble Click en una FILA de la tabla, para editar datos");
            }
            else
            {
                if (editar)
                {
                    try
                    {
                        objetoCN.editar_tusu(txtTipoUs.Text, idTusu);
                        MessageBox.Show("Se edito correctamente..!");
                        verTipoUsuarios();
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
            if (string.IsNullOrEmpty(idTusu))
            {
                MessageBox.Show("De Doble Click en una FILA de la tabla, para ELIMINAR datos");
            }
            else
            {
                try
                {
                    objetoCN.eliminar_tusu(idTusu);
                    MessageBox.Show("Registro Eliminado!");
                    verTipoUsuarios();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("NO SE Elimino el Registro! " + ex.Message);
                    throw;
                }
            }
        }

        private void dgvTusu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTusu.SelectedRows.Count > 0) 
            {
                editar = true;
                txtTipoUs.Text = dgvTusu.CurrentRow.Cells["TusuNombre"].Value.ToString();
                idTusu = dgvTusu.CurrentRow.Cells["idTusu"].Value.ToString();
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
