
namespace i652b8_restapi_client
{
    partial class UsersForm
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
            this.components = new System.ComponentModel.Container();
            this.UsersDgv = new System.Windows.Forms.DataGridView();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.addNewBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UsersDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // UsersDgv
            // 
            this.UsersDgv.AllowUserToAddRows = false;
            this.UsersDgv.AllowUserToDeleteRows = false;
            this.UsersDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersDgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.UsersDgv.Location = new System.Drawing.Point(12, 12);
            this.UsersDgv.MultiSelect = false;
            this.UsersDgv.Name = "UsersDgv";
            this.UsersDgv.RowHeadersWidth = 51;
            this.UsersDgv.RowTemplate.Height = 24;
            this.UsersDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.UsersDgv.Size = new System.Drawing.Size(565, 426);
            this.UsersDgv.TabIndex = 0;
            // 
            // modifyBtn
            // 
            this.modifyBtn.Location = new System.Drawing.Point(583, 97);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(171, 30);
            this.modifyBtn.TabIndex = 7;
            this.modifyBtn.Text = "Modify selected user";
            this.modifyBtn.UseVisualStyleBackColor = true;
            this.modifyBtn.Click += new System.EventHandler(this.modifyBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(582, 133);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(171, 30);
            this.deleteBtn.TabIndex = 6;
            this.deleteBtn.Text = "Delete selected user";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(583, 61);
            this.addNewBtn.Name = "addNewBtn";
            this.addNewBtn.Size = new System.Drawing.Size(171, 30);
            this.addNewBtn.TabIndex = 5;
            this.addNewBtn.Text = "Add new user";
            this.addNewBtn.UseVisualStyleBackColor = true;
            this.addNewBtn.Click += new System.EventHandler(this.addNewBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(583, 12);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(171, 30);
            this.refreshBtn.TabIndex = 8;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 5000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 450);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.modifyBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.addNewBtn);
            this.Controls.Add(this.UsersDgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UsersForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UsersForm_FormClosing);
            this.Load += new System.EventHandler(this.UsersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UsersDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView UsersDgv;
        private System.Windows.Forms.Button modifyBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button addNewBtn;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Timer UpdateTimer;
    }
}