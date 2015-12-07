using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// Pour faire le lien avec le projet FormationEF meme si la reference a ete ajoute dans references
using FormationEF;
// Pour utiliser List
using System.Collections.Generic;
// pour Books.ToList()
using System.Linq;


/*
Penser a faire une reference (via NuGet) sur :
- FormationEF
- entityFramework

Faire un copier/coller de App.config de FormationEF vers FormationEFTest
--> cela permet de lancer les tests
--> car la connexion a la BDD est configuree dessus
*/

namespace FormationEFTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EFTest()
        {
            // FormationEntities2 est le nom que l'on a donne dans FormationEF quand on a fait ajouter un ADO.NET
            // clic droit sur le projet > ajouter un nouvel element > ADO.NET 
            // --> nom : Formation
            // Dans l'ecran suivant, choisir DataBase First
            // Dans l'ecran suivant, selectionner la bonne BDD. Si besoin renommer l'entityFramework : FormationEntities2
            // Dans l'ecran suivant, selectionner les tables. Cocher le pluriel 
            FormationEntities2 entities = new FormationEntities2();

            // "entities.Books" equivant à "select * from Book"
            List<Book> books = entities.Books.ToList();
        
        }
    }
}
