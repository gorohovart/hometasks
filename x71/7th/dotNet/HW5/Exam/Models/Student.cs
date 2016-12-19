using System.Threading;
using Exam.Helpers;

namespace Exam.Models
{
    internal sealed class Student
    {
        private static int CurrentNumberToGive = 1;
        public string Name { get; }
        public int Mark { get; private set; }
        private readonly DeanOffice _deanOffice;
        public readonly int TicketNumber;
        public Student(DeanOffice deanOffice)
        {
            _deanOffice = deanOffice;
            Name = Randomizer.GetStudentName();
            TicketNumber = CurrentNumberToGive++;
        }

        public void Initialize()
        {
            _deanOffice.ExamStartedEvent.WaitOne();
            ExamStarted();

        }
        public void PassExam(int mark) => Mark = mark;

        private void ExamStarted()
        {
            GoToUniver();
            _deanOffice.PassExam(this);
        }

        private void GoToUniver() => Thread.Sleep(Randomizer.GetRandomTime(10));
    }
}
