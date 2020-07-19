using System;
using System.Windows.Forms;

namespace Mso_Backup.Formlar.Setup.UC
{
    public partial class DestinationUC : UserControl
    {
        SetupForm _parent;

        public DestinationUC(SetupForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void btnTarget_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = "C:\\Program Files";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tbxTargetFolder.Text = folderBrowserDialog.SelectedPath + "\\MsoBackup";
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _parent.install.DestinationPath = tbxTargetFolder.Text;
            _parent.install.StartOnStartup = checkBox1.Checked;
            _parent.NextStep();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _parent.BackStep();
        }
    }
}
