namespace Mso_Backup.Formlar.UC
{
    partial class DiskUC
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblDriveLetter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFreeSpace = new System.Windows.Forms.Label();
            this.btnOnline = new System.Windows.Forms.Button();
            this.btnOffline = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Mso_Backup.Properties.Resources.external_disk;
            this.pictureBox1.Location = new System.Drawing.Point(5, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 48);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(51, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(285, 11);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Value = 70;
            // 
            // lblDriveLetter
            // 
            this.lblDriveLetter.AutoSize = true;
            this.lblDriveLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDriveLetter.Location = new System.Drawing.Point(51, 18);
            this.lblDriveLetter.Name = "lblDriveLetter";
            this.lblDriveLetter.Size = new System.Drawing.Size(22, 13);
            this.lblDriveLetter.TabIndex = 2;
            this.lblDriveLetter.Text = "F: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Boş Alan :";
            // 
            // lblFreeSpace
            // 
            this.lblFreeSpace.AutoSize = true;
            this.lblFreeSpace.Location = new System.Drawing.Point(296, 18);
            this.lblFreeSpace.Name = "lblFreeSpace";
            this.lblFreeSpace.Size = new System.Drawing.Size(37, 13);
            this.lblFreeSpace.TabIndex = 4;
            this.lblFreeSpace.Text = "15 GB";
            // 
            // btnOnline
            // 
            this.btnOnline.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F);
            this.btnOnline.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOnline.Location = new System.Drawing.Point(54, 34);
            this.btnOnline.Name = "btnOnline";
            this.btnOnline.Size = new System.Drawing.Size(67, 18);
            this.btnOnline.TabIndex = 5;
            this.btnOnline.Text = "Online";
            this.btnOnline.UseVisualStyleBackColor = true;
            this.btnOnline.Click += new System.EventHandler(this.btnOnline_Click);
            // 
            // btnOffline
            // 
            this.btnOffline.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOffline.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F);
            this.btnOffline.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOffline.Location = new System.Drawing.Point(127, 34);
            this.btnOffline.Name = "btnOffline";
            this.btnOffline.Size = new System.Drawing.Size(67, 18);
            this.btnOffline.TabIndex = 6;
            this.btnOffline.Text = "Offline";
            this.btnOffline.UseVisualStyleBackColor = true;
            this.btnOffline.Click += new System.EventHandler(this.btnOffline_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F);
            this.btnRemove.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRemove.Location = new System.Drawing.Point(269, 34);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(67, 18);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(67, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(175, 13);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "lblName";
            // 
            // DiskUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnOffline);
            this.Controls.Add(this.btnOnline);
            this.Controls.Add(this.lblFreeSpace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDriveLetter);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "DiskUC";
            this.Size = new System.Drawing.Size(339, 55);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblDriveLetter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFreeSpace;
        private System.Windows.Forms.Button btnOnline;
        private System.Windows.Forms.Button btnOffline;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblName;
    }
}
