namespace Mso_Backup.Forms.Setup
{
    partial class EmailUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbxSmtpTestMail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxSmtpPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxSmtpUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxSSL = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxSmtpPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxSmtpServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tbxSmtpTestMail);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbxSmtpPassword);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbxSmtpUsername);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbxSSL);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxSmtpPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxSmtpServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 284);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "E-Posta Sunucu Ayarları";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Gönderilecek E-Posta Adresi :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Test Et...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbxSmtpTestMail
            // 
            this.tbxSmtpTestMail.Location = new System.Drawing.Point(12, 258);
            this.tbxSmtpTestMail.Name = "tbxSmtpTestMail";
            this.tbxSmtpTestMail.Size = new System.Drawing.Size(179, 20);
            this.tbxSmtpTestMail.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(267, 39);
            this.label7.TabIndex = 11;
            this.label7.Text = "Uyarı: Girilen bilgilerde herhangi bir hata olup olmadığını \r\ndenetlemeden bir so" +
    "nra ki adıma geçmeyiniz. \r\nAksi halde E-posta alamayacaksınız.";
            // 
            // tbxSmtpPassword
            // 
            this.tbxSmtpPassword.Location = new System.Drawing.Point(95, 173);
            this.tbxSmtpPassword.Name = "tbxSmtpPassword";
            this.tbxSmtpPassword.Size = new System.Drawing.Size(178, 20);
            this.tbxSmtpPassword.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Parola :";
            // 
            // tbxSmtpUsername
            // 
            this.tbxSmtpUsername.Location = new System.Drawing.Point(95, 147);
            this.tbxSmtpUsername.Name = "tbxSmtpUsername";
            this.tbxSmtpUsername.Size = new System.Drawing.Size(177, 20);
            this.tbxSmtpUsername.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Kullanıcı Adı :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(266, 39);
            this.label4.TabIndex = 6;
            this.label4.Text = "Not: Lütfen kullandığınız SMTP sunucusunun güvenlik \r\nayarlarını kontrol ediniz. " +
    "Aksi halde bu servis \r\nçalışmayacaktır.";
            // 
            // cbxSSL
            // 
            this.cbxSSL.AutoSize = true;
            this.cbxSSL.Checked = true;
            this.cbxSSL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSSL.Location = new System.Drawing.Point(121, 71);
            this.cbxSSL.Name = "cbxSSL";
            this.cbxSSL.Size = new System.Drawing.Size(47, 17);
            this.cbxSSL.TabIndex = 5;
            this.cbxSSL.Text = "Açık";
            this.cbxSSL.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "SSL Desteği :";
            // 
            // tbxSmtpPort
            // 
            this.tbxSmtpPort.Location = new System.Drawing.Point(121, 44);
            this.tbxSmtpPort.Name = "tbxSmtpPort";
            this.tbxSmtpPort.Size = new System.Drawing.Size(54, 20);
            this.tbxSmtpPort.TabIndex = 3;
            this.tbxSmtpPort.Text = "587";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Smtp Port :";
            // 
            // tbxSmtpServer
            // 
            this.tbxSmtpServer.Location = new System.Drawing.Point(121, 17);
            this.tbxSmtpServer.Name = "tbxSmtpServer";
            this.tbxSmtpServer.Size = new System.Drawing.Size(151, 20);
            this.tbxSmtpServer.TabIndex = 1;
            this.tbxSmtpServer.Text = "smtp.gmail.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Smtp Sunucu Adresi :";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(216, 293);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "İleri";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 294);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Geri";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // EmailUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.groupBox1);
            this.Name = "EmailUC";
            this.Size = new System.Drawing.Size(303, 324);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbxSmtpTestMail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxSmtpPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxSmtpUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbxSSL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxSmtpPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxSmtpServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
    }
}
