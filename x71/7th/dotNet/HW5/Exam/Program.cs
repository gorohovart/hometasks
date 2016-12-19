using System;
using System.Windows.Forms;
using Exam.Controllers;
using Exam.Views;

namespace Exam
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            var view = new ExamView();
            var contriller = new ExamController(view);
            Application.Run(view);
        }
    }
}
