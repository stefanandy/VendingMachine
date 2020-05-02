using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessTest
{
    [TestClass]
    public class PaymentTerminalTests
    {
        [TestMethod]
        public void Payment_Test_SUCCESS() {
            PaymentTerminal terminal = new PaymentTerminal();
            terminal.AddCash(2);
            terminal.AddCoins(0.5);
            var result = terminal.VerifyTransaction(2.5);
            Assert.AreEqual(true, result);
        
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void Payment_Test_FAIL()
        {
            PaymentTerminal terminal = new PaymentTerminal();
            terminal.AddCash(2);
            terminal.AddCoins(0.5);
            var result = terminal.VerifyTransaction(3.5);
        }
    }
}
