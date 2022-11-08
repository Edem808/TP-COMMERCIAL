using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryTPCommerciaux;

namespace UnitTestProjectTPCommerciaux
{
    [TestClass]
    public class RepasMidiTest
    {
        [TestMethod]
        public void calculMontantARembrourserTest()
        {
            Commercial c = new Commercial("Jean", "Dupond", 8, 'A');
            NoteFrais f = new RepasMidi(new DateTime(2013, 11, 12), c, 35);
            Assert.AreEqual(f.MontantARembourser, 25);

            NoteFrais f1 = new RepasMidi(new DateTime(2013, 11, 12), c, 15);
            Assert.AreEqual(f1.MontantARembourser, 15);
        }
    }
}