namespace PESModSelector
{
    partial class PESSelector
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PESSelector));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbPesMod = new System.Windows.Forms.ComboBox();
            this.btSeleccionarINI = new System.Windows.Forms.Button();
            this.txtFicheroINI = new System.Windows.Forms.TextBox();
            this.lbPESActual = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(451, 157);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(135, 44);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(591, 157);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(133, 44);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbPesMod
            // 
            this.cbPesMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPesMod.FormattingEnabled = true;
            this.cbPesMod.Location = new System.Drawing.Point(36, 106);
            this.cbPesMod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPesMod.Name = "cbPesMod";
            this.cbPesMod.Size = new System.Drawing.Size(445, 23);
            this.cbPesMod.TabIndex = 2;
            // 
            // btSeleccionarINI
            // 
            this.btSeleccionarINI.Location = new System.Drawing.Point(493, 70);
            this.btSeleccionarINI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSeleccionarINI.Name = "btSeleccionarINI";
            this.btSeleccionarINI.Size = new System.Drawing.Size(60, 20);
            this.btSeleccionarINI.TabIndex = 3;
            this.btSeleccionarINI.Text = "...";
            this.btSeleccionarINI.UseVisualStyleBackColor = true;
            this.btSeleccionarINI.Click += new System.EventHandler(this.btSeleccionarINI_Click);
            // 
            // txtFicheroINI
            // 
            this.txtFicheroINI.Location = new System.Drawing.Point(36, 70);
            this.txtFicheroINI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFicheroINI.Name = "txtFicheroINI";
            this.txtFicheroINI.Size = new System.Drawing.Size(445, 23);
            this.txtFicheroINI.TabIndex = 4;
            // 
            // lbPESActual
            // 
            this.lbPESActual.AutoSize = true;
            this.lbPESActual.Location = new System.Drawing.Point(36, 21);
            this.lbPESActual.Name = "lbPESActual";
            this.lbPESActual.Size = new System.Drawing.Size(73, 15);
            this.lbPESActual.TabIndex = 5;
            this.lbPESActual.Text = "PES EN USO:";
            // 
            // PESSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 272);
            this.Controls.Add(this.lbPESActual);
            this.Controls.Add(this.txtFicheroINI);
            this.Controls.Add(this.btSeleccionarINI);
            this.Controls.Add(this.cbPesMod);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PESSelector";
            this.Text = "PESSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private ComboBox cbPesMod;
        private Button btSeleccionarINI;
        private TextBox txtFicheroINI;
        private Label lbPESActual;
    }
}