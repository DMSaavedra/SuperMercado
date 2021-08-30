﻿using CapaRNegocio;
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
        //private string idProducto = null;
        //private bool editar = false;

        public ProductosUS()
        {
            InitializeComponent();
        }
        private void ProductosUS_Load(object sender, EventArgs e)
        {
            lblTitulo.Visible = false;
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

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog fo = new OpenFileDialog();
            DialogResult dr = fo.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pctProducto.Image = Image.FromFile(fo.FileName);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe Llenar Todos Los Campos!");
            }
            else if (dtpElab.Value == DateTime.Now)
            {
                MessageBox.Show("Debe Seleccionar una Fecha Diferente a la del Dia de Hoy");
            }
            else
            {
                if (lblTitulo.Text == "Nuevo")
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pctProducto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    try
                    {
                        objetoCN.crear_prod(txtNombre.Text, txtCantidad.Text, txtPCP.Text, txtPVP.Text, dtpElab.Value.ToString(), dtpExp.Value.ToString(), ms.GetBuffer(), cmbMarca.SelectedItem.ToString(), cmbCategoria.SelectedItem.ToString());
                        MessageBox.Show("Se Guardo Correctamente!");
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
            dtpElab.Value = DateTime.Now;
            dtpExp.Value = DateTime.Now;
        }
    }
}
