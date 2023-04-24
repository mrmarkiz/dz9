using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace dz9
{

    internal class Task2
    {
        public static void Run()
        {
            Console.WriteLine("Enter what to do(1 - show, 2 - count):");
            uint.TryParse(Console.ReadLine(), out uint choice);
            if (choice == 1)
            {
                do
                {
                    Console.WriteLine("Enter what to show(1 - time, 2 - date, 3 -day of week):");
                    uint.TryParse(Console.ReadLine(), out choice);
                    switch (choice)
                    {
                        case 1:
                            DoOperation(ShowCurrentTime);
                            break;
                        case 2:
                            DoOperation(ShowCurrentDate);
                            break;
                        case 3:
                            DoOperation(ShowCurrentDay);
                            break;
                    }
                } while (choice != 0);
            }
            else if (choice == 2)
            {
                do
                {
                    Console.WriteLine("Enter what to count(1 - rectangle area, 2 - triangle area):");
                    uint.TryParse(Console.ReadLine(), out choice);
                    double result = 0;
                    int a, b, c;
                    string[] input = null;
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter sides(a b): ");
                            input = Console.ReadLine().Split(' ');
                            while (input.Length < 2)
                                input = input.Append("0").ToArray();
                            int.TryParse(input[0], out a);
                            int.TryParse(input[1], out b);
                            result = DoOperation(a, b, RectArea);
                            break;
                        case 2:
                            Console.WriteLine("Enter sides(a b c): ");
                            input = Console.ReadLine().Split(' ');
                            while (input.Length < 3)
                                input = input.Append("0").ToArray();
                            int.TryParse(input[0], out a);
                            int.TryParse(input[1], out b);
                            int.TryParse(input[2], out c);
                            result = DoOperation(a, b, c, TrianArea);
                            break;
                    }
                    Console.WriteLine($"Result: {result}");
                } while (choice != 0);
            }
        }

        public static double DoOperation(int a, int b, Func<int, int, int> operation) => operation(a, b);
        public static double DoOperation(int a, int b, int c, Func<int, int, int, double> operation) => operation(a, b, c);
        public static int RectArea(int a, int b)
        {
            if (a <= 0 || b <= 0)
                return 0;
            return a * b;
        }
        public static double TrianArea(int a, int b, int c)
        {
            if(a <=0 || b<=0 || c<=0 || a>=b+c || b>=a+c || c>=a+b)
                return 0;
            double p = (a + b + c) / 2.0;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }


        public static void DoOperation(Action action)
        {
            action();
        }
        public static void ShowCurrentTime()
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString());
        }
        public static void ShowCurrentDate()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }
        public static void ShowCurrentDay()
        {
            Console.WriteLine(DateTime.Now.DayOfWeek);
        }
    }
}
