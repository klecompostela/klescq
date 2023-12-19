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
            btnAceptar = new Button();
            btnCancelar = new Button();
            cbPesMod = new ComboBox();
            btSeleccionarINI = new Button();
            txtFicheroINI = new TextBox();
            lbPESActual = new Label();
            chkMoverStadiumServer = new CheckBox();
            chkDiscoExterno = new CheckBox();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(451, 157);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(135, 44);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(591, 157);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(133, 44);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cbPesMod
            // 
            cbPesMod.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPesMod.FormattingEnabled = true;
            cbPesMod.Location = new Point(36, 106);
            cbPesMod.Margin = new Padding(3, 2, 3, 2);
            cbPesMod.Name = "cbPesMod";
            cbPesMod.Size = new Size(445, 23);
            cbPesMod.TabIndex = 2;
            // 
            // btSeleccionarINI
            // 
            btSeleccionarINI.Location = new Point(493, 70);
            btSeleccionarINI.Margin = new Padding(3, 2, 3, 2);
            btSeleccionarINI.Name = "btSeleccionarINI";
            btSeleccionarINI.Size = new Size(60, 20);
            btSeleccionarINI.TabIndex = 3;
            btSeleccionarINI.Text = "...";
            btSeleccionarINI.UseVisualStyleBackColor = true;
            btSeleccionarINI.Click += btSeleccionarINI_Click;
            // 
            // txtFicheroINI
            // 
            txtFicheroINI.Location = new Point(36, 70);
            txtFicheroINI.Margin = new Padding(3, 2, 3, 2);
            txtFicheroINI.Name = "txtFicheroINI";
            txtFicheroINI.Size = new Size(445, 23);
            txtFicheroINI.TabIndex = 4;
            // 
            // lbPESActual
            // 
            lbPESActual.AutoSize = true;
            lbPESActual.Location = new Point(36, 21);
            lbPESActual.Name = "lbPESActual";
            lbPESActual.Size = new Size(73, 15);
            lbPESActual.TabIndex = 5;
            lbPESActual.Text = "PES EN USO:";
            // 
            // chkMoverStadiumServer
            // 
            chkMoverStadiumServer.AutoSize = true;
            chkMoverStadiumServer.Checked = true;
            chkMoverStadiumServer.CheckState = CheckState.Checked;
            chkMoverStadiumServer.Location = new Point(38, 146);
            chkMoverStadiumServer.Name = "chkMoverStadiumServer";
            chkMoverStadiumServer.Size = new Size(142, 19);
            chkMoverStadiumServer.TabIndex = 6;
            chkMoverStadiumServer.Text = "Mover Stadium Server";
            chkMoverStadiumServer.UseVisualStyleBackColor = true;
            // 
            // chkDiscoExterno
            // 
            chkDiscoExterno.AutoSize = true;
            chkDiscoExterno.Location = new Point(38, 171);
            chkDiscoExterno.Name = "chkDiscoExterno";
            chkDiscoExterno.Size = new Size(98, 19);
            chkDiscoExterno.TabIndex = 7;
            chkDiscoExterno.Text = "Disco Externo";
            chkDiscoExterno.UseVisualStyleBackColor = true;
            // 
            // PESSelector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 272);
            Controls.Add(chkDiscoExterno);
            Controls.Add(chkMoverStadiumServer);
            Controls.Add(lbPESActual);
            Controls.Add(txtFicheroINI);
            Controls.Add(btSeleccionarINI);
            Controls.Add(cbPesMod);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "PESSelector";
            Text = "PESSelector";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private ComboBox cbPesMod;
        private Button btSeleccionarINI;
        private TextBox txtFicheroINI;
        private Label lbPESActual;
        private CheckBox chkMoverStadiumServer;
        private CheckBox chkDiscoExterno;
    }
}