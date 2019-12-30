using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPI_Teoria_Linguagem.Classes;

namespace TPI_Teoria_Linguagem_UnitTests
{
    [TestClass]
    public class UnitTest_State
    {
        [TestMethod]
        public void TestState()
        {
            State State1 = new State("q", true, false);

            Assert.AreEqual(State1.Name, "q");
            Assert.AreEqual(State1.Initial, true);
            Assert.AreEqual(State1.Final, false);

            State State2 = new State("j", false, false);

            Assert.AreEqual(State2.Name, "j");
            Assert.AreEqual(State2.Initial, false);
            Assert.AreEqual(State2.Final, false);
        }
    }
}
