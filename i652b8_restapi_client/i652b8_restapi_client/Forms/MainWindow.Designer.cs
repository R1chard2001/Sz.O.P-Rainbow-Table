
namespace i652b8_restapi_client
{
    partial class MainWindow
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
            this.rainbowTableDgv = new System.Windows.Forms.DataGridView();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.addNewBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.userManagementBtn = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.filterTb = new System.Windows.Forms.TextBox();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rainbowTableDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // rainbowTableDgv
            // 
            this.rainbowTableDgv.AllowUserToAddRows = false;
            this.rainbowTableDgv.AllowUserToDeleteRows = false;
            this.rainbowTableDgv.AllowUserToResizeRows = false;
            this.rainbowTableDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rainbowTableDgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.rainbowTableDgv.Location = new System.Drawing.Point(12, 89);
            this.rainbowTableDgv.MultiSelect = false;
            this.rainbowTableDgv.Name = "rainbowTableDgv";
            this.rainbowTableDgv.RowHeadersWidth = 51;
            this.rainbowTableDgv.RowTemplate.Height = 24;
            this.rainbowTableDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.rainbowTableDgv.Size = new System.Drawing.Size(1285, 548);
            this.rainbowTableDgv.TabIndex = 0;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(12, 12);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(100, 30);
            this.refreshBtn.TabIndex = 1;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(118, 12);
            this.addNewBtn.Name = "addNewBtn";
            this.addNewBtn.Size = new System.Drawing.Size(146, 30);
            this.addNewBtn.TabIndex = 2;
            this.addNewBtn.Text = "Add new entry";
            this.addNewBtn.UseVisualStyleBackColor = true;
            this.addNewBtn.Click += new System.EventHandler(this.addNewBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(470, 12);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(208, 30);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Delete selected entry";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // modifyBtn
            // 
            this.modifyBtn.Location = new System.Drawing.Point(270, 12);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(194, 30);
            this.modifyBtn.TabIndex = 4;
            this.modifyBtn.Text = "Modify selected entry";
            this.modifyBtn.UseVisualStyleBackColor = true;
            this.modifyBtn.Click += new System.EventHandler(this.modifyBtn_Click);
            // 
            // userManagementBtn
            // 
            this.userManagementBtn.Location = new System.Drawing.Point(1132, 12);
            this.userManagementBtn.Name = "userManagementBtn";
            this.userManagementBtn.Size = new System.Drawing.Size(165, 30);
            this.userManagementBtn.TabIndex = 5;
            this.userManagementBtn.Text = "User management";
            this.userManagementBtn.UseVisualStyleBackColor = true;
            this.userManagementBtn.Click += new System.EventHandler(this.userManagementBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(1026, 12);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(100, 30);
            this.logoutBtn.TabIndex = 6;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(12, 48);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(82, 30);
            this.searchBtn.TabIndex = 7;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // filterTb
            // 
            this.filterTb.Location = new System.Drawing.Point(100, 52);
            this.filterTb.Name = "filterTb";
            this.filterTb.Size = new System.Drawing.Size(578, 22);
            this.filterTb.TabIndex = 8;
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 5000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 649);
            this.Controls.Add(this.filterTb);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.userManagementBtn);
            this.Controls.Add(this.modifyBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.addNewBtn);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.rainbowTableDgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rainbow table";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.rainbowTableDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView rainbowTableDgv;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button addNewBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button modifyBtn;
        private System.Windows.Forms.Button userManagementBtn;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox filterTb;
        private System.Windows.Forms.Timer UpdateTimer;
    }
}