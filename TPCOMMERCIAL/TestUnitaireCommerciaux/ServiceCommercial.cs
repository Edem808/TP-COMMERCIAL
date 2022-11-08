using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryTPCommerciaux;

namespace UnitTestProjectTPCommerciaux
{
    [TestClass]
    public class ServiceCommercialTest
    {
        [TestMethod]
        public void ajouterNoteTest()
        {
            ServiceCommercial sc = new ServiceCommercial();
            Commercial c1 = new Commercial("Dupond", "Jean", 7, 'B');
            sc.ajouterCommercial(c1);
            sc.ajouterNote(c1, new DateTime(2013, 11, 15), 100); // ajoute un frais de transport 
            sc.ajouterNote(c1, new DateTime(2013, 11, 21), 15.5); // ajoute une note de repas 
            sc.ajouterNote(c1, new DateTime(2013, 11, 25), 105, 2); // ajoute une nuitée 
            Assert.AreEqual(3, sc.nbFraisNonRembourses());
        }
    }
}