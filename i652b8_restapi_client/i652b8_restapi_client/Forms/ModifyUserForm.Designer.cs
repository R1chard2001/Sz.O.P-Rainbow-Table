
namespace i652b8_restapi_client
{
    partial class ModifyUserForm
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.isAdminCb = new System.Windows.Forms.CheckBox();
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.usernameTb = new System.Windows.Forms.TextBox();
            this.usernameLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(139, 152);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 30);
            this.cancelBtn.TabIndex = 13;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(58, 152);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 30);
            this.addBtn.TabIndex = 12;
            this.addBtn.Text = "Modify";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.modifyBtn_Click);
            // 
            // isAdminCb
            // 
            this.isAdminCb.AutoSize = true;
            this.isAdminCb.Location = new System.Drawing.Point(103, 125);
            this.isAdminCb.Name = "isAdminCb";
            this.isAdminCb.Size = new System.Drawing.Size(69, 21);
            this.isAdminCb.TabIndex = 11;
            this.isAdminCb.Text = "Admin";
            this.isAdminCb.UseVisualStyleBackColor = true;
            // 
            // passwordTb
            // 
            this.passwordTb.Location = new System.Drawing.Point(10, 88);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.PasswordChar = '*';
            this.passwordTb.Size = new System.Drawing.Size(277, 22);
            this.passwordTb.TabIndex = 10;
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(10, 68);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(69, 17);
            this.passwordLbl.TabIndex = 9;
            this.passwordLbl.Text = "Password";
            // 
            // usernameTb
            // 
            this.usernameTb.Location = new System.Drawing.Point(10, 30);
            this.usernameTb.Name = "usernameTb";
            this.usernameTb.Size = new System.Drawing.Size(277, 22);
            this.usernameTb.TabIndex = 8;
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.Location = new System.Drawing.Point(10, 10);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(73, 17);
            this.usernameLbl.TabIndex = 7;
            this.usernameLbl.Text = "Username";
            // 
            // ModifyUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 201);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.isAdminCb);
            this.Controls.Add(this.passwordTb);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.usernameTb);
            this.Controls.Add(this.usernameLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ModifyUserForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modify user";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.CheckBox isAdminCb;
        private System.Windows.Forms.TextBox passwordTb;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.TextBox usernameTb;
        private System.Windows.Forms.Label usernameLbl;
    }
}