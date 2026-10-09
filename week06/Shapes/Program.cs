using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Vermelho", 3));
        shapes.Add(new Rectangle("Azul", 4, 5));
        shapes.Add(new Circle("Verde", 6));

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea(); 

            Console.WriteLine($"A forma {color} tem área {area:F2}.");
        }
    }
}