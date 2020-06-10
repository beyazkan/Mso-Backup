using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mso_Backup.Entity
{
    public class EfInstall
    {
        public int Id { get; set; }
        public bool Agreement { get; set; }
        public bool StartOnStartup { get; set; }
        public string DestinationPath { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Smtp_Server { get; set; }
        public int Smtp_Port { get; set; }
        public bool SupportSSL { get; set; }
        public string Smtp_Username { get; set; }
        public string Smtp_Password { get; set; }
        public string Smtp_TestEmail { get; set; }
        public bool Log_Database { get; set; }
        public bool Log_File { get; set; }
        public bool Log_Email { get; set; }
        public bool Log_EmailOptionError { get; set; }
        public bool Log_EmailOptionSuccess { get; set; }
        public bool Log_EmailOptionInfo { get; set; }
        public bool Log_EmailOptionWarn { get; set; }
        public string InstallLocation { get; set; }
        public string InstallDateTime { get; set; }
        public int InstallState { get; set; }

    }
}
