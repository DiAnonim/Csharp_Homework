using System;
using System.Collections.Generic;
using System.Collections;
using static System.Console;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Xml;


/*Разработать класс «Счет для оплаты». В классе предусмотреть следующие поля:
■ оплата за день;
■ количество дней;
■ штраф за один день задержки оплаты;
■ количество дней задержи оплаты;
■ сумма к оплате без штрафа (вычисляемое поле);
■ штраф (вычисляемое поле);
■ общая сумма к оплате (вычисляемое поле).

В классе объявить статическое свойство типа bool, 
значение которого влияет на процесс форматирования 
объектов этого класса. Если значение этого свойства равно true, тогда сериализуются и десериализируются все 
поля, если false — вычисляемые поля не сериализуются.


Разработать приложение, в котором необходимо продемонстрировать использование этого класса, результаты 
должны записываться и считываться из файла.*/


class Program
{
    static void Main()
    {

        Expense exp = new( "Anna", "Moiseeva", 300, 7, 60, 3/*, true*/); //надо передать в конце true что бы серилизация стала возможной
        exp.SumNotPenalty();
        exp.Penalty();
        WriteLine(exp.TotalSum());
        exp.saveXML();

        try
        {
            XmlDocument xml = new XmlDocument();
            xml.Load($"D:\\{exp.FName}_{exp.LName}.xml");
            exp.ReadNode(xml.DocumentElement);
        }
        catch (Exception ex)
        {
            WriteLine(ex);
        }
    }
}

class Expense
{
    public string FName;
    public string LName;
    double payDay;       //оплата за день;
    int cntDay;          //количество дней;
    double penaltyOneDay;//штраф за один день задержки оплаты;
    int daysPenalty;     //количество дней задержи оплаты;
    double sumNotPenalty;//сумма к оплате без штрафа (вычисляемое поле);
    double sumPenalty;      //штраф (вычисляемое поле);
    double totalSum;     //общая сумма к оплате (вычисляемое поле).
    bool isFormat;

    public Expense(string FName, string LName, double payDay, int cntDay, double penaltyOneDay, int daysPenalty, bool isFormat = false)
    {
        this.FName = FName;
        this.LName = LName;
        this.payDay = payDay;
        this.cntDay = cntDay;
        this.penaltyOneDay = penaltyOneDay;
        this.daysPenalty = daysPenalty;
        this.isFormat = isFormat;
    }

    public void SumNotPenalty()
    {
        sumNotPenalty = payDay * cntDay;
    }

    public void Penalty()
    {
        sumPenalty = penaltyOneDay * daysPenalty;
    }
    public double TotalSum()
    {
        totalSum = sumNotPenalty + sumPenalty;
        return totalSum;
    }

    public void ReadNode(XmlNode root)
    {
        if (isFormat == true)
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
    }

    public void saveXML()
    {
        if (isFormat == true)
        {
            XmlWriter xml = null;
            try
            {
                xml = XmlWriter.Create($"D:\\{FName}_{LName}.xml");
                xml.WriteStartDocument();

                xml.WriteStartElement("Expense");
                xml.WriteElementString("Name", FName);
                xml.WriteElementString("LName", LName);
                xml.WriteElementString("PayOneDay", payDay.ToString());
                xml.WriteElementString("CountPayDays", cntDay.ToString());
                xml.WriteElementString("PenaltyOneDay", penaltyOneDay.ToString());
                xml.WriteElementString("CountDaysPenalty", daysPenalty.ToString());
                xml.WriteElementString("SumNotPenalty", sumNotPenalty.ToString());
                xml.WriteElementString("SumPenalty", sumPenalty.ToString());
                xml.WriteElementString("TotalSum", totalSum.ToString());
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
            WriteLine("Serilization was successful");
        }
        else WriteLine("Serilization is not possible");

    }

}