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
    public partial class UserUC : UserControl
    {
        SetupForm _parent;
        public UserUC(SetupForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _parent.install.User.FirstName = tbxFirstName.Text;
            _parent.install.User.LastName = tbxLastname.Text;
            _parent.install.User.Username = tbxUsername.Text;
            _parent.install.User.Password = tbxPassword.Text;
            _parent.install.User.Email = tbxEMail.Text;
            _parent.NextStep();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _parent.BackStep();
        }
    }
}
