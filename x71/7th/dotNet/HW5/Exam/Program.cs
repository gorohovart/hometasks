using System;
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
            var controller = new ExamController(view);
            view.ShowDialog();
        }
    }
}
