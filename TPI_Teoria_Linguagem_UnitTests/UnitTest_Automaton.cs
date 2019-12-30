using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPI_Teoria_Linguagem.Classes;

namespace TPI_Teoria_Linguagem_UnitTests
{
    [TestClass]
    public class UnitTest_Automaton
    {
        [TestMethod]
        public void TestAutomaton()
        {
            List<State> ListStates = new List<State>();
            State State = new State("q", true, true);
            ListStates.Add(State);

            string[] Alphabet = { "a", "b" };

            State[,,] TransitionTable = new State[1, 2, 1];
            TransitionTable[0, 0, 0] = State;

            Automaton Automaton = new Automaton("afd", Alphabet, ListStates, TransitionTable);

            Assert.AreEqual(Automaton.Type, "afd");
            Assert.AreEqual(Automaton.Alphabet, Alphabet);
            Assert.AreEqual(Automaton.States, ListStates);
            Assert.AreEqual(Automaton.TransitionTable, TransitionTable);
        }

        [TestMethod]
        public void TestGetAlphabetIndex()
        {
            string[] Alphabet = { "abc", "kkk", "eae" };

            int Index = Automaton.GetAlphabetIndex("kkk", Alphabet);

            Assert.AreEqual(Index, 1);
        }

        [TestMethod]
        public void TestGetStateIndex()
        {
            List<State> ListStates = new List<State>();
            
            ListStates.Add(new State("q", true, true));
            ListStates.Add(new State("f", false, false));

            string[] Alphabet = { "a", "b" };

            State[,,] TransitionTable = new State[1, 2, 1];
            TransitionTable[0, 0, 0] = new State("q", true, true);
            TransitionTable[0, 1, 0] = new State("f", false, false);

            Automaton Automaton = new Automaton("afd", Alphabet, ListStates, TransitionTable);

            int Index = Automaton.GetStateIndex("f");

            Assert.AreEqual(Index, 1);
        }

        [TestMethod]
        public void TestAcceptAFD()
        {
            List<State> ListStates = new List<State>();

            ListStates.Add(new State("q", true, true));
            ListStates.Add(new State("f", false, false));

            string[] Alphabet = { "a", "b" };

            State[,,] TransitionTable = new State[2, 2, 1];
            TransitionTable[0, 0, 0] = new State("q", true, true);
            TransitionTable[0, 1, 0] = new State("f", false, false);

            Automaton Automaton = new Automaton("afd", Alphabet, ListStates, TransitionTable);

            bool Accept = Automaton.AcceptAFD("aaa");

            Assert.AreEqual(Accept, true);

            bool Accept2 = Automaton.AcceptAFD("aab");

            Assert.AreEqual(Accept2, false);
        }

        [TestMethod]
        public void TestAcceptAFN()
        {
            List<State> ListStates = new List<State>();

            ListStates.Add(new State("q", true, true));
            ListStates.Add(new State("f", false, false));

            string[] Alphabet = { "a", "b" };

            State[,,] TransitionTable = new State[2, 2, 2];
            TransitionTable[0, 0, 0] = new State("q", true, true);
            TransitionTable[0, 0, 1] = new State("f", false, false);
            TransitionTable[0, 1, 0] = new State("f", false, false);

            Automaton Automaton = new Automaton("afn", Alphabet, ListStates, TransitionTable);

            bool Accept = Automaton.AcceptAFN("a");

            Assert.AreEqual(Accept, true);

            bool Accept2 = Automaton.AcceptAFN("b");

            Assert.AreEqual(Accept2, false);
        }
    }
}
