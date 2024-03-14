using System;
using System.Collections.Generic;
using System.Collections;
using static System.Console;
using System.IO;
using System.Text;


/*https://metanit.com/sharp/tutorial/3.43.php - классный источний для самостояельной практики
Напишите пример описанный в указанной статье с делегатами манипулирующими банковским аккаунтом.*/

class Program
{
    static void Main()
    {
        Account account = new Account(200);
        
        account.RegisterHandler(PrintSimpleMessage);
        account.RegisterHandler(PrintColorMessage);
       
        account.Take(100);
        account.Take(150);

      
        account.UnregisterHandler(PrintColorMessage);
        
        account.Take(50);

        void PrintSimpleMessage(string message) => Console.WriteLine(message);
        void PrintColorMessage(string message)
        {
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
           
            Console.ResetColor();
        }
    }
}

public delegate void AccountHandler(string message);

public class Account
{
    int sum;
    AccountHandler? taken;
    public Account(int sum) => this.sum = sum;
    public void RegisterHandler(AccountHandler del)
    {
        taken += del;
    }
    public void UnregisterHandler(AccountHandler del)
    {
        taken -= del;
    }
    public void Add(int sum) => this.sum += sum;
    public void Take(int sum)
    {
        if (this.sum >= sum)
        {
            this.sum -= sum;
            taken?.Invoke($"Со счета списано {sum} у.е.");
        }
        else
        {
            taken?.Invoke($"Недостаточно средств. Баланс: {this.sum} у.е.");
        }
    }
}