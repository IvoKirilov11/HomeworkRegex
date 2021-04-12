using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"^[^|$%.]*%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quontity>\d+)\|[^|$%.]*?(?<price>\d+.?\d*)[^|$%.]*\$$");
            double income = 0;
            while (true)
            {
                string line = Console.ReadLine();
                if(line == "end of shift")
                {
                    break;
                }
                Match match = regex.Match(line);

                if(!match.Success)
                {
                    continue;
                }

                string customer = match.Groups["customer"].Value;
                string product = match.Groups["product"].Value;
                double price = double.Parse(match.Groups["price"].Value);
                int quontity = int.Parse(match.Groups["quontity"].Value);

                double totalCustomerIncom = price * quontity;
                Console.WriteLine($"{customer}: {product} - {totalCustomerIncom:f2}");
                income += totalCustomerIncom;
            }
            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}
