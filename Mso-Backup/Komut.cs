using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Mso_Backup
{
    class Komut
    {
        Process _process = new Process();
        ProcessStartInfo _startInfo = new ProcessStartInfo();

        public void Calistir(string arguman)
        {
            _startInfo.WorkingDirectory = Application.StartupPath + "\\Exe\\";
            _startInfo.FileName  = "devcon.exe";
            _startInfo.Arguments = arguman;
            _startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            _startInfo.UseShellExecute = true;
            _startInfo.Verb = "runas";

            _process.StartInfo = _startInfo;
            _process.Start();
        }
        
    }
}
