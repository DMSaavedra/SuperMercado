
namespace SuperMercado
{
    partial class PagPrueba
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblPVP = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtPVP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(100, 37);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(35, 13);
            this.lblCantidad.TabIndex = 0;
            this.lblCantidad.Text = "label1";
            // 
            // lblPVP
            // 
            this.lblPVP.AutoSize = true;
            this.lblPVP.Location = new System.Drawing.Point(314, 37);
            this.lblPVP.Name = "lblPVP";
            this.lblPVP.Size = new System.Drawing.Size(35, 13);
            this.lblPVP.TabIndex = 1;
            this.lblPVP.Text = "label2";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(103, 84);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 2;
            // 
            // txtPVP
            // 
            this.txtPVP.Location = new System.Drawing.Point(317, 84);
            this.txtPVP.Name = "txtPVP";
            this.txtPVP.Size = new System.Drawing.Size(100, 20);
            this.txtPVP.TabIndex = 3;
            // 
            // PagPrueba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 263);
            this.Controls.Add(this.txtPVP);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblPVP);
            this.Controls.Add(this.lblCantidad);
            this.Name = "PagPrueba";
            this.Text = "PagPrueba";
            this.Load += new System.EventHandler(this.PagPrueba_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblPVP;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtPVP;
    }
}