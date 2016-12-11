using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public sealed class Student
    {
        public string Name { get; }
        public int Mark { get; private set; }

        public void PassExam(int mark)
        {
            Mark = mark;
        }
    }
}
