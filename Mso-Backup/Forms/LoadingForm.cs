using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mso_Backup.Forms
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        public void LoadingUpdate(int value, string description)
        {
            progressBar1.Value = value;
            lblPercent.Text = value + "/100";
            lblAciklama.Text = description;
            Thread.Sleep(250);
        }
    }
}
