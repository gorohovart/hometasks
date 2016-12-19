using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Exam.Helpers;

namespace Exam
{
    internal sealed class Student
    {
        public string Name { get; }
        public int Mark { get; private set; }
        private readonly DeanOffice _deanOffice;
        public Student(DeanOffice deanOffice)
        {
            _deanOffice = deanOffice;
            Name = Randomizer.GetStudentName();
        }

        public void Initialize()
        {
            _deanOffice.ExamStartedEvent.WaitOne();
            ExamStarted();

        }
        public void PassExam(int mark)
        {
            Mark = mark;
        }

        private void ExamStarted()
        {
            GoToUniver();
            _deanOffice.PassExam(this);
        }

        private void GoToUniver()
        {
            Thread.Sleep(Randomizer.GetRandomTime(10));
        }
    }
}
