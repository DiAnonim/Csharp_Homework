using System;
using static System.Console;

/*Задание 2(5)
Даны целые положительные числа A и B (A < B). Вывести все целые числа от A до B включительно; каждое 
число должно выводиться на новой строке; при этом каждое число должно выводиться количество раз, равное 
его значению. 
Например: если А = 3, а В = 7, то программа 
должна сформировать в консоли следующий вывод:
3 3 3
4 4 4 4
5 5 5 5 5
6 6 6 6 6 6
7 7 7 7 7 7 7.*/

public class Program
{

    public static void Main()
    {
        WriteLine("Enter two number");
        int a = Int32.Parse(ReadLine());
        int b = Int32.Parse(ReadLine());


        for (int i = a; i <= b; i++, a++)
        {
            for (int j = 0; j < i; j++)
            {
                Write($"{a} ");
            }
            WriteLine();
        }
    }


}
