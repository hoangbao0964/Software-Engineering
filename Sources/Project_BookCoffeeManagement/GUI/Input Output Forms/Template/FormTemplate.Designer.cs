namespace Project_BookCoffeeManagement.GUI.Input_Output_Forms
{
    partial class FormTemplate
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
            this.bunifuElipse_Form = new ns1.BunifuElipse(this.components);
            this.bunifuDragControl_FormHeader = new ns1.BunifuDragControl(this.components);
            this.panel_Header = new System.Windows.Forms.Panel();
            this.bunifuImageButton_Close = new ns1.BunifuImageButton();
            this.bunifuCustomLabel_HeaderName = new ns1.BunifuCustomLabel();
            this.panel_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_Close)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse_Form
            // 
            this.bunifuElipse_Form.ElipseRadius = 5;
            this.bunifuElipse_Form.TargetControl = this;
            // 
            // bunifuDragControl_FormHeader
            // 
            this.bunifuDragControl_FormHeader.Fixed = true;
            this.bunifuDragControl_FormHeader.Horizontal = true;
            this.bunifuDragControl_FormHeader.TargetControl = this.panel_Header;
            this.bunifuDragControl_FormHeader.Vertical = true;
            // 
            // panel_Header
            // 
            this.panel_Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.panel_Header.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Header.Controls.Add(this.bunifuImageButton_Close);
            this.panel_Header.Controls.Add(this.bunifuCustomLabel_HeaderName);
            this.panel_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Header.Location = new System.Drawing.Point(0, 0);
            this.panel_Header.Name = "panel_Header";
            this.panel_Header.Size = new System.Drawing.Size(482, 53);
            this.panel_Header.TabIndex = 0;
            // 
            // bunifuImageButton_Close
            // 
            this.bunifuImageButton_Close.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton_Close.Image = global::Project_BookCoffeeManagement.Properties.Resources.Multiply_Filled_50;
            this.bunifuImageButton_Close.ImageActive = null;
            this.bunifuImageButton_Close.Location = new System.Drawing.Point(212, 3);
            this.bunifuImageButton_Close.Name = "bunifuImageButton_Close";
            this.bunifuImageButton_Close.Size = new System.Drawing.Size(47, 47);
            this.bunifuImageButton_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton_Close.TabIndex = 2;
            this.bunifuImageButton_Close.TabStop = false;
            this.bunifuImageButton_Close.Zoom = 10;
            this.bunifuImageButton_Close.Click += new System.EventHandler(this.bunifuImageButton_Close_Click);
            // 
            // bunifuCustomLabel_HeaderName
            // 
            this.bunifuCustomLabel_HeaderName.AutoSize = true;
            this.bunifuCustomLabel_HeaderName.Font = new System.Drawing.Font("AR JULIAN", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel_HeaderName.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel_HeaderName.Location = new System.Drawing.Point(24, 8);
            this.bunifuCustomLabel_HeaderName.Name = "bunifuCustomLabel_HeaderName";
            this.bunifuCustomLabel_HeaderName.Size = new System.Drawing.Size(182, 34);
            this.bunifuCustomLabel_HeaderName.TabIndex = 1;
            this.bunifuCustomLabel_HeaderName.Text = "Newbee shop";
            // 
            // FormTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(482, 443);
            this.Controls.Add(this.panel_Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormTemplate";
            this.panel_Header.ResumeLayout(false);
            this.panel_Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_Close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected ns1.BunifuElipse bunifuElipse_Form;
        private ns1.BunifuDragControl bunifuDragControl_FormHeader;
        protected System.Windows.Forms.Panel panel_Header;
        protected ns1.BunifuImageButton bunifuImageButton_Close;
        protected ns1.BunifuCustomLabel bunifuCustomLabel_HeaderName;
    }
}