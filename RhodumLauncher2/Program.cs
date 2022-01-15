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
using Newtonsoft.Json;
using DiscordRPC;
using RhodumLauncher2;
using System.Management;

namespace RhodumLauncher
{
    class Program
    {
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        // Api variables
        static void Main(string[] args)
        {

            try
            {


                var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
                ManagementObjectCollection mbsList = mbs.Get();
                string hwid = "";
                foreach (ManagementObject mo in mbsList)
                {
                    hwid = mo["ProcessorId"].ToString();
                    break;
                }

                // other important variables
                Console.Title = "Rhodum Launcher";
                try
                {
                    string verifylaunch = args[0];
                    if (verifylaunch != "4nCMSDw4Jn0jpuSpQ")
                    {
                        MessageBox.Show("Please use the launcher to play.");
                        System.Environment.Exit(0);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("use the launcher to play.");
                    System.Environment.Exit(0);
                }
                string currentversion = "8.0.0";

                WebClient wClient = new WebClient();
                string verget = wClient.DownloadString("http://labs.rhodum.xyz/launcher/version.txt");

                // check for HWID bans
                try
                {
                    string hwidbans = wClient.DownloadString("http://labs.rhodum.xyz/launcher/bans.txt");
                    if (hwidbans.Contains(hwid) == true)
                    {
                        MessageBox.Show("An error happened. (002)");
                        System.Environment.Exit(0);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please check your internet connection.");
                    System.Environment.Exit(0);
                }


                if (verget != currentversion)
                {
                    MessageBox.Show("You are using an outdated version of Rhodum. Please download the new version.");
                    System.Environment.Exit(0);
                }
                try
                {
                    Console.WriteLine("Enter connection code:");
                    
                    string conncode = Console.ReadLine();
                    dynamic jsoncode = JsonConvert.DeserializeObject(Base64Decode(conncode));
                    string lansecurity = "http://labs.rhodum.xyz/launcher/securitycheck.php?key=" + jsoncode.key + "&uid=" + jsoncode.userid + "&gameId=" + jsoncode.gameid + "&invkey=" + hwid;
                    string getvalidation = wClient.DownloadString(lansecurity);

                    // check if we are validated.
                    if (getvalidation == "yes")
                    {
                        // start the game, lol
                        string gamenameurl = "https://labs.rhodum.xyz/launcher/gamename.php?key=Iasdfaxwf03h50nbcinvklnhdhkh&uid=" + jsoncode.gameid;
                        string gamename = wClient.DownloadString(gamenameurl);
                        discord.launchrpc(gamename);
                        string procPath = "";
                        procPath = Directory.GetCurrentDirectory() + "\\" + "Rhodum.exe";
                        ProcessStartInfo RhodumClient = new ProcessStartInfo(procPath);
                        Process mainProcess;
                        RhodumClient.Arguments = "-script \"wait(); dofile('http://labs.rhodum.xyz/user/game/getScript2010.php?userID=" + jsoncode.userid + "&gameID=" + jsoncode.gameid + "&key=9cBOle3VIeU0wBfZmkL92qNU63xk8Y90&pkey=" + jsoncode.key + "')\"";
                        mainProcess = Process.Start(RhodumClient);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Rhodum is now running! Do not close this window or the game will crash, this window will close automatically when you stop playing.");

                        while (true)
                        {
                            Thread.Sleep(500);
                            if (!mainProcess.HasExited)
                            {
                                anticheat.startanticheat();
                            }
                            else
                            {
                                System.Environment.Exit(0);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot connect to Rhodum. please check your internet connection.");
                        System.Environment.Exit(0);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("You provided an invalid code.");
                    System.Environment.Exit(0);
                }
            }
            catch (Exception)
            {
                Console.ReadKey();
                MessageBox.Show("Rhodum crashed for some reason.");
            }
        }

    }
}