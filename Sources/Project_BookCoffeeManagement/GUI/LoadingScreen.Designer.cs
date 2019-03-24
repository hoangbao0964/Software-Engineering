namespace Project_BookCoffeeManagement.GUI
{
    partial class LoadingScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingScreen));
            this.bunifuCircleProgressbar_LoadingScreen = new ns1.BunifuCircleProgressbar();
            this.bunifuCustomLabel_Loading = new ns1.BunifuCustomLabel();
            this.panel_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_Close)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Header
            // 
            this.panel_Header.Size = new System.Drawing.Size(153, 53);
            this.panel_Header.Visible = false;
            // 
            // bunifuImageButton_Close
            // 
            this.bunifuImageButton_Close.Location = new System.Drawing.Point(251, -1);
            this.bunifuImageButton_Close.Visible = false;
            // 
            // bunifuCustomLabel_HeaderName
            // 
            this.bunifuCustomLabel_HeaderName.Size = new System.Drawing.Size(186, 34);
            this.bunifuCustomLabel_HeaderName.Text = "Please wait...";
            this.bunifuCustomLabel_HeaderName.Visible = false;
            // 
            // bunifuCircleProgressbar_LoadingScreen
            // 
            this.bunifuCircleProgressbar_LoadingScreen.animated = true;
            this.bunifuCircleProgressbar_LoadingScreen.animationIterval = 5;
            this.bunifuCircleProgressbar_LoadingScreen.animationSpeed = 10;
            this.bunifuCircleProgressbar_LoadingScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bunifuCircleProgressbar_LoadingScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCircleProgressbar_LoadingScreen.BackgroundImage")));
            this.bunifuCircleProgressbar_LoadingScreen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bunifuCircleProgressbar_LoadingScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.bunifuCircleProgressbar_LoadingScreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bunifuCircleProgressbar_LoadingScreen.LabelVisible = false;
            this.bunifuCircleProgressbar_LoadingScreen.LineProgressThickness = 8;
            this.bunifuCircleProgressbar_LoadingScreen.LineThickness = 5;
            this.bunifuCircleProgressbar_LoadingScreen.Location = new System.Drawing.Point(0, 0);
            this.bunifuCircleProgressbar_LoadingScreen.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.bunifuCircleProgressbar_LoadingScreen.MaxValue = 100;
            this.bunifuCircleProgressbar_LoadingScreen.Name = "bunifuCircleProgressbar_LoadingScreen";
            this.bunifuCircleProgressbar_LoadingScreen.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.bunifuCircleProgressbar_LoadingScreen.ProgressColor = System.Drawing.Color.White;
            this.bunifuCircleProgressbar_LoadingScreen.Size = new System.Drawing.Size(153, 153);
            this.bunifuCircleProgressbar_LoadingScreen.TabIndex = 1;
            this.bunifuCircleProgressbar_LoadingScreen.Value = 0;
            this.bunifuCircleProgressbar_LoadingScreen.ProgressChanged += new System.EventHandler(this.bunifuCircleProgressbar_LoadingScreen_ProgressChanged);
            // 
            // bunifuCustomLabel_Loading
            // 
            this.bunifuCustomLabel_Loading.AutoSize = true;
            this.bunifuCustomLabel_Loading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bunifuCustomLabel_Loading.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.bunifuCustomLabel_Loading.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel_Loading.Location = new System.Drawing.Point(27, 66);
            this.bunifuCustomLabel_Loading.Name = "bunifuCustomLabel_Loading";
            this.bunifuCustomLabel_Loading.Size = new System.Drawing.Size(107, 26);
            this.bunifuCustomLabel_Loading.TabIndex = 2;
            this.bunifuCustomLabel_Loading.Text = "Loading...";
            // 
            // LoadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(153, 153);
            this.Controls.Add(this.bunifuCustomLabel_Loading);
            this.Controls.Add(this.bunifuCircleProgressbar_LoadingScreen);
            this.Name = "LoadingScreen";
            this.Text = "LoadingScreen";
            this.Load += new System.EventHandler(this.LoadingScreen_Load);
            this.Controls.SetChildIndex(this.panel_Header, 0);
            this.Controls.SetChildIndex(this.bunifuCircleProgressbar_LoadingScreen, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_Loading, 0);
            this.panel_Header.ResumeLayout(false);
            this.panel_Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_Close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ns1.BunifuCircleProgressbar bunifuCircleProgressbar_LoadingScreen;
        private ns1.BunifuCustomLabel bunifuCustomLabel_Loading;
    }
}