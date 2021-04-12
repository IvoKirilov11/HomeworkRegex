using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@">>(?<name>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<cqontity>\d+)");

            List<string> furniture = new List<string>();
            double totalMoney = 0;

            while (true)
            {
                string line = Console.ReadLine();

                if(line == "Purchase")
                {
                    break;
                }

                Match match = regex.Match(line);
                if(!match.Success)
                {
                    continue;
                }

                string names = match.Groups["name"].Value;
                double price = double.Parse(match.Groups["price"].Value);
                int cqountity = int.Parse(match.Groups["cqontity"].Value);

                furniture.Add(names);

                totalMoney += price * cqountity;

            }

            Console.WriteLine($"Bought furniture: ");

            foreach (string furnitur in furniture)
            {
                Console.WriteLine(furnitur);
            }

            Console.WriteLine($"Total money spend: {totalMoney:f2}");
        }
    }
}
