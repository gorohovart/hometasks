using System.Drawing;

namespace FilmLibruary.Model
{
    public sealed class FilmViewModel
    {
        public int Id { get; set; }
        public Bitmap Picture { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Actors { get; set; }
    }
}

