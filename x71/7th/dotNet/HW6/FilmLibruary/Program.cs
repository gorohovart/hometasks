using System;
using System.Windows.Forms;
using FilmLibruary.Controller;
using FilmLibruary.Repositories;
using FilmLibruary.Views;

namespace FilmLibruary
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var libruaryView = new LibraryView();
            var filmRepository = new FilmRepository();
            var controller = new FilmController(libruaryView, filmRepository);

            Application.Run(libruaryView);
        }
    }
}
