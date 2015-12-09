using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationEF
{
    public static class StringExtension
    {
        // Le 1er param doit etre this
        // On doit rappeler la classe : string ici
        // Cette methode dit qu'a cause de this, je rajoute cette methode ToUpperFirstLetter a la classe String
        // A la fin cette mthode n'est pas static
        public static string ToUpperFirstLetter(this string s)
        {
            string result = s.First().ToString().ToUpper();
            result += s.Substring(1).ToLower();

            // Premier lettre de s en majuscule et le reste en minuscule
            return result;

        }
    }
}
