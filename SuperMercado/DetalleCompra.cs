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
    public partial class DetalleCompra : Form
    {
        private CN_Productos objetoCN = new CN_Productos();

        private CN_DetVenta objetoCN2 = new CN_DetVenta();

        public DetalleCompra()
        {
            InitializeComponent();
        }

        private void pctSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaHora.Text = DateTime.Now.ToString();
        }

        private void DetalleCompra_Load(object sender, EventArgs e)
        {
            lblFechaHora.Text = DateTime.Now.ToString();
            pnlProductos.Visible = false;
            lblTotal.Text = "$ 0.0";
            verListaProductos();
            ocultarColumnas();
        }

        private void verDetalle()
        {
            CN_DetVenta objeto = new CN_DetVenta();
            dgvProdSelect.DataSource = objeto.mostrar_detalle();
        }

        private void ocultarColumnas()
        {
            dgvListaProductos.Columns[0].Visible = false;   //ID
            dgvListaProductos.Columns[4].Visible = false;   //Fecha Elab
            dgvListaProductos.Columns[5].Visible = false;   //Fecha Elab
            dgvListaProductos.Columns[7].Visible = false;   //Categoria
            dgvListaProductos.Columns[8].Visible = false;   //Marca
            dgvListaProductos.Columns[9].Visible = false;   //Estado
        }

        private void verListaProductos()
        {
            CN_Productos objeto = new CN_Productos();
            dgvListaProductos.DataSource = objeto.mostrar_products_activos();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (dgvProdSelect.Rows.Count > 1)
            {
                DialogResult r = MessageBox.Show("¿Está Seguro De Realizar La Compra?", "Procesando Compra...", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    MessageBox.Show("Compra Registrada Con Exito");
                    this.Hide();
                    new SmsCompra().ShowDialog();
                }
                if (r == DialogResult.No)
                {
                    
                }
            }
            else
            {
                MessageBox.Show("Aún no ha seleccionado los productos para la Compra");
            }
        }

        private void pctSalir_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
        }

        private void btnListaProds_Click(object sender, EventArgs e)
        {
            pnlProductos.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlProductos.Visible = false;
        }

        private void dgvListaProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvProdSelect.Rows.Add(dgvListaProductos.CurrentRow.Cells["PrdNombre"].Value.ToString(),
            numCantidad.Value,
            dgvListaProductos.CurrentRow.Cells["PrdPrecioVenta"].Value.ToString(),
            Convert.ToDecimal(dgvListaProductos.CurrentRow.Cells["PrdPrecioVenta"].Value) * numCantidad.Value);
            calcularTotal();
            pnlProductos.Visible = false;
            numCantidad.Value = 1;
        }

        private void calcularTotal()
        {
            if (dgvProdSelect.Rows.Count > 0)
            {
                decimal total = 0;

                foreach (DataGridViewRow row in dgvProdSelect.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["DtvTotal"].Value);
                }
                lblTotal.Text = total.ToString();
            }
            else
            {
                lblTotal.Text = "$ 0.0";
            }

        }

        private void dgvProdSelect_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdSelect.Rows.Count > 1)
            {
                dgvProdSelect.Rows.RemoveAt(dgvProdSelect.CurrentRow.Index);
                calcularTotal();
            }
            else
            {
                MessageBox.Show("No Existen Productos, para Eliminar");
            }
        }
    }
}
