namespace FilmLibruary.Model
{
    public sealed class FilmEditDescriptor
    {
        public int FilmId { get; set; }
        public int GridRowId { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
    }
}
