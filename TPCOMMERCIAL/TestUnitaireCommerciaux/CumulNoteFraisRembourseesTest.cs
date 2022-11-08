using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryTPCommerciaux;

namespace UnitTestProjectTPCommerciaux
{
    [TestClass]
    public class CumulNoteFraisRembourseesTest
    {
        [TestMethod]
        public void CumulNoteFraisRemboursees()
        {
            Commercial c;
            c = new Commercial("Jean", "Dupond", 8, 'A');
            NoteFrais f, f1, f2;
            f = new NoteFrais(new DateTime(2013, 11, 12), c); // 0
            f1 = new FraisTransport(new DateTime(2013, 11, 12), c, 250); // 50
            f2 = new RepasMidi(new DateTime(2013, 11, 12), c, 35); // 25
            f.setFraisRembourser();
            f1.setFraisRembourser();
            f2.setFraisRembourser();
            Assert.AreEqual(75, c.cumulNoteFraisRemboursees(2013));
        }
    }
}
