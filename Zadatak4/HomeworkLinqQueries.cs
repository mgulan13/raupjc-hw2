using System.Linq;
using Zadatak1;

namespace Zadatak4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.GroupBy(x => x)
                .OrderBy(i => i.Key)
                .Select(i => $"Broj {i.Key} ponavlja se {i.Count()} puta")
                .ToArray();
        }

        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(i => i.Students.All(x => x.Gender == Gender.Male))
                .ToArray();
        }

        public static University[] Linq2_2(University[] universityArray)
        {
            double average = universityArray.Select(u => u.Students.Count()).Average();
            return universityArray.Where(u => u.Students.Count() < average).ToArray();
        }

        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(i => i.Students).Distinct().ToArray();
        }

        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(i => i.Students.All(x => x.Gender == Gender.Male) || i.Students.All(x => x.Gender == Gender.Female))
                .SelectMany(s => s.Students)
                .Distinct()
                .ToArray();
        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(i => i.Students)
                .GroupBy(i => i)
                .Where(i => i.Count() > 1)
                .Select(i => i.Key)
                .ToArray();
        }
    }
}
