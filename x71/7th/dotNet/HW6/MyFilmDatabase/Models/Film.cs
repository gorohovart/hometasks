using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using MyFilmDatabase.DataStructures;

namespace MyFilmDatabase.Models
{
    internal class Film
    {
        //public Film(int filmId, string title, string country, DateTime year, string imagePath, List<Person> directors, List<Person> actors)
        //{
        //    FilmId = filmId;
        //    Title = title;
        //    Country = country;
        //    Year = year;
        //    Image = imagePath;
        //    Directors = directors;
        //    Actors = actors;
        //}
        private ObservableListSource<Person> _directors = new ObservableListSource<Person>();
        private ObservableListSource<Person> _actors = new ObservableListSource<Person>();

        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public DateTime Year { get; set; }
        public Image Image { get; set; }

        public virtual ObservableListSource<Person> Actors
        {
            get { return _actors; }
            set { _actors = value; }
        }

        public virtual ObservableListSource<Person> Directors
        {
            get { return _directors; }
            set { _directors = value; }
        }

        //public Film()
    }
}