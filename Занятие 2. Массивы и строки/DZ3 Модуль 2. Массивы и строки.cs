using System;
using static System.Console;

/*
Задание 3
Дано целое число N большее 0, найти число, полученное при прочтении числа N справа налево. Например, 
если было введено число 345, то программа должна 
вывести число 543. 
Попробуйте решить задание не используя циклы, массивы и строки. Можно сделать реализацию только трехзначного числа (99 < N < 999)
*/

public class Program
{

    public static void Main()
    {
        WriteLine("Enter number");
        int N = Int32.Parse(ReadLine());
        int t = N;
        Write($"{t % 10}");
        N /= 10;
        t = N;
        Write($"{t % 10}");
        N /= 10;
        t = N;
        Write($"{t % 10}");
    }


}
