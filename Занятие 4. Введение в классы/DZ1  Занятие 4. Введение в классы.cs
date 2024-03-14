using System;
using static System.Console;
using Russian;
using Japan;
using England;

/*Разработать приложение, в котором бы сравнивалось население трёх(или N) столиц из разных стран. 
Причём страна бы обозначалась пространством имён, а город — классом в данном пространстве.

В нагрузку, само сравнение должно обрабатываться с основной программе, в отдельном методе Compare
метод Compare во входных данных принимает плавающее количество городов
*/

public class Program
{

    public static void Main()
    {
        CreateCity temp = new CreateCity();
        Russian.Moscow st1 = temp.moscow();
        Japan.Tokyo st2 = temp.tokyo();
        England.London st3 = temp.london();

        List<City> listCity = new List<City>();

        listCity.Add(st1);
        listCity.Add(st2);
        listCity.Add(st3);

        City max = temp.Compare(listCity);
        max.print();
    }


}



public class CreateCity
{
    public Moscow moscow()
    {
        return new Moscow("Moscow", 146);
    }
    public Tokyo tokyo()
    {
        return new Tokyo("Tokyo", 13);
    }
    public London london()
    {
        return new London("London", 56);
    }

    public City Compare(List<City> lstC)
    {
        City max = new City();
        foreach (City c in lstC)
        {
            if (max.population < c.population)
            {
                max = c;
            }
        }
        return max;
    }
}

namespace Russian
{
    public class Moscow : City
    {
        public Moscow(string name, int population) : base(name, population) { }
    }
}

namespace Japan
{
    public class Tokyo : City
    {
        public Tokyo(string name, int population) : base(name, population) { }
    }
}

namespace England
{
    public class London : City
    {
        public London(string name, int population) : base(name, population) { }
    }
}

public class City
{
    public string Name;
    public int population;

    public City() : this("", 0) { }
    public City(string name, int population)
    {
        Name = name;
        this.population = population;
    }

    public void print()
    {
        WriteLine("Maximum population in ");
        WriteLine($"Name: {Name}");
        WriteLine($"Population: {population}");
    }
}
