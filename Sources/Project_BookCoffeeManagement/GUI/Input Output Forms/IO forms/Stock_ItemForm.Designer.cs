namespace Project_BookCoffeeManagement.GUI.Input_Output_Forms.IO_forms
{
    partial class Stock_ItemForm
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
            this.bunifuTileButton_Execute = new ns1.BunifuTileButton();
            this.bunifuCustomTextbox_Note = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel_Note = new ns1.BunifuCustomLabel();
            this.bunifuCustomTextbox_Producer = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel_Producer = new ns1.BunifuCustomLabel();
            this.bunifuDropdown_Type = new ns1.BunifuDropdown();
            this.bunifuCustomLabel_Type = new ns1.BunifuCustomLabel();
            this.bunifuCustomTextbox_Name = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel_Name = new ns1.BunifuCustomLabel();
            this.bunifuCustomTextbox_Quantity = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel_Quantity = new ns1.BunifuCustomLabel();
            this.panel_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_Close)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Header
            // 
            this.panel_Header.Size = new System.Drawing.Size(384, 53);
            // 
            // bunifuImageButton_Close
            // 
            this.bunifuImageButton_Close.Location = new System.Drawing.Point(335, 4);
            // 
            // bunifuCustomLabel_HeaderName
            // 
            this.bunifuCustomLabel_HeaderName.Size = new System.Drawing.Size(150, 33);
            this.bunifuCustomLabel_HeaderName.Tag = "Header_ItemDetail";
            this.bunifuCustomLabel_HeaderName.Text = "Item detail";
            // 
            // bunifuTileButton_Execute
            // 
            this.bunifuTileButton_Execute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bunifuTileButton_Execute.color = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bunifuTileButton_Execute.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.bunifuTileButton_Execute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTileButton_Execute.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.bunifuTileButton_Execute.ForeColor = System.Drawing.Color.White;
            this.bunifuTileButton_Execute.Image = null;
            this.bunifuTileButton_Execute.ImagePosition = 20;
            this.bunifuTileButton_Execute.ImageZoom = 50;
            this.bunifuTileButton_Execute.LabelPosition = 41;
            this.bunifuTileButton_Execute.LabelText = "Execute";
            this.bunifuTileButton_Execute.Location = new System.Drawing.Point(20, 276);
            this.bunifuTileButton_Execute.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuTileButton_Execute.Name = "bunifuTileButton_Execute";
            this.bunifuTileButton_Execute.Size = new System.Drawing.Size(342, 58);
            this.bunifuTileButton_Execute.TabIndex = 94;
            this.bunifuTileButton_Execute.Tag = "Default location 17, 503";
            this.bunifuTileButton_Execute.Click += new System.EventHandler(this.bunifuTileButton_Execute_Click);
            // 
            // bunifuCustomTextbox_Note
            // 
            this.bunifuCustomTextbox_Note.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuCustomTextbox_Note.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.bunifuCustomTextbox_Note.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuCustomTextbox_Note.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bunifuCustomTextbox_Note.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomTextbox_Note.Location = new System.Drawing.Point(92, 207);
            this.bunifuCustomTextbox_Note.Multiline = true;
            this.bunifuCustomTextbox_Note.Name = "bunifuCustomTextbox_Note";
            this.bunifuCustomTextbox_Note.Size = new System.Drawing.Size(278, 54);
            this.bunifuCustomTextbox_Note.TabIndex = 86;
            // 
            // bunifuCustomLabel_Note
            // 
            this.bunifuCustomLabel_Note.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel_Note.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_Note.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_Note.Location = new System.Drawing.Point(0, 207);
            this.bunifuCustomLabel_Note.Name = "bunifuCustomLabel_Note";
            this.bunifuCustomLabel_Note.Size = new System.Drawing.Size(89, 18);
            this.bunifuCustomLabel_Note.TabIndex = 85;
            this.bunifuCustomLabel_Note.Text = "Note :";
            this.bunifuCustomLabel_Note.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bunifuCustomTextbox_Producer
            // 
            this.bunifuCustomTextbox_Producer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.bunifuCustomTextbox_Producer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.bunifuCustomTextbox_Producer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuCustomTextbox_Producer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.bunifuCustomTextbox_Producer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuCustomTextbox_Producer.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bunifuCustomTextbox_Producer.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomTextbox_Producer.Location = new System.Drawing.Point(92, 136);
            this.bunifuCustomTextbox_Producer.Name = "bunifuCustomTextbox_Producer";
            this.bunifuCustomTextbox_Producer.Size = new System.Drawing.Size(278, 24);
            this.bunifuCustomTextbox_Producer.TabIndex = 82;
            this.bunifuCustomTextbox_Producer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bunifuCustomLabel_Producer
            // 
            this.bunifuCustomLabel_Producer.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel_Producer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_Producer.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_Producer.Location = new System.Drawing.Point(0, 136);
            this.bunifuCustomLabel_Producer.Name = "bunifuCustomLabel_Producer";
            this.bunifuCustomLabel_Producer.Size = new System.Drawing.Size(89, 18);
            this.bunifuCustomLabel_Producer.TabIndex = 81;
            this.bunifuCustomLabel_Producer.Text = "Producer :";
            this.bunifuCustomLabel_Producer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bunifuDropdown_Type
            // 
            this.bunifuDropdown_Type.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.bunifuDropdown_Type.BorderRadius = 3;
            this.bunifuDropdown_Type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuDropdown_Type.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bunifuDropdown_Type.ForeColor = System.Drawing.Color.Black;
            this.bunifuDropdown_Type.Items = new string[] {
        "Ingredient"};
            this.bunifuDropdown_Type.Location = new System.Drawing.Point(92, 102);
            this.bunifuDropdown_Type.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuDropdown_Type.Name = "bunifuDropdown_Type";
            this.bunifuDropdown_Type.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuDropdown_Type.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.bunifuDropdown_Type.selectedIndex = 0;
            this.bunifuDropdown_Type.Size = new System.Drawing.Size(278, 24);
            this.bunifuDropdown_Type.TabIndex = 80;
            // 
            // bunifuCustomLabel_Type
            // 
            this.bunifuCustomLabel_Type.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_Type.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_Type.Location = new System.Drawing.Point(0, 102);
            this.bunifuCustomLabel_Type.Name = "bunifuCustomLabel_Type";
            this.bunifuCustomLabel_Type.Size = new System.Drawing.Size(89, 18);
            this.bunifuCustomLabel_Type.TabIndex = 79;
            this.bunifuCustomLabel_Type.Text = "Type :";
            this.bunifuCustomLabel_Type.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bunifuCustomTextbox_Name
            // 
            this.bunifuCustomTextbox_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.bunifuCustomTextbox_Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.bunifuCustomTextbox_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuCustomTextbox_Name.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.bunifuCustomTextbox_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuCustomTextbox_Name.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bunifuCustomTextbox_Name.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomTextbox_Name.Location = new System.Drawing.Point(92, 68);
            this.bunifuCustomTextbox_Name.Name = "bunifuCustomTextbox_Name";
            this.bunifuCustomTextbox_Name.Size = new System.Drawing.Size(278, 24);
            this.bunifuCustomTextbox_Name.TabIndex = 78;
            this.bunifuCustomTextbox_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bunifuCustomLabel_Name
            // 
            this.bunifuCustomLabel_Name.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_Name.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_Name.Location = new System.Drawing.Point(0, 68);
            this.bunifuCustomLabel_Name.Name = "bunifuCustomLabel_Name";
            this.bunifuCustomLabel_Name.Size = new System.Drawing.Size(89, 18);
            this.bunifuCustomLabel_Name.TabIndex = 77;
            this.bunifuCustomLabel_Name.Text = "Name :";
            this.bunifuCustomLabel_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bunifuCustomTextbox_Quantity
            // 
            this.bunifuCustomTextbox_Quantity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.bunifuCustomTextbox_Quantity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.bunifuCustomTextbox_Quantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuCustomTextbox_Quantity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.bunifuCustomTextbox_Quantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuCustomTextbox_Quantity.Enabled = false;
            this.bunifuCustomTextbox_Quantity.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bunifuCustomTextbox_Quantity.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomTextbox_Quantity.Location = new System.Drawing.Point(92, 171);
            this.bunifuCustomTextbox_Quantity.Name = "bunifuCustomTextbox_Quantity";
            this.bunifuCustomTextbox_Quantity.ReadOnly = true;
            this.bunifuCustomTextbox_Quantity.Size = new System.Drawing.Size(278, 24);
            this.bunifuCustomTextbox_Quantity.TabIndex = 84;
            this.bunifuCustomTextbox_Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bunifuCustomLabel_Quantity
            // 
            this.bunifuCustomLabel_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_Quantity.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_Quantity.Location = new System.Drawing.Point(-18, 171);
            this.bunifuCustomLabel_Quantity.Name = "bunifuCustomLabel_Quantity";
            this.bunifuCustomLabel_Quantity.Size = new System.Drawing.Size(107, 18);
            this.bunifuCustomLabel_Quantity.TabIndex = 83;
            this.bunifuCustomLabel_Quantity.Text = "Quantity :";
            this.bunifuCustomLabel_Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Stock_ItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 349);
            this.Controls.Add(this.bunifuCustomTextbox_Note);
            this.Controls.Add(this.bunifuCustomLabel_Note);
            this.Controls.Add(this.bunifuTileButton_Execute);
            this.Controls.Add(this.bunifuCustomTextbox_Quantity);
            this.Controls.Add(this.bunifuCustomTextbox_Producer);
            this.Controls.Add(this.bunifuCustomLabel_Quantity);
            this.Controls.Add(this.bunifuCustomLabel_Name);
            this.Controls.Add(this.bunifuCustomTextbox_Name);
            this.Controls.Add(this.bunifuCustomLabel_Producer);
            this.Controls.Add(this.bunifuCustomLabel_Type);
            this.Controls.Add(this.bunifuDropdown_Type);
            this.Name = "Stock_ItemForm";
            this.Text = "Stock_ItemForm";
            this.Controls.SetChildIndex(this.bunifuDropdown_Type, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_Type, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_Producer, 0);
            this.Controls.SetChildIndex(this.bunifuCustomTextbox_Name, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_Name, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_Quantity, 0);
            this.Controls.SetChildIndex(this.bunifuCustomTextbox_Producer, 0);
            this.Controls.SetChildIndex(this.bunifuCustomTextbox_Quantity, 0);
            this.Controls.SetChildIndex(this.bunifuTileButton_Execute, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_Note, 0);
            this.Controls.SetChildIndex(this.bunifuCustomTextbox_Note, 0);
            this.Controls.SetChildIndex(this.panel_Header, 0);
            this.panel_Header.ResumeLayout(false);
            this.panel_Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_Close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ns1.BunifuTileButton bunifuTileButton_Execute;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox bunifuCustomTextbox_Note;
        private ns1.BunifuCustomLabel bunifuCustomLabel_Note;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox bunifuCustomTextbox_Producer;
        private ns1.BunifuCustomLabel bunifuCustomLabel_Producer;
        private ns1.BunifuDropdown bunifuDropdown_Type;
        private ns1.BunifuCustomLabel bunifuCustomLabel_Type;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox bunifuCustomTextbox_Name;
        private ns1.BunifuCustomLabel bunifuCustomLabel_Name;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox bunifuCustomTextbox_Quantity;
        private ns1.BunifuCustomLabel bunifuCustomLabel_Quantity;
    }
}