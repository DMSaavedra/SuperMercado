using CapaRNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMercado
{
    public partial class ListaProductos : Form
    {
        private CN_Productos objetoCN = new CN_Productos();

        public ListaProductos()
        {
            InitializeComponent();
        }

        private void pctSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
        }

        private void InicioUs_Load(object sender, EventArgs e)
        {
            verListaProductos();
        }

        private void verListaProductos()
        {
            CN_Productos objeto = new CN_Productos();
            dgvListaProductos.DataSource = objeto.mostrar_products_activos();
        }

        private void pctLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DetalleCompra().ShowDialog();
        }

        private void txtBuscador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscador.Text))
            {
                verListaProductos();
            }
            else
            {
                //
                //dgvListaProductos.DataSource = query;
            }
        }
    }
}
