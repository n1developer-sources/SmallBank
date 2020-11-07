namespace SmallBank.Windows
{
    partial class AccountPicker
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
            this.btnAddNewAccount = new System.Windows.Forms.Button();
            this.btnPickSharedAccount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddNewAccount
            // 
            this.btnAddNewAccount.BackColor = System.Drawing.Color.Green;
            this.btnAddNewAccount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddNewAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewAccount.ForeColor = System.Drawing.Color.White;
            this.btnAddNewAccount.Location = new System.Drawing.Point(0, 38);
            this.btnAddNewAccount.Name = "btnAddNewAccount";
            this.btnAddNewAccount.Size = new System.Drawing.Size(277, 38);
            this.btnAddNewAccount.TabIndex = 1;
            this.btnAddNewAccount.Text = "Add New Account";
            this.btnAddNewAccount.UseVisualStyleBackColor = false;
            this.btnAddNewAccount.Click += new System.EventHandler(this.btnAddNewAccount_Click);
            // 
            // btnPickSharedAccount
            // 
            this.btnPickSharedAccount.BackColor = System.Drawing.Color.Green;
            this.btnPickSharedAccount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPickSharedAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickSharedAccount.ForeColor = System.Drawing.Color.White;
            this.btnPickSharedAccount.Location = new System.Drawing.Point(0, 0);
            this.btnPickSharedAccount.Name = "btnPickSharedAccount";
            this.btnPickSharedAccount.Size = new System.Drawing.Size(277, 38);
            this.btnPickSharedAccount.TabIndex = 2;
            this.btnPickSharedAccount.Text = "Pick Existing Shared Account";
            this.btnPickSharedAccount.UseVisualStyleBackColor = false;
            this.btnPickSharedAccount.Click += new System.EventHandler(this.btnPickSharedAccount_Click);
            // 
            // AccountPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 76);
            this.Controls.Add(this.btnPickSharedAccount);
            this.Controls.Add(this.btnAddNewAccount);
            this.Name = "AccountPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AccountPicker";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewAccount;
        private System.Windows.Forms.Button btnPickSharedAccount;
    }
}