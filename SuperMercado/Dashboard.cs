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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaHora.Text = DateTime.Now.ToString();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblFechaHora.Text = DateTime.Now.ToString();
        }

        private void pctSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pctLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
        }
    }
}
