using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using QuickGraph.Graphviz.Dot;
using QuickGraph.Graphviz;

namespace TPI_Teoria_Linguagem.Classes
{
    public sealed class FileDotEngine : IDotEngine
    {
        public string Run(GraphvizImageType imageType, string dot, string outputFileName)
        {
            string output = outputFileName;
            File.WriteAllText(output + ".dot", dot);

            if (File.Exists(outputFileName + ".png"))
            {
                try
                {
                    File.Delete(outputFileName + ".png");
                }
                catch (IOException e)
                {
                    MessageBox.Show("O arquivo em questão está inacessível pois está sendo usado por outro processo.\n\n" + e, "Arquivo Inacessível", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            try
            {
                Process DOT_GraphViz = new Process();
                DOT_GraphViz.StartInfo.FileName = @"graphviz_release\bin\dot.exe";
                DOT_GraphViz.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                DOT_GraphViz.StartInfo.UseShellExecute = true;
                DOT_GraphViz.StartInfo.Verb = "runas";
                DOT_GraphViz.StartInfo.Arguments = string.Format(@" -Tpng {0} -o {1}", outputFileName + ".dot", outputFileName + ".png");
                DOT_GraphViz.Start();
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("O DOT do Graphviz não está no diretório.", "DOT Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("O DOT do Graphviz não está no diretório.", "DOT Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return output + ".png";
        }

        public bool ExportJPG(string FileName)
        {
            if (!Directory.Exists(Properties.Settings.Default.ExportDirectory))
            {
                MessageBox.Show("O diretório informado não existe!", "Diretório Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!File.Exists("graph.dot"))
            {
                MessageBox.Show("Arquivo de geração do grafo não encontrado.", "Arquivo DOT Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                Process DOT_Graphviz = new Process();
                DOT_Graphviz.StartInfo.FileName = @"graphviz_release\bin\dot.exe";
                DOT_Graphviz.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                DOT_Graphviz.StartInfo.UseShellExecute = true;
                DOT_Graphviz.StartInfo.Verb = "runas";
                DOT_Graphviz.StartInfo.Arguments = string.Format(@" -Tjpg {0} -o {1}", "graph.dot", TPI_Teoria_Linguagem.Properties.Settings.Default.ExportDirectory + @"\" + FileName + ".jpg");
                DOT_Graphviz.Start();
                return true;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("O DOT do Graphviz não está no diretório.", "DOT Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("O DOT do Graphviz não está no diretório.", "DOT Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        public bool ExportPNG(string FileName)
        {
            if (!Directory.Exists(TPI_Teoria_Linguagem.Properties.Settings.Default.ExportDirectory))
            {
                MessageBox.Show("O diretório informado não existe!", "Diretório Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!File.Exists("graph.dot"))
            {
                MessageBox.Show("Arquivo de geração do grafo não encontrado.", "Arquivo DOT Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                Process DOT_Graphviz = new Process();
                DOT_Graphviz.StartInfo.FileName = @"graphviz_release\bin\dot.exe";
                DOT_Graphviz.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                DOT_Graphviz.StartInfo.UseShellExecute = true;
                DOT_Graphviz.StartInfo.Verb = "runas";
                DOT_Graphviz.StartInfo.Arguments = string.Format(@" -Tpng {0} -o {1}", "graph.dot", TPI_Teoria_Linguagem.Properties.Settings.Default.ExportDirectory + @"\" + FileName + ".png");
                DOT_Graphviz.Start();
                return true;
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("O DOT do Graphviz não está no diretório.", "DOT Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("O DOT do Graphviz não está no diretório.", "DOT Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}
