﻿using Mso_Backup.Entity;
using Mso_Backup.Formlar.Setup.UC;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Mso_Backup.Formlar.Setup
{
    public partial class SetupForm : Form
    {
        // Loglama Nesnesi
        Logger logger = LogManager.GetCurrentClassLogger();
        FileManagement fileManagement = new FileManagement();
        public EfInstall install;

        public List<UserControl> userControls;
        public int _step { get; set; }

        public SetupForm()
        {
            try
            {
                InitializeComponent();
                logger.Info("Msobackup Kurulumu Çalıştırıldı.");
                // Nesne ve Değişken Tanımları
                _step = 0;
                install = new EfInstall();
                install.InstallLocation = Application.StartupPath;
                userControls = new List<UserControl>();
                userControls.Add(new InstallUC(this));
                userControls.Add(new DestinationUC(this));
                userControls.Add(new UserUC(this));
                userControls.Add(new EmailUC(this));
                userControls.Add(new LoggerUC(this));
                //userControls.Add(new LoadingUC(this));
                userControls.Add(new FinishUC(this));
                logger.Info("UserControl Listesi Oluşturuldu.");
                //string[] sayi = { "1", "2", "3", "4", "5" };
                //MessageBox.Show(sayi[10]);
                this.Controls.Add(userControls[_step]);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

        }
        public void NextStep()
        {
            try
            {
                _step++;
                this.Controls.Clear();
                this.Controls.Add(userControls[_step]);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
        }

        public void BackStep()
        {
            try
            {
                _step--;
                this.Controls.Clear();
                this.Controls.Add(userControls[_step]);
                
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
        }

        public void ChangeStep(int step)
        {
            try
            {
                this.Controls.Clear();
                this.Controls.Add(userControls[step]);
                _step = step;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
        }

        public void InstallScript()
        {
            InstallToDestination(install.DestinationPath);
            Database database = new Database(install.DestinationPath, install);
            logger.Info("Program belirtilen dizine koplayandı.");
            Shortcuts();
        }

        private void Shortcuts()
        {
            Shortcut.CreateShortcut(install.DestinationPath + "\\Mso-Backup.exe", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            logger.Info("Programın kısayolu, Kullanıcının masaüstü klasörüne oluşturuldu.");
            if (install.StartOnStartup)
            {
                Shortcut.CreateStartupShortcut(install.DestinationPath + "\\Mso-Backup.exe");
                logger.Info("Windows başlangıcında çalıştırılması için gerekli kısayol oluşturuldu.");
            }
        }

        public void InstallToDestination(string destinationPath)
        {
            // Hedef Adresi Oluşturma
            if (!fileManagement.FolderExist(destinationPath))
            {
                fileManagement.CreateDirectory(destinationPath);
                logger.Info("Kurulum için belirtilen '{0}' hedef yol oluşturuldu.", destinationPath);
            }
            else
            {
                logger.Warn("Kurulum için belirtilen '{0}' hedef yol zaten mevcut...", destinationPath);
            }

            // Program dosyalarını Kopyalama
            List<FileInfo> fileInfos = fileManagement.GetFiles(Application.StartupPath);

            foreach (var item in fileInfos)
            {
                fileManagement.FileInformation(item);
            }
            fileManagement.AllCopyFileWithFolder(install.InstallLocation, destinationPath);
        }

    }
}
