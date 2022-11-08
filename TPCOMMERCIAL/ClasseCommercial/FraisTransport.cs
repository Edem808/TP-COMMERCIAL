using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryTPCommerciaux
{
    [Serializable]
    public class FraisTransport : NoteFrais
    {
        /// Le nombre de kilomètre.
        private int nbKM;

        /// Constructeur de classe.
        public FraisTransport(DateTime date, Commercial c, int nbKM)
            : base(date, c)
        {
            this.nbKM = nbKM;
            this.setMontantARembourser();
        }

        /// Retourne le montant à rembourser.
        public override double calculMontantARembourser()
        {
            if (this.commercial.PuissanceVoiture < 5)
            {
                return 0.1 * this.nbKM;
            }
            else if(this.commercial.PuissanceVoiture < 10)
            {
               return 0.2 * this.nbKM;
            }
            else
            {
                return 0.3 * this.nbKM;
            }
        }

        /// retourne le numéro, la date, le montant à rembourses, si la note à été remboursé ou non et son nombre de km.
        public override string ToString()
        {
            String libRembourse = "Non Remboursé";
            if (this.FraisRembourse)
            {
                libRembourse = "Remboursé";
            }
            return String.Format("Transport -numéro : {0} - Date : {1} - montant à rembourser : {2} euros - {3}- {4} km-", this.numFrais, this.DateFrais, this.montantARembourser, libRembourse, this.nbKM);
        }
    }
}