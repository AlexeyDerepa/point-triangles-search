﻿namespace Triangle.Models
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public override string ToString()
        {
            return $"x: {X}; y: {Y}"; 
        }
    }
}
