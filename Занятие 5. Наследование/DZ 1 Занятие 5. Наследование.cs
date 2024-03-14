using System;
using System.Collections.Generic;
using System.Collections;
using static System.Console;


/*Разработать абстрактный класс «Геометрическая Фигура» с методами «Площадь Фигуры» и «Периметр Фигуры».
Разработать классы-наследники: Треугольник, Квадрат, Ромб, Прямоугольник, Параллелограмм, Трапеция, Круг, 
Эллипс.Реализовать конструкторы, которые однозначно определяют объекты данных классов.
Реализовать класс «Составная Фигура», который может состоять из любого количества «Геометрических 
Фигур». Для данного класса определить метод нахождения площади фигуры. Создать диаграмму взаимоотношений классов.
*/

class Program
{
    static void Main()
    {
        Triangle tria = new Triangle("Triangle", 5, 6, 7);
        Square square = new Square("Square", 3);
        Rhomb rhomb = new Rhomb("Rhomb", 5, 10, 8);
        Rectangle rectangle = new Rectangle("Rectangle", 5, 8);
        Parallelogram paral = new Parallelogram("Parallelogram", 4, 8, 7);
        Trapezoid trap = new Trapezoid("Trapezoid", 8, 13, 6, 7, 8);
        Circle circle = new Circle("Circle", 5);
        Ellipse ellipse = new Ellipse("Ellipse", 3, 5);

        List<ComposFigure> masFigure = new List<ComposFigure>();
        masFigure.Add(tria);
        masFigure.Add(square);
        masFigure.Add(rhomb);
        masFigure.Add(rectangle);
        masFigure.Add(paral);
        masFigure.Add(trap);
        masFigure.Add(circle);
        masFigure.Add(ellipse);

        foreach(ComposFigure figure in masFigure)
        {
            figure.Area();
            figure.Perimeter();
            figure.Print();
        }


    }

    abstract class GeomShape
    {
        public string name;
        public int A;
        public int B;
        public int C;
        public int D;
        public double S;
        public double P;

        public GeomShape(string Name, int a = 0, int b = 0, int c = 0, int d = 0)
        {
            name = Name;
            A = a;
            B = b;
            C = c;
            D = d;
        }

        abstract public double Area();
        abstract public double Perimeter();

       
    }

    class ComposFigure : GeomShape
    {
        public ComposFigure(string Name, int a = 0, int b = 0, int c = 0, int d = 0) : base(Name, a, b, c, d) { }

        public override double Area()
        {
            throw new NotImplementedException();
        }
        public override double Perimeter()
        {
            throw new NotImplementedException();
        }
        virtual public void Print()
        {
            WriteLine($"Name: {name}");
            if (A > 0)
                WriteLine($"A = {A}");
            if (B > 0)
                WriteLine($"B = {B}");
            if (C > 0)
                WriteLine($"C = {C}");
            WriteLine($"S = {S}");
            WriteLine($"P = {P}");
        }

    }

    class Triangle : ComposFigure
    {
        public Triangle(string Name, int a, int b, int c) : base(Name, a, b, c){}

        public override double Area()
        {
            S = (A * B) / 2;
            return S;
        }

        public override double Perimeter()
        {
            P = A + B + C;
            return P;
        }
        
    }

    class Square : ComposFigure
    {

        public Square(string Name, int a) : base(Name, a) { }

        public override double Area()
        {
            S = A * A;
            return S;
        }

        public override double Perimeter()
        {
            P = A * 4;
            return P;
        }
    }

    class Rhomb : ComposFigure
    {
        public int d1;
        public int d2;

        public Rhomb(string Name, int a, int D1, int D2) : base(Name, a)
        {
            d1 = D1;
            d2 = D2;
        }

        public override double Area()
        {
            S = (d1 * d2) / 2;
            return S;
        }

        public override double Perimeter()
        {
            P = A * 4;
            return P;
        }

        public void Print()
        {
            WriteLine($"d1 = {d1}");
            WriteLine($"d2 = {d2}");
            base.Print();
            
        }

    }

    class Rectangle : ComposFigure
    {
        public Rectangle(string Name, int a, int b) : base(Name, a, b) { }

        public override double Area()
        {
            S = A * B;
            return S;
        }

        public override double Perimeter()
        {
            P = A * 2 + B * 2;
            return P;
        }
    }

    class Parallelogram : ComposFigure
    {
        public int h;
        public Parallelogram(string Name, int a, int b, int h) : base(Name, a, b)
        {
            this.h = h;
        }

        public override double Area()
        {
            S = A * h;
            return S;
        }

        public override double Perimeter()
        {
            P = A * 2 + B * 2;
            return P;
        }

        public void Print()
        {
            base.Print();
            WriteLine($"h = {h}");
        }
    }

    class Trapezoid : ComposFigure
    {
        
        public int h;
        public Trapezoid(string Name, int a, int b, int c, int d, int h) : base(Name, a, b, c, d)
        {
            this.h = h;
        }

        public override double Area()
        {
            S = ((A + B) * h) / 2;
            return S;
        }

        public override double Perimeter()
        {
            P = A + B + C * D;
            return P;
        }

        public void Print()
        {
            base.Print();
            WriteLine($"h = {h}");
            
        }
    }

    class Circle : ComposFigure
    {
        private double pi;
        public Circle(string Name, int a) : base(Name, a)
        {
            pi = 3.14;
        }

        public override double Area()
        {
            S = pi * (A * A);
            return S;
        }

        public override double Perimeter()
        {
            P = 2 * (pi * A);
            return P;
        }

        public override void Print()
        {
            WriteLine($"Name: {name}");
            if (A > 0)
                WriteLine($"R = {A}");
            if (B > 0)
                WriteLine($"B = {B}");
            if (C > 0)
                WriteLine($"C = {C}");
            WriteLine($"S = {S}");
            WriteLine($"P = {P}");
            WriteLine($"Pi = {pi}");
        }
    }

    class Ellipse : ComposFigure
    {
        private double pi;
        public Ellipse(string Name, int a, int b) : base(Name, a, b)
        {
            pi = 3.14;
        }

        public override double Area()
        {
            S = pi * (A * B);
            return S;
        }

        public override double Perimeter()
        {
            double temp = (A - B);
            P = 4 * (((pi * A * B) + (temp * temp)) / (A + B));
            return P;
        }

        public void Print()
        {
            base.Print();
            WriteLine($"Pi = {pi}");
        }
    }
}