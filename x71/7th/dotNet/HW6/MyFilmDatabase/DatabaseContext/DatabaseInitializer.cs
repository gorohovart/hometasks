using System;
using System.Data.Entity;
using MyFilmDatabase.DataStructures;
using MyFilmDatabase.Models;

namespace MyFilmDatabase.DatabaseContext
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Models.DatabaseContext>
    {
        protected override void Seed(Models.DatabaseContext context)
        {
            var persons = new ObservableListSource<Person>
            {
                new Person { Name = "Carson",   LastName = "Alexander"},
                new Person { Name = "Meredith", LastName = "Alonso"},
                new Person { Name = "Arturo",   LastName = "Anand"},
                new Person { Name = "Gytis",    LastName = "Barzdukas"},
                new Person { Name = "Yan",      LastName = "Li"},
                new Person { Name = "Peggy",    LastName = "Justice"},
                new Person { Name = "Laura",    LastName = "Norman"},
                new Person { Name = "Nino",     LastName = "Olivetto"}
            };
            foreach (var person in persons)
            {
                context.Persons.Add(person);
            }
                
            context.SaveChanges();

            var films = new ObservableListSource<Film>
            {
                new Film { Title = "Chemistry", Year = new DateTime(2016), Country = "USA", Actors = persons.GetRange(1, 2), ImagePath = "..\\img.jpg"},// Directors = persons.GetRange(0, 1)},
                new Film { Title = "Microeconomics", Year = new DateTime(2016), Country = "Russia", Actors = persons.GetRange(2, 2), ImagePath = "..\\img.jpg"},//Directors = persons.GetRange(1, 1), ImagePath = "..\\img.jpg"},
                new Film { Title = "Macroeconomics", Year = new DateTime(2016), Country = "Mexica", Actors = persons.GetRange(3, 2), ImagePath = "..\\img.jpg"},//Directors = persons.GetRange(2, 1), ImagePath = "..\\img.jpg"},
                new Film { Title = "Calculus", Year = new DateTime(2016), Country = "Latvia", Actors = persons.GetRange(0, 2), ImagePath = "..\\img.jpg"},//Directors = persons.GetRange(3, 1), ImagePath = "..\\img.jpg"},
                new Film { Title = "Trigonometry", Year = new DateTime(2016), Country = "Estonia", Actors = persons.GetRange(4, 2), ImagePath = "..\\img.jpg"},//Directors = persons.GetRange(4, 1), ImagePath = "..\\img.jpg"},
                new Film { Title = "Composition", Year = new DateTime(2016), Country = "Thailand", Actors = persons.GetRange(5, 2), ImagePath = "..\\img.jpg"},//Directors = persons.GetRange(5, 2), ImagePath = "..\\img.jpg"},
                new Film { Title = "Literature", Year = new DateTime(2016), Country = "Turkey", Actors = persons.GetRange(6, 2), ImagePath = "..\\img.jpg"},//Directors = persons.GetRange(6, 1), ImagePath = "..\\img.jpg"},
            };
            foreach (var film in films)
            {
                context.Films.Add(film);
            }
            context.SaveChanges();
        }
    }
}