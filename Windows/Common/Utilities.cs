using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using static System.Windows.Forms.SendKeys;

namespace ATF.Windows.Common
{
    public class Utilities
    {
        public static void KillProcess(bool killIfAlreadyLaunched, string processName)
        {
            if (killIfAlreadyLaunched)
            {
                var timeout = DateTime.Now.AddMilliseconds(10000);
                var process = GetProcess(processName);
                while (process != null && DateTime.Now < timeout)
                {
                    try
                    {
                        process.Kill();
                    }
                    catch (Exception ex) when (ex is InvalidOperationException || ex is Win32Exception || ex is NotSupportedException)
                    {
                        Console.WriteLine(ex.InnerException);
                    }

                    Thread.Sleep(100);
                    process = GetProcess(processName);
                }

                if (process != null)
                    throw new Exception("Unable to Kill the Process");
            }
        }

        public static void StartProcess(string filePath, string processArguments, string workingDirectory = null)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Specified File Path {filePath} does not exists");

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = filePath,
                    Arguments = processArguments,
                    CreateNoWindow = false,
                    WorkingDirectory = workingDirectory ?? string.Empty,
                }
            };
            process.Start();
        }

        public static void CleanDirectory(string directoryPath)
        {
            var di = new DirectoryInfo(directoryPath);
            foreach (var file in di.GetFiles())
                file.Delete();
            foreach (var dir in di.GetDirectories())
                dir.Delete(true);
        }

        public static void Sleep(int millisecondsTime)
        {
            Thread.Sleep(millisecondsTime);
        }

        public static void SendKeys(string keys, int num = 1)
        {
            for (var i = 0; i < num; i++)
                SendWait(keys);
        }

        public static Process GetProcess(string processToKill)
        {
            return Process
                .GetProcesses()
                .FirstOrDefault(p => p.ProcessName == processToKill);
        }
    }
}
