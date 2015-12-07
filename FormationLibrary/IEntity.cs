using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationLibrary
{
    // Si pas "public", cela est considérée comme internal et donc visibilité seulement dans le package FormationLibrary
    public interface IEntity
    {
        // Comme en java, pas besoin de mettre public abstract
        // Si on le met cela est considéré comme une erreur
        int Id { get; set; }
    }
}
