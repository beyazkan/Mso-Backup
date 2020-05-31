namespace Mso_Backup
{
    partial class DriversForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.DepolamaCihazlariBtn = new System.Windows.Forms.Button();
            this.OnlineBtn = new System.Windows.Forms.Button();
            this.OfflineBtn = new System.Windows.Forms.Button();
            this.gbxDiskBilgileri = new System.Windows.Forms.GroupBox();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.lblSerialNumberText = new System.Windows.Forms.Label();
            this.lblFreeSpace = new System.Windows.Forms.Label();
            this.lblFreeSpaceText = new System.Windows.Forms.Label();
            this.gbxDiskBilgileri.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(13, 40);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(399, 94);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // DepolamaCihazlariBtn
            // 
            this.DepolamaCihazlariBtn.Location = new System.Drawing.Point(13, 12);
            this.DepolamaCihazlariBtn.Name = "DepolamaCihazlariBtn";
            this.DepolamaCihazlariBtn.Size = new System.Drawing.Size(130, 23);
            this.DepolamaCihazlariBtn.TabIndex = 1;
            this.DepolamaCihazlariBtn.Text = "Depolama Cihazları";
            this.DepolamaCihazlariBtn.UseVisualStyleBackColor = true;
            this.DepolamaCihazlariBtn.Click += new System.EventHandler(this.DepolamaCihazlariBtn_Click);
            // 
            // OnlineBtn
            // 
            this.OnlineBtn.Location = new System.Drawing.Point(150, 12);
            this.OnlineBtn.Name = "OnlineBtn";
            this.OnlineBtn.Size = new System.Drawing.Size(75, 23);
            this.OnlineBtn.TabIndex = 2;
            this.OnlineBtn.Text = "Online";
            this.OnlineBtn.UseVisualStyleBackColor = true;
            this.OnlineBtn.Click += new System.EventHandler(this.OnlineBtn_Click);
            // 
            // OfflineBtn
            // 
            this.OfflineBtn.Location = new System.Drawing.Point(232, 12);
            this.OfflineBtn.Name = "OfflineBtn";
            this.OfflineBtn.Size = new System.Drawing.Size(75, 23);
            this.OfflineBtn.TabIndex = 3;
            this.OfflineBtn.Text = "Offline";
            this.OfflineBtn.UseVisualStyleBackColor = true;
            this.OfflineBtn.Click += new System.EventHandler(this.OfflineBtn_Click);
            // 
            // gbxDiskBilgileri
            // 
            this.gbxDiskBilgileri.Controls.Add(this.lblSerialNumber);
            this.gbxDiskBilgileri.Controls.Add(this.lblSerialNumberText);
            this.gbxDiskBilgileri.Controls.Add(this.lblFreeSpace);
            this.gbxDiskBilgileri.Controls.Add(this.lblFreeSpaceText);
            this.gbxDiskBilgileri.Location = new System.Drawing.Point(13, 146);
            this.gbxDiskBilgileri.Name = "gbxDiskBilgileri";
            this.gbxDiskBilgileri.Size = new System.Drawing.Size(398, 72);
            this.gbxDiskBilgileri.TabIndex = 4;
            this.gbxDiskBilgileri.TabStop = false;
            this.gbxDiskBilgileri.Text = "Disk Bilgileri";
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoSize = true;
            this.lblSerialNumber.Location = new System.Drawing.Point(92, 45);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(0, 13);
            this.lblSerialNumber.TabIndex = 3;
            // 
            // lblSerialNumberText
            // 
            this.lblSerialNumberText.AutoSize = true;
            this.lblSerialNumberText.Location = new System.Drawing.Point(7, 45);
            this.lblSerialNumberText.Name = "lblSerialNumberText";
            this.lblSerialNumberText.Size = new System.Drawing.Size(78, 13);
            this.lblSerialNumberText.TabIndex = 2;
            this.lblSerialNumberText.Text = "Seri Numarası :";
            // 
            // lblFreeSpace
            // 
            this.lblFreeSpace.AutoSize = true;
            this.lblFreeSpace.Location = new System.Drawing.Point(69, 19);
            this.lblFreeSpace.Name = "lblFreeSpace";
            this.lblFreeSpace.Size = new System.Drawing.Size(0, 13);
            this.lblFreeSpace.TabIndex = 1;
            // 
            // lblFreeSpaceText
            // 
            this.lblFreeSpaceText.AutoSize = true;
            this.lblFreeSpaceText.Location = new System.Drawing.Point(7, 20);
            this.lblFreeSpaceText.Name = "lblFreeSpaceText";
            this.lblFreeSpaceText.Size = new System.Drawing.Size(55, 13);
            this.lblFreeSpaceText.TabIndex = 0;
            this.lblFreeSpaceText.Text = "Boş Alan :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 230);
            this.Controls.Add(this.gbxDiskBilgileri);
            this.Controls.Add(this.OfflineBtn);
            this.Controls.Add(this.OnlineBtn);
            this.Controls.Add(this.DepolamaCihazlariBtn);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "Form1";
            this.Text = "Depolama Cihazları";
            this.gbxDiskBilgileri.ResumeLayout(false);
            this.gbxDiskBilgileri.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button DepolamaCihazlariBtn;
        private System.Windows.Forms.Button OnlineBtn;
        private System.Windows.Forms.Button OfflineBtn;
        private System.Windows.Forms.GroupBox gbxDiskBilgileri;
        private System.Windows.Forms.Label lblFreeSpaceText;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Label lblSerialNumberText;
        private System.Windows.Forms.Label lblFreeSpace;
    }
}

