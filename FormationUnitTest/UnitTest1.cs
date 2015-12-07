using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// "using" = import en java
/* 
Pour lier cette classe de test avec les autres (Author, Book..), il faut faire :
clic droit sur les Références du projet FormationUnitTest > Ajouter une référence > Sélectionner le nom du projet
Apres validation, cela ajoutera le using FormationLibrary dans ce cas présent
*/
using FormationLibrary;

namespace FormationUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        // Pour tester, clic droit sur la methode et faire executer 
        [TestMethod]
        public void AuthorTest()
        {
            Author a = new Author();
            a.Id = 1;
            a.Name = "toto";
            Assert.AreEqual(1, a.Id);
        }


        [TestMethod]
        public void BookTest()
        {
            // une methode pour initialiser les valeurs des propriétés d'un objet
            Book b = new Book { Id = 1, Title = ".NET" };
            Assert.AreEqual(1, b.Id);
        }


        [TestMethod]
        public void PublisherTest()
        {
            Book b = new Book { Id = 1, Title = ".NET", Publisher = new Publisher { Id = 2, Name = "Publisher" } };
            Assert.AreEqual(2, b.Publisher.Id);
        }



        [TestMethod]
        public void Author2Test()
        {
            Book b = new Book { Id = 1, Title = ".NET" };
            b.Authors.Add(new Author { Id = 2, Name = "YODA" });
            Assert.AreEqual(1, b.Authors.Count);

        }
        
    }
}
