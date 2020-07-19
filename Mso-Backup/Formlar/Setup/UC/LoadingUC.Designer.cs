namespace Mso_Backup.Formlar.Setup.UC
{
    partial class LoadingUC
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.fileName = new System.Windows.Forms.Label();
            this.percentInfo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(17, 26);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(348, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fileName.Location = new System.Drawing.Point(15, 52);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(81, 9);
            this.fileName.TabIndex = 1;
            this.fileName.Text = "Kopyalanan Dosya Adı";
            // 
            // percentInfo
            // 
            this.percentInfo.AutoSize = true;
            this.percentInfo.BackColor = System.Drawing.Color.Transparent;
            this.percentInfo.Location = new System.Drawing.Point(166, 31);
            this.percentInfo.Name = "percentInfo";
            this.percentInfo.Size = new System.Drawing.Size(27, 13);
            this.percentInfo.TabIndex = 2;
            this.percentInfo.Text = "00%";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(154, 74);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LoadingUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.percentInfo);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.progressBar1);
            this.Name = "LoadingUC";
            this.Size = new System.Drawing.Size(380, 104);
            this.Load += new System.EventHandler(this.LoadingUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.Label percentInfo;
        private System.Windows.Forms.Button btnCancel;
    }
}
