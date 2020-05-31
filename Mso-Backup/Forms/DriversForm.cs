using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mso_Backup
{
    public partial class DriversForm : Form
    {
        DiskYonetimi _diskYonetimi = new DiskYonetimi();

        public DriversForm()
        {
            InitializeComponent();
            
            
        }

        private void DepolamaCihazlariBtn_Click(object sender, EventArgs e)
        {
            _diskYonetimi.DepolamaCihazlari();
            if(_diskYonetimi.disks.Count != 0)
            {
                checkedListBox1.DataSource = new BindingSource(_diskYonetimi.disks, null);
                checkedListBox1.DisplayMember = "DisplayMember";
                checkedListBox1.ValueMember = "UsingDeviceId";
            }
            
        }

        private void OnlineBtn_Click(object sender, EventArgs e)
        {
            foreach (Disk item in checkedListBox1.CheckedItems)
            {
                _diskYonetimi.Online(item.UsingDeviceId.ToString());
            }
            
        }

        private void OfflineBtn_Click(object sender, EventArgs e)
        {
            foreach (Disk item in checkedListBox1.CheckedItems)
            {
                _diskYonetimi.Offline(item.UsingDeviceId.ToString());
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Disk disk = (Disk)checkedListBox1.SelectedItem;
           lblFreeSpace.Text = disk.FreeSpaceGB;
           lblSerialNumber.Text = disk.SerialNumber;
        }
    }
}
