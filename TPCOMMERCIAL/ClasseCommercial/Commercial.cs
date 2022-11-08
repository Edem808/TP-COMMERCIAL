using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryTPCommerciaux
{
    [Serializable]
    public class Commercial
    {
        /// Le nom du commercial.
        private String nom;

        /// Le prénom du commercial.
        private String prenom;

        /// La catégorie professionnelle du commercial.
        private char categorieProfessionnelle;

        /// Accesseur en lecture de la catégorie professionnelle du commercial.
        public char CategorieProfessionnelle
        {
            get { return categorieProfessionnelle; }
        }

        /// La puissance en ch. du commercial.
        private int puissanceVoiture;

        /// Accesseur en lecture de puissanceVoiture.
        public int PuissanceVoiture
        {
            get { return puissanceVoiture; }
        }

        /// La liste des notes de frais du commercial.
        private List<NoteFrais> mesNotesFrais;

        /// Accesseur en lecture de la liste des notes de frais.
        /// Retourne la liste des notes de frais.
        public List<NoteFrais> getMesNotesFrais()
        {
            return mesNotesFrais;
        }

        /// Le service commercial du commercial.
        private ServiceCommercial leService;

        /// Accesseur en lecture de leService.
        public ServiceCommercial LeService
        {
            get { return leService; }
        }

        /// Constructeur de classe.
        public Commercial(String unNom, String unPrenom, int unePuissanceVoiture, char uneCategorieProfessionnelle)
        {
            this.nom = unNom; 
            this.prenom = unPrenom; 
            this.categorieProfessionnelle = uneCategorieProfessionnelle; 
            this.puissanceVoiture = unePuissanceVoiture; 
            this.mesNotesFrais = new List<NoteFrais>(); 
        }

        /// Ajouter une note de frais pour le commercial.
        public void ajouterNoteFrais(NoteFrais f)
        {
            this.mesNotesFrais.Add(f); 
        }

        /// Ajouter le service commercial du commercial
        public void ajouterServiceCommercial(ServiceCommercial sc)
        {
            this.leService = sc;
        }

        /// Cumul des notes de frais remboursées pour une année.
        public double cumulNoteFraisRemboursees(int annee)
        {
            double fraisRemboursees = 0;
            foreach (NoteFrais f in mesNotesFrais)
            {
                if (f.FraisRembourse && f.DateFrais.Year == annee)
                {
                    fraisRemboursees += f.MontantARembourser;
                }
            }
            return fraisRemboursees; 
        }

        /// Rédéfinition de la méthode ToString().
        public override String ToString() 
        {
            return String.Format("Nom : {0} ; Prénom : {1} ; Puissance voiture : {2} ; Catégorie : {3} ", this.nom, this.prenom, this.puissanceVoiture, this.categorieProfessionnelle); 
        }
    }
}