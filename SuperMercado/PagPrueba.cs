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
    public partial class PagPrueba : Form
    {
        private CN_Prueba objetoCN = new CN_Prueba();

        public PagPrueba()
        {
            InitializeComponent();
        }

        private void PagPrueba_Load(object sender, EventArgs e)
        {
            verDatos();
        }

        private void verDatos()
        {
            CN_Prueba obj = new CN_Prueba();
            
        }
    }
}
