using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

/*Классы:
Придумать класс, описывающий студента.
Предусмотреть в нем следующие моменты: фамилия, имя,
отчество, группа, возраст, массив (зубчатый) оценок по 
программированию, администрированию и дизайну.
А также добавить методы по работе с перечисленными данными: возможность установки/получения оценки, получение среднего балла по заданному предмету,
распечатка данных о студенте.

Структуры:
1.Описать структуру Article, содержащую следующие поля: код товара; название товара; цену товара.
2.Описать структуру Client содержащую поля: код клиента; ФИО; адрес; телефон; количество заказов 
осуществленных клиентом; общая сумма заказов клиента.
3. Описать структуру RequestItem содержащую поля: товар; количество единиц товара.
4. Описать структуру Request содержащую поля: код заказа; клиент; дата заказа; перечень заказанных товаров; сумма заказа(реализовать вычисляемым свойством).*/


namespace C_Sharpp
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}

class Student
{
    public string fio;
    public string group;
    public int age;
    public int[] evalProrgam;
    public int[] evalAdmin;
    public int[] evalDesign;

    public string FIO
    {
        get { return fio; }
        set { fio = value; }
    }
    public string Group
    {
        get { return group; }
        set { group = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public void Print()
    {
        WriteLine($"FIO: {FIO}");
        WriteLine($"Groupe: {Group}");
        WriteLine($"Age: {Age}");
    }

    public double AVG(int[] masEval)
    {
        double res = 0;
        for (int i = 0; i < masEval.Length; i++)
        {
            res += masEval[i];
        }
        res /= masEval.Length;
        return res;
    }

}

struct Article
{
    public int id;
    public string name;
    public double price;
}

struct Client
{
    public int id;
    public string FIO;
    public string address;
    public int number;
    public int cntOrder;
    public double totalPrice;
}

struct RequestItem
{
    public Article idTovar;
    public string cntTovar;
}

struct Request
{
    public int id;
    public Client idClient;
    public string date;
    public RequestItem[] tovar;
    public double SumTotalPrice(RequestItem[] tovar)
    {
        double res = 0;
        foreach (var item in tovar)
        {
            res += item.idTovar.price;
        }
        return res;
    }
}

