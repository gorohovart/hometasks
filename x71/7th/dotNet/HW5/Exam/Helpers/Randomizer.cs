using System;

namespace Exam.Helpers
{
    internal static class Randomizer
    {
        private const int MaxStudentMark = 5;
        private const int MinStudentMark = 2;
        private const int MaxStudents = 10;
        private const int MinTime = 2;
        private const int MinStudents = 5;
        private static readonly Random Random = new Random();

        private static readonly string[][] Names = {
            new[]{ "Егор", "Владимир", "Петр", "Константин", "Иван", "Семен"},
            new[]{ "Вика", "Светлана", "Татьяна", "Валентина", "Екатерина" }};
        private static readonly string[] Surnames = { "Горохов", "Пупкин", "Григорьев", "Сергеев", "Батьков"};

        public static TimeSpan GetRandomTime(int maxSeconds) => TimeSpan.FromSeconds(new Random().Next(MinTime,maxSeconds));

        public static int GetStudentMark() => Random.Next(MinStudentMark, MaxStudentMark);

        public static int GetNumberOfStudents() => Random.Next(MinStudents, MaxStudents);

        public static string GetStudentName()
        {
            var gender = Random.Next(1);
            var ending = (gender == 1) ? "a" : "";
            var name = Names[gender][Random.Next(Names[gender].Length - 1)];
            var surname = Surnames[Random.Next(Surnames.Length - 1)] + ending;
            return $"{name} {surname}";
        }
    }
}