using System;
using System.Collections.Generic;
using System.Collections;
using static System.Console;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


/*- Hangman Поле чудес
Компьютер загадывает слово из заранее определенного вами словаря (можно использовать обобщенный список) - 
игроку дается определенное количество попыток чтобы угадать слово по буквам.
От игрока получаем букву и показываем есть ли эта буква в загаданном слове или отнимаем попытку.
Игра заказнчивается если игрок угадал слово или закончились попытки.


Доделайте программу таким образом, чтобы слова брались из файла и раунды пользователя сохранялись в файл.*/

class Program
{
    static void Main()
    {
        Hangman hang = new Hangman();
        hang.AddWordsInFile();
        Write("Введите Ваше Имя: ");
        try
        {
            hang.userName = ReadLine();
        }
        catch (Exception ex) { }
        hang.GameStart();

    }
}

class Hangman
{
    public string[] dictionary;
    public char[] userWord;
    public string CompWord;
    public string path;
    public string userName;
    public int attempts;
    public int idxLetter;
    public bool isHave;
    public bool isWin;


    public Hangman()
    {
        ReaderWordsFromFile();
        attempts = 4;
        isHave = false;
        isWin = false;
        CompWord = randChoice();
        char[] userWord = new char[CompWord.Length];
        idxLetter = 0;
        userName = null;

    }

    public string randChoice()
    {
        Random rnd = new Random();
        return dictionary[rnd.Next(0, 6)];
    }
    public void GameStart()
    {

        char letter = ' ';
        char[] charArray = new char[CompWord.Length];

        for (int i = 0; i < CompWord.Length; i++)
        {
            charArray[i] = '_';
        }
        while (attempts > 0)
        {
            WriteLine($"У вас есть {attempts} попытки");

            for (int i = 0; i < CompWord.Length; i++)
            {
                if (isHave)
                {
                    charArray[idxLetter] = letter;
                }
            }
            userWord = charArray;
            for (int i = 0; i < CompWord.Length; i++)
            {
                Write($"{userWord[i]} ");
            }
            WriteLine();
            if (Win())
            {
                WriteLine("------------------------");
                WriteLine($"You Win {userName}");
                WriteLine($"Word: {CompWord}");
                WriteLine($"Attempts left: {attempts}");
                AddFileRound();
                break;
            }

            Write("Введите букву: ");
            try
            {
                letter = char.Parse(ReadLine());
            }
            catch (Exception ex) { }
            if (!haveLetter(letter)) attempts--;
            if (attempts == 0)
            {
                WriteLine($"Game over");
                WriteLine($"Word: {CompWord}");
                break;
            }
        }
    }

    public bool haveLetter(char let)
    {
        int cnt = 0;
        foreach (var letterInWord in CompWord)
        {
            if (letterInWord == let)
            {
                isHave = true;
                break;
            }
            else
                isHave = false;
            cnt++;
        }
        idxLetter = cnt;
        return isHave;
    }

    public void AddWordsInFile()
    {
        path = @"D:\dictionary.txt";
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            fs.Close();
        }
        using (FileStream fs = new FileStream(path, FileMode.Append))
        {
            using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
            {
                sw.WriteLine("place");
                sw.WriteLine("chair");
                sw.WriteLine("walk");
                sw.WriteLine("love");
                sw.WriteLine("sun");
                sw.WriteLine("star");

                sw.Close();
            }
        }
    }

    public void AddFileRound()
    {
        path = @"D:\round.txt";
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            fs.Close();
        }
        using (FileStream fs = new FileStream(path, FileMode.Append))
        {
            using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
            {
                sw.WriteLine(userName);
                sw.WriteLine(CompWord);
                sw.WriteLine(attempts);

                sw.Close();
            }
        }
    }

    public void ReaderWordsFromFile()
    {
        path = @"D:\dictionary.txt";
        dictionary = File.ReadAllLines(path);
    }

    public bool Win()
    {
        for (int i = 0; i < userWord.Length; i++)
        {
            if (userWord[i] == '_')
            {
                isWin = false;
                break;
            }
            isWin = true;
        }
        return isWin;
    }
}