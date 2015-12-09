using FormationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace FormationREST.Controllers
{
    public class DefaultController : ApiController
    {
        
        [HttpGet]
        public string Get()
        {
            return "Hello ";
        }


        [HttpGet]
        public string Get(int id)
        {
            return "Hello " + id;
        }

        /* C'est notre URL redefini. On peut mettre autant de param que l'on veut : [Route("api/book/{id}/{param2}")]*/
        /* Les noms de param ds route doivent etre pareil que dans la methodes*/
        /*
        Design Pattern Transport Object : On redefinit un objet local (ex : BookBean en java) avec que seulement les proprietes que l'on veut transporter sur le reseau.
        
            Les objets ne sont pas serializables. Donc il faut faire une copie via le design pattern Transport object

        JSON et XML sont deja inclus. Alors qu'en java, il fallait faire Jackson, Jersey, ...
        */
        [HttpGet]
        [Route("api/book/{id}")] 
        public Book GetBook(int id)
        {
            return new Book { Id = id};
        }

        [HttpGet]
        [Route("api/books")] /* C'est notre URL*/
        public IEnumerable<Book> GetBooks()
        {
            List<Book> l = new List<Book>();
            l.Add(new Book { });
            l.Add(new Book { });
            l.Add(new Book { });
            return l;
        }

    }
}