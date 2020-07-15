using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mso_Backup.Forms
{
    public partial class Main : Form
    {
        MainForm _mainForm;
        LoadingForm _loadingForm;
        LoginForm _loginForm;

        public Main()
        {
            InitializeComponent();
            // Yükleme Ekranı...
            Control.CheckForIllegalCrossThreadCalls = false;
            _loadingForm = new LoadingForm();
            Thread thread1 = new Thread(new ThreadStart(Loading));
            thread1.Start();
            // Temel Nesneler Tanımlanıyor..
            _mainForm = new MainForm(_loadingForm);
            _loginForm = new LoginForm(_mainForm);
            _loginForm.Show();
            thread1.Abort();
        }

        private void Loading()
        {
            Application.Run(_loadingForm);
        }
    }
}
