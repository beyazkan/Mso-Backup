using NLog;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Mso_Backup
{
    public static class Tools
    {
        static Logger _logger = LogManager.GetCurrentClassLogger();

        // First Tools : Basamak Sayısına Göre Disk Boyutunu Dönüştürme
        static readonly string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };

        public static int FormatSize(Int64 bytes)
        {
            int counter = 0;
            decimal number = (decimal)bytes;

            while (Math.Round(number / 1024) >= 1)
            {
                number = number / 1024;
                counter++;
            }

            return (int)number;
        }

        public static int FormatSizeToMB(Int64 bytes)
        {
            int counter = 0;
            decimal number = (decimal)bytes;

            while (Math.Round(number / 1024) >= 1)
            {
                if (counter == 2)
                    break;
                number = number / 1024;
                counter++;
            }

            return (int)number;
        }

        public static string FormatSizeText(Int64 bytes)
        {
            int counter = 0;
            decimal number = (decimal)bytes;

            while(Math.Round(number / 1024) >= 1)
            {
                number = number / 1024;
                counter++;
            }

            return string.Format("{0:n1} {1}", number, suffixes[counter]);
        }

        static String[] _Durum = { "enable", "disable" };
        static String _RestartReq = "-r";

        static Process _process = new Process();
        static ProcessStartInfo _startInfo = new ProcessStartInfo();

        public static void Calistir(string arguman)
        {
            _startInfo.WorkingDirectory = Application.StartupPath + "\\Exe\\";
            _startInfo.FileName = "devcon.exe";
            _startInfo.Arguments = arguman;
            _startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            _startInfo.UseShellExecute = true;
            _startInfo.Verb = "runas";

            _process.StartInfo = _startInfo;
            _process.Start();
        }

        public static void Online(string PnpDeviceId)
        {
            String arguman = _RestartReq + " " + _Durum[0] + " " + PnpDeviceId;
            Calistir(arguman);
        }

        public static void Offline(string PnpDeviceId)
        {
            String arguman = _RestartReq + " " + _Durum[1] + " " + PnpDeviceId;
            Calistir(arguman);
        }
    }
}
