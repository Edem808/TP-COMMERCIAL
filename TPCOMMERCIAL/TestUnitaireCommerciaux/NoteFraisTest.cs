using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryTPCommerciaux;

namespace UnitTestProjectTPCommerciaux
{
    [TestClass]
    public class NoteFraisTest
    {
        [TestMethod]
        public void ajouterNoteFraisTest()
        {
            Commercial c = new Commercial("Jean", "Dupond", 25, 'A');
            NoteFrais f, f1;
            f = new NoteFrais(new DateTime(2013, 11, 12), c);
            f1 = new NoteFrais(new DateTime(2013, 11, 15), c);
            Assert.AreEqual(2, c.getMesNotesFrais().Count);
        }
    }
}