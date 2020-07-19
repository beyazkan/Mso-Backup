using NLog;
using System;
using System.Windows.Forms;

namespace Mso_Backup.Formlar
{
    public partial class LoginForm : Form
    {
        Database database;
        Logger logger = LogManager.GetCurrentClassLogger();
        MainForm _mainForm;

        public LoginForm(MainForm mainForm)
        {
            InitializeComponent();
            database = new Database();
            _mainForm = mainForm;
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
                // Kullanıcı Doğrulama
                if (database.checkUser(tbxUsername.Text, tbxPassword.Text))
                {
                    // Ana Pencerenin Açılması
                    MessageBox.Show("Giriş yapılmıştır.");
                    logger.Info($"{tbxUsername.Text} adlı kullanıcı giriş yaptı.");
                    this.Hide();
                    _mainForm.Show();
                    _mainForm.setStatusBarText(tbxUsername.Text + " adlı kullanıcı ile giriş yapılmıştır.");
                    _mainForm.Text = "MsoBackup - Kullanıcı : " + tbxUsername.Text;
                }
                else
                {
                    // TODO : Hatalı yada şüpheli giriş denemeleri için kontrol sağlanacak...
                    MessageBox.Show("Kullanıcı adı veya Şifre Hatalıdır.");
                    logger.Info($"{tbxUsername.Text} - Kullanıcı adı veya Şifre Hatalıdır.");
                    database.login_attemp(tbxUsername.Text);
                }
            }
        }

        private void btnPasswordReset_Click(object sender, EventArgs e)
        {
            // TODO : Şifremi Unuttum Seçeneği Kodlanacak...
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
