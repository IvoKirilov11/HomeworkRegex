using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;


namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"(\+359([ -])2(\2)(\d{3})(\2)(\d{4}))\b";
            var phones = Console.ReadLine();

            MatchCollection phoneMatches = Regex.Matches(phones,pattern);

            string[] matchNumb = phoneMatches
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();

            
            Console.WriteLine(string.Join(", ",matchNumb));
        }
    }
}
