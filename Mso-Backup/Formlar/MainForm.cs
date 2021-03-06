﻿using Mso_Backup.Entity;
using Mso_Backup.Formlar.Settings;
using Mso_Backup.Formlar.UC;
using NLog;
using NLog.LayoutRenderers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Mso_Backup.Formlar
{
    public partial class MainForm : Form
    {
        LoadingForm _loadingForm;
        DriversForm _driverForms;
        SettingsForm _settingsForm;
        DiskYonetimi _diskYonetimi;
        Logger _logger;
        List<Disk> _disks;


        public MainForm(LoadingForm loadingForm)
        {
            InitializeComponent();
            _loadingForm = loadingForm;
            _loadingForm.LoadingUpdate(1, "Program Yükleniyor.");
            _loadingForm.LoadingUpdate(2, "Program Yükleniyor..");
            _loadingForm.LoadingUpdate(3, "Program Yükleniyor...");
            _loadingForm.LoadingUpdate(4, "Program Yükleniyor....");
            _loadingForm.LoadingUpdate(5, "Program Yükleniyor.....");
            _logger = LogManager.GetCurrentClassLogger();
            _loadingForm.LoadingUpdate(7, "Loglama Nesnesi Yüklendi.");
            _diskYonetimi = new DiskYonetimi(this);
            _loadingForm.LoadingUpdate(10, "Disk Nesnesi Yüklendi.");
            _settingsForm = new SettingsForm();
            _loadingForm.LoadingUpdate(20, "Ayarlar Penceresi Yüklendi.");
            _driverForms = new DriversForm(_diskYonetimi);
            _loadingForm.LoadingUpdate(30, "Sürücü Nesnesi Yüklendi.");
            _disks = _diskYonetimi.disks;
            _loadingForm.LoadingUpdate(40, "Diskler Yüklendi");
            _loadingForm.LoadingUpdate(50, "Nesne 5 Yüklendi");
            _loadingForm.LoadingUpdate(60, "Nesne 6 Yüklendi");
            _loadingForm.LoadingUpdate(70, "Nesne 7 Yüklendi");
            _loadingForm.LoadingUpdate(80, "Nesne 8 Yüklendi");
            _loadingForm.LoadingUpdate(90, "Nesne 9 Yüklendi");
            _loadingForm.LoadingUpdate(100, "Nesne 10 Yüklendi");
            _diskYonetimi.AddInsetUSBHandler();
            _diskYonetimi.AddRemoveUSBHandler();
            
        }

        public void DiskListele()
        {
            _disks = _diskYonetimi.disks;
            if(flDisks.Controls.Count != 0)
            {
                flDisks.Controls.Clear();
                if (this.InvokeRequired) { 
                    foreach (var disk in _diskYonetimi.disks)
                    {
                        this.Invoke((MethodInvoker)delegate () { flDisks.Controls.Add(new DiskUC(_diskYonetimi, disk)); });
                    }
                }
                else {
                    foreach (var disk in _diskYonetimi.disks)
                    {
                        flDisks.Controls.Add(new DiskUC(_diskYonetimi, disk));
                    }
                }
                
            }
            else
            {
                if (this.InvokeRequired)
                {
                    foreach (var disk in _diskYonetimi.disks)
                    {
                        this.Invoke((MethodInvoker)delegate () { flDisks.Controls.Add(new DiskUC(_diskYonetimi, disk)); });
                    }
                }
                else
                {
                    foreach (var disk in _diskYonetimi.disks)
                    {
                        flDisks.Controls.Add(new DiskUC(_diskYonetimi, disk));
                    }
                }
            }
        }

        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
        }
        private void kapatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _logger.Info("Program sonlandırıldı.");
            Application.Exit();
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _logger.Info("Program sonlandırıldı.");
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

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + "\\logs");
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _settingsForm.Show();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            DiskListele();
        }
    }
}
