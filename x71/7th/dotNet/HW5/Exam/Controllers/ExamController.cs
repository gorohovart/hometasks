using System;
using System.Collections.Generic;
using System.Threading;
using Exam.Helpers;
using Exam.Models;
using Exam.Views;

namespace Exam.Controllers
{
    internal sealed class ExamController
    {
        private readonly IExamView _view;
        private readonly int _numberOfStudents;
        private readonly object _lock = new object();
        private readonly List<Student> _studentsList = new List<Student>();
        private int _passedExamAmount;
        private readonly DeanOffice _deanOffice = new DeanOffice();

        public ExamController(IExamView view)
        {
            _view = view;
            view.ExamStarted += OnExamStarted;
            _numberOfStudents = Randomizer.GetNumberOfStudents();
            view.SetProgressBarMaxValue(_numberOfStudents);

            _deanOffice.StudentComeEventHandler += OnStudentCome;
            _deanOffice.StudentPassExamEventHandler += OnStudentPassedExam;

            for (var i = 1; i <= _numberOfStudents; i++)
            {
                _studentsList.Add(new Student(_deanOffice));
            }
        }

        //private void OnFormClosed(object sender, EventArgs e) => Environment.Exit(Environment.ExitCode);

        private void OnStudentCome(object sender, EventArgs e) => _view.AddStudentToList((Student) sender);

        private void OnStudentPassedExam(object sender, EventArgs e)
        {
            _view.ShowStudentMarkAndUpdateProgress((Student)sender);
            lock (_lock)
            {
                _passedExamAmount = _passedExamAmount + 1;
                if (_passedExamAmount == _numberOfStudents)
                {
                    _view.FinishExam();
                }
            }
        }

        private void OnExamStarted(object sender, EventArgs e)
        {
            _passedExamAmount = 0;

            foreach (var student in _studentsList)
            {
                (new Thread(student.Initialize) {IsBackground = true}).Start();
            }
            _deanOffice.StartExam();
        }
    }
}
