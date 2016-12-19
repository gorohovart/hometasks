using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFilmDatabase.Models;
using MyFilmDatabase.Views;

namespace MyFilmDatabase
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //Database.SetInitializer(new DatabaseInitializer());
            //Database.SetInitializer<Models.DatabaseContext>(null);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView());
        }
    }
}
