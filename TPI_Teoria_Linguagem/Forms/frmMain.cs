using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using QuickGraph;
using QuickGraph.Graphviz;
using TPI_Teoria_Linguagem.Classes;

namespace TPI_Teoria_Linguagem.Forms
{
    public partial class frmMain : Form
    {
        Automaton Automaton = null;
        public bool FileOpened = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenAutomaton();
        }

        private void tmsiUnitEntry_Click(object sender, EventArgs e)
        {
            if (FileOpened && Automaton != default(Automaton))
            {
                string TestString = Interaction.InputBox("Insira a entrada para testar", "Entrada Unitária", string.Empty);
                
                if (Automaton.Type == "afd")
                {
                    if (Automaton.AcceptAFD(TestString))
                    {
                        MessageBox.Show("Entrada aceita pelo autômato finito determinístico.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Entrada rejeitada pelo autômato finito determinístico.", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (Automaton.Type == "afn")
                {
                    if (Automaton.AcceptAFN(TestString))
                    {
                        MessageBox.Show("Entrada aceita pelo autômato finito não-determinístico.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Entrada rejeitada pelo autômato finito não-determinístico.", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (Automaton.Type == "afdp")
                {
                    if (Automaton.AcceptAFDP(TestString))
                    {
                        MessageBox.Show("Entrada aceita pelo autômato finito determinístico com pilha.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Entrada rejeitada pelo autômato finito determinístico com pilha.", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um arquivo para carregar um autômato antes de tentar testá-lo.", "Selecione um arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tmsiMultipleEntry_Click(object sender, EventArgs e)
        {
            if (FileOpened && Automaton != default(Automaton))
            {
                if (dgvMultipleEntry.Rows.Count > 1)
                {
                    if (Automaton.Type == "afd")
                    {
                        foreach (DataGridViewRow Row in dgvMultipleEntry.Rows)
                        {
                            if (Row.Cells[0].Value != null)
                            {
                                if (Automaton.AcceptAFD(Row.Cells[0].Value.ToString()))
                                {
                                    if (TPI_Teoria_Linguagem.Properties.Settings.Default.ColorRow)
                                    {
                                        Row.DefaultCellStyle.BackColor = Color.LightGreen;
                                    }

                                    Row.Cells[1].Value = "Aceito";
                                }
                                else
                                {
                                    if (TPI_Teoria_Linguagem.Properties.Settings.Default.ColorRow)
                                    {
                                        Row.DefaultCellStyle.BackColor = Color.Red;
                                    }

                                    Row.Cells[1].Value = "Não aceito";
                                }
                            }
                        }
                    }
                    else if (Automaton.Type == "afn")
                    {
                        foreach (DataGridViewRow Row in dgvMultipleEntry.Rows)
                        {
                            if (Row.Cells[0].Value != null)
                            {
                                if (Automaton.AcceptAFN(Row.Cells[0].Value.ToString()))
                                {
                                    if (TPI_Teoria_Linguagem.Properties.Settings.Default.ColorRow)
                                    {
                                        Row.DefaultCellStyle.BackColor = Color.LightGreen;
                                    }

                                    Row.Cells[1].Value = "Aceito";
                                }
                                else
                                {
                                    if (TPI_Teoria_Linguagem.Properties.Settings.Default.ColorRow)
                                    {
                                        Row.DefaultCellStyle.BackColor = Color.Red;
                                    }

                                    Row.Cells[1].Value = "Não aceito";
                                }
                            }
                        }
                    }
                    else if (Automaton.Type == "afdp")
                    {
                        foreach (DataGridViewRow Row in dgvMultipleEntry.Rows)
                        {
                            if (Row.Cells[0].Value != null)
                            {
                                if (Automaton.AcceptAFDP(Row.Cells[0].Value.ToString()))
                                {
                                    if (TPI_Teoria_Linguagem.Properties.Settings.Default.ColorRow)
                                    {
                                        Row.DefaultCellStyle.BackColor = Color.LightGreen;
                                    }

                                    Row.Cells[1].Value = "Aceito";
                                }
                                else
                                {
                                    if (TPI_Teoria_Linguagem.Properties.Settings.Default.ColorRow)
                                    {
                                        Row.DefaultCellStyle.BackColor = Color.Red;
                                    }

                                    Row.Cells[1].Value = "Não aceito";
                                }
                            }
                        }
                    }
                    else if (Automaton.Type == "afnp")
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Não há linhas na tabela de entradas múltiplas.", "Tabela Vazia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um arquivo para carregar um autômato antes de tentar testá-lo.", "Selecione um arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillTable(Automaton Automaton)
        {
            DataTable TableData = new DataTable();

            for (int i = 0; i < Automaton.Alphabet.Length + 1; i++)
            {
                if (i == 0)
                {
                    TableData.Columns.Add("δ");
                }
                else
                {
                    TableData.Columns.Add(Automaton.Alphabet[i - 1]);
                }
            }

            for (int i = 0; i < Automaton.States.Count; i++)
            {
                DataRow DR = TableData.NewRow();

                for (int j = 0; j < Automaton.Alphabet.Length + 1; j++)
                {
                    if (j == 0)
                    {
                        string CellText = string.Empty;

                        if (Automaton.States[i].Initial)
                        {

                            CellText += "→";
                        }

                        if (Automaton.States[i].Final)
                        {
                            CellText += "*";
                        }

                        if (CellText != string.Empty)
                        {
                            CellText += " ";   
                        }

                        CellText += Automaton.States[i].Name;

                        DR[j] = CellText;
                    }
                    else
                    {
                        if (Automaton.Type == "afd" || Automaton.Type == "afdp")
                        {
                            if (Automaton.TransitionTable[i, j - 1, 0] != default(State))
                            {
                                DR[j] = Automaton.TransitionTable[i, j - 1, 0].Name;
                            }
                            else
                            {
                                DR[j] = "∅";
                            }
                        }
                        else
                        {
                            string ToDR = string.Empty;
                            ToDR += "{ ";

                            for (int k = 0; k < Automaton.States.Count; k++)
                            {
                                if (Automaton.TransitionTable[i, j - 1, k] != default(State) && k != (Automaton.States.Count - 1))
                                {
                                    ToDR += Automaton.TransitionTable[i, j - 1, k].Name + ", ";
                                }
                            }

                            if (ToDR.Length > 2)
                            {
                                ToDR = ToDR.Substring(0, ToDR.Length - 2);
                            }
                            
                            ToDR += " }";

                            DR[j] = ToDR;
                        }
                    }
                }

                TableData.Rows.Add(DR);
            }

            dgvTransitionTable.DataSource = TableData;
        }

        private void MountGraph(Automaton Automaton)
        {
            var Graph = new AdjacencyGraph<string, TaggedEdge<string, string>>(true);

            for (int i = 0; i < Automaton.States.Count; i++)
            {
                Graph.AddVertex(Automaton.States[i].Name);
            }

            for (int i = 0; i < Automaton.TransitionTable.GetLength(0); i++)
            {
                for (int j = 0; j < Automaton.TransitionTable.GetLength(1); j++)
                {
                    if (Automaton.Type == "afd" || Automaton.Type == "afdp")
                    {
                        if (Automaton.TransitionTable[i, j, 0] != default(State))
                        {
                            if (Automaton.Type == "afd")
                                Graph.AddEdge(new TaggedEdge<string, string>(Automaton.States[i].Name, Automaton.TransitionTable[i, j, 0].Name, Automaton.Alphabet[j]));
                            else
                                Graph.AddEdge(new TaggedEdge<string, string>(Automaton.States[i].Name, Automaton.TransitionTable[i, j, 0].Name.Split(',')[0], "(" + Automaton.Alphabet[j] + "," + Automaton.TransitionTable[i, j, 0].Name.Split(',')[1] + "," + Automaton.TransitionTable[i, j, 0].Name.Split(',')[2] + ")"));
                        }
                    }
                    else
                    {
                        for (int k = 0; k < Automaton.States.Count; k++)
                        {
                            if (Automaton.TransitionTable[i, j, k] != default(State))
                            {
                                if (Automaton.Type == "afn")
                                    Graph.AddEdge(new TaggedEdge<string, string>(Automaton.States[i].Name, Automaton.TransitionTable[i, j, k].Name, Automaton.Alphabet[j]));
                                else
                                    Graph.AddEdge(new TaggedEdge<string, string>(Automaton.States[i].Name, Automaton.TransitionTable[i, j, k].Name.Split(',')[0], "(" + Automaton.Alphabet[j] + "," + Automaton.TransitionTable[i, j, 0].Name.Split(',')[1] + "," + Automaton.TransitionTable[i, j, k].Name.Split(',')[2] + ")"));
                            }
                        }
                    }
                }
            }

            var GraphViz = new GraphvizAlgorithm<string, TaggedEdge<string, string>> (Graph);
           
            GraphViz.FormatVertex += (sender, args) => args.VertexFormatter.Label = args.Vertex.ToString();
            GraphViz.FormatEdge += (sender, args) => { args.EdgeFormatter.Label.Value = args.Edge.Tag.ToString(); };
            GraphViz.Generate(new FileDotEngine(), "graph");

            Thread.Sleep(500);

            try
            {
                FileStream FS = new FileStream(@"graph.png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Bitmap Image = new Bitmap(FS);
                pcbGraph.Image = Image;
                ReadjustImage();
                FS.Close();
            } catch (IOException)
            {
                MessageBox.Show("A imagem não pôde ser gerada!", "Imagem inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (TPI_Teoria_Linguagem.Properties.Settings.Default.ExportDirectory == string.Empty)
            {
                TPI_Teoria_Linguagem.Properties.Settings.Default.ExportDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                TPI_Teoria_Linguagem.Properties.Settings.Default.Save();
            }
        }
        
        private void pcbLogo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ah... Agora eu entedi!\nAgora eu saquei!\nAgora todas as peças se encaixaram!\nEu estou entendendo tudo agora!", "Outro caso encerrado, meu caro Watson", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void jPGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileOpened && Automaton != default(Automaton))
            {
                FileDotEngine FDE = new FileDotEngine();
                string FileName = Interaction.InputBox("Insira o nome do arquivo para exportar", string.Empty);
                if (FileName != string.Empty)
                {
                    if (!File.Exists(TPI_Teoria_Linguagem.Properties.Settings.Default.ExportDirectory + @"\" + FileName + ".jpg"))
                    {
                        FDE.ExportJPG(FileName);
                    }
                    else
                    {
                        MessageBox.Show("Este arquivo já existe no diretório de exportação.", "Arquivo já existente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um arquivo para carregar um autômato antes de tentar exportá-lo.", "Selecione um arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileOpened && Automaton != default(Automaton))
            {
                FileDotEngine FDE = new FileDotEngine();
                string FileName = Interaction.InputBox("Insira o nome do arquivo para exportar", string.Empty);
                if (FileName != string.Empty)
                {
                    if (!File.Exists(TPI_Teoria_Linguagem.Properties.Settings.Default.ExportDirectory + @"\" + FileName + ".png"))
                    {
                        FDE.ExportPNG(FileName);
                    }
                    else
                    {
                        MessageBox.Show("Este arquivo já existe no diretório de exportação.", "Arquivo já existente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um arquivo para carregar um autômato antes de tentar exportá-lo.", "Selecione um arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pcbGraph_SizeChanged(object sender, EventArgs e)
        {
            ReadjustImage();
        }

        private void ReadjustImage()
        {
            if (pcbGraph.Image != null)
            {
                if (pcbGraph.Image.Height < pcbGraph.Height && pcbGraph.Image.Width < pcbGraph.Width)
                {
                    pcbGraph.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                else
                {
                    pcbGraph.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void OpenAutomaton()
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString();
            OFD.Filter = "Arquivos TXT (*.txt)|*.txt";
            OFD.RestoreDirectory = true;

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                FileStream FS = new FileStream(OFD.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                FileHandler FH = new FileHandler(OFD.FileName, FS);

                if (FH.CheckFile())
                {
                    if ((Automaton = FH.TurnFileToAutomaton()) != null)
                    {
                        FileOpened = true;
                        lblFileStatus.Text = OFD.FileName;
                        FillTable(Automaton);
                        MountGraph(Automaton);
                        gpbMultipleEntry.Enabled = true;
                        lblAutomatonSpecs.Text = string.Format("Especificações do Autômato: {0} - {1} Estados - [ ", Automaton.Type.ToUpper().Trim(), Automaton.States.Count);
                        foreach (string Alpha in Automaton.Alphabet)
                        {
                            lblAutomatonSpecs.Text += Alpha + ", ";
                        }
                        lblAutomatonSpecs.Text = lblAutomatonSpecs.Text.Substring(0, lblAutomatonSpecs.Text.Length - 2);
                        lblAutomatonSpecs.Text += " ]";
                        MessageBox.Show("O autômato foi carregado com sucesso.", "Autômato Carregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível abrir o arquivo.");
                }
            }
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfig frmConfig = new frmConfig();
            frmConfig.ShowDialog();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if(TPI_Teoria_Linguagem.Properties.Settings.Default.OpenDialog)
            {
                OpenAutomaton();
            }
        }

        private void testePassoaPassoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileOpened && Automaton != default(Automaton))
            {
                string TestString = Interaction.InputBox("Insira a entrada para testar", "Entrada Unitária", string.Empty);

                if (Automaton.Type == "afd")
                {
                    if (Automaton.AcceptAFD_StepByStep(TestString, dgvTransitionTable))
                    {
                        MessageBox.Show("Entrada aceita pelo autômato.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Entrada não foi aceita pelo autômato.", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (Automaton.Type == "afn")
                {
                    if (Automaton.AcceptAFN_StepByStep(TestString, dgvTransitionTable))
                    {
                        MessageBox.Show("Entrada aceita pelo autômato.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Entrada não foi aceita pelo autômato.", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (Automaton.Type == "afdp")
                {
                    if (Automaton.AcceptAFDP_StepByStep(TestString, dgvTransitionTable))
                    {
                        MessageBox.Show("Entrada aceita pelo autômato.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Entrada não foi aceita pelo autômato.", "Fracasso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (Automaton.Type == "afnp")
                {

                }
            }
            else
            {
                MessageBox.Show("Selecione um arquivo para carregar um autômato antes de tentar testá-lo.", "Selecione um arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
