using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ClassLibraryTPCommerciaux
{
    public static class PersisteServiceCommercial
    {
        /// <summary>
        /// Méthode static qui sérialise en binaire un service commercial.
        /// </summary>
        /// <param name="sc">Service commercial à sérialiser</param>
        /// <param name="chemin">Le chemin et le nom.ext du fichier</param>
        public static void sauve(ServiceCommercial sc, String chemin)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream flux = null;
            try
            {
                flux = new FileStream(chemin, FileMode.Create, FileAccess.Write);
                formatter.Serialize(flux, sc);
                flux.Flush();
            }
            catch { }
            finally
            {
                if (flux != null)
                    flux.Close();
            }
        }

        /// <summary>
        /// Méthode static qui désérialise un fichier binaire.
        /// </summary>
        /// <param name="chemin">Le chemin et le nom.ext du fichier</param>
        /// <returns>Le service commercial.</returns>
        public static ServiceCommercial charge(String chemin)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream flux = null;
            try
            {
                flux = new FileStream(chemin, FileMode.Open, FileAccess.Read);

                return (ServiceCommercial)formatter.Deserialize(flux);
            }
            catch
            {
                return default(ServiceCommercial);
            }
            finally
            {
                if(flux != null)
                    flux.Close();
            }
        } 
    }
}
