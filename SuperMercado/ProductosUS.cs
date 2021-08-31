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
    public partial class ProductosUS : Form
    {
        private CN_Productos objetoCN = new CN_Productos();
        private string idProducto = null;
        private bool editar = false;

        public ProductosUS()
        {
            InitializeComponent();
        }
        private void ProductosUS_Load(object sender, EventArgs e)
        {
            lblTitulo.Visible = false;
            lblTituloDos.Visible = false;
            verProductos();
            verCmbCateg();
            verCmbMarca();
        }

        private void verCmbMarca()
        {
            CN_Productos objeto3 = new CN_Productos();
            cmbMarca.DataSource = objeto3.cargar_marcas();
            cmbMarca.DisplayMember = "MrcPrdNombre";
            cmbMarca.ValueMember = "idMarcaPrd";
        }

        private void verCmbCateg()
        {
            CN_Productos objeto2 = new CN_Productos();
            cmbCategoria.DataSource = objeto2.cargar_categoria();
            cmbCategoria.DisplayMember = "CartPrdNombre";
            cmbCategoria.ValueMember = "idCatPrd";
        }

        private void verProductos()
        {
            CN_Productos objeto = new CN_Productos();
            dgvProductos.DataSource = objeto.mostrar_products();
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int idMarcaPrd = Convert.ToInt32(cmbMarca.SelectedValue.ToString());
            int idCatPrd = Convert.ToInt32(cmbCategoria.SelectedValue.ToString());

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtCantidad.Text) || string.IsNullOrEmpty(txtPVP.Text))
            {
                MessageBox.Show("Debe Llenar Todos Los Campos!");
            }
            else
            {
                if (lblTitulo.Text == "Nuevo")
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pctProducto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    try
                    {
                        objetoCN.crear_prod(txtNombre.Text, txtCantidad.Text, txtPVP.Text, dtpElab.Value.ToString(), dtpExp.Value.ToString(), ms.GetBuffer(), idMarcaPrd.ToString(), idCatPrd.ToString());
                        MessageBox.Show("Se Guardo Correctamente!");
                        verProductos();
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
            txtNombre.Clear();
            txtCantidad.Clear();
            txtPVP.Clear();
            dtpElab.Value = DateTime.Now;
            dtpExp.Value = DateTime.Now;
            cmbMarca.Text = "Seleccione";
            cmbCategoria.Text = "Seleccione";
            btnRegistrar.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int idMarcaPrd = Convert.ToInt32(cmbMarca.SelectedValue.ToString());
            int idCatPrd = Convert.ToInt32(cmbCategoria.SelectedValue.ToString());

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtCantidad.Text) || string.IsNullOrEmpty(txtPVP.Text))
            {
                MessageBox.Show("De Doble Click en una FILA de la tabla, para editar datos");
            }
            else
            {
                if (lblTituloDos.Text == "Editar")
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pctProducto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    try
                    {
                        objetoCN.editar_prod(txtNombre.Text, txtCantidad.Text, txtPVP.Text, dtpElab.Value.ToString(), dtpExp.Value.ToString(), ms.GetBuffer(), idMarcaPrd.ToString(), idCatPrd.ToString(), idProducto);
                        MessageBox.Show("Se edito correctamente..!");
                        btnRegistrar.Enabled = true;
                        verProductos();
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
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtCantidad.Text) || string.IsNullOrEmpty(txtPVP.Text))
            {
                MessageBox.Show("De Doble Click en una FILA de la tabla, para ELIMINAR datos");
            }
            else
            {
                try
                {
                    objetoCN.eliminar_prod(idProducto);
                    MessageBox.Show("Registro Eliminado!");
                    verProductos();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se Elimino el Registro! " + ex.Message);
                    throw;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog fo = new OpenFileDialog();
            DialogResult dr = fo.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pctProducto.Image = Image.FromFile(fo.FileName);
            }
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0) 
            {
                editar = true;
                txtNombre.Text = dgvProductos.CurrentRow.Cells["PrdNombre"].Value.ToString();
                txtCantidad.Text = dgvProductos.CurrentRow.Cells["PrdCantidad"].Value.ToString();
                txtPVP.Text = dgvProductos.CurrentRow.Cells["PrdPrecioVenta"].Value.ToString();
                cmbCategoria.SelectedValue = dgvProductos.CurrentRow.Cells["idCatPrd"].Value.ToString(); 
                cmbMarca.SelectedValue = dgvProductos.CurrentRow.Cells["idMarcaPrd"].Value.ToString();
                idProducto = dgvProductos.CurrentRow.Cells["idProducto"].Value.ToString();
                byte[] img = (byte[])dgvProductos.CurrentRow.Cells["PrdImagen"].Value;

                System.IO.MemoryStream ms = new System.IO.MemoryStream(img);
                pctProducto.Image = Image.FromStream(ms);


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
