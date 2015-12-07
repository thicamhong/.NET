using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationLibrary
{
    // Book herite de Media => mot cle ":" 
    public class Book : Media
    {
        public int NbPage { get; set; }

        // Le mot cle override est obligatoire en .NET mais pas en java
        public override double VATPrice
        {
            get
            {
                return Price * 1.05;
            }
        }
    }
}
