using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz9
{
    public delegate int[] DelegateTask1(int[] arr);

    internal class Task1
    {
        public static void Run()
        {
            Console.Write("Enter array size: ");
            uint.TryParse(Console.ReadLine(), out uint n);
            int[] array = new int[n], result;
            Init(array);
            uint choice;
            DelegateTask1 delegateTask1;
            do
            {
                Console.WriteLine("Enter what to show(1 - array, 2 - even numbers, 3 - odd numbers, 4 - simple numbers, 5 - fibonacci numbers):");
                uint.TryParse(Console.ReadLine(), out choice);
                switch(choice)
                {
                    case 1:
                        delegateTask1 = null;
                        break;
                    case 2:
                        delegateTask1 = Even;
                        break;
                    case 3:
                        delegateTask1 = Odd;
                        break;
                    case 4:
                        delegateTask1 = Simple;
                        break;
                    case 5:
                        delegateTask1 = Fibonacci;
                        break;
                    default:
                        delegateTask1 = null;
                        break;
                }
                if (delegateTask1 != null)
                    result = delegateTask1(array);
                else
                    result = array;
                Console.WriteLine("Result:");
                Show(result);
            } while (choice != 0);
        }

        public static void Init(int[] arr)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = random.Next(21);
        }

        private static void Show(int[] arr)
        {
            if (arr == null)
                return;
            foreach(int i in arr)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        private static int[] Even(int[] arr)
        {
            int[] result = new int[0];
            foreach(int i in arr)
            {
                if (i % 2 == 0)
                    result = result.Append(i).ToArray();
            }
            return result;
        }

        private static int[] Odd(int[] arr)
        {
            int[] result = new int[0];
            foreach (int i in arr)
            {
                if (i % 2 == 1 || i % 2 == -1)
                    result = result.Append(i).ToArray();
            }
            return result;
        }

        private static int[] Simple(int[] arr)
        {
            int[] result = new int[0];
            byte div;
            foreach (int num in arr)
            {
                if (num < 0)
                    continue;
                div = 0;
                for (int i = 1; i < Math.Sqrt(num) && div <= 2; i++)
                {
                    if (num % i == 0)
                        div++;
                }
                if (div <= 2)
                    result = result.Append(num).ToArray();
            }
            return result;
        }

        private static int[] Fibonacci(int[] arr)
        {
            int[] result = new int[0];
            uint a, b, c, tmp;
            foreach (int num in arr)
            {
                a = 0; b = 1;c = 1;
                while (a < num)
                {
                    tmp = b + c;
                    a = b;
                    b = c;
                    c = tmp;
                }
                if (num == a)
                    result = result.Append(num).ToArray();
            }
            return result;
        }
    }


}
