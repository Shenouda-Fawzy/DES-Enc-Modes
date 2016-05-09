namespace Cipher_Modes
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.browsImage = new System.Windows.Forms.Button();
            this.imgPath_txt = new System.Windows.Forms.TextBox();
            this.ECBBtn = new System.Windows.Forms.Button();
            this.CBCBtn = new System.Windows.Forms.Button();
            this.CFBBtn = new System.Windows.Forms.Button();
            this.OFBBtn = new System.Windows.Forms.Button();
            this.CTRBtn = new System.Windows.Forms.Button();
            this.OriginalPicBox = new System.Windows.Forms.PictureBox();
            this.EncryptedPicBox = new System.Windows.Forms.PictureBox();
            this.ChageKeyBtn = new System.Windows.Forms.Button();
            this.ChangeIVBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.keyLabel = new System.Windows.Forms.Label();
            this.ivLable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EncryptedPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // browsImage
            // 
            this.browsImage.Location = new System.Drawing.Point(679, 45);
            this.browsImage.Name = "browsImage";
            this.browsImage.Size = new System.Drawing.Size(157, 31);
            this.browsImage.TabIndex = 0;
            this.browsImage.Text = "Brows BMP Gray Pic";
            this.browsImage.UseVisualStyleBackColor = true;
            this.browsImage.Click += new System.EventHandler(this.button1_Click);
            // 
            // imgPath_txt
            // 
            this.imgPath_txt.Location = new System.Drawing.Point(27, 45);
            this.imgPath_txt.Multiline = true;
            this.imgPath_txt.Name = "imgPath_txt";
            this.imgPath_txt.Size = new System.Drawing.Size(602, 31);
            this.imgPath_txt.TabIndex = 1;
            // 
            // ECBBtn
            // 
            this.ECBBtn.Location = new System.Drawing.Point(680, 127);
            this.ECBBtn.Name = "ECBBtn";
            this.ECBBtn.Size = new System.Drawing.Size(156, 33);
            this.ECBBtn.TabIndex = 2;
            this.ECBBtn.Text = "ECB Mode";
            this.ECBBtn.UseVisualStyleBackColor = true;
            this.ECBBtn.Click += new System.EventHandler(this.checkButton);
            // 
            // CBCBtn
            // 
            this.CBCBtn.Location = new System.Drawing.Point(680, 170);
            this.CBCBtn.Name = "CBCBtn";
            this.CBCBtn.Size = new System.Drawing.Size(156, 33);
            this.CBCBtn.TabIndex = 2;
            this.CBCBtn.Text = "CBC Mode";
            this.CBCBtn.UseVisualStyleBackColor = true;
            this.CBCBtn.Click += new System.EventHandler(this.checkButton);
            // 
            // CFBBtn
            // 
            this.CFBBtn.Location = new System.Drawing.Point(680, 213);
            this.CFBBtn.Name = "CFBBtn";
            this.CFBBtn.Size = new System.Drawing.Size(156, 33);
            this.CFBBtn.TabIndex = 2;
            this.CFBBtn.Text = "CFB Mode";
            this.CFBBtn.UseVisualStyleBackColor = true;
            this.CFBBtn.Click += new System.EventHandler(this.checkButton);
            // 
            // OFBBtn
            // 
            this.OFBBtn.Location = new System.Drawing.Point(679, 256);
            this.OFBBtn.Name = "OFBBtn";
            this.OFBBtn.Size = new System.Drawing.Size(156, 33);
            this.OFBBtn.TabIndex = 2;
            this.OFBBtn.Text = "OFB Mode";
            this.OFBBtn.UseVisualStyleBackColor = true;
            this.OFBBtn.Click += new System.EventHandler(this.OFBBtn_Click);
            // 
            // CTRBtn
            // 
            this.CTRBtn.Location = new System.Drawing.Point(679, 299);
            this.CTRBtn.Name = "CTRBtn";
            this.CTRBtn.Size = new System.Drawing.Size(156, 33);
            this.CTRBtn.TabIndex = 2;
            this.CTRBtn.Text = "CTR Mode";
            this.CTRBtn.UseVisualStyleBackColor = true;
            this.CTRBtn.Click += new System.EventHandler(this.CTRBtn_Click);
            // 
            // OriginalPicBox
            // 
            this.OriginalPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OriginalPicBox.Location = new System.Drawing.Point(65, 109);
            this.OriginalPicBox.Name = "OriginalPicBox";
            this.OriginalPicBox.Size = new System.Drawing.Size(266, 223);
            this.OriginalPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OriginalPicBox.TabIndex = 3;
            this.OriginalPicBox.TabStop = false;
            // 
            // EncryptedPicBox
            // 
            this.EncryptedPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EncryptedPicBox.Location = new System.Drawing.Point(363, 109);
            this.EncryptedPicBox.Name = "EncryptedPicBox";
            this.EncryptedPicBox.Size = new System.Drawing.Size(266, 223);
            this.EncryptedPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EncryptedPicBox.TabIndex = 3;
            this.EncryptedPicBox.TabStop = false;
            // 
            // ChageKeyBtn
            // 
            this.ChageKeyBtn.Location = new System.Drawing.Point(65, 406);
            this.ChageKeyBtn.Name = "ChageKeyBtn";
            this.ChageKeyBtn.Size = new System.Drawing.Size(156, 33);
            this.ChageKeyBtn.TabIndex = 2;
            this.ChageKeyBtn.Text = "Change Key";
            this.ChageKeyBtn.UseVisualStyleBackColor = true;
            this.ChageKeyBtn.Click += new System.EventHandler(this.ChageKeyBtn_Click);
            // 
            // ChangeIVBtn
            // 
            this.ChangeIVBtn.Location = new System.Drawing.Point(260, 406);
            this.ChangeIVBtn.Name = "ChangeIVBtn";
            this.ChangeIVBtn.Size = new System.Drawing.Size(156, 33);
            this.ChangeIVBtn.TabIndex = 2;
            this.ChangeIVBtn.Text = "Change IV";
            this.ChangeIVBtn.UseVisualStyleBackColor = true;
            this.ChangeIVBtn.Click += new System.EventHandler(this.ChangeIVBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(549, 406);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(80, 33);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Location = new System.Drawing.Point(65, 446);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(28, 13);
            this.keyLabel.TabIndex = 4;
            this.keyLabel.Text = "key:";
            // 
            // ivLable
            // 
            this.ivLable.AutoSize = true;
            this.ivLable.Location = new System.Drawing.Point(65, 479);
            this.ivLable.Name = "ivLable";
            this.ivLable.Size = new System.Drawing.Size(24, 13);
            this.ivLable.TabIndex = 4;
            this.ivLable.Text = "IV: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 501);
            this.Controls.Add(this.ivLable);
            this.Controls.Add(this.keyLabel);
            this.Controls.Add(this.EncryptedPicBox);
            this.Controls.Add(this.OriginalPicBox);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.ChangeIVBtn);
            this.Controls.Add(this.ChageKeyBtn);
            this.Controls.Add(this.CTRBtn);
            this.Controls.Add(this.OFBBtn);
            this.Controls.Add(this.CFBBtn);
            this.Controls.Add(this.CBCBtn);
            this.Controls.Add(this.ECBBtn);
            this.Controls.Add(this.imgPath_txt);
            this.Controls.Add(this.browsImage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EncryptedPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browsImage;
        private System.Windows.Forms.TextBox imgPath_txt;
        private System.Windows.Forms.Button ECBBtn;
        private System.Windows.Forms.Button CBCBtn;
        private System.Windows.Forms.Button CFBBtn;
        private System.Windows.Forms.Button OFBBtn;
        private System.Windows.Forms.Button CTRBtn;
        private System.Windows.Forms.PictureBox OriginalPicBox;
        private System.Windows.Forms.PictureBox EncryptedPicBox;
        private System.Windows.Forms.Button ChageKeyBtn;
        private System.Windows.Forms.Button ChangeIVBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.Label ivLable;
    }
}

