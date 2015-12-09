using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationEF
{
    public class BookRepository2 : IRepository <Book>
    {
        public FormationEFEntities Entities { get; set; }

        public IEnumerable<Book> GetAll()
        {
            /*
            Si il y a 10000000000 lignes et pas de lazy loading, je ne veux pas qu'il fasse 
            La requete part quand j'essaie de lire le resultat (cad qd il y a ToList par ex.
            1)Entities.Books.Where(b=>b.PRice <=price).ToList()
            2)Entities.Books.ToList().Whereb=>b.PRice <=price)
            Ces deux lignes executent la meme chose mais c'est l'ordre d'execution 
            Dans 1), on fait le filtre en premier et apres seulement on a la List via ToList()
            Or la List est en memoire alors que le IEnumerable est...??? . 
            Dans le 2) le Where marchera mais sur la liste en memoire. Donc cela prendra bcp de tps
            Il faut faire le ToList au tout dernier moment, cad dans la VUE ou le Service REST dans le MVC
            En enchainant les points, on fait du fluant API. Et en .NET on est fan de ca

            Entities.Books.Take(10) : prend les 10 premieres lignes
            Entities.Books.Skip(100) : saute les 100 premieres lignes
            ==> ces deux methodes permettent de faire de la pagination
            */
            return Entities.Books;
        }

        public Book GetById(int id)
        {
            // Ou faire un where + First
            // .First : si list est vide, cela va lever ne exception
            // .FirstOrDefault : Si list est vide, cela renvoie NULL => on prefere ca
            // .FirstSingle : pareil que First mais s'il y a plus de un ca renvoie une exception
            // .FirstSingleOrDefault comme FirstOrDefault 
            return Entities.Books.Find(id);
        }

        public IEnumerable<Book> GetByLambda(Func<Book, bool> where)
        {
            return Entities.Books.Where(where);
        }

        public Book Insert(Book entity)
        {
            Entities.Books.Add(entity);

            // Ce return permet de recuperer l'Id
            // Car une fois que le save est fait, on peut recuperer l'id directement
            return entity;
        }

        public void Remove(Book entity)
        {
            Entities.Books.Remove(entity);
        }

        public void Save()
        {
            // SaveChanges gere automatiquement les transactions
            // On ne met pas save dans les autres car on separe 
            Entities.SaveChanges();
        }

        // Les input param peuvent avoir des valeurs par defaut
        // => si on ne les renseigne pas, ils prennent ces valeurs la.
        // Pb qd il y en a plusieurs. 
        // ==> Solution est de les passer par nom et non par ordre et dans ce cas la, dans l'ordre que l'on veut
        // ex : repo.GetPrice(price : 10)
        public IEnumerable<Book> GetByPrice (decimal price = Decimal.MaxValue)
        {
            return GetByLambda(book => book.Price <= price);
        }


        public IEnumerable<Book> GetByTitle(string title)
        {
            return GetByLambda(book => book.Title.ToUpper().Contains(title.ToUpper()));
        }
    }
}
