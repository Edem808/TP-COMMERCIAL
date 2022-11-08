using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryTPCommerciaux;

namespace ConsoleApplicationTPCommerciaux
{
   public class Program
    {
        static void Main(string[] args)
        {
            ServiceCommercial sc1 = PersisteServiceCommercial.charge("service.sr"); //le ServiceCommercial sc1 est désérialisé

            // 3.	Code de la classe Commercial 
            Console.WriteLine("3.	Code de la classe Commercial ");
            Commercial c, c1;
            c = new Commercial("Jean", "Dupond", 8, 'A');
            Console.WriteLine(c.ToString());
            Console.WriteLine();

            // 4.	Code de la classe NoteFrais
            Console.WriteLine("4.	Code de la classe NoteFrais");
            NoteFrais f, f1, f2, f3, f4, f5;
            f = new NoteFrais(new DateTime(2013, 11, 12), c);
            Console.WriteLine(f.ToString());
            Console.WriteLine();

            // 6.1 La classe FraisTransport
            Console.WriteLine("6.1 La classe FraisTransport");
            f1 = new FraisTransport(new DateTime(2013, 11, 12), c, 250);
            Console.WriteLine(f1.ToString());
            Console.WriteLine();

            // 6.2 La classe RepasMidi
            Console.WriteLine("6.2 La classe RepasMidi");
            f2 = new RepasMidi(new DateTime(2013, 11, 12), c, 35);
            Console.WriteLine(f2.ToString());
            f3 = new RepasMidi(new DateTime(2013, 11, 12), c, 15);
            Console.WriteLine(f3.ToString());
            Console.WriteLine();

            // 6.3 La classe Nuitee
            Console.WriteLine("6.3 La classe Nuitee");
            f4 = new Nuitee(new DateTime(2013, 11, 12), c, 2, 46);
            Console.WriteLine(f4.ToString());
            f5 = new Nuitee(new DateTime(2013, 11, 12), c, 3, 80);
            Console.WriteLine(f5.ToString());
            Console.WriteLine();

            // 7.	Gestion des notes de frais d'un commercial
            Console.WriteLine("7.	Gestion des notes de frais d'un commercial");
            ServiceCommercial sc;
            sc = new ServiceCommercial();
            c1 = new Commercial("Dupond", "Jean", 7, 'B');
            sc.ajouterCommercial(c1);
            sc.ajouterNote(c1, new DateTime(2013, 11, 15), 100); // ajoute un frais de transport 
            sc.ajouterNote(c1, new DateTime(2013, 11, 21), 15.5); // ajoute une note de repas 
            sc.ajouterNote(c1, new DateTime(2013,11 , 25), 105, 2); // ajoute une nuitée 
            Console.WriteLine("Les frais ajouté depuis la classe service commercial : {0}",sc.nbFraisNonRembourses());

            f.setFraisRembourser();
            f1.setFraisRembourser();
            f2.setFraisRembourser();
            Console.WriteLine("Test du cumul des notes de frais remboursées en 2013 : {0} euros.", c.cumulNoteFraisRemboursees(2013));

            PersisteServiceCommercial.sauve(sc, "service.sr"); // le ServiceCommercial sc est sérialisé et enregistré en mémoire

            Console.ReadLine();
        }
    }
}