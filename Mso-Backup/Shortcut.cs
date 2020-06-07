using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IWshRuntimeLibrary;
using File = System.IO.File;

namespace Mso_Backup
{
    public static class Shortcut
    {
        public static void CreateShortcut(string originalFilePathAndName, string destinationSavePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(originalFilePathAndName);
            string originalFilePath = Path.GetDirectoryName(originalFilePathAndName);

            string link = destinationSavePath + Path.DirectorySeparatorChar + fileName + ".lnk";
            var shell = new WshShell();
            var shortcut = shell.CreateShortcut(link) as IWshShortcut;
            if (shortcut != null)
            {
                shortcut.TargetPath = originalFilePathAndName;
                shortcut.WorkingDirectory = originalFilePath;
                shortcut.Save();
            }
        }

        public static void CreateStartupShortcut(string originalFilePathAndName)
        {
            CreateShortcut(originalFilePathAndName, Environment.GetFolderPath(Environment.SpecialFolder.Startup));
        }

        public static void DeleteShortcut(string originalFilePathAndName, string destinationSavePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(originalFilePathAndName);
            string originalFilePath = Path.GetDirectoryName(originalFilePathAndName);

            string link = destinationSavePath + Path.DirectorySeparatorChar + fileName + ".lnk";
            if (File.Exists(link)) File.Delete(link);
        }

        public static void DeleteStartupShortcut()
        {
            DeleteShortcut(System.Reflection.Assembly.GetEntryAssembly()?.Location, Environment.GetFolderPath(Environment.SpecialFolder.Startup));
        }
    }
}
