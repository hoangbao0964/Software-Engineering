namespace Project_BookCoffeeManagement.GUI
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.bunifuCustomTextbox_Username = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel_Username = new ns1.BunifuCustomLabel();
            this.bunifuCustomTextbox_Password = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel_Password = new ns1.BunifuCustomLabel();
            this.bunifuThinButton_Login = new ns1.BunifuThinButton2();
            this.bunifuCustomLabel_ForgotPassword = new ns1.BunifuCustomLabel();
            this.panel_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_Close)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Header
            // 
            this.panel_Header.Size = new System.Drawing.Size(278, 53);
            // 
            // bunifuImageButton_Close
            // 
            this.bunifuImageButton_Close.Location = new System.Drawing.Point(228, 3);
            // 
            // bunifuCustomTextbox_Username
            // 
            this.bunifuCustomTextbox_Username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuCustomTextbox_Username.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.bunifuCustomTextbox_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuCustomTextbox_Username.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bunifuCustomTextbox_Username.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomTextbox_Username.Location = new System.Drawing.Point(30, 100);
            this.bunifuCustomTextbox_Username.Name = "bunifuCustomTextbox_Username";
            this.bunifuCustomTextbox_Username.Size = new System.Drawing.Size(227, 24);
            this.bunifuCustomTextbox_Username.TabIndex = 87;
            this.bunifuCustomTextbox_Username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bunifuCustomTextbox_Username_KeyDown);
            // 
            // bunifuCustomLabel_Username
            // 
            this.bunifuCustomLabel_Username.AutoSize = true;
            this.bunifuCustomLabel_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_Username.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_Username.Location = new System.Drawing.Point(15, 70);
            this.bunifuCustomLabel_Username.Name = "bunifuCustomLabel_Username";
            this.bunifuCustomLabel_Username.Size = new System.Drawing.Size(91, 20);
            this.bunifuCustomLabel_Username.TabIndex = 86;
            this.bunifuCustomLabel_Username.Text = "Username :";
            // 
            // bunifuCustomTextbox_Password
            // 
            this.bunifuCustomTextbox_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuCustomTextbox_Password.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.bunifuCustomTextbox_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuCustomTextbox_Password.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bunifuCustomTextbox_Password.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomTextbox_Password.Location = new System.Drawing.Point(30, 170);
            this.bunifuCustomTextbox_Password.Name = "bunifuCustomTextbox_Password";
            this.bunifuCustomTextbox_Password.Size = new System.Drawing.Size(227, 24);
            this.bunifuCustomTextbox_Password.TabIndex = 89;
            this.bunifuCustomTextbox_Password.UseSystemPasswordChar = true;
            this.bunifuCustomTextbox_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bunifuCustomTextbox_Password_KeyDown);
            // 
            // bunifuCustomLabel_Password
            // 
            this.bunifuCustomLabel_Password.AutoSize = true;
            this.bunifuCustomLabel_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_Password.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_Password.Location = new System.Drawing.Point(15, 138);
            this.bunifuCustomLabel_Password.Name = "bunifuCustomLabel_Password";
            this.bunifuCustomLabel_Password.Size = new System.Drawing.Size(86, 20);
            this.bunifuCustomLabel_Password.TabIndex = 88;
            this.bunifuCustomLabel_Password.Text = "Password :";
            // 
            // bunifuThinButton_Login
            // 
            this.bunifuThinButton_Login.ActiveBorderThickness = 1;
            this.bunifuThinButton_Login.ActiveCornerRadius = 20;
            this.bunifuThinButton_Login.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.bunifuThinButton_Login.ActiveForecolor = System.Drawing.Color.White;
            this.bunifuThinButton_Login.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bunifuThinButton_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuThinButton_Login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton_Login.BackgroundImage")));
            this.bunifuThinButton_Login.ButtonText = "Login";
            this.bunifuThinButton_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton_Login.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton_Login.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton_Login.IdleBorderThickness = 1;
            this.bunifuThinButton_Login.IdleCornerRadius = 20;
            this.bunifuThinButton_Login.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bunifuThinButton_Login.IdleForecolor = System.Drawing.Color.White;
            this.bunifuThinButton_Login.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bunifuThinButton_Login.Location = new System.Drawing.Point(46, 204);
            this.bunifuThinButton_Login.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuThinButton_Login.Name = "bunifuThinButton_Login";
            this.bunifuThinButton_Login.Size = new System.Drawing.Size(181, 41);
            this.bunifuThinButton_Login.TabIndex = 90;
            this.bunifuThinButton_Login.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton_Login.Click += new System.EventHandler(this.bunifuThinButton_Login_Click);
            // 
            // bunifuCustomLabel_ForgotPassword
            // 
            this.bunifuCustomLabel_ForgotPassword.AutoSize = true;
            this.bunifuCustomLabel_ForgotPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuCustomLabel_ForgotPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline);
            this.bunifuCustomLabel_ForgotPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bunifuCustomLabel_ForgotPassword.Location = new System.Drawing.Point(129, 252);
            this.bunifuCustomLabel_ForgotPassword.Name = "bunifuCustomLabel_ForgotPassword";
            this.bunifuCustomLabel_ForgotPassword.Size = new System.Drawing.Size(137, 20);
            this.bunifuCustomLabel_ForgotPassword.TabIndex = 91;
            this.bunifuCustomLabel_ForgotPassword.Text = "Forgot password?";
            this.bunifuCustomLabel_ForgotPassword.Click += new System.EventHandler(this.bunifuCustomLabel_ForgotPassword_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 281);
            this.Controls.Add(this.bunifuCustomLabel_ForgotPassword);
            this.Controls.Add(this.bunifuThinButton_Login);
            this.Controls.Add(this.bunifuCustomTextbox_Password);
            this.Controls.Add(this.bunifuCustomLabel_Password);
            this.Controls.Add(this.bunifuCustomTextbox_Username);
            this.Controls.Add(this.bunifuCustomLabel_Username);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.Controls.SetChildIndex(this.panel_Header, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_Username, 0);
            this.Controls.SetChildIndex(this.bunifuCustomTextbox_Username, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_Password, 0);
            this.Controls.SetChildIndex(this.bunifuCustomTextbox_Password, 0);
            this.Controls.SetChildIndex(this.bunifuThinButton_Login, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_ForgotPassword, 0);
            this.panel_Header.ResumeLayout(false);
            this.panel_Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_Close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsFormsControlLibrary1.BunifuCustomTextbox bunifuCustomTextbox_Username;
        private ns1.BunifuCustomLabel bunifuCustomLabel_Username;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox bunifuCustomTextbox_Password;
        private ns1.BunifuCustomLabel bunifuCustomLabel_Password;
        private ns1.BunifuThinButton2 bunifuThinButton_Login;
        private ns1.BunifuCustomLabel bunifuCustomLabel_ForgotPassword;
    }
}