using System;
using System.Threading;
using Exam.Helpers;

namespace Exam.Models
{
    internal sealed class DeanOffice
    {
        private readonly object _lock = new object();
        public event EventHandler StudentComeEventHandler;
        public event EventHandler StudentPassExamEventHandler;

        public DeanOffice()
        {
            ExamStartedEvent = new ManualResetEvent(false);
        }

        public ManualResetEvent ExamStartedEvent { get; }
        public void StartExam() => ExamStartedEvent.Set();

        public void PassExam(Student student)
        {
            lock (_lock)
            {
                StudentComeEventHandler?.Invoke(student, EventArgs.Empty);
                Thread.Sleep(Randomizer.GetRandomTime(3));
                var mark = Randomizer.GetStudentMark();
                student.PassExam(mark);
                StudentPassExamEventHandler?.Invoke(student, EventArgs.Empty);
            }
        }
    }
}
