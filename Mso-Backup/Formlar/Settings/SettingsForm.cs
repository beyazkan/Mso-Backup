using System.Windows.Forms;

namespace Mso_Backup.Formlar.Settings
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }
    }
}
