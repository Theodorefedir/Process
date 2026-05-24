namespace TaskHw1

{
    internal class Program
    {
        static bool IsSimple (int number) {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
        static void SimpleNumbers() {
            for (int i = 0; i < 1000; i++) {
                if (IsSimple(i)) {
                    Console.WriteLine(i);
                }
            }
        }
        static void SimpleNumbersInR(int a, int b)
        {
            if (a < b)
            {
                for (int i = a; i < b; i++)
                {
                    if (IsSimple(i))
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            else {
                throw new Exception("the numbers are incorrect, (a)should be greater than(b)");
            }
        }
        static void RemoveDuplicates(ref int[] arr)
        {
            arr = arr.Distinct().ToArray();
        }
        static void SortArray(ref int[] arr)
        {
            arr = arr.OrderBy(x => x).ToArray();
        }
        static void BinSearch(ref int[] arr)
        {
            Console.Write("Enter number ");
            int n = int.Parse(Console.ReadLine());
            int i = Array.BinarySearch(arr, n);
            Console.WriteLine(i >= 0 ? $"In index {i}" : "there is no number with this index");
        }
        static void Main(string[] args)
        {

            Task task = new Task(() => { Console.WriteLine(DateTime.Now); });
            task.Start();
            Task task1 = Task.Factory.StartNew(() => { Console.WriteLine(DateTime.Now); });
            Task task2 = Task.Run(() => { Console.WriteLine(DateTime.Now); });
            Task task3 = Task.Run(() => { SimpleNumbers(); });
            task3.Wait();
            Console.Write("Enter a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter b: ");
            int b = int.Parse(Console.ReadLine());
            Task task4 = Task.Run(() => { SimpleNumbersInR(a, b); });
            

            int[] arr = { 0, 1, 1, 3, 6, 7, 9, 5, 44, 3, 55, 989 };
            int[] numbers = { 5, 2, 78, 2, 5, 1, 69, 3, 8, 67 };
            Task[] tasks = new Task[4];
            tasks[0] = Task.Run(() => Console.WriteLine($"Min: {arr.Min()}"));
            tasks[1] = Task.Run(() => Console.WriteLine($"Max: {arr.Max()}"));
            tasks[2] = Task.Run(() => Console.WriteLine($"Avg: {arr.Average()}"));
            tasks[3] = Task.Run(() => Console.WriteLine($"Sum: {arr.Sum()}"));
            Task task5 = Task.Run(() => RemoveDuplicates(ref numbers));
            Task task6 = task5.ContinueWith(t => SortArray(ref numbers));
            Task task7 = task6.ContinueWith(t => BinSearch(ref numbers));
            task7.Wait();
            //Console.ReadKey();

        }
    }
}
