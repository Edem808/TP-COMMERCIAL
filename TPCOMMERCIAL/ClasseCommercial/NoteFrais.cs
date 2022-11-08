using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryTPCommerciaux
{
    [Serializable]
    public class NoteFrais
    {
        /// La date de la note de frais.
        private DateTime dateFrais;

        /// Accesseur en lecture de dateFrais.
        public DateTime DateFrais
        {
            get { return dateFrais; }
        }
        
        /// le numéro de la note de frais.
        protected int numFrais;

        /// Le montant à rembourser de la note de frais
        protected double montantARembourser;

        /// Vrai si la note de frais a été remboursé, faux si non.
        private bool fraisRembourse;

        /// Accesseur en lecture du fraisRembourse.
        public bool FraisRembourse
        {
            get { return fraisRembourse; }
        }

        /// Le commercial concerné par la note de frais.
        protected Commercial commercial;

        /// Constructeur de classe.
        public NoteFrais(DateTime dateFrais, Commercial commercial)
        {
            this.commercial = commercial;
            this.dateFrais = dateFrais;
            this.numFrais = this.commercial.getMesNotesFrais().Count + 1;
            this.setMontantARembourser();
            this.fraisRembourse = false;
            this.commercial.ajouterNoteFrais(this);
        }

        /// Accesseur du champ commercial.
        public Commercial Commercial
        {
            get { return commercial; }
            set { commercial = value; }
        }

        /// Accesseur en lecture du champ montantARembourser.
        public double MontantARembourser
        {
            get { return montantARembourser; }
        }

        /// La note de frais a été rembourser.
        /// Passe le champ fraisRembourses à vrai.
        public void setFraisRembourser()
        {
            this.fraisRembourse = true;
        }

        /// Valorise le champ montantARembourser grâce à la méthode calculMontantARembourser().
        public void setMontantARembourser()
        {
            this.montantARembourser = calculMontantARembourser();
        }

        /// Méthode qui calcul le montant à rembourser.
        /// Retourne le montant à rembourser.
        public virtual double calculMontantARembourser() 
        { 
            return 0;
        }

        /// Rédéfinition de la méthode ToString().
        /// retourne le numéro, la date, le montant à rembourses et si la note à été remboursé ou non.
        public override String ToString()
        {
            String libRembourse = "Non Remboursé";
            if (this.fraisRembourse)
            {
                libRembourse = "Remboursé";
            }
            return String.Format("numéro : {0} - Date : {1} - montant à rembourser : {2} euros - {3}", this.numFrais, this.dateFrais, this.montantARembourser, libRembourse);
        }
    }
}