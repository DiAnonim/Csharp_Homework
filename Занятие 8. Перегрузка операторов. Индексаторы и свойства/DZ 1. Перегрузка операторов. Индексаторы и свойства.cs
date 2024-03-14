using System;
using System.Collections.Generic;
using System.Collections;
using static System.Console;
using System.IO;
using System.Text;


/*Разработать класс Fraction, представляющий простую 
дробь. в классе предусмотреть два поля: числитель 
и знаменатель дроби. Выполнить перегрузку следующих операторов: +,-,*,/,==,!=,<,>, true и false.
Арифметические действия и сравнение выполняется 
в соответствии с правилами работы с дробями. Оператор true возвращает true если дробь правильная 
(числитель меньше знаменателя), оператор false
возвращает true если дробь неправильная (числитель 
больше знаменателя).
Выполнить перегрузку операторов, необходимых для 
успешной компиляции следующего фрагмента кода:
Fraction f = new Fraction(3, 4);
int a = 10;
Fraction f1 = f * a;
Fraction f2 = a * f;
double d = 1.5;
Fraction f3 = f + d;
*/

class Program
{
    static void Main()
    {
        Fraction f = new Fraction(3, 4);
        WriteLine($"f: ");
        f.Print();
        int a = 10;
        Fraction f1 = f * a;
        WriteLine($"f1: ");
        f1.Print();
        Fraction f2 = a * f;
        WriteLine($"f2: ");
        f2.Print();
        double d = 1.5;
        Fraction f3 = f + d;
        WriteLine($"f3: ");
        f3.Print();
    }

}

class Fraction
{
    public int num;
    public int den;

    public Fraction(int chis, int znam)
    {
        this.num = chis;
        this.den = znam;
    }

    public static Fraction operator *(Fraction val, int a)
    {
        Fraction temp = new(val.num, val.den);
        temp.num *= a;
        return temp;
    }

    public static Fraction operator *(int a, Fraction val)
    {
        Fraction temp = new(val.num, val.den);
        temp.num *= a;
        return temp;
    }

    public static Fraction operator +(Fraction val, double d)
    {
        Fraction temp = new(val.num, val.den);
        double Tnum = (double)temp.num / (double)temp.den;
        Tnum = Tnum + d;
        int cnt = searchCnt(Tnum); //2
        int t2 = 1;
        for (int i = 0; i < cnt; i++)
        {
            Tnum *= 10;
            t2 *= 10;
        }
        temp.num = (int)Tnum;
        temp.den = t2;
        return temp;
    }

    static int searchCnt(double val)
    {
        int i = 1;
        while (val * Math.Pow(10, 1 + i) % 10 != 0) { i++; };
        return i--;
    }

    public void Print()
    {
        WriteLine($"Numerator = {num}");
        WriteLine($"Denominator = {den}");
    }
}
