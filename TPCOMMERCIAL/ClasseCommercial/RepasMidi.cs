using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryTPCommerciaux
{
    [Serializable]
    public class RepasMidi : NoteFrais
    {
        /// Le montant du repas.
        private double montantRepas;

        /// Constructeur de classe.
        public RepasMidi(DateTime date, Commercial c, double montantRepas) 
            : base(date, c)
        {
            this.montantRepas = montantRepas;
            this.setMontantARembourser();
        }

        /// retourne le montant à rembourser.
        public override double calculMontantARembourser()
        {
            double remboursement = 0;
            switch (commercial.CategorieProfessionnelle){
                case 'A':
                    if (this.montantRepas < 25)
                    {
                        remboursement = this.montantRepas;
                    }
                    else
                    {
                        remboursement = 25;
                    }
                    break;
                case 'B':
                    if (this.montantRepas < 22)
                    {
                        remboursement = this.montantRepas;
                    }
                    else
                    {
                        remboursement = 22;
                    }
                    break;
                default:
                    if (this.montantRepas < 20)
                    {
                        remboursement = this.montantRepas;
                    }
                    else
                    {
                        remboursement = 20;
                    }
                    break;
            }
            return remboursement;
        }

        /// retourne le numéro, la date, le montant à rembourses et si la note à été remboursé ou non.
        public override string ToString()
        {
            String libRembourse = "Non Remboursé";
            if (this.FraisRembourse)
            {
                libRembourse = "Remboursé";
            }
            return String.Format("Transport -numéro : {0} - Date : {1} - montant à rembourser : {2} euros - {3}- Montant repas : {4} euros-", this.numFrais, this.DateFrais, this.montantARembourser, libRembourse, this.montantRepas);
        }
    }
}