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
    public partial class EmailUC : System.Windows.Forms.UserControl
    {
        SetupForm _parent;
        public EmailUC(SetupForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _parent.NextStep();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _parent.BackStep();
        }
    }
}
