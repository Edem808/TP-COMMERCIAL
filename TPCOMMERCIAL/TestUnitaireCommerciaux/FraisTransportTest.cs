using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryTPCommerciaux;

namespace UnitTestProjectTPCommerciaux
{
    [TestClass]
    public class FraisTransportTest
    {
        [TestMethod]
        public void calculMontantARembrourserTest()
        {
            Commercial c = new Commercial("Jean", "Dupond", 8, 'A');
            NoteFrais f = new FraisTransport(new DateTime(2013, 11, 12), c, 250);
            Assert.AreEqual(f.MontantARembourser, 50);
        }
    }
}