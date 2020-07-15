using Mso_Backup.Forms;
using NLog;
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
        Database database;
        Logger logger = LogManager.GetCurrentClassLogger();

        public LoginForm()
        {
            InitializeComponent();
            database = new Database();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            if (tbxUsername.TextLength == 0 & tbxPassword.TextLength == 0)
            {
                MessageBox.Show("Kullanıcı adı veya şifre boş olamaz.");
                logger.Error("Kullanıcı adı veya şifre boş olamaz.");
            }
            else
            {
                if (database.checkUser(tbxUsername.Text, tbxPassword.Text))
                {
                    MessageBox.Show("Giriş yapılmıştır.");
                    logger.Info($"{tbxUsername.Text} adlı kullanıcı giriş yaptı.");
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya Şifre Hatalıdır.");
                    logger.Info($"{tbxUsername.Text} - Kullanıcı adı veya Şifre Hatalıdır.");
                    database.login_attemp(tbxUsername.Text);
                }
            }
        }

        private void btnPasswordReset_Click(object sender, EventArgs e)
        {

        }

        private void tbxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void tbxUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxPassword.Select();
            }
        }
    }
}
