using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TPI_Teoria_Linguagem.Classes
{
    public class FileHandler
    {
        public string FilePath { get; private set; }
        public string FileContent { get; private set; }

        public FileHandler(string FilePath, FileStream Stream)
        {
            StreamReader Reader = new StreamReader(Stream);

            this.FilePath = FilePath;

            try
            {
                this.FileContent = Reader.ReadToEnd();
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Não há memória suficiente para alocar o buffer da string retornada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException e)
            {
                MessageBox.Show("Ocorreu um erro de I/O.\n\nErro: " + e, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Reader.Close();
        }

        // Checa se o arquivo foi aberto e lido
        public bool CheckFile()
        {
            if (this.FilePath != String.Empty)
            {
                return true;
            }

            return false;
        }

        public Automaton TurnFileToAutomaton()
        {
            StringReader SR = new StringReader(this.FileContent);
            string FirstLine = SR.ReadLine();

            string[] FirstLineContents = FirstLine.Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);

            if (FirstLineContents.Length < 3)
            {
                MessageBox.Show("Arquivo inválido.\nHá menos argumentos que o esperado no cabeçalho.", "Arquivo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            string AutomatonType = FirstLineContents[0].ToLower().Trim();

            if (AutomatonType == "afd" || AutomatonType == "afn" || AutomatonType == "afdp" || AutomatonType == "afnp")
            {
                FirstLineContents[1] = FirstLineContents[1].Replace("[", string.Empty);
                FirstLineContents[1] = FirstLineContents[1].Replace("]", string.Empty);

                string[] AutomatonAlphabet = FirstLineContents[1].Split(',');
                string[] AutomatonStates = new string[FirstLineContents.Length - 2];
                Array.Copy(FirstLineContents, 2, AutomatonStates, 0, FirstLineContents.Length - 2);

                bool FindInitial = false;
                List<State> StateList = new List<State>();
                for (int i = 0; i < AutomatonStates.Length; i++)
                {
                    State State = null;

                    if (AutomatonStates[i][AutomatonStates[i].Length - 1] == '+')
                    {
                        if (FindInitial)
                        {
                            MessageBox.Show("Arquivo inválido.\nNão é possível ter mais de um estado inicial.", "Arquivo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }

                        FindInitial = true;

                        if (AutomatonStates[i][AutomatonStates[i].Length - 2] == '*')
                        {
                            AutomatonStates[i] = AutomatonStates[i].Remove(AutomatonStates[i].Length - 2);
                            State = new State(AutomatonStates[i], true, true);
                        }
                        else
                        {
                            AutomatonStates[i] = AutomatonStates[i].Remove(AutomatonStates[i].Length - 1);
                            State = new State(AutomatonStates[i], true, false);
                        }
                    }
                    else if (AutomatonStates[i][AutomatonStates[i].Length - 1] == '*')
                    {
                        if (AutomatonStates[i][AutomatonStates[i].Length - 2] == '+')
                        {
                            if (FindInitial)
                            {
                                MessageBox.Show("Arquivo inválido.\nNão é possível ter mais de um estado inicial.", "Arquivo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return null;
                            }

                            FindInitial = true;

                            AutomatonStates[i] = AutomatonStates[i].Remove(AutomatonStates[i].Length - 2);
                            State = new State(AutomatonStates[i], true, true);
                        }
                        else
                        {
                            AutomatonStates[i] = AutomatonStates[i].Remove(AutomatonStates[i].Length - 1);
                            State = new State(AutomatonStates[i], false, true);
                        }
                    }
                    else
                    {
                        State = new State(AutomatonStates[i], false, false);
                    }

                    int CheckCounter = 0;
                    foreach (string AutomatonStateTest in AutomatonStates)
                    {
                        if (AutomatonStateTest == AutomatonStates[i])
                        {
                            CheckCounter++;
                        }
                    }

                    if (CheckCounter > 1)
                    {
                        MessageBox.Show("Arquivo inválido.\nHá estados repetidos.", "Arquivo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }

                    if (State != null)
                    {
                        StateList.Add(State);
                    }
                    else
                    {
                        MessageBox.Show("Algo de errado não está certo.", "Arquivo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }

                // Adiciona numa lista as transições cruas.
                // É considerado como transição tudo que não está na primeira linha.
                List<string> AutomatonTransitions = new List<string>();
                string AutomatonTransition;
                while ((AutomatonTransition = SR.ReadLine()) != null)
                {
                    AutomatonTransitions.Add(AutomatonTransition);
                }

                //MessageBox.Show(string.Join("\n", AutomatonTransitions));

                try
                {
                    string InitialStateName = StateList.Find(r => r.Initial == true).Name;
                }
                catch (ArgumentNullException) { }
                catch (NullReferenceException) { /* Não há estado inicial */ }


                State[,,] TransitionTable;

                if (AutomatonType == "afd" || AutomatonType == "afdp")
                {
                    TransitionTable = new State[AutomatonStates.Length, AutomatonAlphabet.Length, 1];
                }
                else
                {
                    TransitionTable = new State[AutomatonStates.Length, AutomatonAlphabet.Length, AutomatonStates.Length];
                }

                // Percorre todos estados citados no cabeçalho
                for (int i = 0; i < StateList.Count; i++)
                {
                    // Percore as transições
                    foreach (string Transition in AutomatonTransitions)
                    {
                        string[] TransitionSplitted = Transition.Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);

                        // Tira o [ e ] da transição
                        TransitionSplitted[TransitionSplitted.Length - 1] = TransitionSplitted[TransitionSplitted.Length - 1].Replace("[", string.Empty);
                        TransitionSplitted[TransitionSplitted.Length - 1] = TransitionSplitted[TransitionSplitted.Length - 1].Replace("]", string.Empty);
                        if (AutomatonType == "afdp" || AutomatonType == "afnp")
                        {
                            TransitionSplitted[TransitionSplitted.Length - 1] = TransitionSplitted[TransitionSplitted.Length - 1].Replace("(", string.Empty);
                            TransitionSplitted[TransitionSplitted.Length - 1] = TransitionSplitted[TransitionSplitted.Length - 1].Replace(")", string.Empty);
                        }
                        string[] TransitionAlpha = TransitionSplitted[TransitionSplitted.Length - 1].Split(',');

                        //MessageBox.Show(string.Join("\n", TransitionAlpha));
                        // Checa se a transição tem estado de origem igual ao estado atual
                        if (TransitionSplitted[0] == AutomatonStates[i])
                        {
                            // Percorre símbolos da transição
                            for (int j = 0; j < TransitionAlpha.Length; j++)
                            {
                                int AlphabetIndex;

                                if (AutomatonType == "afdp" || AutomatonType == "afnp")
                                {
                                    AlphabetIndex = Automaton.GetAlphabetIndex(TransitionAlpha[j][0].ToString(), AutomatonAlphabet); // Mudar para [1] caso tire os parenteses
                                }
                                else
                                {
                                    AlphabetIndex = Automaton.GetAlphabetIndex(TransitionAlpha[j], AutomatonAlphabet);
                                }

                                if (AlphabetIndex != -1)
                                {
                                    if (AutomatonType == "afd" || AutomatonType == "afdp")
                                    {
                                        State State = new State(StateList.Find(r => r.Name == TransitionSplitted[1]).Name, StateList.Find(r => r.Name == TransitionSplitted[1]).Initial, StateList.Find(r => r.Name == TransitionSplitted[1]).Final);
                                        TransitionTable[i, AlphabetIndex, 0] = State;
                                        
                                        if (AutomatonType == "afdp")
                                            if (TransitionTable[i, AlphabetIndex, 0] != default(State))
                                                TransitionTable[i, AlphabetIndex, 0].Name = TransitionTable[i, AlphabetIndex, 0].Name + "," + TransitionAlpha[j][2] + "," + TransitionAlpha[j][4];
                                    }
                                    else // AFN e AFNP
                                    {
                                        for (int k = 0; k < StateList.Count; k++)
                                        {
                                            if (TransitionTable[i, AlphabetIndex, k] == default(State))
                                            {
                                                State State = new State(StateList.Find(r => r.Name == TransitionSplitted[1]).Name, StateList.Find(r => r.Name == TransitionSplitted[1]).Initial, StateList.Find(r => r.Name == TransitionSplitted[1]).Final);
                                                TransitionTable[i, AlphabetIndex, k] = State;

                                                if (AutomatonType == "afnp")
                                                    if (TransitionTable[i, AlphabetIndex, k] != default(State))
                                                        TransitionTable[i, AlphabetIndex, k].Name = TransitionTable[i, AlphabetIndex, k].Name + "," + TransitionAlpha[j][2] + "," + TransitionAlpha[j][4];
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Arquivo inválido.\nNa transição " + (j + 1).ToString() + " há um símbolo que não pertence ao alfabeto.", "Arquivo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return null;
                                }
                            }
                        }
                    }
                }

                return new Automaton(AutomatonType, AutomatonAlphabet, StateList, TransitionTable);
            }
            else
            {
                MessageBox.Show("Arquivo inválido.\nNão foi possível detectar AFN/AFD.", "Arquivo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return null;
        }
    }
}
