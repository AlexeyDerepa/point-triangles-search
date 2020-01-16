using System;
using System.Collections.Generic;
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
            var dataSet = Enumerable.Range(0, 10).Select(x => new Point { X = random.Next(0, 150), Y = random.Next(-150, 150) }).ToList();
            dataSet.AddRange(new List<Point> { new Point { X = -3, Y = -2 }, new Point { X = 0, Y = -1 }, new Point { X = -2, Y = 5 } });
            dataSet.AddRange(new List<Point> { new Point { X = -5, Y = -2 }, new Point { X = 2, Y = -1 }, new Point { X = -0, Y = 5 } });
            dataSet.AddRange(new List<Point> { new Point { X = 0, Y = 0 }, new Point { X = 2, Y = 0 }, new Point { X = 2, Y = 8 } });
            dataSet.AddRange(Enumerable.Range(0, 5).Select(x => new Point { X = random.Next(0, 150), Y = random.Next(-150, 150) }).ToList());

            var iteratoR = dataSet.GetRenges(10)
                .AsParallel()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .WithDegreeOfParallelism(10)
                .SelectMany(x => x.GetData(dataSet))
                .Select(x => new CommonTriangle(x))
                .Where(x => x.IsRightTriangle()); 

            foreach (var item in iteratoR)
            {
                Console.WriteLine(++count + "\t" + item);
            }

            Console.Read();
        }
    }
}
