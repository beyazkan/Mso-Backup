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
        EMail eMail;
        public EmailUC(SetupForm parent)
        {
            InitializeComponent();
            _parent = parent;
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _parent.install.smtp.Server = tbxSmtpServer.Text;
            _parent.install.smtp.Port = Convert.ToInt32(tbxSmtpPort.Text);
            _parent.install.smtp.Username = tbxSmtpUsername.Text;
            _parent.install.smtp.Password = tbxSmtpPassword.Text;
            _parent.install.smtp.Name = tbxViewofName.Text;
            _parent.install.smtp.SSLSupport = cbxSSL.Checked;
            _parent.install.smtp.TestEmail = tbxSmtpTestMail.Text;

            _parent.NextStep();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _parent.BackStep();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            _parent.install.smtp.Server = tbxSmtpServer.Text;
            _parent.install.smtp.Port = Convert.ToInt32(tbxSmtpPort.Text);
            _parent.install.smtp.Username = tbxSmtpUsername.Text;
            _parent.install.smtp.Password = tbxSmtpPassword.Text;
            _parent.install.smtp.Name = tbxViewofName.Text;
            _parent.install.smtp.SSLSupport = cbxSSL.Checked;
            _parent.install.smtp.TestEmail = tbxSmtpTestMail.Text;

            string mailAddress = tbxSmtpTestMail.Text;
            eMail = new EMail(_parent.install.smtp);
            eMail.TestMail();
        }
    }
}
