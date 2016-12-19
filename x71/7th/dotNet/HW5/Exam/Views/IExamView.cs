using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Views
{
    internal interface IExamView
    {
        event EventHandler ExamStarted;
        void AddStudentName(Student student);
        void ShowStudentMarkAndUpdateProgress(Student student);
        void FinishExam();
        void SetProgressBarMaxValue(int max);
    }
}
