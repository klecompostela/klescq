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
            lbDISCO_USB = new Label();
            lbCPK_DOWNLOAD_ORIGINAL = new Label();
            lbVERSION_EXE = new Label();
            lbCPK_DOWNLOAD_ORIGINAL_SEL = new Label();
            lbDISCO_USB_SEL = new Label();
            lbVERSION_EXE_SEL = new Label();
            lbPESSel = new Label();
            label1 = new Label();
            label2 = new Label();
            cbUnidades = new ComboBox();
            lblDisco = new Label();
            lbCPK_DATA_ORIGINAL_SEL = new Label();
            lbCPK_DATA_ORIGINAL = new Label();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(591, 156);
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
            btnCancelar.Location = new Point(591, 205);
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
            cbPesMod.SelectedIndexChanged += cbPesMod_SelectedIndexChanged;
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
            lbPESActual.Location = new Point(123, 20);
            lbPESActual.Name = "lbPESActual";
            lbPESActual.Size = new Size(0, 15);
            lbPESActual.TabIndex = 5;
            // 
            // chkMoverStadiumServer
            // 
            chkMoverStadiumServer.AutoSize = true;
            chkMoverStadiumServer.Checked = true;
            chkMoverStadiumServer.CheckState = CheckState.Checked;
            chkMoverStadiumServer.Location = new Point(38, 146);
            chkMoverStadiumServer.Name = "chkMoverStadiumServer";
            chkMoverStadiumServer.Size = new Size(186, 19);
            chkMoverStadiumServer.TabIndex = 6;
            chkMoverStadiumServer.Text = "Copia archivos Stadium Server";
            chkMoverStadiumServer.UseVisualStyleBackColor = true;
            // 
            // chkDiscoExterno
            // 
            chkDiscoExterno.AutoSize = true;
            chkDiscoExterno.Location = new Point(246, 146);
            chkDiscoExterno.Name = "chkDiscoExterno";
            chkDiscoExterno.Size = new Size(98, 19);
            chkDiscoExterno.TabIndex = 7;
            chkDiscoExterno.Text = "Disco Externo";
            chkDiscoExterno.UseVisualStyleBackColor = true;
            // 
            // lbDISCO_USB
            // 
            lbDISCO_USB.AutoSize = true;
            lbDISCO_USB.Location = new Point(36, 205);
            lbDISCO_USB.Name = "lbDISCO_USB";
            lbDISCO_USB.Size = new Size(70, 15);
            lbDISCO_USB.TabIndex = 8;
            lbDISCO_USB.Text = "DISCO_USB:";
            // 
            // lbCPK_DOWNLOAD_ORIGINAL
            // 
            lbCPK_DOWNLOAD_ORIGINAL.AutoSize = true;
            lbCPK_DOWNLOAD_ORIGINAL.Location = new Point(36, 231);
            lbCPK_DOWNLOAD_ORIGINAL.Name = "lbCPK_DOWNLOAD_ORIGINAL";
            lbCPK_DOWNLOAD_ORIGINAL.Size = new Size(163, 15);
            lbCPK_DOWNLOAD_ORIGINAL.TabIndex = 9;
            lbCPK_DOWNLOAD_ORIGINAL.Text = "CPK_DOWNLOAD_ORIGINAL:";
            // 
            // lbVERSION_EXE
            // 
            lbVERSION_EXE.AutoSize = true;
            lbVERSION_EXE.Location = new Point(36, 178);
            lbVERSION_EXE.Name = "lbVERSION_EXE";
            lbVERSION_EXE.Size = new Size(81, 15);
            lbVERSION_EXE.TabIndex = 10;
            lbVERSION_EXE.Text = "VERSION_EXE:";
            // 
            // lbCPK_DOWNLOAD_ORIGINAL_SEL
            // 
            lbCPK_DOWNLOAD_ORIGINAL_SEL.AutoSize = true;
            lbCPK_DOWNLOAD_ORIGINAL_SEL.Location = new Point(233, 231);
            lbCPK_DOWNLOAD_ORIGINAL_SEL.Name = "lbCPK_DOWNLOAD_ORIGINAL_SEL";
            lbCPK_DOWNLOAD_ORIGINAL_SEL.Size = new Size(163, 15);
            lbCPK_DOWNLOAD_ORIGINAL_SEL.TabIndex = 11;
            lbCPK_DOWNLOAD_ORIGINAL_SEL.Text = "CPK_DOWNLOAD_ORIGINAL:";
            // 
            // lbDISCO_USB_SEL
            // 
            lbDISCO_USB_SEL.AutoSize = true;
            lbDISCO_USB_SEL.Location = new Point(233, 205);
            lbDISCO_USB_SEL.Name = "lbDISCO_USB_SEL";
            lbDISCO_USB_SEL.Size = new Size(70, 15);
            lbDISCO_USB_SEL.TabIndex = 12;
            lbDISCO_USB_SEL.Text = "DISCO_USB:";
            // 
            // lbVERSION_EXE_SEL
            // 
            lbVERSION_EXE_SEL.AutoSize = true;
            lbVERSION_EXE_SEL.Location = new Point(233, 178);
            lbVERSION_EXE_SEL.Name = "lbVERSION_EXE_SEL";
            lbVERSION_EXE_SEL.Size = new Size(81, 15);
            lbVERSION_EXE_SEL.TabIndex = 13;
            lbVERSION_EXE_SEL.Text = "VERSION_EXE:";
            // 
            // lbPESSel
            // 
            lbPESSel.AutoSize = true;
            lbPESSel.Location = new Point(168, 42);
            lbPESSel.Name = "lbPESSel";
            lbPESSel.Size = new Size(0, 15);
            lbPESSel.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 20);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 15;
            label1.Text = "PES EN USO:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 42);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 16;
            label2.Text = "PES SELECCIONADO:";
            // 
            // cbUnidades
            // 
            cbUnidades.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUnidades.FormattingEnabled = true;
            cbUnidades.Items.AddRange(new object[] { "C", "P", "S", "R" });
            cbUnidades.Location = new Point(591, 106);
            cbUnidades.Margin = new Padding(3, 2, 3, 2);
            cbUnidades.Name = "cbUnidades";
            cbUnidades.Size = new Size(133, 23);
            cbUnidades.TabIndex = 17;
            // 
            // lblDisco
            // 
            lblDisco.AutoSize = true;
            lblDisco.Location = new Point(534, 108);
            lblDisco.Name = "lblDisco";
            lblDisco.Size = new Size(39, 15);
            lblDisco.TabIndex = 18;
            lblDisco.Text = "Disco:";
            // 
            // lbCPK_DATA_ORIGINAL_SEL
            // 
            lbCPK_DATA_ORIGINAL_SEL.AutoSize = true;
            lbCPK_DATA_ORIGINAL_SEL.Location = new Point(233, 261);
            lbCPK_DATA_ORIGINAL_SEL.Name = "lbCPK_DATA_ORIGINAL_SEL";
            lbCPK_DATA_ORIGINAL_SEL.Size = new Size(123, 15);
            lbCPK_DATA_ORIGINAL_SEL.TabIndex = 20;
            lbCPK_DATA_ORIGINAL_SEL.Text = "CPK_DATA_ORIGINAL:";
            // 
            // lbCPK_DATA_ORIGINAL
            // 
            lbCPK_DATA_ORIGINAL.AutoSize = true;
            lbCPK_DATA_ORIGINAL.Location = new Point(36, 261);
            lbCPK_DATA_ORIGINAL.Name = "lbCPK_DATA_ORIGINAL";
            lbCPK_DATA_ORIGINAL.Size = new Size(123, 15);
            lbCPK_DATA_ORIGINAL.TabIndex = 19;
            lbCPK_DATA_ORIGINAL.Text = "CPK_DATA_ORIGINAL:";
            // 
            // PESSelector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 297);
            Controls.Add(lbCPK_DATA_ORIGINAL_SEL);
            Controls.Add(lbCPK_DATA_ORIGINAL);
            Controls.Add(lblDisco);
            Controls.Add(cbUnidades);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbPESSel);
            Controls.Add(lbVERSION_EXE_SEL);
            Controls.Add(lbDISCO_USB_SEL);
            Controls.Add(lbCPK_DOWNLOAD_ORIGINAL_SEL);
            Controls.Add(lbVERSION_EXE);
            Controls.Add(lbCPK_DOWNLOAD_ORIGINAL);
            Controls.Add(lbDISCO_USB);
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
        private Label lbDISCO_USB;
        private Label lbCPK_DOWNLOAD_ORIGINAL;
        private Label lbVERSION_EXE;
        private Label lbCPK_DOWNLOAD_ORIGINAL_SEL;
        private Label lbDISCO_USB_SEL;
        private Label lbVERSION_EXE_SEL;
        private Label lbPESSel;
        private Label label1;
        private Label label2;
        private ComboBox cbUnidades;
        private Label lblDisco;
        private Label lbCPK_DATA_ORIGINAL_SEL;
        private Label lbCPK_DATA_ORIGINAL;
    }
}