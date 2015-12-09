using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationEF
{
    // Ici c'est le meme nameSpace et meme nom que la classe, il va merger a la compilation
    public partial class Book
    {
        public decimal VATPrice
        {
            // la multiplication sur un nullable n'existe pas
            // ?? : si c'est null, cela renvoie 0. Ca n'existe pas en java
            get { return (Price ?? 0m) * 1.05m; }
        }
    }
}
