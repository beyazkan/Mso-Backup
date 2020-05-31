using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mso_Backup.Forms.Setup
{
    public partial class FinishUC : UserControl
    {
        SetupForm _parent;
        public FinishUC(SetupForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _parent.BackStep();
        }
    }
}
