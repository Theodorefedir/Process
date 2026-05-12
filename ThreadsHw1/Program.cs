using System.Threading;

namespace ThreadsHw1
{
    internal class Program
    {
        static void PrintNumbers(object obj)
        {
            int[] arr = (int[])obj;
            for (int i = arr[0]; i <= arr[1]; i++)
                Console.WriteLine(i);
        }
        static void PrintAllNumbers(object obj)
        {
            int[] arr = (int[])obj;
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);
        }
        static void FindMax(object obj)
        {
            int[] arr = (int[])obj;
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            Console.WriteLine($"Max: {max}");
        }
        static void FindMin(object obj)
        {
            int[] arr = (int[])obj;
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            Console.WriteLine($"Min: {min}");
        }
        static void FindArM(object obj)
        {
            int[] arr = (int[])obj;
            long sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine($"arithmetic mean: {(double)sum / arr.Length}");
        }
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] numbers = new int[10000];
            for (int i = 0; i < numbers.Length; i++)
            {

                numbers[i] = rand.Next(0, 1000);
            }
            Thread maxThread = new Thread(FindMax);
            Thread minThread = new Thread(FindMin);
            Thread sumThread = new Thread(FindArM);
            Thread printThread = new Thread(PrintAllNumbers);
            Console.Write("Enter min number: ");
            int min = int.Parse(Console.ReadLine());
            Console.Write("Enter max number: ");
            int max = int.Parse(Console.ReadLine());
            Console.Write("Enter number of threads: ");
            int num = int.Parse(Console.ReadLine());
            List<Thread> threads = new List<Thread>();
            int[] arr = { min, max};
            //Thread t = new Thread(PrintNumbers);
            //t.Start(arr);
            //t.Join();
            for (int i = 0; i < num; i++)
            {
                Thread t = new Thread(PrintNumbers);
                t.Start(arr);
                threads.Add(t);
            }
            maxThread.Start(numbers);
            minThread.Start(numbers);
            sumThread.Start(numbers);
            printThread.Start(numbers);

            Console.ReadKey();
        }
    }
}
