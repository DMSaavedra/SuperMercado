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
            customDesign();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaHora.Text = DateTime.Now.ToString();
        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            lblFechaHora.Text = DateTime.Now.ToString();
        }

        #region Diseño Botones
        public void customDesign()
        {
            pnlSbmUsuarios.Visible = false;
            pnlSbmProductos.Visible = false;
            pnlSbmProveedores.Visible = false;
            pnlSbmVentas.Visible = false;
        }

        private void hideSubMenu()
        {
            if (pnlSbmUsuarios.Visible == true) 
            {
                pnlSbmUsuarios.Visible = false;
            }
            if (pnlSbmProductos.Visible == true)
            {
                pnlSbmProductos.Visible = false;
            }
            if (pnlSbmProveedores.Visible == true)
            {
                pnlSbmProveedores.Visible = false;
            }
            if (pnlSbmVentas.Visible == true)
            {
                pnlSbmVentas.Visible = false;
            }
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        #endregion
        
        #region Abrir Formularios Hijos
        private Form activeForm = null;
        private void abriFormHijo(Form FormHijo)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = FormHijo;
            FormHijo.TopLevel = false;
            FormHijo.FormBorderStyle = FormBorderStyle.None;
            FormHijo.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(FormHijo);
            pnlContenedor.Tag = FormHijo;
            FormHijo.BringToFront();
            FormHijo.Show();
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSbmUsuarios);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            abriFormHijo(new UsuariosAdm());
            //Codigo...
            hideSubMenu();
        }

        private void btnTipoUsuarios_Click(object sender, EventArgs e)
        {
            abriFormHijo(new TipoUsuariosAdm());
            //Codigo...
            hideSubMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSbmProductos);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            //Codigo...
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            abriFormHijo(new CategoriaProdAdm());
            //Codigo...
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSbmProveedores);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            abriFormHijo(new ProveedoresAdm());
            //Codigo...
            hideSubMenu();
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            abriFormHijo(new MarcaAdm());
            //Codigo...
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSbmVentas);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            //Codigo...
            hideSubMenu();
        }

        private void btnDetalleVentas_Click(object sender, EventArgs e)
        {
            //Codigo...
            hideSubMenu();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            //Mostrar Pantalla Anidado
        }

        private void pctSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
            this.Close();
        }
    }
}
