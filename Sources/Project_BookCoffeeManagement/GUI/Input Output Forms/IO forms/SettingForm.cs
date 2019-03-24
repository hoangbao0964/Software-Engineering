using Project_BookCoffeeManagement.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_BookCoffeeManagement.GUI.Input_Output_Forms.IO_forms
{
    public partial class SettingForm : FormTemplate
    {
        #region Init
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            GetDataForLanguageComboBox();
            LoadCurrentThemeColor();
        }

        private void LoadCurrentThemeColor()
        {
            //Normal color
            label_DisplayNormalColor.BackColor = ThemeManager.NormalColor;
            colorDialog_NormalColor.Color = ThemeManager.NormalColor;
            //Focus color
            label_DisplayFocusColor.BackColor = ThemeManager.FocusColor;
            colorDialog_FocusColor.Color = ThemeManager.FocusColor;
            //Font color
            label_DisplayFontColor.BackColor = ThemeManager.ForeColor;
            colorDialog_ForeColor.Color = ThemeManager.ForeColor;
            //Background color
            label_DisplayBackgroundColor.BackColor = ThemeManager.BackgroundColor;
            colorDialog_BackgroundColor.Color = ThemeManager.BackgroundColor;
            //Menu color
            label_DisplayMenuColor.BackColor = ThemeManager.MenuColor;
            colorDialog_MenuColor.Color = ThemeManager.MenuColor;
            //Field color
            label_DisplayButtonForeColor.BackColor = ThemeManager.ButtonForeColor;
            colorDialog_ButtonForeColor.Color = ThemeManager.ButtonForeColor;
        }

        private void GetDataForLanguageComboBox()
        {
            string folderPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));
            DirectoryInfo directory = new DirectoryInfo(folderPath + "\\Resources\\Languages");

            //string folderPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            //DirectoryInfo directory = new DirectoryInfo(folderPath + "\\Languages");

            FileInfo[] files = directory.GetFiles("*.resx");
            foreach (FileInfo file in files)
            {
                bunifuDropdown_LanguagePicker.AddItem(file.Name);
            }
            bunifuDropdown_LanguagePicker.selectedIndex = 0;
        }
        #endregion

        #region Handling button color picker
        private void button_NormalColor_Click(object sender, EventArgs e)
        {
            if (colorDialog_NormalColor.ShowDialog() == DialogResult.OK)
            {
                label_DisplayNormalColor.BackColor = colorDialog_NormalColor.Color;
            }
        }

        private void button_FocusColor_Click(object sender, EventArgs e)
        {
            if (colorDialog_FocusColor.ShowDialog() == DialogResult.OK)
            {
                label_DisplayFocusColor.BackColor = colorDialog_FocusColor.Color;
            }
        }

        private void button_FontColor_Click(object sender, EventArgs e)
        {
            if (colorDialog_ForeColor.ShowDialog() == DialogResult.OK)
            {
                label_DisplayFontColor.BackColor = colorDialog_ForeColor.Color;
            }
        }

        private void button_BackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog_BackgroundColor.ShowDialog() == DialogResult.OK)
            {
                label_DisplayBackgroundColor.BackColor = colorDialog_BackgroundColor.Color;
            }
        }

        private void button_MenuColor_Click(object sender, EventArgs e)
        {
            if (colorDialog_MenuColor.ShowDialog() == DialogResult.OK)
            {
                label_DisplayMenuColor.BackColor = colorDialog_MenuColor.Color;
            }
        }

        private void button_ButtonForeColor_Click(object sender, EventArgs e)
        {
            if (colorDialog_ButtonForeColor.ShowDialog() == DialogResult.OK)
            {
                label_DisplayButtonForeColor.BackColor = colorDialog_ButtonForeColor.Color;
            }
        }
        #endregion

        #region Handling background image

        private void button_BackgroundImage_Click(object sender, EventArgs e)
        {
            if(openFileDialog_GetImage.ShowDialog() == DialogResult.OK)
            {
                bunifuMetroTextbox_ImageLink.Text = openFileDialog_GetImage.FileName;
            }
        }

        private void bunifuCheckbox_UsingBackgroundImage_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox_UsingBackgroundImage.Checked == false)
            {
                ThemeManager.UseBackgroundImage = false;
                ThemeManager.BackgroundImageLink = string.Empty;
                button_BackgroundImage.Enabled = false;
                bunifuMetroTextbox_ImageLink.Enabled = false;
            }
            else
            {
                ThemeManager.UseBackgroundImage = true;
                button_BackgroundImage.Enabled = true;
                bunifuMetroTextbox_ImageLink.Enabled = true;
            }
        }
        #endregion

        #region Default setting & click event

        private void bunifuTileButton_DefaultSetting_Click(object sender, EventArgs e)
        {
            ThemeManager.LoadDefaultThemeSetting();
            LanguageManager.LoadDefaultLanguageSetting();
            ThemeManager.DeleteCurrentThemeFile();
            this.Close();
        }
        
        #endregion

        #region Custom setting & click event

        private void bunifuTileButton_bunifuTileButton_ApplySetting_Click(object sender, EventArgs e)
        {
            if (checkThemeSettingChanges())
            {
                SaveCustomThemeSetting();
                ThemeManager.UseCustomTheme = true;
            }
            if (checkLanguageSettingChanges())
            {
                LanguageManager.UseCustomLanguage = true;
                SaveCustomLanguageSetting();
            }
            this.Close();
        }

        #region Handling Theme
        private bool checkThemeSettingChanges()
        {
            if (CompareColor(ThemeManager.NormalColor,colorDialog_NormalColor.Color))
                return true;
            if (CompareColor(ThemeManager.FocusColor, colorDialog_FocusColor.Color))
                return true;
            if (CompareColor(ThemeManager.ForeColor, colorDialog_ForeColor.Color))
                return true;
            if (CompareColor(ThemeManager.BackgroundColor, colorDialog_BackgroundColor.Color))
                return true;
            if (CompareColor(ThemeManager.MenuColor, colorDialog_MenuColor.Color))
                return true;
            if (CompareColor(ThemeManager.ButtonForeColor, colorDialog_ButtonForeColor.Color))
                return true;
            if (bunifuCheckbox_UsingBackgroundImage.Checked == true && bunifuMetroTextbox_ImageLink.Text != string.Empty)
                return true;

            return false;
        }

        private void SaveCustomThemeSetting()
        {
            ThemeManager.NormalColor = colorDialog_NormalColor.Color;
            ThemeManager.FocusColor = colorDialog_FocusColor.Color;
            ThemeManager.ForeColor = colorDialog_ForeColor.Color;
            ThemeManager.MenuColor = colorDialog_MenuColor.Color;
            ThemeManager.BackgroundColor = colorDialog_BackgroundColor.Color;
            ThemeManager.ButtonForeColor = colorDialog_ButtonForeColor.Color;
            if (checkValidImagePath())
            {
                ThemeManager.UseBackgroundImage = true;
                ThemeManager.BackgroundImageLink = bunifuMetroTextbox_ImageLink.Text;
            }
            ThemeManager.SaveCurrentThemeToFile();
        }

        private bool checkValidImagePath()
        {
            //ktra cái link có phải ảnh ko + có mở được hay ko
            return true;
        }
        #endregion

        #region Handling Language

        private bool checkLanguageSettingChanges()
        {
            if (bunifuDropdown_LanguagePicker.selectedValue != LanguageManager.CurrentLanguage)
                return true;
            return false;
        }

        private void SaveCustomLanguageSetting()
        {
            LanguageManager.CurrentLanguage = bunifuDropdown_LanguagePicker.selectedValue;
            string[] temp = bunifuDropdown_LanguagePicker.selectedValue.Split('.');
            LanguageManager.CultureProvider = CultureInfo.CreateSpecificCulture(temp[1]);//temp[1] = name of language, just a temporary solution
        }

        private bool CompareColor(Color DefaultColor, Color NewColor)
        {
            if (DefaultColor != NewColor)
                return true;
            return false;
        }

        #endregion

        #endregion


    }
}
