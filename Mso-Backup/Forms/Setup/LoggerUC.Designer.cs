namespace Mso_Backup.Forms.Setup
{
    partial class LoggerUC
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxWarn = new System.Windows.Forms.CheckBox();
            this.cbxInfo = new System.Windows.Forms.CheckBox();
            this.cbxSuccess = new System.Windows.Forms.CheckBox();
            this.cbxError = new System.Windows.Forms.CheckBox();
            this.cbxEmail = new System.Windows.Forms.CheckBox();
            this.cbxTextFile = new System.Windows.Forms.CheckBox();
            this.cbxDatabase = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cbxEmail);
            this.groupBox1.Controls.Add(this.cbxTextFile);
            this.groupBox1.Controls.Add(this.cbxDatabase);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loglama Ayarları";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxWarn);
            this.groupBox2.Controls.Add(this.cbxInfo);
            this.groupBox2.Controls.Add(this.cbxSuccess);
            this.groupBox2.Controls.Add(this.cbxError);
            this.groupBox2.Location = new System.Drawing.Point(10, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 48);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "E-Posta Loglama Seçenekleri";
            // 
            // cbxWarn
            // 
            this.cbxWarn.AutoSize = true;
            this.cbxWarn.Location = new System.Drawing.Point(183, 19);
            this.cbxWarn.Name = "cbxWarn";
            this.cbxWarn.Size = new System.Drawing.Size(50, 17);
            this.cbxWarn.TabIndex = 3;
            this.cbxWarn.Text = "Uyarı";
            this.cbxWarn.UseVisualStyleBackColor = true;
            // 
            // cbxInfo
            // 
            this.cbxInfo.AutoSize = true;
            this.cbxInfo.Location = new System.Drawing.Point(131, 19);
            this.cbxInfo.Name = "cbxInfo";
            this.cbxInfo.Size = new System.Drawing.Size(45, 17);
            this.cbxInfo.TabIndex = 2;
            this.cbxInfo.Text = "Bilgi";
            this.cbxInfo.UseVisualStyleBackColor = true;
            // 
            // cbxSuccess
            // 
            this.cbxSuccess.AutoSize = true;
            this.cbxSuccess.Location = new System.Drawing.Point(69, 19);
            this.cbxSuccess.Name = "cbxSuccess";
            this.cbxSuccess.Size = new System.Drawing.Size(55, 17);
            this.cbxSuccess.TabIndex = 1;
            this.cbxSuccess.Text = "Başarı";
            this.cbxSuccess.UseVisualStyleBackColor = true;
            // 
            // cbxError
            // 
            this.cbxError.AutoSize = true;
            this.cbxError.Location = new System.Drawing.Point(14, 19);
            this.cbxError.Name = "cbxError";
            this.cbxError.Size = new System.Drawing.Size(49, 17);
            this.cbxError.TabIndex = 0;
            this.cbxError.Text = "Hata";
            this.cbxError.UseVisualStyleBackColor = true;
            // 
            // cbxEmail
            // 
            this.cbxEmail.AutoSize = true;
            this.cbxEmail.Location = new System.Drawing.Point(8, 108);
            this.cbxEmail.Name = "cbxEmail";
            this.cbxEmail.Size = new System.Drawing.Size(63, 17);
            this.cbxEmail.TabIndex = 3;
            this.cbxEmail.Text = "E-Posta";
            this.cbxEmail.UseVisualStyleBackColor = true;
            // 
            // cbxTextFile
            // 
            this.cbxTextFile.AutoSize = true;
            this.cbxTextFile.Location = new System.Drawing.Point(10, 84);
            this.cbxTextFile.Name = "cbxTextFile";
            this.cbxTextFile.Size = new System.Drawing.Size(92, 17);
            this.cbxTextFile.TabIndex = 2;
            this.cbxTextFile.Text = "Metin Dosyası";
            this.cbxTextFile.UseVisualStyleBackColor = true;
            // 
            // cbxDatabase
            // 
            this.cbxDatabase.AutoSize = true;
            this.cbxDatabase.Location = new System.Drawing.Point(10, 60);
            this.cbxDatabase.Name = "cbxDatabase";
            this.cbxDatabase.Size = new System.Drawing.Size(73, 17);
            this.cbxDatabase.TabIndex = 1;
            this.cbxDatabase.Text = "Veritabanı";
            this.cbxDatabase.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bu adımda loglama yöntemini belirmeniz gerekiyor. \r\nBirden fazla loglama yöntemin" +
    "i tercih edebilirsiniz.";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(206, 197);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Kur";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(9, 197);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Geri";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // LoggerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.groupBox1);
            this.Name = "LoggerUC";
            this.Size = new System.Drawing.Size(288, 226);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbxWarn;
        private System.Windows.Forms.CheckBox cbxInfo;
        private System.Windows.Forms.CheckBox cbxSuccess;
        private System.Windows.Forms.CheckBox cbxError;
        private System.Windows.Forms.CheckBox cbxEmail;
        private System.Windows.Forms.CheckBox cbxTextFile;
        private System.Windows.Forms.CheckBox cbxDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
    }
}
