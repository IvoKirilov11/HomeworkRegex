using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> racers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToDictionary(x => x, x => 0);

            Regex nameRegex = new Regex(@"[A-Za-z]+");
            Regex digitregex = new Regex(@"\d");

            while (true)
            {
                string line = Console.ReadLine();
                if(line == "end of race")
                {
                    break;
                }
                MatchCollection maches = nameRegex.Matches(line);
                MatchCollection digitMaches = digitregex.Matches(line);
                string name = GetName(maches);
                int sum = GetSum(digitMaches);

                if(!racers.ContainsKey(name))
                {
                    continue;
                }
                racers[name] += sum;
            }
            string[] winners = racers
                .OrderByDescending(r => r.Value)
                .Take(3)
                .Select(r => r.Key)
                .ToArray();

            Console.WriteLine($"1st place: {winners[0]}");
            Console.WriteLine($"2nd place: {winners[1]}");
            Console.WriteLine($"3rd place: {winners[2]}");
        }

        private static int GetSum(MatchCollection digitMaches)
        {
            int sum = 0;
            foreach (Match match in digitMaches)
            {
                sum += int.Parse(match.Value);
            }
            return sum;
        }

        private static string GetName(MatchCollection maches)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Match match in maches)
            {
                sb.Append(match.Value);
            }

            return sb.ToString();
        }
    }
}
