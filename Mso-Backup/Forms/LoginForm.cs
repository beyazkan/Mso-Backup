﻿using Mso_Backup.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mso_Backup
{
    public partial class LoginForm : Form
    {
        Database database;

        public LoginForm()
        {
            InitializeComponent();
            database = new Database();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnPasswordReset_Click(object sender, EventArgs e)
        {

        }
    }
}
