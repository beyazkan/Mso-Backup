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
        public int AgreementToDB { get { return Convert.ToInt32(Agreement); } set { } }
        public bool StartOnStartup { get; set; }
        public int StartOnStartupToDB { get { return Convert.ToInt32(StartOnStartup); } set { } }
        public string DestinationPath { get; set; }
        public EfUser User = new EfUser();
        public Smtp smtp = new Smtp();
        public string Smtp_TestEmail { get; set; }
        public bool Log_Database { get; set; }
        public int Log_DatabaseToDB { get { return Convert.ToInt32(Log_Database); } set { } }
        public bool Log_File { get; set; }
        public int Log_FileToDB { get { return Convert.ToInt32(Log_File); } set { } }
        public bool Log_Email { get; set; }
        public int Log_EmailToDB { get { return Convert.ToInt32(Log_Email); } set { } }
        public bool Log_EmailOptionError { get; set; }
        public int Log_EmailOptionErrorToDB { get { return Convert.ToInt32(Log_EmailOptionError); } set { } }
        public bool Log_EmailOptionSuccess { get; set; }
        public int Log_EmailOptionSuccessToDB { get { return Convert.ToInt32(Log_EmailOptionSuccess); } set { } }
        public bool Log_EmailOptionInfo { get; set; }
        public int Log_EmailOptionInfoToDB { get { return Convert.ToInt32(Log_EmailOptionInfo); } set { } }
        public bool Log_EmailOptionWarn { get; set; }
        public int Log_EmailOptionWarnToDB { get { return Convert.ToInt32(Log_EmailOptionWarn); } set { } }
        public string InstallLocation { get; set; }
        public string InstallDateTime { get; set; }
        public int InstallState { get; set; }

    }
}
