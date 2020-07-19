using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NLog;
using System.IO;
using System.Threading;

namespace Mso_Backup.Formlar.Setup.UC
{
    public partial class LoadingUC : UserControl
    {
        SetupForm _parent;
        int percent;
        //int minimum;
        //int maximum;
        string labelPercent;
        //string fileFullName;
        FileManagement fileManagement = new FileManagement();
        Logger logger = LogManager.GetCurrentClassLogger();

        public LoadingUC(SetupForm parent)
        {
            InitializeComponent();
            percent = 0;
            //minimum = 0;
            //maximum = 100;
            labelPercent = "{0}%";
            _parent = parent;            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Yüklemeyi iptal etmek istediğinize emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if(dialogResult == DialogResult.Yes)
            {

                _parent.Controls.Clear();
                _parent.Controls.Add(new FailedUC());
            }
        }

        public void changePercent(int value, string fileFullName)
        {
            //percent = value * 100 / total;
            progressBar1.Value = value;
            percentInfo.Text = string.Format(labelPercent, percent);
            fileName.Text = fileFullName;
            //if(percent >= 100)
            //{
            //    _parent.NextStep();
            //}
        }

        public void Install()
        {
            // Hedef Adresi Oluşturma
            if (!fileManagement.FolderExist(_parent.install.DestinationPath))
            {
                fileManagement.CreateDirectory(_parent.install.DestinationPath);
                logger.Info("Kurulum için belirtilen '{0}' hedef yol oluşturuldu.", _parent.install.DestinationPath);
            }
            else
            {
                logger.Warn("Kurulum için belirtilen '{0}' hedef yol zaten mevcut...", _parent.install.DestinationPath);
            }

            // Program dosyalarını Kopyalama
            List<FileInfo> fileInfos = fileManagement.GetFiles(Application.StartupPath);

            foreach (var item in fileInfos)
            {
                fileManagement.FileInformation(item);
            }
            fileManagement.AllCopyForProgressBar(Application.StartupPath, _parent.install.DestinationPath, this);
        }

        private void LoadingUC_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(Install));
            thread.Start();
            percentInfo.Text = string.Format(labelPercent, 100);
            Thread.Sleep(3000);
            _parent.NextStep();

        }
    }
}
