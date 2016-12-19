using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Controllers;
using Exam.Views;

namespace Exam
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var view = new ExamView();
            var controller = new ExamController(view);
            view.ShowDialog();
        }
    }
}
