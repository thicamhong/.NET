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
            // Dans l'ecran suivant, selectionner la bonne BDD. Si besoin renommer l'entityFramework : FormationEntities
            // Dans l'ecran suivant, selectionner les tables. Cocher le pluriel 
            FormationEFEntities entities = new FormationEFEntities();

            // "entities.Books" equivant à "select * from Book"
            // Le resultat est de type DBSet qu'il ne faut pas utiliser
            // ToList permet de transformer le IEnumerable en list
            List<Book> books = entities.Books.ToList();

            // Quand on suffixe un type par un "?", ca veut dire qu'il est nullable
            // Decimal n'existe pas en java car c'est un virgule fixe. Leur avantage : par d'erreur d'arrondi . Inconvenient : tres lent
            // Ici, il faut rajouter "m" a 15.49 pour qu'il n'y ait plus d'erreur
           Book b = new Book { Title="EF", Price=15.49m };
           
            //On ajoute a la BDD
            entities.Books.Add(b);

            // Cela sauvegarde en BDD
            // Les transactions sont implicites en .NET
            entities.SaveChanges();

            // On va mettre a jour le prix du book
            b = entities.Books.First();
            b.Price += 1;
            entities.SaveChanges();

            // On recupere le premier element 
            // Comme en JPA, le find marche sur la cle primaire
            b = entities.Books.Find(1);
            Assert.AreEqual(1, b.Id);
            //Console.WriteLine("b.Id=" + b.Id);
            //Console.ReadKey();


            // Comment faire une requete quelconque?
            // EN JPA, il fallait avoir JPQL
            // EN .NET, on a LINQ et les lambdas expressions = deux solutions majeurs
            // Java a mis 8 ans pour copier ca
            // LINQ : Language Integrated Query

            //LINQ :
            // IEnumerable est en desspus de toutes les collections
            // On ne met pas la requete entre ""
            // LE select est a la fin
            // Avantage : 1- on a l'intelliSense. Donc si erreur de frappe => cela soulignera en rouge
            //            2 - c'est un vrai language
            //            3 - on a access a tout le framework comme les methodes qu'on aurait developpees soit meme
            //            4 - on est en lazy loading. La requete ie n'est pas encore partie. Si on rajoute une contrainte (ex : where), il executera la requete au dernier moment
            IEnumerable<Book> ie = from Book in entities.Books
                                   where Book.Price < 10
                                   orderby Book.Id
                                   select Book;
            IEnumerable<Book> ie2 = from Book in entities.Books
                                    where Book.Title.ToUpper().Contains(".NET")
                                    orderby Book.Id
                                    select Book;

            //On fait une intersection entre ie et ie2
            // On aurait pu faire une seule requete
            // Pour lui c'est 50-50. 
            // La requete ne part que si on fait un :
            //  1-foreach sur le resultat,
            //  2- ToList,
            //  3- First
            //  4- Count.
            // Et seulement a ce moment la, il compilera la requete
            // Linq decide pour vous. Vous faites 3 requetes, et il trouve cela pas top. Il n'en fera qu'une seule.
            IEnumerable<Book> ie3 = ie2.Intersect(ie);

            // Comment lire la requete :
            // from = foreach
            // Select : pour connaitre le type du generique de IEnumerable

            // LINQ n'existe pas en .NET. C'est une forme userFriendly. Le compilateur va transformer ca en expressions lambda

            /*
            Lamba expression : beaucoup plus puissant que le LINQ
            * "=>" equivant a "donne" : f(x)=x+1 --> x => x+1
            * Plus puissant : ecriture plus concise, orientee fonction, methode dc objet
            * Les clause where sont rigides en LINQ, ne peuvent pas etre des variables mais en lambda si.            
            */

            // L'equivalent des deux requetes d'en haut mais en lambda expressions
            ie = entities.Books.Where(Book => Book.Price < 10).OrderBy(Book => Book.Id);
            ie2 = entities.Books.Where(Book => Book.Title.ToUpper().Contains(".NET")).OrderBy(Book => Book.Id);

            // La, la variable ne contient pas de donnees mais une fct math cad un traitement
            // Func : fonction arithmetique 
            // <Book, bool> : Book est le type d'entree et bool le type de retour
            Func<Book, bool> f = Book => Book.Title.ToUpper().Contains(".NET");
            // On peut passer en param d'une fonction une fonction
            ie2 = entities.Books.Where(f);
            // 

            // Tout ce qu'on peut faire en LINQ, on peut le faire en lambda. Mais l'inverse n'est pas vrai.
            // Ex : on ne peut pas stocker une fct en param en LINQ
            // On n'ecrit plus qu'en lambda expression car beaucoup plus puissant. On ne fait plus de boucle
            // Lambda expression existe en java mais beaucoup plus complique a mettre en oeuvre

            /* 
            Pour la classe absrtact (TP pour BookRepository): 
            entities.Set<Book>() <=> entities.Books
            */

            BookRepository2 repo = new BookRepository2();
            repo.GetByPrice(price: 10);

            string s = "toto";
            s.ToUpperFirstLetter();
            
        }
    }
}
