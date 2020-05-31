using Mso_Backup.Forms;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadingForm loadingFrom = new LoadingForm();
            DriversForm drivers = new DriversForm();
            loadingFrom.Show();
            //System.Threading.Thread.Sleep(1000);
            //this.Opacity = 100;
            //System.Threading.Thread.Sleep(1000);
            //this.Opacity = 0;
        }
    }
}
