using System;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace RhodumLauncherHandler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //kill rhodum function
            void killrhodum()
            {
                foreach (var process in Process.GetProcessesByName("Rhodum"))
                {
                    process.Kill();
                }
            }

            // 2nd anticheat
            string[] definedPrograms = { "cheatengine", "fiddler", "wireshark", "Extreme Injector", "by master131", "dll injector", "dll Vaccine", "Remote Injector DLL", "Xenos injector" };

            void stopCheats()
            {
               foreach (string definedProgram in definedPrograms)
               {
                 System.Diagnostics.Process.GetProcesses()
                 .Where(x => x.ProcessName.StartsWith(definedProgram, StringComparison.OrdinalIgnoreCase))
                 .ToList()
                 .ForEach(x => x.Kill());
               }
            }
            // start launcher
            string procPath = "";
            procPath = Directory.GetCurrentDirectory() + "\\" + "LauncherHandler.exe";
            ProcessStartInfo RhodumHandler = new ProcessStartInfo(procPath);
            Process mainProcess;
            RhodumHandler.Arguments = "4nCMSDw4Jn0jpuSpQ";
            mainProcess = Process.Start(RhodumHandler);
            while (true)
            {
                Thread.Sleep(500);
                if (!mainProcess.HasExited)
                {
                    stopCheats();
                }
                else
                {
                    killrhodum();
                    System.Environment.Exit(0);
                }
            }
        }
    }
}
