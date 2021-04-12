using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";
            string names = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection validName = regex.Matches(names);
            foreach (Match item in validName)
            {
                Console.Write($"{item.Value+ " "}");
            }
            Console.WriteLine();

        }
    }
}
