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
    public partial class MarcaAdm : Form
    {
        private CN_Marca objetoCN = new CN_Marca();
        private string idMarcaPrd = null;
        private bool editar = false;

        public MarcaAdm()
        {
            InitializeComponent();
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MarcaAdm_Load(object sender, EventArgs e)
        {
            verMarcas();
            verCmbProveedores();
        }

        private void verMarcas()
        {
            CN_Marca objeto = new CN_Marca();
            dgvMarca.DataSource = objeto.mostrar_mrc();
        }

        private void verCmbProveedores()
        {
            CN_Marca objeto2 = new CN_Marca();
            cmbProveedor.DataSource = objeto2.cargar_provs();
            cmbProveedor.DisplayMember = "ProvNombre";
            cmbProveedor.ValueMember = "idProveedor";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int idProveedor = Convert.ToInt32(cmbProveedor.SelectedValue.ToString());

            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                MessageBox.Show("Debe Llenar El Campo!");
            }
            else if (cmbProveedor.Text == "Seleccione") 
            {
                MessageBox.Show("Seleccione un Proveedor!");
            }
            else
            {
                if (editar == false)
                {
                    try
                    {
                        objetoCN.crear_mrc(txtMarca.Text, idProveedor.ToString());
                        MessageBox.Show("Se Guardo Correctamente!");
                        verMarcas();
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

        private void limpiar()
        {
            txtMarca.Clear();
            cmbProveedor.Text = "Seleccione";
            idMarcaPrd = null;
            editar = false;
            btnRegistrar.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int idProveedor = Convert.ToInt32(cmbProveedor.SelectedValue.ToString());

            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                MessageBox.Show("De Doble Click en una FILA de la tabla, para editar datos");
            }
            else
            {
                if (editar)
                {
                    try
                    {
                        objetoCN.editar_mrc(txtMarca.Text, idProveedor.ToString(), idMarcaPrd);
                        MessageBox.Show("Se edito correctamente..!");
                        verMarcas();
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
            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                MessageBox.Show("De Doble Click en una FILA de la tabla, para ELIMINAR datos");
            }
            else
            {
                try
                {
                    objetoCN.eliminar_mrc(idMarcaPrd);
                    MessageBox.Show("Registro Eliminado!");
                    verMarcas();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("NO SE Elimino el Registro! " + ex.Message);
                    throw;
                }
            }
        }

        private void dgvMarca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMarca.SelectedRows.Count > 0) 
            {
                editar = true;
                txtMarca.Text = dgvMarca.CurrentRow.Cells["MrcPrdNombre"].Value.ToString();
                cmbProveedor.SelectedValue = dgvMarca.CurrentRow.Cells["idProveedor"].Value.ToString();
                idMarcaPrd = dgvMarca.CurrentRow.Cells["idMarcaPrd"].Value.ToString();
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
