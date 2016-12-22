using System;
using FilmLibruary.Model;

namespace FilmLibruary.CustomEventArgs
{
    internal class FilmEditDescriptorEventArgs : EventArgs
    {
        public FilmEditDescriptor EditedFilm { get; private set; }

        public FilmEditDescriptorEventArgs(FilmEditDescriptor editedFilm)
        {
            EditedFilm = editedFilm;
        }
    }
}