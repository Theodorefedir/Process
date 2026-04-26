using System.Diagnostics;

namespace less1_process
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region AllProcesses
            //Process[] processes = Process.GetProcesses();
            //Console.WriteLine("Process Name \tPID\tPriority\tMachine name\tStart time");
            //foreach (Process p in processes)
            //{
            //    try
            //    {
            //        Console.WriteLine($"{p.ProcessName}\t{p.Id}\t{p.BasePriority}" +
            //       $"\t{p.MachineName}\t{p.StartTime}");
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.Write(p.ProcessName + " ");
            //        Console.WriteLine(ex.Message);
            //        Console.ResetColor();
            //    }
            //}
            #endregion

            #region KillProcess

            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = @"notepad",
                Arguments = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\777.txt",
                WindowStyle = ProcessWindowStyle.Maximized
            };

            Process pr = Process.Start(info);
            Console.WriteLine("Press any key");
            Console.ReadKey();
            pr.Close();//clear reference
            //pr.CloseMainWindow();
            //pr.Kill();

            pr.WaitForExit();
            Console.WriteLine($"ExitCode {pr.ExitCode}");
            Console.WriteLine($"ExitTime {pr.ExitTime}");

            #endregion
        }
    }
}
