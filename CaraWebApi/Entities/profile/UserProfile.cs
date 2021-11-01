using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.profile
{
    class UserProfile
    {
    }

    public class DomainClass
    {
        public int Id { get; set; }

        public string A { get; set; }
        public string B { get; set; }
    }

    public class Parent
    {
        public int Id { get; set; }
        public string A { get; set; }

        public Child Child { get; set; }
    }

    public class Child
    {
        public int Id { get; set; }
        public string B { get; set; }
    }


    //IEnumerable
    //IEnumerable<T>
    //ICollection
    //ICollection<T>
    //IList
    //IList<T>
    //List<T>
    //Arrays

}
