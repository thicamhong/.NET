using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FormationEF;
using System.Linq;

namespace FormationEFTest
{
    /// <summary>
    /// Description résumée pour BookRepositoryUnitTest
    /// </summary>
    [TestClass]
    public class BookRepositoryUnitTest
    {
        [TestMethod]
        public void GetAllTest()
        {
            BookRepository br = new BookRepository();
            IEnumerable<Book> books = br.GetAll();

            // Dans la BDD, il y a deux livres
            Assert.AreEqual(2, books.Count());
        }


        [TestMethod]
        public void GetByIdTest()
        {
            // Cet id correspond a "EF"
            int idToTest = 1;
            BookRepository br = new BookRepository();
            Book book = br.GetById(idToTest);

            // On teste le livre dont le titre est "EF"
            Assert.AreEqual("EF", book.Title);
            Assert.AreEqual(idToTest, book.Id);
        }


        [TestMethod]
        public void GetByLambdaTest()
        {
            // On cherche tous les livres contenant "F"...
            Func<Book, bool> f = Book => Book.Title.ToUpper().Contains("F");

            BookRepository br = new BookRepository();
            IEnumerable<Book> books = br.GetByLambda(f);

            // ToList() crée une List a partir de IEnumerable
            Assert.AreEqual(1, books.ToList().Count());
        }


        [TestMethod]
        public void InsertTest()
        {
            // On cherche tous les livres contenant "F"...
            Book b = new Book { Title="L'ile de lumiere", Price=5.99m };

            BookRepository br = new BookRepository();
            br.Insert(b);
            br.Save();

            // On recupere les donnees dans la BDD
            // Il devrait y avoir trois data car dans le premier test il y en avait deja 2
            IEnumerable<Book> books = br.GetAll();

           // ToList() crée une List a partir de IEnumerable
           Assert.AreEqual(3, books.ToList().Count());
        }


        [TestMethod]
        public void GetByTitleTest()
        {
            BookRepository br = new BookRepository();
            IEnumerable<Book> books = br.GetByTitle("EF");
            
            // On verifie que seul un livre contient le titre "EF"
            Assert.AreEqual(1, books.ToList().Count());
            // On verifie que son id vaut bien 1
            Assert.AreEqual(1, books.ToList().FirstOrDefault().Id);
        }


        [TestMethod]
        public void GetByPriceTest()
        {
            BookRepository br = new BookRepository();
            IEnumerable<Book> books = br.GetByPrice(16);

            // On verifie que seuls deux livre ont un prix <= 16
            Assert.AreEqual(2, books.ToList().Count());
        }


        [TestMethod]
        public void RemoveTest()
        {
            BookRepository br = new BookRepository();

            // On recupere le book qu'on a insere dans le test InsertTest()
            IEnumerable<Book> books = br.GetByTitle("lumiere");
            Assert.AreEqual(1, books.ToList().Count());

            // On recupere ce book et on verifie que son titre est bien ""L'ile de lumiere"
            Book b = books.FirstOrDefault();
            string titreToTest = "L'ile de lumiere";
            Assert.AreEqual(titreToTest, b.Title);

            // On supprime ce book
            br.Remove(b);
            br.Save();

            // On verifie que la BDD ne contient plus que deux data
            books = br.GetAll();
            Assert.AreEqual(2, books.ToList().Count());

            // 2e test : On verifie que le livre n'y est plus
            books = br.GetByTitle("lumiere");
            b = books.FirstOrDefault();
            Assert.AreEqual(null, b);

        }
    }
}
