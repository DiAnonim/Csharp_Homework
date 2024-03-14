using System;
using static System.Console;

/*Задание 1(4)
Пользователь вводит с клавиатуры границы числового 
диапазона. Требуется показать все числа Фибоначчи из 
этого диапазона. Числа Фибоначчи — элементы числовой 
последовательности, в которой первые два числа равны 0
и 1, а каждое последующее число равно сумме двух предыдущих чисел. Например, если указан диапазон 0–20,
результат будет: 0, 1, 1, 2, 3, 5, 8, 13.*/

public class Program
{

    public static void Main()
    {
        WriteLine("Enter two number");
        int a = Int32.Parse(ReadLine());
        int b = Int32.Parse(ReadLine());
        int c = a + 1;

        for (int i = 0; i < b; i++)
        {
            int sum = a + c;
            if (sum > 20) { break; }
            a = c;
            c = sum;
            WriteLine(sum);
        }
    }


}
