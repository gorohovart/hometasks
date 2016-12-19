using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Helpers
{
    internal static class Randomizer
    {
        private const int MaxStudentMark = 5;
        private const int MaxStudents = 10;
        private static readonly List<string> Names = new List<string> { "Егор", "Владимир", "Петр", "Константин", "Иван", "Семен", "Вика", "Светлана", "Татьяна", "Валентина", "Екатерина" };
        public static TimeSpan GetRandomTime(int maxSeconds)
        {
            return TimeSpan.FromSeconds(new Random().Next(maxSeconds));
        }
        public static int GetStudentMark()
        {
            return new Random().Next(MaxStudentMark - 2) + 2;
        }
        public static int GetNumberOfStudents()
        {
            return new Random().Next(MaxStudents - 1) + 1;
        }
        public static string GetStudentName()
        {
            return Names[new Random().Next(Names.Count - 1)];
        }
    }
}
