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
        Disk _disk;
        int size;
        int freesize;
        int currentsize;

        public DiskUC()
        {
            InitializeComponent();
        }

        public DiskUC(Disk disk)
        {
            InitializeComponent();
            _disk = disk;
            lblDriveLetter.Text = disk.DriveLetter;
            lblFreeSpace.Text = disk.FreeSpaceGB;
            lblName.Text = disk.Model;
            size = (int)(disk.Size / 100);
            freesize = (int)(disk.FreeSpace / 100);
            currentsize = size - freesize;
            progressBar1.Maximum = size;
            progressBar1.Value = currentsize;
        }
    }
}
