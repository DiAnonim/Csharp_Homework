using System;
using System.Collections.Generic;
using System.Collections;
using static System.Console;
using System.IO;
using System.Text;


/*Создать примитивный англо-русский и русско-английский словарь, содержащий пары слов — названий 
стран на русском и английском языках. Пользователь 
должен иметь возможность выбирать направление перевода и запрашивать перевод

Словарь может быть преднаполненным или справшивать у пользователя.

В нагрузку, сделайте словарь разных языков KZ, RU, EN, FR, IT, JP*/

class Program
{
    static void Main()
    {
        Hashtable ER = new Hashtable();
        Hashtable EF = new Hashtable();
        ICollection keyER = ER.Keys;
        ICollection keyEF = EF.Keys;
        bool find = false;
        English_RussianAdd(ref ER);
        English_FranceAdd(ref EF);
        bool exit = true;

        while (exit)
        {
            WriteLine("Enter Esc for Exit");
            WriteLine("Enter the word you are looking for");
            string word = ReadLine();
            if (word == "Esc" || word == "ESC" || word == "esc")
            {
                exit = false;
                break;
            }
            WriteLine("What language do you want to translate into?(RU, EN, FR)");
            string lang = ReadLine();
            string temp = word;
            switch (lang)
            {
                case "RU":
                case "Ru":
                case "ru":
                    Search(ref find, ref word, ref ER);
                    if (!find)
                    {
                        foreach (string s in keyEF)
                        {
                            if ((string)EF[s] == word)
                                temp = s;
                        }
                    }
                    foreach (string s in keyER)
                    {
                        if (s == temp)
                            WriteLine(word + ": " + ER[s]);
                    }
                    break;
                case "EN":
                case "En":
                case "en":
                    Search(ref find, ref word, ref ER);
                    if (find)
                    {
                        foreach (string s in keyER)
                        {
                            if ((string)ER[s] == word)
                                WriteLine(ER[s] + ": " + s);
                        }
                    }
                    else
                    {
                        foreach (string s in keyEF)
                        {
                            if ((string)EF[s] == word)
                                WriteLine(EF[s] + ": " + s);
                        }
                    }
                    break;
                case "FR":
                case "Fr":
                case "fr":
                    Search(ref find, ref word, ref EF);
                    if (!find)
                    {
                        foreach (string s in keyER)
                        {
                            if ((string)ER[s] == word)
                                temp = s;

                        }
                    }
                    foreach (string s in keyEF)
                    {
                        if (s == temp)
                            WriteLine(word + ": " + EF[s]);
                    }
                    break;
                default:
                    WriteLine($"Error: Incorrect language selected! Try again.");
                    break;
            }
        }
    }



    public static void English_RussianAdd(ref Hashtable ER)
    {
        //Англо-Русский словарь
        ER.Add("Russian", "Россия");
        ER.Add("Apple", "Яблоко");
        ER.Add("Chair", "Стул");
        ER.Add("Cheese", "Сыр");
        ER.Add("Door", "Дверь");
    }

    public static void English_FranceAdd(ref Hashtable EJ)
    {
        //Англо-Япоский словарь
        EJ.Add("Russian", "Russe");
        EJ.Add("Apple", "Pomme");
        EJ.Add("Chair", "Chaise");
        EJ.Add("Cheese", "Fromage");
        EJ.Add("Door", "Porte");
    }

    public static bool Search(ref bool find, ref string word, ref Hashtable val)
    {
        ICollection key = val.Keys;
        foreach (string s in key)
        {
            if (s == word)
                find = true;
            else if ((string)val[s] == word)
                find = true;
            else
                find = false;
        }
        return find;
    }
}