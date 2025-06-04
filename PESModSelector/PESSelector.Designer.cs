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
            lbPESSel = new Label();
            lbPesUso = new Label();
            lbPesSeleccionado = new Label();
            cbUnidades = new ComboBox();
            lblDisco = new Label();
            gbPESSeleccionado = new GroupBox();
            lbCPK_DATA_ORIGINAL_SEL = new Label();
            lbVERSION_EXE_SEL = new Label();
            lbDISCO_USB_SEL = new Label();
            lbCPK_DOWNLOAD_ORIGINAL_SEL = new Label();
            gbPESUso = new GroupBox();
            lbCPK_DATA_ORIGINAL = new Label();
            lbVERSION_EXE = new Label();
            lbCPK_DOWNLOAD_ORIGINAL = new Label();
            lbDISCO_USB = new Label();
            gbPESSeleccionado.SuspendLayout();
            gbPESUso.SuspendLayout();
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
            // lbPESSel
            // 
            lbPESSel.AutoSize = true;
            lbPESSel.Location = new Point(168, 42);
            lbPESSel.Name = "lbPESSel";
            lbPESSel.Size = new Size(0, 15);
            lbPESSel.TabIndex = 14;
            // 
            // lbPesUso
            // 
            lbPesUso.AutoSize = true;
            lbPesUso.ForeColor = SystemColors.HotTrack;
            lbPesUso.Location = new Point(44, 20);
            lbPesUso.Name = "lbPesUso";
            lbPesUso.Size = new Size(73, 15);
            lbPesUso.TabIndex = 15;
            lbPesUso.Text = "PES EN USO:";
            // 
            // lbPesSeleccionado
            // 
            lbPesSeleccionado.AutoSize = true;
            lbPesSeleccionado.ForeColor = Color.Red;
            lbPesSeleccionado.Location = new Point(44, 42);
            lbPesSeleccionado.Name = "lbPesSeleccionado";
            lbPesSeleccionado.Size = new Size(118, 15);
            lbPesSeleccionado.TabIndex = 16;
            lbPesSeleccionado.Text = "PES SELECCIONADO:";
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
            // gbPESSeleccionado
            // 
            gbPESSeleccionado.Controls.Add(lbCPK_DATA_ORIGINAL_SEL);
            gbPESSeleccionado.Controls.Add(lbVERSION_EXE_SEL);
            gbPESSeleccionado.Controls.Add(lbDISCO_USB_SEL);
            gbPESSeleccionado.Controls.Add(lbCPK_DOWNLOAD_ORIGINAL_SEL);
            gbPESSeleccionado.ForeColor = Color.Red;
            gbPESSeleccionado.Location = new Point(259, 171);
            gbPESSeleccionado.Name = "gbPESSeleccionado";
            gbPESSeleccionado.Size = new Size(243, 133);
            gbPESSeleccionado.TabIndex = 21;
            gbPESSeleccionado.TabStop = false;
            gbPESSeleccionado.Text = "Pes seleccionado";
            // 
            // lbCPK_DATA_ORIGINAL_SEL
            // 
            lbCPK_DATA_ORIGINAL_SEL.AutoSize = true;
            lbCPK_DATA_ORIGINAL_SEL.Location = new Point(30, 100);
            lbCPK_DATA_ORIGINAL_SEL.Name = "lbCPK_DATA_ORIGINAL_SEL";
            lbCPK_DATA_ORIGINAL_SEL.Size = new Size(123, 15);
            lbCPK_DATA_ORIGINAL_SEL.TabIndex = 24;
            lbCPK_DATA_ORIGINAL_SEL.Text = "CPK_DATA_ORIGINAL:";
            // 
            // lbVERSION_EXE_SEL
            // 
            lbVERSION_EXE_SEL.AutoSize = true;
            lbVERSION_EXE_SEL.Location = new Point(30, 17);
            lbVERSION_EXE_SEL.Name = "lbVERSION_EXE_SEL";
            lbVERSION_EXE_SEL.Size = new Size(81, 15);
            lbVERSION_EXE_SEL.TabIndex = 23;
            lbVERSION_EXE_SEL.Text = "VERSION_EXE:";
            // 
            // lbDISCO_USB_SEL
            // 
            lbDISCO_USB_SEL.AutoSize = true;
            lbDISCO_USB_SEL.Location = new Point(30, 44);
            lbDISCO_USB_SEL.Name = "lbDISCO_USB_SEL";
            lbDISCO_USB_SEL.Size = new Size(70, 15);
            lbDISCO_USB_SEL.TabIndex = 22;
            lbDISCO_USB_SEL.Text = "DISCO_USB:";
            // 
            // lbCPK_DOWNLOAD_ORIGINAL_SEL
            // 
            lbCPK_DOWNLOAD_ORIGINAL_SEL.AutoSize = true;
            lbCPK_DOWNLOAD_ORIGINAL_SEL.Location = new Point(30, 70);
            lbCPK_DOWNLOAD_ORIGINAL_SEL.Name = "lbCPK_DOWNLOAD_ORIGINAL_SEL";
            lbCPK_DOWNLOAD_ORIGINAL_SEL.Size = new Size(163, 15);
            lbCPK_DOWNLOAD_ORIGINAL_SEL.TabIndex = 21;
            lbCPK_DOWNLOAD_ORIGINAL_SEL.Text = "CPK_DOWNLOAD_ORIGINAL:";
            // 
            // gbPESUso
            // 
            gbPESUso.Controls.Add(lbCPK_DATA_ORIGINAL);
            gbPESUso.Controls.Add(lbVERSION_EXE);
            gbPESUso.Controls.Add(lbCPK_DOWNLOAD_ORIGINAL);
            gbPESUso.Controls.Add(lbDISCO_USB);
            gbPESUso.ForeColor = SystemColors.HotTrack;
            gbPESUso.Location = new Point(12, 171);
            gbPESUso.Name = "gbPESUso";
            gbPESUso.Size = new Size(228, 130);
            gbPESUso.TabIndex = 25;
            gbPESUso.TabStop = false;
            gbPESUso.Text = "Pes en uso:";
            // 
            // lbCPK_DATA_ORIGINAL
            // 
            lbCPK_DATA_ORIGINAL.AutoSize = true;
            lbCPK_DATA_ORIGINAL.Location = new Point(19, 99);
            lbCPK_DATA_ORIGINAL.Name = "lbCPK_DATA_ORIGINAL";
            lbCPK_DATA_ORIGINAL.Size = new Size(123, 15);
            lbCPK_DATA_ORIGINAL.TabIndex = 23;
            lbCPK_DATA_ORIGINAL.Text = "CPK_DATA_ORIGINAL:";
            // 
            // lbVERSION_EXE
            // 
            lbVERSION_EXE.AutoSize = true;
            lbVERSION_EXE.Location = new Point(19, 16);
            lbVERSION_EXE.Name = "lbVERSION_EXE";
            lbVERSION_EXE.Size = new Size(81, 15);
            lbVERSION_EXE.TabIndex = 22;
            lbVERSION_EXE.Text = "VERSION_EXE:";
            // 
            // lbCPK_DOWNLOAD_ORIGINAL
            // 
            lbCPK_DOWNLOAD_ORIGINAL.AutoSize = true;
            lbCPK_DOWNLOAD_ORIGINAL.Location = new Point(19, 69);
            lbCPK_DOWNLOAD_ORIGINAL.Name = "lbCPK_DOWNLOAD_ORIGINAL";
            lbCPK_DOWNLOAD_ORIGINAL.Size = new Size(163, 15);
            lbCPK_DOWNLOAD_ORIGINAL.TabIndex = 21;
            lbCPK_DOWNLOAD_ORIGINAL.Text = "CPK_DOWNLOAD_ORIGINAL:";
            // 
            // lbDISCO_USB
            // 
            lbDISCO_USB.AutoSize = true;
            lbDISCO_USB.Location = new Point(19, 43);
            lbDISCO_USB.Name = "lbDISCO_USB";
            lbDISCO_USB.Size = new Size(70, 15);
            lbDISCO_USB.TabIndex = 20;
            lbDISCO_USB.Text = "DISCO_USB:";
            // 
            // PESSelector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 313);
            Controls.Add(gbPESUso);
            Controls.Add(gbPESSeleccionado);
            Controls.Add(lblDisco);
            Controls.Add(cbUnidades);
            Controls.Add(lbPesSeleccionado);
            Controls.Add(lbPesUso);
            Controls.Add(lbPESSel);
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
            gbPESSeleccionado.ResumeLayout(false);
            gbPESSeleccionado.PerformLayout();
            gbPESUso.ResumeLayout(false);
            gbPESUso.PerformLayout();
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
        private Label lbPESSel;
        private Label lbPesUso;
        private Label lbPesSeleccionado;
        private ComboBox cbUnidades;
        private Label lblDisco;
        private GroupBox gbPESSeleccionado;
        private Label lbCPK_DATA_ORIGINAL_SEL;
        private Label lbVERSION_EXE_SEL;
        private Label lbDISCO_USB_SEL;
        private Label lbCPK_DOWNLOAD_ORIGINAL_SEL;
        private GroupBox gbPESUso;
        private Label lbCPK_DATA_ORIGINAL;
        private Label lbVERSION_EXE;
        private Label lbCPK_DOWNLOAD_ORIGINAL;
        private Label lbDISCO_USB;
    }
}