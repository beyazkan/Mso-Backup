using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mso_Backup.Entity
{
    public class Smtp
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public bool SSLSupport { get; set; }
        public int SSLSupportToDB { get { return Convert.ToInt32(SSLSupport); } set { } }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string TestEmail { get; set; }
    }
}
