namespace Project_BookCoffeeManagement.GUI.Input_Output_Forms.IO_forms
{
    partial class VoucherForm
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
            this.bunifuCustomTextbox_VoucherName = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel_VoucherName = new ns1.BunifuCustomLabel();
            this.bunifuCustomLabel_Quantity = new ns1.BunifuCustomLabel();
            this.numericUpDown_Quantity = new System.Windows.Forms.NumericUpDown();
            this.bunifuCustomTextbox_PulishDate = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel_PulishDate = new ns1.BunifuCustomLabel();
            this.bunifuCustomTextbox_ExpireDate = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel_ExpireDate = new ns1.BunifuCustomLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bunifuCustomLabel_Type = new ns1.BunifuCustomLabel();
            this.bunifuDropdown_Type = new ns1.BunifuDropdown();
            this.bunifuCustomLabel_Description = new ns1.BunifuCustomLabel();
            this.bunifuCustomTextbox_Description = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuTileButton_CreateVouchers = new ns1.BunifuTileButton();
            this.panel_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Header
            // 
            this.panel_Header.Size = new System.Drawing.Size(564, 53);
            // 
            // bunifuImageButton_Close
            // 
            this.bunifuImageButton_Close.Location = new System.Drawing.Point(513, 1);
            // 
            // bunifuCustomLabel_HeaderName
            // 
            this.bunifuCustomLabel_HeaderName.Size = new System.Drawing.Size(214, 33);
            this.bunifuCustomLabel_HeaderName.Tag = "Header_CreateVoucher";
            this.bunifuCustomLabel_HeaderName.Text = "Create voucher";
            // 
            // bunifuCustomTextbox_VoucherName
            // 
            this.bunifuCustomTextbox_VoucherName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuCustomTextbox_VoucherName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.bunifuCustomTextbox_VoucherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuCustomTextbox_VoucherName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bunifuCustomTextbox_VoucherName.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomTextbox_VoucherName.Location = new System.Drawing.Point(131, 67);
            this.bunifuCustomTextbox_VoucherName.Name = "bunifuCustomTextbox_VoucherName";
            this.bunifuCustomTextbox_VoucherName.Size = new System.Drawing.Size(415, 24);
            this.bunifuCustomTextbox_VoucherName.TabIndex = 87;
            // 
            // bunifuCustomLabel_VoucherName
            // 
            this.bunifuCustomLabel_VoucherName.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel_VoucherName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_VoucherName.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_VoucherName.Location = new System.Drawing.Point(11, 66);
            this.bunifuCustomLabel_VoucherName.Name = "bunifuCustomLabel_VoucherName";
            this.bunifuCustomLabel_VoucherName.Size = new System.Drawing.Size(114, 20);
            this.bunifuCustomLabel_VoucherName.TabIndex = 86;
            this.bunifuCustomLabel_VoucherName.Text = "Name :";
            this.bunifuCustomLabel_VoucherName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bunifuCustomLabel_Quantity
            // 
            this.bunifuCustomLabel_Quantity.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_Quantity.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_Quantity.Location = new System.Drawing.Point(291, 153);
            this.bunifuCustomLabel_Quantity.Name = "bunifuCustomLabel_Quantity";
            this.bunifuCustomLabel_Quantity.Size = new System.Drawing.Size(97, 20);
            this.bunifuCustomLabel_Quantity.TabIndex = 88;
            this.bunifuCustomLabel_Quantity.Text = "Quantity :";
            this.bunifuCustomLabel_Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_Quantity
            // 
            this.numericUpDown_Quantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.numericUpDown_Quantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numericUpDown_Quantity.Location = new System.Drawing.Point(394, 151);
            this.numericUpDown_Quantity.Name = "numericUpDown_Quantity";
            this.numericUpDown_Quantity.Size = new System.Drawing.Size(152, 26);
            this.numericUpDown_Quantity.TabIndex = 89;
            this.numericUpDown_Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bunifuCustomTextbox_PulishDate
            // 
            this.bunifuCustomTextbox_PulishDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuCustomTextbox_PulishDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.bunifuCustomTextbox_PulishDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuCustomTextbox_PulishDate.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bunifuCustomTextbox_PulishDate.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomTextbox_PulishDate.Location = new System.Drawing.Point(131, 111);
            this.bunifuCustomTextbox_PulishDate.Name = "bunifuCustomTextbox_PulishDate";
            this.bunifuCustomTextbox_PulishDate.Size = new System.Drawing.Size(154, 24);
            this.bunifuCustomTextbox_PulishDate.TabIndex = 91;
            // 
            // bunifuCustomLabel_PulishDate
            // 
            this.bunifuCustomLabel_PulishDate.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel_PulishDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_PulishDate.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_PulishDate.Location = new System.Drawing.Point(11, 111);
            this.bunifuCustomLabel_PulishDate.Name = "bunifuCustomLabel_PulishDate";
            this.bunifuCustomLabel_PulishDate.Size = new System.Drawing.Size(114, 20);
            this.bunifuCustomLabel_PulishDate.TabIndex = 90;
            this.bunifuCustomLabel_PulishDate.Text = "Publish date :";
            this.bunifuCustomLabel_PulishDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bunifuCustomTextbox_ExpireDate
            // 
            this.bunifuCustomTextbox_ExpireDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuCustomTextbox_ExpireDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.bunifuCustomTextbox_ExpireDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuCustomTextbox_ExpireDate.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bunifuCustomTextbox_ExpireDate.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomTextbox_ExpireDate.Location = new System.Drawing.Point(392, 112);
            this.bunifuCustomTextbox_ExpireDate.Name = "bunifuCustomTextbox_ExpireDate";
            this.bunifuCustomTextbox_ExpireDate.Size = new System.Drawing.Size(154, 24);
            this.bunifuCustomTextbox_ExpireDate.TabIndex = 93;
            // 
            // bunifuCustomLabel_ExpireDate
            // 
            this.bunifuCustomLabel_ExpireDate.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel_ExpireDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_ExpireDate.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_ExpireDate.Location = new System.Drawing.Point(291, 111);
            this.bunifuCustomLabel_ExpireDate.Name = "bunifuCustomLabel_ExpireDate";
            this.bunifuCustomLabel_ExpireDate.Size = new System.Drawing.Size(97, 20);
            this.bunifuCustomLabel_ExpireDate.TabIndex = 92;
            this.bunifuCustomLabel_ExpireDate.Text = "Expire date :";
            this.bunifuCustomLabel_ExpireDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bunifuCustomLabel_Type
            // 
            this.bunifuCustomLabel_Type.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_Type.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_Type.Location = new System.Drawing.Point(11, 153);
            this.bunifuCustomLabel_Type.Name = "bunifuCustomLabel_Type";
            this.bunifuCustomLabel_Type.Size = new System.Drawing.Size(114, 20);
            this.bunifuCustomLabel_Type.TabIndex = 94;
            this.bunifuCustomLabel_Type.Text = "Discount type :";
            this.bunifuCustomLabel_Type.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bunifuDropdown_Type
            // 
            this.bunifuDropdown_Type.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.bunifuDropdown_Type.BorderRadius = 1;
            this.bunifuDropdown_Type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuDropdown_Type.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bunifuDropdown_Type.ForeColor = System.Drawing.Color.Black;
            this.bunifuDropdown_Type.Items = new string[] {
        "Discount by #%",
        "Buy # & Get Free #"};
            this.bunifuDropdown_Type.Location = new System.Drawing.Point(131, 154);
            this.bunifuDropdown_Type.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuDropdown_Type.Name = "bunifuDropdown_Type";
            this.bunifuDropdown_Type.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuDropdown_Type.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.bunifuDropdown_Type.selectedIndex = -1;
            this.bunifuDropdown_Type.Size = new System.Drawing.Size(154, 23);
            this.bunifuDropdown_Type.TabIndex = 98;
            // 
            // bunifuCustomLabel_Description
            // 
            this.bunifuCustomLabel_Description.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_Description.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_Description.Location = new System.Drawing.Point(11, 205);
            this.bunifuCustomLabel_Description.Name = "bunifuCustomLabel_Description";
            this.bunifuCustomLabel_Description.Size = new System.Drawing.Size(114, 20);
            this.bunifuCustomLabel_Description.TabIndex = 99;
            this.bunifuCustomLabel_Description.Text = "Description :";
            this.bunifuCustomLabel_Description.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bunifuCustomTextbox_Description
            // 
            this.bunifuCustomTextbox_Description.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuCustomTextbox_Description.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.bunifuCustomTextbox_Description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuCustomTextbox_Description.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bunifuCustomTextbox_Description.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomTextbox_Description.Location = new System.Drawing.Point(131, 203);
            this.bunifuCustomTextbox_Description.Multiline = true;
            this.bunifuCustomTextbox_Description.Name = "bunifuCustomTextbox_Description";
            this.bunifuCustomTextbox_Description.Size = new System.Drawing.Size(415, 82);
            this.bunifuCustomTextbox_Description.TabIndex = 100;
            // 
            // bunifuTileButton_CreateVouchers
            // 
            this.bunifuTileButton_CreateVouchers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bunifuTileButton_CreateVouchers.color = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bunifuTileButton_CreateVouchers.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.bunifuTileButton_CreateVouchers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTileButton_CreateVouchers.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.bunifuTileButton_CreateVouchers.ForeColor = System.Drawing.Color.White;
            this.bunifuTileButton_CreateVouchers.Image = null;
            this.bunifuTileButton_CreateVouchers.ImagePosition = 20;
            this.bunifuTileButton_CreateVouchers.ImageZoom = 50;
            this.bunifuTileButton_CreateVouchers.LabelPosition = 41;
            this.bunifuTileButton_CreateVouchers.LabelText = "Create vouchers";
            this.bunifuTileButton_CreateVouchers.Location = new System.Drawing.Point(112, 300);
            this.bunifuTileButton_CreateVouchers.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuTileButton_CreateVouchers.Name = "bunifuTileButton_CreateVouchers";
            this.bunifuTileButton_CreateVouchers.Size = new System.Drawing.Size(342, 58);
            this.bunifuTileButton_CreateVouchers.TabIndex = 101;
            this.bunifuTileButton_CreateVouchers.Tag = "Default location 17, 503";
            this.bunifuTileButton_CreateVouchers.Click += new System.EventHandler(this.bunifuTileButton_CreateVouchers_Click);
            // 
            // VoucherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 376);
            this.Controls.Add(this.bunifuTileButton_CreateVouchers);
            this.Controls.Add(this.bunifuCustomTextbox_Description);
            this.Controls.Add(this.bunifuCustomLabel_Description);
            this.Controls.Add(this.bunifuDropdown_Type);
            this.Controls.Add(this.bunifuCustomLabel_Type);
            this.Controls.Add(this.bunifuCustomTextbox_ExpireDate);
            this.Controls.Add(this.bunifuCustomLabel_ExpireDate);
            this.Controls.Add(this.bunifuCustomTextbox_PulishDate);
            this.Controls.Add(this.bunifuCustomLabel_PulishDate);
            this.Controls.Add(this.numericUpDown_Quantity);
            this.Controls.Add(this.bunifuCustomLabel_Quantity);
            this.Controls.Add(this.bunifuCustomTextbox_VoucherName);
            this.Controls.Add(this.bunifuCustomLabel_VoucherName);
            this.Name = "VoucherForm";
            this.Text = "VoucherForm";
            this.Controls.SetChildIndex(this.panel_Header, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_VoucherName, 0);
            this.Controls.SetChildIndex(this.bunifuCustomTextbox_VoucherName, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_Quantity, 0);
            this.Controls.SetChildIndex(this.numericUpDown_Quantity, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_PulishDate, 0);
            this.Controls.SetChildIndex(this.bunifuCustomTextbox_PulishDate, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_ExpireDate, 0);
            this.Controls.SetChildIndex(this.bunifuCustomTextbox_ExpireDate, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_Type, 0);
            this.Controls.SetChildIndex(this.bunifuDropdown_Type, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_Description, 0);
            this.Controls.SetChildIndex(this.bunifuCustomTextbox_Description, 0);
            this.Controls.SetChildIndex(this.bunifuTileButton_CreateVouchers, 0);
            this.panel_Header.ResumeLayout(false);
            this.panel_Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Quantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsFormsControlLibrary1.BunifuCustomTextbox bunifuCustomTextbox_VoucherName;
        private ns1.BunifuCustomLabel bunifuCustomLabel_VoucherName;
        private ns1.BunifuCustomLabel bunifuCustomLabel_Quantity;
        private System.Windows.Forms.NumericUpDown numericUpDown_Quantity;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox bunifuCustomTextbox_PulishDate;
        private ns1.BunifuCustomLabel bunifuCustomLabel_PulishDate;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox bunifuCustomTextbox_ExpireDate;
        private ns1.BunifuCustomLabel bunifuCustomLabel_ExpireDate;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ns1.BunifuCustomLabel bunifuCustomLabel_Type;
        private ns1.BunifuDropdown bunifuDropdown_Type;
        private ns1.BunifuCustomLabel bunifuCustomLabel_Description;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox bunifuCustomTextbox_Description;
        private ns1.BunifuTileButton bunifuTileButton_CreateVouchers;
    }
}