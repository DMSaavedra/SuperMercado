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
    public partial class ProveedoresAdm : Form
    {
        private CN_Proveedores objetoCN = new CN_Proveedores();
        private string idProveedor = null;
        private bool editar = false;

        public ProveedoresAdm()
        {
            InitializeComponent();
        }
        private void ProveedoresAdm_Load(object sender, EventArgs e)
        {
            verProveedores();
        }

        private void verProveedores()
        {
            CN_Proveedores objeto = new CN_Proveedores();
            dgvProveedores.DataSource = objeto.mostrar_prov();
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) && string.IsNullOrEmpty(txtCedula.Text))
            {
                MessageBox.Show("Debe Llenar El Campo!");
            }
            else
            {
                if (editar == false)
                {
                    try
                    {
                        objetoCN.crear_prov(txtNombre.Text, txtCedula.Text);
                        MessageBox.Show("Se Guardo Correctamente!");
                        verProveedores();
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
            txtNombre.Clear();
            txtCedula.Clear();
            idProveedor = null;
            editar = false;
            btnRegistrar.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) && string.IsNullOrEmpty(txtCedula.Text))
            {
                MessageBox.Show("De Doble Click en una FILA de la tabla, para editar datos");
            }
            else
            {
                if (editar)
                {
                    try
                    {
                        objetoCN.editar_prov(txtNombre.Text,txtCedula.Text,idProveedor);
                        MessageBox.Show("Se edito correctamente..!");
                        verProveedores();
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
            if (string.IsNullOrEmpty(txtNombre.Text) && string.IsNullOrEmpty(txtCedula.Text))
            {
                MessageBox.Show("De Doble Click en una FILA de la tabla, para ELIMINAR datos");
            }
            else
            {
                try
                {
                    objetoCN.eliminar_prov(idProveedor);
                    MessageBox.Show("Registro Eliminado!");
                    verProveedores();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("NO SE Elimino el Registro! " + ex.Message);
                    throw;
                }
            }
        }

        private void dgvProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0) 
            {
                editar = true;
                txtNombre.Text = dgvProveedores.CurrentRow.Cells["ProvNombre"].Value.ToString();
                txtNombre.Text = dgvProveedores.CurrentRow.Cells["ProvCedula"].Value.ToString();
                idProveedor = dgvProveedores.CurrentRow.Cells["idProveedor"].Value.ToString();
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
