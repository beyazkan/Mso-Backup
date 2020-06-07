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
    public partial class LoadingUC : UserControl
    {
        SetupForm _parent;
        int percent;
        int minimum;
        int maximum;
        string labelPercent;
        string fileFullName;

        public LoadingUC(SetupForm parent)
        {
            InitializeComponent();
            percent = 0;
            minimum = 0;
            maximum = 100;
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

        private void changePercent()
        {
            


        }
    }
}
