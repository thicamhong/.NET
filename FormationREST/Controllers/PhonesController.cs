using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FormationREST.Controllers
{
    public class PhonesController : ApiController
    {
        [HttpGet]
        [Route("api/phones/all")]
        public IEnumerable<Phone> GetPhoneList()
        {
            List<Phone> l = new List<Phone>();
            l.Add(new Phone
            {
                age = 3,
                id = "nexus-5",
                imageUrl = "http://techbeasts.com/wp-content/uploads/2015/03/Google-Nexus-5-Photo1.jpg",
                name = "Google Nexus 5",
                snippet = "Petit texte de presentation de ce telephone"
            });
            l.Add(new Phone
            {
                age = 2,
                id = "iphone-6",
                imageUrl = "http://img.clubic.com/07606839-photo-iphone6-2.jpg",
                name = "Apple Iphone 6",
                snippet = "Petit texte de presentation de cette pomme"
            });
            l.Add(new Phone
            {
                age = 1,
                id = "galaxy-s6",
                imageUrl = "http://www.samsung.com/ca_fr/consumer-images/product/mobile-phones/2015/SM-G920WZWABMC/features/SM-G920WZWABMC-403979-0.jpg",
                name = "Samsung Galaxy S6",
                snippet = "Telephone concurent de la pomme !"
            });
            l.Add(new Phone
            {
                age = 2,
                id = "xperia-z3-compact",
                imageUrl = "http://api.sonymobile.com/files/xperia-z3-compact-mandarin-1240x840-6732d63f6eb7dfe080a35e4f4f04c920.jpg",
                name = "Sony Xperia Z3 Compact",
                snippet = "Ce telephone est le meilleur compromis qui existe au monde !"
            });

            return l;
        }
    }
}
