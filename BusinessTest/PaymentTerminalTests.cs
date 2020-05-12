using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistanceTests
{
    [TestClass]
    public class PaymentTerminalTests
    {

        PaymentTerminal terminal;


        [TestInitialize]
        public void TestInitialize() {
            terminal = new PaymentTerminal();
            terminal.AddCash(2);
            terminal.AddCoins(0.5);
        }

        [TestCleanup]
        public void TestCleanUp() {
            terminal = null;
        }

        [TestMethod]
        public void Payment_Test_SUCCESS() {
            
            var result = terminal.Pay(2.5);
            Assert.AreEqual(true, result);
        
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void Payment_Test_FAIL()
        {            
            var result = terminal.Pay(3.5);
        }
    }
}
