using System;
using System.Collections.Generic;
using System.Linq;

namespace Triangle.Models
{
    public class CommonTriangle
    {
        Point A;
        Point B;
        Point C;

        public CommonTriangle(ICollection<Point> points)
        {
            A = points.ElementAt(0);
            B = points.ElementAt(1);
            C = points.ElementAt(2);
        }

        public static double GetLength(Point first, Point second)
        {
            double result = Math.Sqrt(Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2));

            return result;
        }

        const double Epsilon = .00001;
        public static bool IsEqual(double a, double b) =>
            Math.Abs(a - b) <= Math.Abs(a * Epsilon);
        public bool IsRightTriangle()
        {
            double ab = GetLength(A, B);
            double ac = GetLength(A, C);
            double bc = GetLength(B, C);
            var array = new[] { ab, ac, bc };
            Array.Sort(array);  

            double abacSq = Math.Pow(array[0], 2) + Math.Pow(array[1], 2);
            double bcSq = Math.Pow(array[2], 2);

            return IsEqual(abacSq, bcSq);
        }
        public override string ToString()
        {
            return $"A: {{{A}}}; B: {{{B}}}; C: {{{C}}};";
        }
    }
}
