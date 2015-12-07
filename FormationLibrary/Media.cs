using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
Sous Visual Studio, il est plus facile de generer de l'UML que sous Eclipse.


Pour générer le diagramme des classe :
clic droit sur le projet FormationLibrary > Ajouter nouvel élément > Sélectionner diagrammes de classes

Sur ce nouveau fichier .cd, il suffit de glisser les classes pour voir les apparaitre.

Pour faire les associations : 
- relation 1 : clic droit sur la propriété > Afficher en tant qu'association
- relation n : clic droit sur la propriété > Afficher en tant qu'associations de collection
*/

namespace FormationLibrary
{
    // ATTENTION : Bien penser à mettre public devant la classe sinon elle est consideree comme private
    // Media implemente la classe IEntity => mot cle ":" 
    public abstract class Media : IEntity
    {
/*
        // Premiere facon de creer un champs, appele une propriete
        private int id;

        // Cela (actions rapides) a genere ca mais verbeux: 
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
*/
        // Autre solution : 
        // Les proprietes commencent par une majuscule
        // Comme les methodes get/set sont en public, cela commence par public
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public Publisher Publisher { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();

        // Pour le polymorphisme => le mot cle abstract
        // Cette propriete n'est accessible qu'en lecture
        public abstract double VATPrice {get;}
    }
}
