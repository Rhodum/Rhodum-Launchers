using System;
using DiscordRPC;

namespace RhodumLauncher2
{
    class discord
    {
        public static void launchrpc(string gamename)
        {
            DiscordRpcClient client = new DiscordRpcClient("847924026176831518");
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = "Rhodum - Playing",
                State = gamename,
                Timestamps = Timestamps.Now,
                Assets = new Assets()
                {
                    LargeImageKey = "untitled",
                    LargeImageText = "Rhodum"
                }
            });
        }
    }
}
