using System;
using System.Windows.Forms;

namespace Mso_Backup.Formlar.Setup.UC
{
    public partial class FinishUC : UserControl
    {
        SetupForm _parent;
        public FinishUC(SetupForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
