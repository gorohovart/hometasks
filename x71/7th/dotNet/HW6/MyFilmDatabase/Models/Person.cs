using System;
using System.Collections.Generic;

namespace MyFilmDatabase.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        //public int FilmId { get; set; }
        //public virtual Film Film { get; set; }

        //public static implicit operator List<object>(Person v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}