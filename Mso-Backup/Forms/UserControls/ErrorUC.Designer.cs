namespace Mso_Backup.Forms.UserControls
{
    partial class ErrorUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorUC));
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbxMessage = new System.Windows.Forms.RichTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription1 = new System.Windows.Forms.Label();
            this.lblDipnot = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.suggestItemUC1 = new Mso_Backup.Forms.UserControls.SuggestItemUC();
            this.errorItemUC1 = new Mso_Backup.Forms.UserControls.ErrorItemUC();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(272, 344);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Gönder";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(353, 344);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbxMessage
            // 
            this.tbxMessage.Location = new System.Drawing.Point(7, 237);
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.Size = new System.Drawing.Size(421, 79);
            this.tbxMessage.TabIndex = 2;
            this.tbxMessage.Text = "";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(7, 219);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(56, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Açıklama :";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.Location = new System.Drawing.Point(57, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(317, 24);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Üzgünüm bir sorunla karşılaştık...";
            // 
            // lblDescription1
            // 
            this.lblDescription1.AutoSize = true;
            this.lblDescription1.Location = new System.Drawing.Point(58, 40);
            this.lblDescription1.Name = "lblDescription1";
            this.lblDescription1.Size = new System.Drawing.Size(370, 78);
            this.lblDescription1.TabIndex = 6;
            this.lblDescription1.Text = resources.GetString("lblDescription1.Text");
            // 
            // lblDipnot
            // 
            this.lblDipnot.AutoSize = true;
            this.lblDipnot.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDipnot.Location = new System.Drawing.Point(8, 318);
            this.lblDipnot.Name = "lblDipnot";
            this.lblDipnot.Size = new System.Drawing.Size(410, 24);
            this.lblDipnot.TabIndex = 7;
            this.lblDipnot.Text = "Uyarı : Bu işlem ile gerekli sistem bilgisinin bir özeti ve programın log dosyala" +
    "rı tarafımızla paylaşmış \r\nolacaksınız.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Mso_Backup.Properties.Resources.icons8_cancel_40;
            this.pictureBox1.Location = new System.Drawing.Point(10, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 40);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // suggestItemUC1
            // 
            this.suggestItemUC1.Location = new System.Drawing.Point(10, 175);
            this.suggestItemUC1.Name = "suggestItemUC1";
            this.suggestItemUC1.Size = new System.Drawing.Size(412, 39);
            this.suggestItemUC1.TabIndex = 9;
            // 
            // errorItemUC1
            // 
            this.errorItemUC1.Location = new System.Drawing.Point(10, 121);
            this.errorItemUC1.Name = "errorItemUC1";
            this.errorItemUC1.Size = new System.Drawing.Size(412, 53);
            this.errorItemUC1.TabIndex = 8;
            // 
            // ErrorUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.suggestItemUC1);
            this.Controls.Add(this.errorItemUC1);
            this.Controls.Add(this.lblDipnot);
            this.Controls.Add(this.lblDescription1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbxMessage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSend);
            this.Name = "ErrorUC";
            this.Size = new System.Drawing.Size(434, 373);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RichTextBox tbxMessage;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription1;
        private System.Windows.Forms.Label lblDipnot;
        private ErrorItemUC errorItemUC1;
        private SuggestItemUC suggestItemUC1;
    }
}
