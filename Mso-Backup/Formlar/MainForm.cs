﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Mso_Backup.Formlar
{
    public partial class MainForm : Form
    {
        LoadingForm _loadingForm;
        DriversForm _driverForms;
        public MainForm(LoadingForm loadingForm)
        {
            InitializeComponent();
            _loadingForm = loadingForm;
            _loadingForm.LoadingUpdate(1, "Program Yükleniyor.");
            _loadingForm.LoadingUpdate(2, "Program Yükleniyor..");
            _loadingForm.LoadingUpdate(3, "Program Yükleniyor...");
            _loadingForm.LoadingUpdate(4, "Program Yükleniyor....");
            _loadingForm.LoadingUpdate(5, "Program Yükleniyor.....");
            _driverForms = new DriversForm();
            _loadingForm.LoadingUpdate(10, "Sürücü Nesnesi Yüklendi.");
            _loadingForm.LoadingUpdate(20, "Nesne 2 Yüklendi");
            _loadingForm.LoadingUpdate(30, "Nesne 3 Yüklendi");
            _loadingForm.LoadingUpdate(40, "Nesne 4 Yüklendi");
            _loadingForm.LoadingUpdate(50, "Nesne 5 Yüklendi");
            _loadingForm.LoadingUpdate(60, "Nesne 6 Yüklendi");
            _loadingForm.LoadingUpdate(70, "Nesne 7 Yüklendi");
            _loadingForm.LoadingUpdate(80, "Nesne 8 Yüklendi");
            _loadingForm.LoadingUpdate(90, "Nesne 9 Yüklendi");
            _loadingForm.LoadingUpdate(100, "Nesne 10 Yüklendi");
        }
        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
        }
        private void kapatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
        }

        public void setStatusBarText(string text)
        {
            toolStripStatusLabel1.Text = text;
        }

        private void dahiliDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _driverForms.AddToList();
            _driverForms.Show();
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + "\\logs");
        }
    }
}