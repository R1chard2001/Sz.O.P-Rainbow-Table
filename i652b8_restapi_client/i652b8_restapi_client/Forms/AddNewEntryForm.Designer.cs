
namespace i652b8_restapi_client
{
    partial class AddNewEntryForm
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
            this.passwordLbl = new System.Windows.Forms.Label();
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.md5Tb = new System.Windows.Forms.TextBox();
            this.md5hashLbl = new System.Windows.Forms.Label();
            this.sha1Tb = new System.Windows.Forms.TextBox();
            this.sha1hashLbl = new System.Windows.Forms.Label();
            this.sha256Tb = new System.Windows.Forms.TextBox();
            this.sha256hashLbl = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.autofillBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(12, 9);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(69, 17);
            this.passwordLbl.TabIndex = 0;
            this.passwordLbl.Text = "Password";
            // 
            // passwordTb
            // 
            this.passwordTb.Location = new System.Drawing.Point(15, 29);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.Size = new System.Drawing.Size(547, 22);
            this.passwordTb.TabIndex = 1;
            // 
            // md5Tb
            // 
            this.md5Tb.Location = new System.Drawing.Point(15, 79);
            this.md5Tb.Name = "md5Tb";
            this.md5Tb.Size = new System.Drawing.Size(547, 22);
            this.md5Tb.TabIndex = 3;
            // 
            // md5hashLbl
            // 
            this.md5hashLbl.AutoSize = true;
            this.md5hashLbl.Location = new System.Drawing.Point(12, 59);
            this.md5hashLbl.Name = "md5hashLbl";
            this.md5hashLbl.Size = new System.Drawing.Size(72, 17);
            this.md5hashLbl.TabIndex = 2;
            this.md5hashLbl.Text = "MD5 hash";
            // 
            // sha1Tb
            // 
            this.sha1Tb.Location = new System.Drawing.Point(15, 134);
            this.sha1Tb.Name = "sha1Tb";
            this.sha1Tb.Size = new System.Drawing.Size(547, 22);
            this.sha1Tb.TabIndex = 5;
            // 
            // sha1hashLbl
            // 
            this.sha1hashLbl.AutoSize = true;
            this.sha1hashLbl.Location = new System.Drawing.Point(12, 114);
            this.sha1hashLbl.Name = "sha1hashLbl";
            this.sha1hashLbl.Size = new System.Drawing.Size(79, 17);
            this.sha1hashLbl.TabIndex = 4;
            this.sha1hashLbl.Text = "SHA1 hash";
            // 
            // sha256Tb
            // 
            this.sha256Tb.Location = new System.Drawing.Point(15, 188);
            this.sha256Tb.Name = "sha256Tb";
            this.sha256Tb.Size = new System.Drawing.Size(547, 22);
            this.sha256Tb.TabIndex = 7;
            // 
            // sha256hashLbl
            // 
            this.sha256hashLbl.AutoSize = true;
            this.sha256hashLbl.Location = new System.Drawing.Point(12, 168);
            this.sha256hashLbl.Name = "sha256hashLbl";
            this.sha256hashLbl.Size = new System.Drawing.Size(95, 17);
            this.sha256hashLbl.TabIndex = 6;
            this.sha256hashLbl.Text = "SHA256 hash";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(179, 237);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 30);
            this.addBtn.TabIndex = 8;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(260, 237);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(75, 30);
            this.resetBtn.TabIndex = 9;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(341, 237);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 30);
            this.cancelBtn.TabIndex = 10;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // autofillBtn
            // 
            this.autofillBtn.Location = new System.Drawing.Point(179, 273);
            this.autofillBtn.Name = "autofillBtn";
            this.autofillBtn.Size = new System.Drawing.Size(237, 30);
            this.autofillBtn.TabIndex = 11;
            this.autofillBtn.Text = "Autofill hashes";
            this.autofillBtn.UseVisualStyleBackColor = true;
            this.autofillBtn.Click += new System.EventHandler(this.autofillBtn_Click);
            // 
            // AddNewEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 315);
            this.Controls.Add(this.autofillBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.sha256Tb);
            this.Controls.Add(this.sha256hashLbl);
            this.Controls.Add(this.sha1Tb);
            this.Controls.Add(this.sha1hashLbl);
            this.Controls.Add(this.md5Tb);
            this.Controls.Add(this.md5hashLbl);
            this.Controls.Add(this.passwordTb);
            this.Controls.Add(this.passwordLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddNewEntryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddNewEntryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.TextBox passwordTb;
        private System.Windows.Forms.TextBox md5Tb;
        private System.Windows.Forms.Label md5hashLbl;
        private System.Windows.Forms.TextBox sha1Tb;
        private System.Windows.Forms.Label sha1hashLbl;
        private System.Windows.Forms.TextBox sha256Tb;
        private System.Windows.Forms.Label sha256hashLbl;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button autofillBtn;
    }
}