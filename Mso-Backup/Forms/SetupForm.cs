using Mso_Backup.Forms.Setup;
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

namespace Mso_Backup.Forms
{
    public partial class SetupForm : Form
    {
        // Loglama Nesnesi
        Logger logger = LogManager.GetCurrentClassLogger();

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
                logger.Info("UserControl Listesi Oluşturuldu.");
                userControls.Add(new InstallUC(this));
                userControls.Add(new DestinationUC(this));
                userControls.Add(new UserUC(this));
                userControls.Add(new EmailUC(this));
                userControls.Add(new LoggerUC(this));
                userControls.Add(new FinishUC(this));
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
    }
}
