using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationEF
{
    public class BookRepository : AbstractRepository<Book>
    {
        // Methode de pagination qui est tres utile dans le service REST
        // L'utilisateur final qui choisit generalement combien de lignes a afficher et quelle page visualiser
        public IEnumerable<Book> GetByLambda(Func<Book, bool> where, int page=0, int nbRow=20)
        {
            // On recupere les books remplissant la condition where
            IEnumerable<Book> books = GetByLambda(where);

            // 1- Skip : on saute les page * nbRow pour aller a telle page
            // 2- Take : on prend les nbRow pour les afficher
            // 3- OrderBy : On affiche selon les Id
            return books.Skip(page * nbRow).Take(nbRow).OrderBy(Book => Book.Id);
        }

        public IEnumerable<Book> GetByTitle(string title)
        {
            return GetByLambda(book => book.Title.ToUpper().Contains(title.ToUpper()));
        }


        public IEnumerable<Book> GetByPrice(decimal price)
        {
            return GetByLambda(book => book.Price <= price);
        }
    }
}
