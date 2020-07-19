using System.Threading;
using System.Windows.Forms;

namespace Mso_Backup.Formlar
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        public void LoadingUpdate(int value, string description)
        {
            progressBar1.Value = value;
            lblPercent.Text = value + "/100";
            lblAciklama.Text = description;
            Thread.Sleep(250);
        }
    }
}
