using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Exam.Helpers;
using Exam.Views;

namespace Exam.Controllers
{
    internal sealed class ExamController
    {
        private readonly IExamView _view;
        private readonly int _numberOfStudents;

        public ExamController(IExamView view)
        {
            _view = view;
            view.ExamStarted += OnExamStarted;
            _numberOfStudents = Randomizer.GetNumberOfStudents();
            view.SetProgressBarMaxValue(_numberOfStudents);
        }

        private void OnStudentCome(object sender, EventArgs e)
        {
            _view.AddStudentName((Student) sender);
        }

        private void OnStudentPassedExam(object sender, EventArgs e)
        {
            _view.ShowStudentMarkAndUpdateProgress((Student)sender);
        }

        private void OnExamStarted(object sender, EventArgs e)
        {
            var deanOffice = new DeanOffice();
            deanOffice.StudentComeEventHandler += OnStudentCome;
            deanOffice.StudentPassExamEventHandler += OnStudentPassedExam;

            for (int i = 1; i <= _numberOfStudents; i++)
            {
                new Thread(new Student(deanOffice).Initialize).Start();
            }

            deanOffice.StartExam();
        }
    }
}
