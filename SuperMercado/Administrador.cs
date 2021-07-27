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
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtFechaHora.Text = DateTime.Now.ToString();
        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            txtFechaHora.Text = DateTime.Now.ToString();
            label33.Text = "Diego";
        }

        private void btnAbrirImg_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }
    }
}
