using System;
using System.Collections.Generic;
using System.Collections;
using static System.Console;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Xml;



/*Напишите консольное приложение для сохранения Объектов в xml file (serialization)
 
 Доделайте приложение для работы с контактами:
- Каждый контакт - это файл в папке контакты
- Каждый контакт хранит ФИО Номер телефона ДатаРождения

- Редактирование контактов
- Создание новых контактов*/

class Contacts
{
    List<Person> persons;

    public Contacts(List<Person> list)
    {
        persons = list;
    }

    public void saveXML()
    {
        XmlWriter xml = null;
        try
        {
            xml = XmlWriter.Create($"D:\\Contacts.xml");
            xml.WriteStartDocument();

            xml.WriteStartElement("Contacts");
            foreach (Person p in persons)
            {
                xml.WriteStartElement("Person");
                xml.WriteElementString("Name", p.FName);
                xml.WriteElementString("LName", p.LName);
                xml.WriteElementString("Phone", p.Phone);
                xml.WriteElementString("BirthDay", p.BirthDay);
                xml.WriteEndElement();
            }
            xml.WriteEndElement();
        }
        catch (Exception ex)
        {
            WriteLine(ex.Message);
        }
        finally
        {
            if (xml != null) xml.Close();
        }

    }
}

class Person
{
    public string FName;
    public string LName;
    public string Phone;
    public string BirthDay;


    public Person() { }
    public Person(string fName, string lName, string phone, string birthDay)
    {
        FName = fName;
        LName = lName;
        Phone = phone;
        BirthDay = birthDay;
    }

    public void saveXML()
    {
        XmlWriter xml = null;
        try
        {
            xml = XmlWriter.Create($"D:\\Contacts\\{FName}_{LName}.xml");
            xml.WriteStartDocument();

            xml.WriteStartElement("Person");
            xml.WriteElementString("Name", FName);
            xml.WriteElementString("LName", LName);
            xml.WriteElementString("Phone", Phone);
            xml.WriteElementString("BirthDay", BirthDay);
            xml.WriteEndElement();
        }
        catch (Exception ex)
        {
            WriteLine(ex.Message);
        }
        finally
        {
            if (xml != null) xml.Close();
        }

    }

    public void CreateNewPerson()
    {
        WriteLine("Enter First Name, Last name, Pnohe and Birthday");
        FName = ReadLine();
        LName = ReadLine();
        Phone = ReadLine();
        BirthDay = ReadLine();
        saveXML();
    }
}

class Program
{
    static void ReadNode(XmlNode root)
    {
        WriteLine($"Type={root.NodeType}\tRootName={root.Name}\tRootValue={root.Value}");
        if (root.HasChildNodes)
        {
            foreach (XmlNode node in root.ChildNodes)
            {
                ReadNode(node);
            }
        }
    }

    static void Main()
    {

        Person p1 = new("Алиса", "Федорова", "87337010077", "20");
        Person p2 = new("Василиса", "Дубинина", "8711368967", "25");
        Person p3 = new("Валерия", "Моисеева", "87608108694", "25");
        Person p4 = new();

        Directory.CreateDirectory(@"D:\Contacts");
        p1.saveXML();
        p2.saveXML();
        p3.saveXML();

        p4.CreateNewPerson();

    }
}