using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationLibrary
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
