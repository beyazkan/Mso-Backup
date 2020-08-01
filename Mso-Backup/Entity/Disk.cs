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
        public long UsedSpace { get { return Size - FreeSpace; } set { } }
        public int SizeToInt { get { return Tools.FormatSize(Size); } set { } }
        public int FreeSpaceToInt { get { return Tools.FormatSize(FreeSpace); } set { } }
        public int UsedSpaceToInt { get { return Tools.FormatSize(UsedSpace); } set { } }
        public String SizeText { get { return Tools.FormatSizeText(Size);  } set { } }
        public String FreeSpaceText { get { return Tools.FormatSizeText(FreeSpace); } set { } }
        public String UsedSpaceText { get { return Tools.FormatSizeText(UsedSpace); } set { } }
        public int State { get; set; }
        public string UsingDeviceId { get { return "@" + PNPDeviceId; } set { } }
        public string DisplayMember { get { return this.DriveLetter + " " + this.Model + " " + this.SizeText; } set { } }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public DateTime DeleteDateTime { get; set; }
        public int UserID { get; set; }
    }
}
