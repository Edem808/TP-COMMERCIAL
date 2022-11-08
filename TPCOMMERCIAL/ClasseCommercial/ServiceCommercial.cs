using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryTPCommerciaux
{
    [Serializable]
    public class ServiceCommercial
    {
        /// La liste des commerciaux dans le service commercial.
        private List<Commercial> lesCommerciaux;

        /// Constructeur de classe.
        public ServiceCommercial()
        {
            lesCommerciaux = new List<Commercial>();
        }

        /// Ajouter un commercial dans le service commercial.
        public void ajouterCommercial(Commercial c)
        {
            lesCommerciaux.Add(c);
            c.ajouterServiceCommercial(this);
        }

        /// Ajouter note de frais de transport.
        public void ajouterNote(Commercial c, DateTime date, int nbKm)
        {
            NoteFrais uneNoteTrans = new FraisTransport(date, c, nbKm);
        }

        /// Ajouter note de frais de repas.
        public void ajouterNote(Commercial c, DateTime date, double prix)
        {
            NoteFrais uneNoteRepas = new RepasMidi(date, c, prix);
        }

        /// Ajouter note de frais d'une nuitée.
        public void ajouterNote(Commercial c, DateTime date, int montant, int region)
        {
            NoteFrais uneNoteNuitee = new Nuitee(date, c, region, montant);
        }

        /// Méthode qui renvoi le nombre de frais non remboursés.
        /// retourne le nombre de frais non remboursés
        public int nbFraisNonRembourses()
        {
            int compteur = 0;
            foreach (Commercial c in lesCommerciaux)
            {
                foreach (NoteFrais f in c.getMesNotesFrais())
                {
                    if (f.FraisRembourse == false)
                    {
                        compteur++;
                    }
                }
            }
            return compteur;
        }
    }
}