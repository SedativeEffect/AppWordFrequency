using System;
using System.Collections.Generic;
using System.Linq;

namespace task3
{
    class Solver
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> words = new Dictionary<string, int>();
            for (var i = 0; i < tokens.Length; i++)
            {
                var word = tokens[i];
                var count = tokens.Where(x => x == word).Count();
                words[word] = count;
            }

            var longestWordLength = words.Keys.Max(x => x.Length);
            var maxRateWord = words.Values.Max();
            const decimal maxDots = 10;

            foreach (var word in words.OrderBy(x => x.Value))
            {
                decimal x = maxDots * word.Value / maxRateWord;
                var countDots = Math.Round(x, MidpointRounding.AwayFromZero);
                var symbolDot = new string('.', (int)countDots);
                var symbolUnderline = new string('_', longestWordLength - word.Key.Length);
                Console.WriteLine($"{symbolUnderline}{word.Key} {symbolDot}");
            }

        }
    }
}
