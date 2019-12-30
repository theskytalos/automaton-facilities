using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPI_Teoria_Linguagem;
using TPI_Teoria_Linguagem.Classes;

namespace TPI_Teoria_Linguagem_UnitTests
{
    [TestClass]
    public class UnitTest_FileHandler
    {
        [TestMethod]
        public void TestFileHandler()
        {
            try
            {
                FileStream FS = new FileStream(@"Testes\testfile.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                FileHandler FH = new FileHandler(@"Testes\testfile.txt", FS);
                Assert.AreEqual(FH.FilePath, @"Testes\testfile.txt");

                FileStream FS2 = new FileStream(@"Testes\testfile.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Assert.AreEqual(FH.FileContent, new StreamReader(FS2).ReadToEnd());
            }
            catch (IOException)
            {
                Assert.Fail();
            } 
        }

        [TestMethod]
        public void TestTurnFileToAutomaton()
        {
            try
            {
                FileStream FS = new FileStream(@"Testes\testfile.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                FileHandler FH = new FileHandler(@"Testes\testfile.txt", FS);

                Automaton Automaton = FH.TurnFileToAutomaton();

                List<State> ListTest = new List<State>();
                ListTest.Add(new State("q0", true, false));
                ListTest.Add(new State("q1", false, false));
                ListTest.Add(new State("q3", false, false));
                ListTest.Add(new State("qf", false, true));

                string[] AlphabetTest = { "a", "e", "i", "o", "u" };
                
                Assert.AreEqual(Automaton.Type, "afd");
                CollectionAssert.AreEqual(Automaton.Alphabet, AlphabetTest);

                Assert.AreEqual(Automaton.States.Count, ListTest.Count);

                for (int i = 0; i < ListTest.Count; i++)
                {
                    Assert.AreEqual(Automaton.States[i].Name, ListTest[i].Name);
                    Assert.AreEqual(Automaton.States[i].Initial, ListTest[i].Initial);
                    Assert.AreEqual(Automaton.States[i].Final, ListTest[i].Final);
                }
            }
            catch (IOException)
            {
                Assert.Fail();
            }
        }
    }
}
