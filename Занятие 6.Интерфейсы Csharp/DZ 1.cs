using System;
using System.Collections.Generic;
using System.Collections;
using static System.Console;


/*Разработать абстрактный класс ГеометрическаяФигура с полями ПлощадьФигуры и ПериметрФигуры.
Разработать классы-наследники: Треугольник, Квадрат, Ромб, Прямоугольник, Параллелограмм, Трапеция, 
Круг, Эллипс и реализовать свойства, которые однозначно 
определяют объекты данных классов.

Реализовать интерфейс ПростойНУгольник, который 
имеет свойства: Высота, Основание, УголМеждуОснованиемИСмежнойСтороной, КоличествоСторон, ДлиныСторон, Площадь, Периметр.

Реализовать класс СоставнаяФигура который может 
состоять из любого количества ПростыхНУгольников.
Для данного класса определить метод нахождения площади фигуры.

Предусмотреть варианты невозможности задания 
фигуры (введены отрицательные длины сторон или при 
создании объекта треугольника существует пара сторон, 
сумма длин которых меньше длины третьей стороны и т.п.)
*/

class Program
{
    static void Main()
    {
        Triangle tria = new Triangle("Triangle", 7, 14, 6);
        Square square = new Square("Square", 3);
        Rhomb rhomb = new Rhomb("Rhomb", -3, 10, 8);
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

        foreach (ComposFigure figure in masFigure)
        {
            figure.Area();
            figure.Perimeter();

        }

        ComposFigure figure1 = new ComposFigure();

        foreach (ISimple_N_Square a in masFigure)
        {
            figure1.arrFig.Add(a);
        }

        figure1.Show();


    }

    public interface ISimple_N_Square
    {
        double height { get; set; }
        double osnovanie { get; set; }
        double corner { get; set; }
        int cnt { get; set; }
        double length { get; set; }
        double Area();
        double Perimeter();

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
        public bool isCreate;

        public GeomShape(string Name, int a = 0, int b = 0, int c = 0, int d = 0)
        {
            if (a < 0 || b < 0 || c < 0 || d < 0)
            {
                name = Name;
                WriteLine($"Error1 {name}: Data entered incorrectly!");
            }
            else
            {
                name = Name;
                A = a;
                B = b;
                C = c;
                D = d;
                isCreate = true;
            }
        }

        abstract public double Area();
        abstract public double Perimeter();


    }

    class ComposFigure : GeomShape, ISimple_N_Square
    {
        public List<ISimple_N_Square> arrFig;
        public double h;
        double osnov;
        double cor;
        int Cnt;
        double len;

        public ComposFigure() : base("") { arrFig = new List<ISimple_N_Square>(); }
        public ComposFigure(string Name, int a = 0, int b = 0, int c = 0, int d = 0) : base(Name, a, b, c, d) { arrFig = new List<ISimple_N_Square>(); }



        public override double Area()
        {
            throw new NotImplementedException();
        }
        public override double Perimeter()
        {
            throw new NotImplementedException();
        }

        public double height
        {
            get { return h; }
            set { h = value; }
        }
        public double osnovanie
        {
            get { return osnov; }
            set { osnov = value; }
        }
        public double corner
        {
            get { return cor; }
            set { cor = value; }
        }
        public int cnt
        {
            get { return Cnt; }
            set { Cnt = value; }
        }
        public double length
        {
            get { return len; }
            set { len = value; }
        }

        public void Show()
        {
            foreach (ComposFigure square in arrFig)
            {
                square.Print();
            }
        }

        virtual public void Print()
        {
            if (isCreate == true)
            {
                WriteLine($"Name: {name}");
                if (A > 0)
                    WriteLine($"A = {A}");
                if (B > 0)
                    WriteLine($"B = {B}");
                if (C > 0)
                    WriteLine($"C = {C}");
                if (h > 0)
                    WriteLine($"h = {h}");
                WriteLine($"S = {S}");
                WriteLine($"P = {P}");
            }
        }

    }

    class Triangle : ComposFigure
    {
        public Triangle(string Name, int a, int b, int c)
        {
            if (a + b < c || b + c < a || a + c < b)
            {
                name = Name;
                WriteLine($"Error2 {name}: Data entered incorrectly!");
                isCreate = false;
            }
            else
            {
                name = Name;
                A = a;
                B = b;
                C = c;

            }
        }

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
        public Parallelogram(string Name, int a, int b, int h) : base(Name, a, b)
        {
            base.h = h;
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
    }

    class Trapezoid : ComposFigure
    {
        public Trapezoid(string Name, int a, int b, int c, int d, int h) : base(Name, a, b, c, d)
        {
            base.h = h;
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