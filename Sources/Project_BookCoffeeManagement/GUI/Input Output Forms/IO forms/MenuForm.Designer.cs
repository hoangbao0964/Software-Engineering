namespace Project_BookCoffeeManagement.GUI.Input_Output_Forms
{
    partial class MenuForm
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
            this.bunifuCustomTextbox_Description = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel_Description = new ns1.BunifuCustomLabel();
            this.bunifuDropdown_Status = new ns1.BunifuDropdown();
            this.bunifuCustomLabel_Status = new ns1.BunifuCustomLabel();
            this.bunifuMetroTextbox_Price = new ns1.BunifuMetroTextbox();
            this.bunifuCustomLabel_Price = new ns1.BunifuCustomLabel();
            this.bunifuImageButton_ChooseIngredient = new ns1.BunifuImageButton();
            this.bunifuCustomTextbox__list_selectedIngredients = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel_Ingredients = new ns1.BunifuCustomLabel();
            this.bunifuCustomTextbox_Name = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel_Name = new ns1.BunifuCustomLabel();
            this.bunifuTileButton_Execute = new ns1.BunifuTileButton();
            this.panel_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_ChooseIngredient)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Header
            // 
            this.panel_Header.Size = new System.Drawing.Size(602, 53);
            // 
            // bunifuImageButton_Close
            // 
            this.bunifuImageButton_Close.Location = new System.Drawing.Point(548, 2);
            this.bunifuImageButton_Close.Click += new System.EventHandler(this.bunifuImageButton_Close_Click);
            // 
            // bunifuCustomLabel_HeaderName
            // 
            this.bunifuCustomLabel_HeaderName.Size = new System.Drawing.Size(249, 34);
            this.bunifuCustomLabel_HeaderName.Tag = "Header_DishDrinkDetail";
            this.bunifuCustomLabel_HeaderName.Text = "Dish/Drink detail";
            // 
            // bunifuCustomTextbox_Description
            // 
            this.bunifuCustomTextbox_Description.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuCustomTextbox_Description.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.bunifuCustomTextbox_Description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuCustomTextbox_Description.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bunifuCustomTextbox_Description.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomTextbox_Description.Location = new System.Drawing.Point(115, 241);
            this.bunifuCustomTextbox_Description.Multiline = true;
            this.bunifuCustomTextbox_Description.Name = "bunifuCustomTextbox_Description";
            this.bunifuCustomTextbox_Description.Size = new System.Drawing.Size(470, 109);
            this.bunifuCustomTextbox_Description.TabIndex = 81;
            // 
            // bunifuCustomLabel_Description
            // 
            this.bunifuCustomLabel_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_Description.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_Description.Location = new System.Drawing.Point(12, 240);
            this.bunifuCustomLabel_Description.Name = "bunifuCustomLabel_Description";
            this.bunifuCustomLabel_Description.Size = new System.Drawing.Size(97, 20);
            this.bunifuCustomLabel_Description.TabIndex = 80;
            this.bunifuCustomLabel_Description.Text = "Description :";
            this.bunifuCustomLabel_Description.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bunifuDropdown_Status
            // 
            this.bunifuDropdown_Status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuDropdown_Status.BorderRadius = 3;
            this.bunifuDropdown_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuDropdown_Status.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bunifuDropdown_Status.ForeColor = System.Drawing.Color.Black;
            this.bunifuDropdown_Status.Location = new System.Drawing.Point(454, 69);
            this.bunifuDropdown_Status.Items = new string[0];
            this.bunifuDropdown_Status.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuDropdown_Status.Name = "bunifuDropdown_Status";
            this.bunifuDropdown_Status.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuDropdown_Status.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.bunifuDropdown_Status.selectedIndex = -1;
            this.bunifuDropdown_Status.Size = new System.Drawing.Size(131, 23);
            this.bunifuDropdown_Status.TabIndex = 79;
            // 
            // bunifuCustomLabel_Status
            // 
            this.bunifuCustomLabel_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_Status.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_Status.Location = new System.Drawing.Point(350, 69);
            this.bunifuCustomLabel_Status.Name = "bunifuCustomLabel_Status";
            this.bunifuCustomLabel_Status.Size = new System.Drawing.Size(97, 20);
            this.bunifuCustomLabel_Status.TabIndex = 78;
            this.bunifuCustomLabel_Status.Text = "Status :";
            this.bunifuCustomLabel_Status.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bunifuMetroTextbox_Price
            // 
            this.bunifuMetroTextbox_Price.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.bunifuMetroTextbox_Price.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.bunifuMetroTextbox_Price.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.bunifuMetroTextbox_Price.BorderThickness = 3;
            this.bunifuMetroTextbox_Price.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuMetroTextbox_Price.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.bunifuMetroTextbox_Price.ForeColor = System.Drawing.Color.Black;
            this.bunifuMetroTextbox_Price.isPassword = false;
            this.bunifuMetroTextbox_Price.Location = new System.Drawing.Point(113, 357);
            this.bunifuMetroTextbox_Price.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuMetroTextbox_Price.Name = "bunifuMetroTextbox_Price";
            this.bunifuMetroTextbox_Price.Size = new System.Drawing.Size(472, 44);
            this.bunifuMetroTextbox_Price.TabIndex = 77;
            this.bunifuMetroTextbox_Price.Text = "00000000";
            this.bunifuMetroTextbox_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bunifuCustomLabel_Price
            // 
            this.bunifuCustomLabel_Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_Price.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_Price.Location = new System.Drawing.Point(12, 369);
            this.bunifuCustomLabel_Price.Name = "bunifuCustomLabel_Price";
            this.bunifuCustomLabel_Price.Size = new System.Drawing.Size(97, 20);
            this.bunifuCustomLabel_Price.TabIndex = 76;
            this.bunifuCustomLabel_Price.Text = "Price :";
            this.bunifuCustomLabel_Price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bunifuImageButton_ChooseIngredient
            // 
            this.bunifuImageButton_ChooseIngredient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuImageButton_ChooseIngredient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton_ChooseIngredient.Image = global::Project_BookCoffeeManagement.Properties.Resources.Edit_Property_26__1_;
            this.bunifuImageButton_ChooseIngredient.ImageActive = null;
            this.bunifuImageButton_ChooseIngredient.Location = new System.Drawing.Point(72, 190);
            this.bunifuImageButton_ChooseIngredient.Name = "bunifuImageButton_ChooseIngredient";
            this.bunifuImageButton_ChooseIngredient.Size = new System.Drawing.Size(38, 40);
            this.bunifuImageButton_ChooseIngredient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton_ChooseIngredient.TabIndex = 75;
            this.bunifuImageButton_ChooseIngredient.TabStop = false;
            this.bunifuImageButton_ChooseIngredient.Zoom = 0;
            this.bunifuImageButton_ChooseIngredient.Click += new System.EventHandler(this.bunifuImageButton_ChooseIngredient_Click);
            // 
            // bunifuCustomTextbox__list_selectedIngredients
            // 
            this.bunifuCustomTextbox__list_selectedIngredients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(237)))), ((int)(((byte)(233)))));
            this.bunifuCustomTextbox__list_selectedIngredients.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuCustomTextbox__list_selectedIngredients.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bunifuCustomTextbox__list_selectedIngredients.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomTextbox__list_selectedIngredients.Location = new System.Drawing.Point(115, 102);
            this.bunifuCustomTextbox__list_selectedIngredients.Multiline = true;
            this.bunifuCustomTextbox__list_selectedIngredients.Name = "bunifuCustomTextbox__list_selectedIngredients";
            this.bunifuCustomTextbox__list_selectedIngredients.ReadOnly = true;
            this.bunifuCustomTextbox__list_selectedIngredients.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bunifuCustomTextbox__list_selectedIngredients.Size = new System.Drawing.Size(470, 126);
            this.bunifuCustomTextbox__list_selectedIngredients.TabIndex = 74;
            this.bunifuCustomTextbox__list_selectedIngredients.Text = "click vào icon kế bên sẽ hiện lên bảng chọn nguyên liệu";
            // 
            // bunifuCustomLabel_Ingredients
            // 
            this.bunifuCustomLabel_Ingredients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_Ingredients.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_Ingredients.Location = new System.Drawing.Point(12, 102);
            this.bunifuCustomLabel_Ingredients.Name = "bunifuCustomLabel_Ingredients";
            this.bunifuCustomLabel_Ingredients.Size = new System.Drawing.Size(97, 20);
            this.bunifuCustomLabel_Ingredients.TabIndex = 73;
            this.bunifuCustomLabel_Ingredients.Text = "Ingredients :";
            this.bunifuCustomLabel_Ingredients.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.bunifuCustomTextbox_Name.Location = new System.Drawing.Point(115, 68);
            this.bunifuCustomTextbox_Name.Name = "bunifuCustomTextbox_Name";
            this.bunifuCustomTextbox_Name.Size = new System.Drawing.Size(229, 24);
            this.bunifuCustomTextbox_Name.TabIndex = 72;
            this.bunifuCustomTextbox_Name.Text = "Tên món";
            this.bunifuCustomTextbox_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bunifuCustomTextbox_Name.TextChanged += new System.EventHandler(this.bunifuCustomTextbox_Name_TextChanged);
            // 
            // bunifuCustomLabel_Name
            // 
            this.bunifuCustomLabel_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel_Name.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel_Name.Location = new System.Drawing.Point(12, 69);
            this.bunifuCustomLabel_Name.Name = "bunifuCustomLabel_Name";
            this.bunifuCustomLabel_Name.Size = new System.Drawing.Size(97, 20);
            this.bunifuCustomLabel_Name.TabIndex = 71;
            this.bunifuCustomLabel_Name.Tag = "Name_DishDrink";
            this.bunifuCustomLabel_Name.Text = "Name :";
            this.bunifuCustomLabel_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.bunifuTileButton_Execute.Location = new System.Drawing.Point(123, 414);
            this.bunifuTileButton_Execute.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuTileButton_Execute.Name = "bunifuTileButton_Execute";
            this.bunifuTileButton_Execute.Size = new System.Drawing.Size(342, 58);
            this.bunifuTileButton_Execute.TabIndex = 82;
            this.bunifuTileButton_Execute.Tag = "Default location 17, 503";
            this.bunifuTileButton_Execute.Click += new System.EventHandler(this.bunifuTileButton_Execute_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 485);
            this.Controls.Add(this.bunifuTileButton_Execute);
            this.Controls.Add(this.bunifuCustomTextbox_Description);
            this.Controls.Add(this.bunifuCustomLabel_Description);
            this.Controls.Add(this.bunifuDropdown_Status);
            this.Controls.Add(this.bunifuCustomLabel_Status);
            this.Controls.Add(this.bunifuMetroTextbox_Price);
            this.Controls.Add(this.bunifuCustomLabel_Price);
            this.Controls.Add(this.bunifuImageButton_ChooseIngredient);
            this.Controls.Add(this.bunifuCustomTextbox__list_selectedIngredients);
            this.Controls.Add(this.bunifuCustomLabel_Ingredients);
            this.Controls.Add(this.bunifuCustomTextbox_Name);
            this.Controls.Add(this.bunifuCustomLabel_Name);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Controls.SetChildIndex(this.panel_Header, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_Name, 0);
            this.Controls.SetChildIndex(this.bunifuCustomTextbox_Name, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_Ingredients, 0);
            this.Controls.SetChildIndex(this.bunifuCustomTextbox__list_selectedIngredients, 0);
            this.Controls.SetChildIndex(this.bunifuImageButton_ChooseIngredient, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_Price, 0);
            this.Controls.SetChildIndex(this.bunifuMetroTextbox_Price, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_Status, 0);
            this.Controls.SetChildIndex(this.bunifuDropdown_Status, 0);
            this.Controls.SetChildIndex(this.bunifuCustomLabel_Description, 0);
            this.Controls.SetChildIndex(this.bunifuCustomTextbox_Description, 0);
            this.Controls.SetChildIndex(this.bunifuTileButton_Execute, 0);
            this.panel_Header.ResumeLayout(false);
            this.panel_Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_ChooseIngredient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsFormsControlLibrary1.BunifuCustomTextbox bunifuCustomTextbox_Description;
        private ns1.BunifuCustomLabel bunifuCustomLabel_Description;
        private ns1.BunifuDropdown bunifuDropdown_Status;
        private ns1.BunifuCustomLabel bunifuCustomLabel_Status;
        private ns1.BunifuMetroTextbox bunifuMetroTextbox_Price;
        private ns1.BunifuCustomLabel bunifuCustomLabel_Price;
        private ns1.BunifuImageButton bunifuImageButton_ChooseIngredient;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox bunifuCustomTextbox__list_selectedIngredients;
        private ns1.BunifuCustomLabel bunifuCustomLabel_Ingredients;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox bunifuCustomTextbox_Name;
        private ns1.BunifuCustomLabel bunifuCustomLabel_Name;
        private ns1.BunifuTileButton bunifuTileButton_Execute;
    }
}