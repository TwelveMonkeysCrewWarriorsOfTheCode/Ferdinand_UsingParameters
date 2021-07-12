using System;
using UsingParametersBLL;

namespace UsingParameters_New
{
    class Program
    {
        static void Main(string[] args)
        {
            Time time1, time2;
            time1 = new Time(2, 30);
            time2 = new Time(3, 15);
            int TimeInt = 120;
            int coefficient = 2;
            float timeFloat = 12.5215354f;

            Console.WriteLine("++++++++++++++++ Operators overloading +++++++++++++++++++++");

            Console.WriteLine($"{time1} + {time2} = {time1 + time2}");
            Console.WriteLine($"{time1} - {time2} = {time1 - time2}");
            Console.WriteLine($"{time1} * {coefficient} = {time1 * coefficient}");
            Console.WriteLine($"{time2} / {coefficient} = {time2 / coefficient}");

            Console.WriteLine("++++++++++++++++ Overloading conversion operators ++++++++++");

            Console.WriteLine($"Int ({TimeInt}) en Time --> {(Time)TimeInt}");
            Console.WriteLine($"Time ({time1}) en Int --> {(int)time1}");
            Console.WriteLine($"Time ({time1}) en float --> {(float)time1}");
            Console.WriteLine($"Float ({timeFloat}) en Time --> {(Time)timeFloat}");

            Console.WriteLine("++++++++++++++++ Overloading relational operators ++++++++++");

            Console.WriteLine($"Comparaison: {time1} < {time2} --> {time1 < time2}");
            Console.WriteLine($"Comparaison: {time1} > {time2} --> {time1 > time2}");
            Console.WriteLine($"Comparaison: {time1} <= {time2} --> {time1 <= time2}");
            Console.WriteLine($"Comparaison: {time1} >= {time2} --> {time1 >= time2}");
            Console.WriteLine($"Comparaison: {time1} == {time2} --> {time1 == time2}");
            Console.WriteLine($"Comparaison: {time1} != {time2} --> {time1 != time2}");
        }
    }
}
