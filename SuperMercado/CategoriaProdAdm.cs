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
    public partial class CategoriaProdAdm : Form
    {
        private CN_Categorias objetoCN = new CN_Categorias();
        private string idCatPrd = null;
        private bool editar = false;

        public CategoriaProdAdm()
        {
            InitializeComponent();
        }
        private void CategoriaProdAdm_Load(object sender, EventArgs e)
        {
            verCategorias();
        }

        private void verCategorias()
        {
            CN_Categorias objeto = new CN_Categorias();
            dgvCategorias.DataSource = objeto.mostrar_cat();
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoria.Text))
            {
                MessageBox.Show("Debe Llenar El Campo!");
            }
            else
            {
                if (editar == false) 
                {
                    try
                    {
                        objetoCN.crear_cat(txtCategoria.Text);
                        MessageBox.Show("Se Guardo Correctamente!");
                        verCategorias();
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
            txtCategoria.Clear();
            idCatPrd = null;
            editar = false;
            btnRegistrar.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoria.Text))
            {
                MessageBox.Show("De Doble Click en una FILA de la tabla, para editar datos");
            }
            else
            {
                if (editar)
                {
                    try
                    {
                        objetoCN.editar_cat(txtCategoria.Text, idCatPrd);
                        MessageBox.Show("Se edito correctamente..!");
                        verCategorias();
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
            if (string.IsNullOrEmpty(idCatPrd))
            {
                MessageBox.Show("De Doble Click en una FILA de la tabla, para ELIMINAR datos");
            }
            else
            {
                try
                {
                    objetoCN.eliminar_cat(idCatPrd);
                    MessageBox.Show("Registro Eliminado!");
                    verCategorias();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("NO SE Elimino el Registro! " + ex.Message);
                    throw;
                }
            }
        }

        private void dgvCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0) 
            {
                editar = true;
                txtCategoria.Text = dgvCategorias.CurrentRow.Cells["CartPrdNombre"].Value.ToString();
                idCatPrd = dgvCategorias.CurrentRow.Cells["idCatPrd"].Value.ToString();
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
