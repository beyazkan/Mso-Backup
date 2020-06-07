using Mso_Backup.Forms.Setup;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mso_Backup.Forms
{
    public partial class SetupForm : Form
    {
        // Loglama Nesnesi
        Logger logger = LogManager.GetCurrentClassLogger();
        FileManagement fileManagement = new FileManagement();
        public string destinationPath;

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
                userControls = new List<UserControl>();
                userControls.Add(new InstallUC(this));
                userControls.Add(new DestinationUC(this));
                userControls.Add(new UserUC(this));
                userControls.Add(new EmailUC(this));
                userControls.Add(new LoggerUC(this));
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
            InstallToDestination();
        }
        public void InstallToDestination()
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
            fileManagement.AllCopyFileWithFolder(Application.StartupPath, destinationPath);
        }
    }
}
