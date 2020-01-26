using System;
using System.Linq;

using Triangle.Extensions;
using Triangle.Models;

namespace Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int count = 0;

            var iteratoR = Enumerable.Range(0, 100)
                .Select(x => new Point { X = random.Next(-150, 150), Y = random.Next(-150, 150) })
                .GetCombinations()
                .Select(x => new CommonTriangle(x))
                .Where(x => x.IsRightTriangle());

            foreach (var item in iteratoR)
            {
                Console.WriteLine(++count + "\t" + item);
            }

            Console.WriteLine("done");
            Console.Read();
        }
    }
}
