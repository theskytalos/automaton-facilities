using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPI_Teoria_Linguagem.Classes
{
    public class Automaton
    {
        public string Type { get; private set; }
        public string[] Alphabet { get; private set; }
        public List<State> States { get; private set; }
        public State[,,] TransitionTable { get; private set; }

        public Automaton(string Type, string[] Alphabet, List<State> States, State[,,] TransitionTable)
        {
            this.Type = Type;
            this.Alphabet = Alphabet;
            this.States = States;
            this.TransitionTable = TransitionTable;
        }

        public static int GetAlphabetIndex(string SearchFor, string[] Alphabet)
        {
            for (int i = 0; i < Alphabet.Length; i++)
            {
                if (SearchFor == Alphabet[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public int GetStateIndex(string SearchFor)
        {
            for (int i = 0; i < this.States.Count; i++)
            {
                if (SearchFor == this.States[i].Name)
                {
                    return i;
                }
            }

            return -1;
        }

        public List<State> GetTransitionsByState(State State)
        {
            List<State> Transitions = new List<State>();
            for (int i = 0; i < this.Alphabet.Length; i++)
                if (this.TransitionTable[GetStateIndex(State.Name.Split(',')[0]), i, 0] != default(State))
                    Transitions.Add(this.TransitionTable[GetStateIndex(State.Name.Split(',')[0]), i, 0]);               

            return Transitions;
        }

        public bool AcceptAFD(string Tape)
        {
            int InitialStateIndex = -1;

            for (int i = 0; i < this.States.Count; i++)
            {
                if (States[i].Initial)
                {
                    InitialStateIndex = i;
                    break;
                }
            }

            if (InitialStateIndex == -1)
            {
                MessageBox.Show("O autômato provido não possui um estado inicial.", "Autômato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool HasEndState = false;

            for (int i = 0; i < this.States.Count; i++)
            {
                if (States[i].Final)
                {
                    HasEndState = true;
                    break;
                }
            }

            if (!HasEndState)
            {
                return false;
            }

            int CurrentLineIndex = InitialStateIndex;
            int CurrentColumnIndex;
            State CurrentState = this.States[InitialStateIndex];
            State NextState = null;
            
            for (int i = 0; i < Tape.Length; i++)
            {
                CurrentColumnIndex = GetAlphabetIndex(Tape[i].ToString(), this.Alphabet);
                if (CurrentColumnIndex != -1)
                {
                    NextState = this.TransitionTable[CurrentLineIndex, CurrentColumnIndex, 0];
                }
                else
                {
                    return false;
                }

                CurrentState = NextState;

                if (NextState == default(State))
                {
                    break;
                }
                else
                {
                    CurrentLineIndex = GetStateIndex(NextState.Name);
                }
            }

            if (CurrentState != default(State))
            {   
                if (CurrentState.Final)
                {
                    return true;
                }
            }

            return false;
        }

        public bool AcceptAFDP(string Tape)
        {
            int InitialStateIndex = -1;

            for (int i = 0; i < this.States.Count; i++)
            {
                if (States[i].Initial)
                {
                    InitialStateIndex = i;
                    break;
                }
            }

            if (InitialStateIndex == -1)
            {
                MessageBox.Show("O autômato provido não possui um estado inicial.", "Autômato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool HasEndState = false;

            for (int i = 0; i < this.States.Count; i++)
            {
                if (States[i].Final)
                {
                    HasEndState = true;
                    break;
                }
            }

            if (!HasEndState)
            {
                return false;
            }

            int CurrentLineIndex = InitialStateIndex;
            int CurrentColumnIndex;
            State CurrentState = this.States[InitialStateIndex];
            State NextState = null;
            Stack<string> AutomatonStack = new Stack<string>();

            for (int i = 0; i < Tape.Length; i++)
            {
                CurrentColumnIndex = GetAlphabetIndex(Tape[i].ToString(), this.Alphabet);
                if (CurrentColumnIndex != -1)
                {
                    NextState = this.TransitionTable[CurrentLineIndex, CurrentColumnIndex, 0];
                }
                else
                {
                    return false;
                }
               
                CurrentState = NextState;

                if (CurrentState.Name.Split(',')[1] != "$")
                {
                    if (AutomatonStack.Count > 0)
                    {
                        if (AutomatonStack.Peek() == CurrentState.Name.Split(',')[1])
                            AutomatonStack.Pop();
                        else
                            return false;
                    }
                    else
                        return false;
                }

                if (CurrentState.Name.Split(',')[2] != "$")
                {
                    AutomatonStack.Push(CurrentState.Name.Split(',')[2]);
                }

                if (NextState == default(State))
                {
                    break;
                }
                else
                {
                    CurrentLineIndex = GetStateIndex(NextState.Name.Split(',')[0]);
                }
            }

            List<State> Transitions = GetTransitionsByState(CurrentState);

            bool IsTapeEnded = false;
            bool IsStackEmpty = false;

            State PossibleEnd = this.TransitionTable[GetStateIndex(CurrentState.Name.Split(',')[0]), this.Alphabet.Length - 1, 0];

            if (PossibleEnd != default(State))
            {
                IsTapeEnded = true;
            }

            if (PossibleEnd.Name.Split(',')[1] == "?" && PossibleEnd.Name.Split(',')[2] == "$")
            {
                if (AutomatonStack.Count == 0)
                {
                    IsStackEmpty = true;
                }
                
            }

            if (IsTapeEnded && IsStackEmpty)
            {
                CurrentColumnIndex = this.Alphabet.Length - 1;
                CurrentState = this.TransitionTable[CurrentLineIndex, CurrentColumnIndex, 0];
            }

            if (CurrentState != default(State))
            {
                if (CurrentState.Final)
                {
                    return true;
                }
            }

            return false;
        }

        public bool AcceptAFD_StepByStep(string Tape, DataGridView dgvTransitionTable)
        {
            int InitialStateIndex = -1;

            for (int i = 0; i < this.States.Count; i++)
            {
                if (States[i].Initial)
                {
                    InitialStateIndex = i;
                    break;
                }
            }

            if (InitialStateIndex == -1)
            {
                MessageBox.Show("O autômato provido não possui um estado inicial.", "Autômato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool HasEndState = false;

            for (int i = 0; i < this.States.Count; i++)
            {
                if (States[i].Final)
                {
                    HasEndState = true;
                    break;
                }
            }

            if (!HasEndState)
            {
                return false;
            }

            int CurrentLineIndex = InitialStateIndex;
            int CurrentColumnIndex;
            State CurrentState = this.States[InitialStateIndex];
            State NextState = null;

            dgvTransitionTable.ClearSelection();

            for (int i = 0; i < Tape.Length; i++)
            {
                CurrentColumnIndex = GetAlphabetIndex(Tape[i].ToString(), this.Alphabet);
                if (CurrentColumnIndex != -1)
                {
                    NextState = this.TransitionTable[CurrentLineIndex, CurrentColumnIndex, 0];
                }
                else
                {
                    return false;
                }

                dgvTransitionTable.Rows[GetStateIndex(CurrentState.Name)].DefaultCellStyle.BackColor = Color.Green;
                dgvTransitionTable.FirstDisplayedScrollingRowIndex = GetStateIndex(CurrentState.Name);
                MessageBox.Show("Estado atual: " + CurrentState.Name + "\nIrá ser processado agora: " + Tape[i], "Estado atual", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (i != (Tape.Length - 1))
                {
                    dgvTransitionTable.Rows[GetStateIndex(CurrentState.Name)].DefaultCellStyle.BackColor = Color.Gray;
                }

                CurrentState = NextState;

                if (NextState == default(State))
                {
                    break;
                }
                else
                {
                    CurrentLineIndex = GetStateIndex(NextState.Name);
                }
            }

            if (CurrentState != default(State))
            {
                if (CurrentState.Final)
                {
                    return true;
                }
            }

            return false;
        }

        public bool AcceptAFDP_StepByStep(string Tape, DataGridView dgvTransitionTable)
        {
            int InitialStateIndex = -1;

            for (int i = 0; i < this.States.Count; i++)
            {
                if (States[i].Initial)
                {
                    InitialStateIndex = i;
                    break;
                }
            }

            if (InitialStateIndex == -1)
            {
                MessageBox.Show("O autômato provido não possui um estado inicial.", "Autômato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool HasEndState = false;

            for (int i = 0; i < this.States.Count; i++)
            {
                if (States[i].Final)
                {
                    HasEndState = true;
                    break;
                }
            }

            if (!HasEndState)
            {
                return false;
            }

            int CurrentLineIndex = InitialStateIndex;
            int CurrentColumnIndex;
            State CurrentState = this.States[InitialStateIndex];
            State NextState = null;
            Stack<string> AutomatonStack = new Stack<string>();

            dgvTransitionTable.ClearSelection();

            for (int i = 0; i < Tape.Length; i++)
            {
                CurrentColumnIndex = GetAlphabetIndex(Tape[i].ToString(), this.Alphabet);
                if (CurrentColumnIndex != -1)
                {
                    NextState = this.TransitionTable[CurrentLineIndex, CurrentColumnIndex, 0];
                }
                else
                {
                    return false;
                }

                dgvTransitionTable.Rows[GetStateIndex(CurrentState.Name.Split(',')[0])].DefaultCellStyle.BackColor = Color.Green;
                dgvTransitionTable.FirstDisplayedScrollingRowIndex = GetStateIndex(CurrentState.Name.Split(',')[0]);
                MessageBox.Show("Estado atual: " + CurrentState.Name.Split(',')[0] + "\nIrá ser processado agora: " + Tape[i] + "\nPilha\n\n" + string.Join("\n", AutomatonStack), "Estado atual", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                dgvTransitionTable.Rows[GetStateIndex(CurrentState.Name.Split(',')[0])].DefaultCellStyle.BackColor = Color.Gray;
                

                CurrentState = NextState;

                if (CurrentState.Name.Split(',')[1] != "$")
                {
                    if (AutomatonStack.Count > 0)
                    {
                        if (AutomatonStack.Peek() == CurrentState.Name.Split(',')[1])
                        {
                            string Popped = AutomatonStack.Pop();
                            MessageBox.Show(Popped + " foi removido da pilha.", "Atualização da pilha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("A fita está a tentar desempilhar um símbolo errado.\nA máquina será parada.", "Atualização da pilha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                            
                    }
                    else
                    {
                        MessageBox.Show("A fita está a tentar desempilhar em uma pilha vazia.\nA máquina será parada.", "Atualização da pilha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }

                if (CurrentState.Name.Split(',')[2] != "$")
                {
                    AutomatonStack.Push(CurrentState.Name.Split(',')[2]);
                    MessageBox.Show(CurrentState.Name.Split(',')[2] + " foi adicionado a pilha.", "Atualização da pilha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (NextState == default(State))
                {
                    break;
                }
                else
                {
                    CurrentLineIndex = GetStateIndex(NextState.Name.Split(',')[0]);
                }
            }

            List<State> Transitions = GetTransitionsByState(CurrentState);

            bool IsTapeEnded = false;
            bool IsStackEmpty = false;

            State PossibleEnd = this.TransitionTable[GetStateIndex(CurrentState.Name.Split(',')[0]), this.Alphabet.Length - 1, 0];

            if (PossibleEnd != default(State))
            {
                IsTapeEnded = true;
            }

            if (PossibleEnd.Name.Split(',')[1] == "?" && PossibleEnd.Name.Split(',')[2] == "$")
            {
                if (AutomatonStack.Count == 0)
                {
                    IsStackEmpty = true;
                }

            }

            if (IsTapeEnded && IsStackEmpty)
            {
                MessageBox.Show("(?,?,$) -> Condição Satisfeita, fita acabou e a pilha está vazia.", "Estado atual", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CurrentColumnIndex = this.Alphabet.Length - 1;
                CurrentState = this.TransitionTable[CurrentLineIndex, CurrentColumnIndex, 0];
                dgvTransitionTable.Rows[GetStateIndex(CurrentState.Name.Split(',')[0])].DefaultCellStyle.BackColor = Color.Green;
                dgvTransitionTable.FirstDisplayedScrollingRowIndex = GetStateIndex(CurrentState.Name.Split(',')[0]);
                MessageBox.Show("Estado atual: " + CurrentState.Name.Split(',')[0], "Estado atual", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (CurrentState != default(State))
            {
                if (CurrentState.Final)
                {
                    return true;
                }
            }

            return false;
        }

        public bool AcceptAFN(string Tape)
        {
            int InitialStateIndex = -1;

            for (int i = 0; i < this.States.Count; i++)
            {
                if (States[i].Initial)
                {
                    InitialStateIndex = i;
                    break;
                }
            }

            if (InitialStateIndex == -1)
            {
                MessageBox.Show("O autômato provido não possui um estado inicial.", "Autômato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool HasEndState = false;

            for (int i = 0; i < this.States.Count; i++)
            {
                if (States[i].Final)
                {
                    HasEndState = true;
                    break;
                }
            }

            if (!HasEndState)
            {
                return false;
            }

            int CurrentLineIndex = InitialStateIndex;
            int CurrentColumnIndex;
            List<State> CurrentEnlightedStates = new List<State>();
            List<State> NextEnlightedStates = new List<State>();

            CurrentEnlightedStates.Add(this.States[InitialStateIndex]);
            
            for (int i = 0; i < Tape.Length; i++)
            {
                NextEnlightedStates.Clear();
                CurrentColumnIndex = GetAlphabetIndex(Tape[i].ToString(), this.Alphabet);

                if (CurrentColumnIndex == -1)
                {
                    return false;
                }

                for (int j = 0; j < CurrentEnlightedStates.Count; j++)
                {
                    CurrentLineIndex = GetStateIndex(CurrentEnlightedStates[j].Name);

                    for (int k = 0; k < this.States.Count; k++)
                    {
                        if (this.TransitionTable[CurrentLineIndex, CurrentColumnIndex, k] != default(State))
                        {
                            NextEnlightedStates.Add(this.TransitionTable[CurrentLineIndex, CurrentColumnIndex, k]);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (NextEnlightedStates.Count == 0)
                {
                    break;
                }
                else
                {
                    CurrentEnlightedStates.Clear();
                    CurrentEnlightedStates.AddRange(NextEnlightedStates);
                }
            }
            
            foreach(State EnlightedState in CurrentEnlightedStates)
            {
                if (EnlightedState.Final)
                {
                    return true;
                }
            }

            return false;
        }

        public bool AcceptAFNP(string Tape)
        {
            int InitialStateIndex = -1;

            for (int i = 0; i < this.States.Count; i++)
            {
                if (States[i].Initial)
                {
                    InitialStateIndex = i;
                    break;
                }
            }

            if (InitialStateIndex == -1)
            {
                MessageBox.Show("O autômato provido não possui um estado inicial.", "Autômato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool HasEndState = false;

            for (int i = 0; i < this.States.Count; i++)
            {
                if (States[i].Final)
                {
                    HasEndState = true;
                    break;
                }
            }

            if (!HasEndState)
            {
                return false;
            }

            int CurrentLineIndex = InitialStateIndex;
            int CurrentColumnIndex;
            List<State> CurrentEnlightedStates = new List<State>();
            List<State> NextEnlightedStates = new List<State>();

            CurrentEnlightedStates.Add(this.States[InitialStateIndex]);

            for (int i = 0; i < Tape.Length; i++)
            {
                NextEnlightedStates.Clear();
                CurrentColumnIndex = GetAlphabetIndex(Tape[i].ToString(), this.Alphabet);

                if (CurrentColumnIndex == -1)
                {
                    return false;
                }

                for (int j = 0; j < CurrentEnlightedStates.Count; j++)
                {
                    CurrentLineIndex = GetStateIndex(CurrentEnlightedStates[j].Name);

                    for (int k = 0; k < this.States.Count; k++)
                    {
                        if (this.TransitionTable[CurrentLineIndex, CurrentColumnIndex, k] != default(State))
                        {
                            NextEnlightedStates.Add(this.TransitionTable[CurrentLineIndex, CurrentColumnIndex, k]);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (NextEnlightedStates.Count == 0)
                {
                    break;
                }
                else
                {
                    CurrentEnlightedStates.Clear();
                    CurrentEnlightedStates.AddRange(NextEnlightedStates);
                }
            }

            foreach (State EnlightedState in CurrentEnlightedStates)
            {
                if (EnlightedState.Final)
                {
                    return true;
                }
            }

            return false;
        }

        public bool AcceptAFN_StepByStep(string Tape, DataGridView dgv)
        {
            int InitialStateIndex = -1;

            for (int i = 0; i < this.States.Count; i++)
            {
                if (States[i].Initial)
                {
                    InitialStateIndex = i;
                    break;
                }
            }

            if (InitialStateIndex == -1)
            {
                MessageBox.Show("O autômato provido não possui um estado inicial.", "Autômato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool HasEndState = false;

            for (int i = 0; i < this.States.Count; i++)
            {
                if (States[i].Final)
                {
                    HasEndState = true;
                    break;
                }
            }

            if (!HasEndState)
            {
                return false;
            }

            int CurrentLineIndex = InitialStateIndex;
            int CurrentColumnIndex;
            List<State> CurrentEnlightedStates = new List<State>();
            List<State> NextEnlightedStates = new List<State>();

            CurrentEnlightedStates.Add(this.States[InitialStateIndex]);
            
            for (int i = 0; i < Tape.Length; i++)
            {
                string Step = "{ ";
                foreach (State StepState in CurrentEnlightedStates)
                {
                    Step += StepState.Name + ", ";
                }
                if (Step.Length > 2)
                {
                    Step = Step.Substring(0, Step.Length - 2);
                }
                Step += " }";
                MessageBox.Show("Estados Acesos: " + Step + "\nIrá ser processado agora: " + Tape[i], "Estados Atuais", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NextEnlightedStates.Clear();
                CurrentColumnIndex = GetAlphabetIndex(Tape[i].ToString(), this.Alphabet);

                if (CurrentColumnIndex == -1)
                {
                    return false;
                }

                for (int j = 0; j < CurrentEnlightedStates.Count; j++)
                {
                    CurrentLineIndex = GetStateIndex(CurrentEnlightedStates[j].Name);

                    for (int k = 0; k < this.States.Count; k++)
                    {
                        if (this.TransitionTable[CurrentLineIndex, CurrentColumnIndex, k] != default(State))
                        {
                            NextEnlightedStates.Add(this.TransitionTable[CurrentLineIndex, CurrentColumnIndex, k]);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (NextEnlightedStates.Count == 0)
                {
                    break;
                }
                else
                {
                    CurrentEnlightedStates.Clear();
                    CurrentEnlightedStates.AddRange(NextEnlightedStates);
                }
            }

            string FinalStep = "{ ";
            foreach (State StepState in CurrentEnlightedStates)
            {
                FinalStep += StepState.Name + ", ";
            }
            if (FinalStep.Length > 2)
            {
                FinalStep = FinalStep.Substring(0, FinalStep.Length - 2);
            }
            FinalStep += " }";
            MessageBox.Show("Estados Acesos: " + FinalStep, "Estados Atuais (Último Passo)", MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (State EnlightedState in CurrentEnlightedStates)
            {
                if (EnlightedState.Final)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
