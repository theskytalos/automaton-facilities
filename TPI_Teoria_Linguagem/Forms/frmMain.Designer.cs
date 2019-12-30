namespace TPI_Teoria_Linguagem.Forms
{
    partial class frmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gpbFileEntrance = new System.Windows.Forms.GroupBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.lblFileStatus = new System.Windows.Forms.Label();
            this.mspTopMenu = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jPGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiUnitEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiMultipleEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.testePassoaPassoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gpbGraph = new System.Windows.Forms.GroupBox();
            this.pcbGraph = new System.Windows.Forms.PictureBox();
            this.gpbTable = new System.Windows.Forms.GroupBox();
            this.dgvTransitionTable = new System.Windows.Forms.DataGridView();
            this.gpbLogo = new System.Windows.Forms.GroupBox();
            this.pcbLogo = new System.Windows.Forms.PictureBox();
            this.gpbMultipleEntry = new System.Windows.Forms.GroupBox();
            this.dgvMultipleEntry = new System.Windows.Forms.DataGridView();
            this.clmnTape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAutomatonSpecs = new System.Windows.Forms.Label();
            this.gpbFileEntrance.SuspendLayout();
            this.mspTopMenu.SuspendLayout();
            this.gpbGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGraph)).BeginInit();
            this.gpbTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransitionTable)).BeginInit();
            this.gpbLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).BeginInit();
            this.gpbMultipleEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMultipleEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbFileEntrance
            // 
            this.gpbFileEntrance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbFileEntrance.Controls.Add(this.btnOpenFile);
            this.gpbFileEntrance.Controls.Add(this.lblFileStatus);
            this.gpbFileEntrance.Location = new System.Drawing.Point(118, 27);
            this.gpbFileEntrance.Name = "gpbFileEntrance";
            this.gpbFileEntrance.Size = new System.Drawing.Size(423, 100);
            this.gpbFileEntrance.TabIndex = 0;
            this.gpbFileEntrance.TabStop = false;
            this.gpbFileEntrance.Text = "Arquivo";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOpenFile.Location = new System.Drawing.Point(159, 47);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(104, 41);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "Abrir Arquivo";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // lblFileStatus
            // 
            this.lblFileStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFileStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileStatus.Location = new System.Drawing.Point(6, 19);
            this.lblFileStatus.Name = "lblFileStatus";
            this.lblFileStatus.Size = new System.Drawing.Size(411, 23);
            this.lblFileStatus.TabIndex = 0;
            this.lblFileStatus.Text = "Nenhum arquivo selecionado.";
            this.lblFileStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mspTopMenu
            // 
            this.mspTopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.testeToolStripMenuItem,
            this.configuraçõesToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.mspTopMenu.Location = new System.Drawing.Point(0, 0);
            this.mspTopMenu.Name = "mspTopMenu";
            this.mspTopMenu.Size = new System.Drawing.Size(800, 24);
            this.mspTopMenu.TabIndex = 1;
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jPGToolStripMenuItem,
            this.pNGToolStripMenuItem});
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.exportarToolStripMenuItem.Text = "Exportar Autômato";
            // 
            // jPGToolStripMenuItem
            // 
            this.jPGToolStripMenuItem.Name = "jPGToolStripMenuItem";
            this.jPGToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.jPGToolStripMenuItem.Text = "JPG";
            this.jPGToolStripMenuItem.Click += new System.EventHandler(this.jPGToolStripMenuItem_Click);
            // 
            // pNGToolStripMenuItem
            // 
            this.pNGToolStripMenuItem.Name = "pNGToolStripMenuItem";
            this.pNGToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.pNGToolStripMenuItem.Text = "PNG";
            this.pNGToolStripMenuItem.Click += new System.EventHandler(this.pNGToolStripMenuItem_Click);
            // 
            // testeToolStripMenuItem
            // 
            this.testeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmsiUnitEntry,
            this.tmsiMultipleEntry,
            this.testePassoaPassoToolStripMenuItem});
            this.testeToolStripMenuItem.Name = "testeToolStripMenuItem";
            this.testeToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.testeToolStripMenuItem.Text = "Teste";
            // 
            // tmsiUnitEntry
            // 
            this.tmsiUnitEntry.Name = "tmsiUnitEntry";
            this.tmsiUnitEntry.Size = new System.Drawing.Size(179, 22);
            this.tmsiUnitEntry.Text = "Entrada Unitária";
            this.tmsiUnitEntry.Click += new System.EventHandler(this.tmsiUnitEntry_Click);
            // 
            // tmsiMultipleEntry
            // 
            this.tmsiMultipleEntry.Name = "tmsiMultipleEntry";
            this.tmsiMultipleEntry.Size = new System.Drawing.Size(179, 22);
            this.tmsiMultipleEntry.Text = "Entradas Múltiplas";
            this.tmsiMultipleEntry.Click += new System.EventHandler(this.tmsiMultipleEntry_Click);
            // 
            // testePassoaPassoToolStripMenuItem
            // 
            this.testePassoaPassoToolStripMenuItem.Name = "testePassoaPassoToolStripMenuItem";
            this.testePassoaPassoToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.testePassoaPassoToolStripMenuItem.Text = "Teste Passo-a-Passo";
            this.testePassoaPassoToolStripMenuItem.Click += new System.EventHandler(this.testePassoaPassoToolStripMenuItem_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            this.configuraçõesToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // gpbGraph
            // 
            this.gpbGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbGraph.Controls.Add(this.pcbGraph);
            this.gpbGraph.Location = new System.Drawing.Point(12, 133);
            this.gpbGraph.Name = "gpbGraph";
            this.gpbGraph.Size = new System.Drawing.Size(529, 276);
            this.gpbGraph.TabIndex = 2;
            this.gpbGraph.TabStop = false;
            this.gpbGraph.Text = "Grafo";
            // 
            // pcbGraph
            // 
            this.pcbGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbGraph.BackColor = System.Drawing.Color.White;
            this.pcbGraph.Location = new System.Drawing.Point(6, 19);
            this.pcbGraph.Name = "pcbGraph";
            this.pcbGraph.Size = new System.Drawing.Size(517, 251);
            this.pcbGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbGraph.TabIndex = 0;
            this.pcbGraph.TabStop = false;
            this.pcbGraph.SizeChanged += new System.EventHandler(this.pcbGraph_SizeChanged);
            // 
            // gpbTable
            // 
            this.gpbTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbTable.Controls.Add(this.dgvTransitionTable);
            this.gpbTable.Location = new System.Drawing.Point(547, 133);
            this.gpbTable.Name = "gpbTable";
            this.gpbTable.Size = new System.Drawing.Size(241, 305);
            this.gpbTable.TabIndex = 3;
            this.gpbTable.TabStop = false;
            this.gpbTable.Text = "Tabela";
            // 
            // dgvTransitionTable
            // 
            this.dgvTransitionTable.AllowUserToAddRows = false;
            this.dgvTransitionTable.AllowUserToDeleteRows = false;
            this.dgvTransitionTable.AllowUserToResizeRows = false;
            this.dgvTransitionTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvTransitionTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransitionTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransitionTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransitionTable.Location = new System.Drawing.Point(6, 19);
            this.dgvTransitionTable.Name = "dgvTransitionTable";
            this.dgvTransitionTable.ReadOnly = true;
            this.dgvTransitionTable.RowHeadersVisible = false;
            this.dgvTransitionTable.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTransitionTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransitionTable.Size = new System.Drawing.Size(229, 280);
            this.dgvTransitionTable.TabIndex = 0;
            // 
            // gpbLogo
            // 
            this.gpbLogo.Controls.Add(this.pcbLogo);
            this.gpbLogo.Location = new System.Drawing.Point(12, 27);
            this.gpbLogo.Name = "gpbLogo";
            this.gpbLogo.Size = new System.Drawing.Size(100, 100);
            this.gpbLogo.TabIndex = 4;
            this.gpbLogo.TabStop = false;
            // 
            // pcbLogo
            // 
            this.pcbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pcbLogo.Image")));
            this.pcbLogo.Location = new System.Drawing.Point(6, 12);
            this.pcbLogo.Name = "pcbLogo";
            this.pcbLogo.Size = new System.Drawing.Size(88, 82);
            this.pcbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbLogo.TabIndex = 0;
            this.pcbLogo.TabStop = false;
            this.pcbLogo.Click += new System.EventHandler(this.pcbLogo_Click);
            // 
            // gpbMultipleEntry
            // 
            this.gpbMultipleEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbMultipleEntry.Controls.Add(this.dgvMultipleEntry);
            this.gpbMultipleEntry.Enabled = false;
            this.gpbMultipleEntry.Location = new System.Drawing.Point(547, 27);
            this.gpbMultipleEntry.Name = "gpbMultipleEntry";
            this.gpbMultipleEntry.Size = new System.Drawing.Size(241, 100);
            this.gpbMultipleEntry.TabIndex = 5;
            this.gpbMultipleEntry.TabStop = false;
            this.gpbMultipleEntry.Text = "Entradas Múltiplas";
            // 
            // dgvMultipleEntry
            // 
            this.dgvMultipleEntry.AllowUserToResizeRows = false;
            this.dgvMultipleEntry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMultipleEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMultipleEntry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnTape,
            this.clmnResult});
            this.dgvMultipleEntry.Location = new System.Drawing.Point(6, 19);
            this.dgvMultipleEntry.Name = "dgvMultipleEntry";
            this.dgvMultipleEntry.RowHeadersVisible = false;
            this.dgvMultipleEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMultipleEntry.Size = new System.Drawing.Size(229, 75);
            this.dgvMultipleEntry.TabIndex = 0;
            // 
            // clmnTape
            // 
            this.clmnTape.HeaderText = "Fita";
            this.clmnTape.Name = "clmnTape";
            // 
            // clmnResult
            // 
            this.clmnResult.HeaderText = "Resultado";
            this.clmnResult.Name = "clmnResult";
            this.clmnResult.ReadOnly = true;
            // 
            // lblAutomatonSpecs
            // 
            this.lblAutomatonSpecs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAutomatonSpecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutomatonSpecs.Location = new System.Drawing.Point(12, 412);
            this.lblAutomatonSpecs.Name = "lblAutomatonSpecs";
            this.lblAutomatonSpecs.Size = new System.Drawing.Size(529, 29);
            this.lblAutomatonSpecs.TabIndex = 6;
            this.lblAutomatonSpecs.Text = "Especificações do Autômato: Não Carregado";
            this.lblAutomatonSpecs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAutomatonSpecs);
            this.Controls.Add(this.gpbMultipleEntry);
            this.Controls.Add(this.gpbLogo);
            this.Controls.Add(this.gpbTable);
            this.Controls.Add(this.gpbGraph);
            this.Controls.Add(this.gpbFileEntrance);
            this.Controls.Add(this.mspTopMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mspTopMenu;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automaton Facilities - Principal";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.gpbFileEntrance.ResumeLayout(false);
            this.mspTopMenu.ResumeLayout(false);
            this.mspTopMenu.PerformLayout();
            this.gpbGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbGraph)).EndInit();
            this.gpbTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransitionTable)).EndInit();
            this.gpbLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).EndInit();
            this.gpbMultipleEntry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMultipleEntry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbFileEntrance;
        private System.Windows.Forms.MenuStrip mspTopMenu;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.GroupBox gpbGraph;
        private System.Windows.Forms.GroupBox gpbTable;
        private System.Windows.Forms.Label lblFileStatus;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.ToolStripMenuItem testeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmsiUnitEntry;
        private System.Windows.Forms.ToolStripMenuItem tmsiMultipleEntry;
        private System.Windows.Forms.ToolStripMenuItem testePassoaPassoToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvTransitionTable;
        private System.Windows.Forms.PictureBox pcbGraph;
        private System.Windows.Forms.GroupBox gpbLogo;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jPGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pNGToolStripMenuItem;
        private System.Windows.Forms.GroupBox gpbMultipleEntry;
        private System.Windows.Forms.DataGridView dgvMultipleEntry;
        private System.Windows.Forms.PictureBox pcbLogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnTape;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnResult;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.Label lblAutomatonSpecs;
    }
}