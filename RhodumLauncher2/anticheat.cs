using System;
using System.Net;
using System.Linq;

namespace RhodumLauncher2
{
    class anticheat
    {
        public static void startanticheat()
        {
            WebClient wClient = new WebClient();
            string[] definedPrograms = { "injector", "cheat", "hack", "master131", "guardian", "patcher", "xenos", "ploit", "venom", "exploit", "Vaccine", "fiddler", "Gadget", "Big Bang", "Neferty", "GIFDO", "Traitc0re", "Shad0w" };
            foreach (string definedProgram in definedPrograms)
            {
                System.Diagnostics.Process.GetProcesses()
                .Where(x => x.ProcessName.StartsWith(definedProgram, StringComparison.OrdinalIgnoreCase))
                .ToList()
                .ForEach(x => wClient.DownloadString("http://labs.rhodum.xyz/launcher/report.php?report=" + x.ProcessName));
            }
        }
    }
}
