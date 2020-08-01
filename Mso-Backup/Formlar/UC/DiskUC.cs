using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mso_Backup.Entity;

namespace Mso_Backup.Formlar.UC
{
    public partial class DiskUC : UserControl
    {
        DiskYonetimi _diskYonetimi;
        Disk _disk;

        public DiskUC()
        {
            InitializeComponent();            
        }

        public DiskUC(DiskYonetimi diskYonetimi, Disk disk)
        {
            InitializeComponent();
            _diskYonetimi = diskYonetimi;
            _disk = disk;
            lblDriveLetter.Text = disk.DriveLetter;
            lblFreeSpace.Text = disk.FreeSpaceText;
            lblName.Text = disk.Model;
            progressBar1.Maximum = disk.SizeToInt;
            progressBar1.Value = disk.UsedSpaceToInt;
        }

        private void btnOnline_Click(object sender, EventArgs e)
        {
            _diskYonetimi.Online(_disk.UsingDeviceId);
        }

        private void btnOffline_Click(object sender, EventArgs e)
        {
            _diskYonetimi.Offline(_disk.UsingDeviceId);
        }
    }
}
