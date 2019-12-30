using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TPI_Teoria_Linguagem.Forms
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            txtExportDirectory.Text = TPI_Teoria_Linguagem.Properties.Settings.Default.ExportDirectory;

            if (TPI_Teoria_Linguagem.Properties.Settings.Default.ColorRow)
            {
                ckbPaintRows.Checked = true;
            }

            if (TPI_Teoria_Linguagem.Properties.Settings.Default.OpenDialog)
            {
                ckbOpenDialog.Checked = true;
            }
        }  

        private void btnSearchDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();

            if (FBD.ShowDialog() == DialogResult.OK)
            {
                txtExportDirectory.Text = FBD.SelectedPath;
                TPI_Teoria_Linguagem.Properties.Settings.Default.ExportDirectory = FBD.SelectedPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TPI_Teoria_Linguagem.Properties.Settings.Default.ColorRow = ckbPaintRows.Checked;
            TPI_Teoria_Linguagem.Properties.Settings.Default.OpenDialog = ckbOpenDialog.Checked;
            TPI_Teoria_Linguagem.Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
