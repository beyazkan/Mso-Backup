using System;
using System.Windows.Forms;

namespace Mso_Backup.Formlar.Setup.UC
{
    public partial class FailedUC : UserControl
    {
        public FailedUC()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
