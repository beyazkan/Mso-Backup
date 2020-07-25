using Mso_Backup.Formlar.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mso_Backup.Formlar
{
    public partial class Deneme : Form
    {

        List<DiskUC> diskUCs = new List<DiskUC>();
        public Deneme()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            diskUCs.Add(new DiskUC());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in diskUCs)
            {
                flowLayoutPanel1.Controls.Add(item);
            }
            
        }
    }
}
