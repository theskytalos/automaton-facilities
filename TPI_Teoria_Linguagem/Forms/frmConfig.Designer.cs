namespace TPI_Teoria_Linguagem.Forms
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.gpbConfig = new System.Windows.Forms.GroupBox();
            this.btnSearchDirectory = new System.Windows.Forms.Button();
            this.txtExportDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblConfig = new System.Windows.Forms.Label();
            this.ckbPaintRows = new System.Windows.Forms.CheckBox();
            this.ckbOpenDialog = new System.Windows.Forms.CheckBox();
            this.gpbConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbConfig
            // 
            this.gpbConfig.Controls.Add(this.ckbOpenDialog);
            this.gpbConfig.Controls.Add(this.ckbPaintRows);
            this.gpbConfig.Controls.Add(this.btnSearchDirectory);
            this.gpbConfig.Controls.Add(this.txtExportDirectory);
            this.gpbConfig.Controls.Add(this.label1);
            this.gpbConfig.Location = new System.Drawing.Point(12, 74);
            this.gpbConfig.Name = "gpbConfig";
            this.gpbConfig.Size = new System.Drawing.Size(476, 113);
            this.gpbConfig.TabIndex = 0;
            this.gpbConfig.TabStop = false;
            // 
            // btnSearchDirectory
            // 
            this.btnSearchDirectory.Location = new System.Drawing.Point(395, 26);
            this.btnSearchDirectory.Name = "btnSearchDirectory";
            this.btnSearchDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnSearchDirectory.TabIndex = 2;
            this.btnSearchDirectory.Text = "Procurar";
            this.btnSearchDirectory.UseVisualStyleBackColor = true;
            this.btnSearchDirectory.Click += new System.EventHandler(this.btnSearchDirectory_Click);
            // 
            // txtExportDirectory
            // 
            this.txtExportDirectory.Location = new System.Drawing.Point(88, 28);
            this.txtExportDirectory.Name = "txtExportDirectory";
            this.txtExportDirectory.ReadOnly = true;
            this.txtExportDirectory.Size = new System.Drawing.Size(301, 20);
            this.txtExportDirectory.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exportar para: ";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(332, 192);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(413, 193);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblConfig
            // 
            this.lblConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConfig.BackColor = System.Drawing.SystemColors.Control;
            this.lblConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfig.Location = new System.Drawing.Point(12, 12);
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Size = new System.Drawing.Size(476, 56);
            this.lblConfig.TabIndex = 4;
            this.lblConfig.Text = "Configurações";
            this.lblConfig.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckbPaintRows
            // 
            this.ckbPaintRows.AutoSize = true;
            this.ckbPaintRows.Location = new System.Drawing.Point(9, 54);
            this.ckbPaintRows.Name = "ckbPaintRows";
            this.ckbPaintRows.Size = new System.Drawing.Size(87, 17);
            this.ckbPaintRows.TabIndex = 9;
            this.ckbPaintRows.Text = "Pintar Linhas";
            this.ckbPaintRows.UseVisualStyleBackColor = true;
            // 
            // ckbOpenDialog
            // 
            this.ckbOpenDialog.AutoSize = true;
            this.ckbOpenDialog.Location = new System.Drawing.Point(9, 77);
            this.ckbOpenDialog.Name = "ckbOpenDialog";
            this.ckbOpenDialog.Size = new System.Drawing.Size(217, 17);
            this.ckbOpenDialog.TabIndex = 10;
            this.ckbOpenDialog.Text = "Selecionar autômato ao abrir o programa";
            this.ckbOpenDialog.UseVisualStyleBackColor = true;
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 227);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gpbConfig);
            this.Controls.Add(this.lblConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.gpbConfig.ResumeLayout(false);
            this.gpbConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbConfig;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblConfig;
        private System.Windows.Forms.Button btnSearchDirectory;
        private System.Windows.Forms.TextBox txtExportDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbOpenDialog;
        private System.Windows.Forms.CheckBox ckbPaintRows;
    }
}