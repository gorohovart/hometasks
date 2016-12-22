using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FilmLibruary.Model;
using FilmLibruary.Properties;

namespace FilmLibruary.DbAdapter.DBHelper
{
    internal sealed class FilmDbHelper
    {
        private const int filmRecFieldCount = 6;
        private const int actorToFilmFieldCount = 2;

        public Film ConvertRecordToFilm(DbDataRecord rec)
        {
            if (rec == null || rec.FieldCount < filmRecFieldCount)
            {
                return null;
            }

            var film = new Film
            {
                Id = rec.GetInt32((int)FilmColumns.Id),
                Picture = GetImageFromDbRec(rec.GetString((int)FilmColumns.Picture)),
                Name = rec.GetString((int)FilmColumns.Name),
                Country = rec.GetString((int)FilmColumns.Country),
                Year = rec.GetInt32((int)FilmColumns.Year),
                Producer = new Producer(rec.GetString((int)FilmColumns.Producer)),
                MainActors = new List<Actor>()
            };


            return film;
        }

        public ActorToFilm ConvertRecordToActorToFilm(DbDataRecord rec)
        {
            if (rec == null || rec.FieldCount < actorToFilmFieldCount)
            {
                return null;
            }

            var actorToFilm = new ActorToFilm
            {
                FilmId = rec.GetInt32((int)ActorToFilmColumn.FilmId),
                Actor = new Actor(rec.GetString((int)ActorToFilmColumn.ActorName))
            };

            return actorToFilm;
        }

        public Image GetImageFromDbRec(string imagePath)
        {
            Image image;
            var imgPath = Path.Combine(Application.StartupPath, imagePath);
            try
            {
                image = Image.FromFile(imgPath);
            }
            catch (FileNotFoundException)
            {
                image = Resources.ImageResource;
            }
            return image;
        }
    }
}
