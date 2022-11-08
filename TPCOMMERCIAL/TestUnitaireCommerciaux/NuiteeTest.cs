using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryTPCommerciaux;

namespace UnitTestProjectTPCommerciaux
{
    [TestClass]
    public class NuiteeTest
    {
        [TestMethod]
        public void calculMontantARembrourserTest()
        {
            Commercial c = new Commercial("Jean", "Dupond", 8, 'A');
            NoteFrais f = new Nuitee(new DateTime(2013, 11, 12), c, 2, 46);
            Assert.AreEqual(f.MontantARembourser, 46);

            NoteFrais f1 = new Nuitee(new DateTime(2013, 11, 12), c, 3, 80);
            Assert.AreEqual(f1.MontantARembourser, 74.75);
        }
    }
}