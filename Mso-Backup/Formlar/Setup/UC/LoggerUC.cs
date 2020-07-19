using System;
using System.Windows.Forms;

namespace Mso_Backup.Formlar.Setup.UC
{
    public partial class LoggerUC : UserControl
    {
        SetupForm _parent;
        public LoggerUC(SetupForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Parametreler tanımlandı.
            _parent.install.Log_Database = cbxDatabase.Checked;
            _parent.install.Log_Email = cbxEmail.Checked;
            _parent.install.Log_File = cbxTextFile.Checked;
            _parent.install.Log_EmailOptionError = cbxError.Checked;
            _parent.install.Log_EmailOptionSuccess = cbxSuccess.Checked;
            _parent.install.Log_EmailOptionInfo = cbxInfo.Checked;
            _parent.install.Log_EmailOptionWarn = cbxWarn.Checked;
            _parent.NextStep();
            _parent.InstallScript();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _parent.BackStep();
        }
    }
}
