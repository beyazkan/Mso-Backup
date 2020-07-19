using System;
using System.IO;
using System.Windows.Forms;
using Mso_Backup.Formlar;
using Mso_Backup.Formlar.Setup;


namespace Mso_Backup
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.Exists(Application.StartupPath + "\\msobackup.db")){
                Application.Run(new Main());
            }
            else
            {
                Application.Run(new SetupForm());
            }
            
        }
    }
}
