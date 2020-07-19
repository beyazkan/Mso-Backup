using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mso_Backup.Formlar.Setup.UC
{
    public partial class InstallUC : UserControl
    {
        private SetupForm _parent;
        public InstallUC(SetupForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            switch (checkBox2.CheckState)
            {
                case CheckState.Unchecked:
                    btnNext.Enabled = false;
                    break;
                case CheckState.Checked:
                    btnNext.Enabled = true;
                    break;
                case CheckState.Indeterminate:
                    break;
                default:
                    break;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _parent.install.Agreement = true;
            _parent.NextStep();
        }
    }
}
