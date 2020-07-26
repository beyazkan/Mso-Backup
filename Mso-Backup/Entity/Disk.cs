using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mso_Backup.Entity
{
    public class Disk
    {
        public int Id { get; set; }
        public string PNPDeviceId { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string DriveLetter { get; set; }
        public long Size { get; set; }
        public long FreeSpace { get; set; }
        public String SizeGB { get { return Convert.ToString(Math.Ceiling((decimal)this.Size / 1024 / 1024 / 1024) + 1) + "GB";  } set { } }
        public String FreeSpaceGB { get { return Convert.ToString(Math.Ceiling((decimal)this.FreeSpace / 1024 / 1024 / 1024) + 1) + "GB"; } set { } }
        public int State { get; set; }
        public string UsingDeviceId { get { return "@" + PNPDeviceId; } set { } }
        public string DisplayMember { get { return this.DriveLetter + " " + this.Model + " " + this.SizeGB; } set { } }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public DateTime DeleteDateTime { get; set; }
        public int UserID { get; set; }
    }
}
