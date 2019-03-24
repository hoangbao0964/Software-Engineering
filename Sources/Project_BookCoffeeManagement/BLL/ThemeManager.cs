using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.BLL
{
    class ThemeManager
    {
        protected static string defaultThemeFilePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + "\\" + "theme.txt";

        protected static Color normalColor = Color.FromArgb(17, 112, 112);
        protected static Color focusColor = Color.FromArgb(39, 173, 173);
        protected static Color foreColor = Color.FromArgb(0, 0, 0);
        protected static Color buttonForeColor = Color.FromArgb(255, 255, 255);
        protected static Color backgroundColor = Color.FromArgb(218, 237, 233);
        protected static Color menuColor = Color.FromArgb(16, 45, 45);
        protected static bool useBackgroundImage = false;
        protected static string backgroundImageLink = string.Empty;

        protected static Color default_NormalColor = Color.FromArgb(17, 112, 112);
        protected static Color default_FocusColor = Color.FromArgb(39, 173, 173);
        protected static Color default_ForeColor = Color.FromArgb(0, 0, 0);
        protected static Color default_ButtonForeColor = Color.FromArgb(255, 255, 255);
        protected static Color default_BackgroundColor = Color.FromArgb(218, 237, 233);
        protected static Color default_MenuColor = Color.FromArgb(16, 45, 45);

        protected static bool useCustomTheme = false;

        #region Get/Set properties
        public static Color NormalColor
        {
            get
            {
                return normalColor;
            }

            set
            {
                normalColor = value;
            }
        }       

        public static Color FocusColor
        {
            get
            {
                return focusColor;
            }

            set
            {
                focusColor = value;
            }
        }

        public static Color ForeColor
        {
            get
            {
                return foreColor;
            }

            set
            {
                foreColor = value;
            }
        }

        public static Color BackgroundColor
        {
            get
            {
                return backgroundColor;
            }

            set
            {
                backgroundColor = value;
            }
        }

        public static string BackgroundImageLink
        {
            get
            {
                return backgroundImageLink;
            }

            set
            {
                backgroundImageLink = value;
            }
        }

        public static Color Default_NormalColor
        {
            get
            {
                return default_NormalColor;
            }
        }

        public static Color Default_FocusColor
        {
            get
            {
                return default_FocusColor;
            }
        }

        public static Color Default_ForeColor
        {
            get
            {
                return default_ForeColor;
            }
        }

        public static Color Default_BackgroundColor
        {
            get
            {
                return default_BackgroundColor;
            }
        }

        public static bool UseBackgroundImage
        {
            get
            {
                return useBackgroundImage;
            }

            set
            {
                useBackgroundImage = value;
            }
        }

        public static bool UseCustomTheme
        {
            get
            {
                return useCustomTheme;
            }

            set
            {
                useCustomTheme = value;
            }
        }

        public static Color Default_MenuColor
        {
            get
            {
                return default_MenuColor;
            }

            set
            {
                default_MenuColor = value;
            }
        }

        public static Color MenuColor
        {
            get
            {
                return menuColor;
            }

            set
            {
                menuColor = value;
            }
        }

        public static Color ButtonForeColor
        {
            get
            {
                return buttonForeColor;
            }

            set
            {
                buttonForeColor = value;
            }
        }

        public static Color Default_ButtonForeColor
        {
            get
            {
                return default_ButtonForeColor;
            }
        }
        #endregion


        #region Methods
        public static void LoadThemeFromFile()
        {
            List<int> themeValues = new List<int>();
            try
            {
                string[] lines = System.IO.File.ReadAllLines(defaultThemeFilePath);
                foreach (string data in lines)
                {
                    try
                    {
                        int temp = int.Parse(data);
                        themeValues.Add(temp);
                    }
                    catch (Exception ex)
                    {
                        ErrorManager.MessageDisplay(ex.Message, "", "A saved theme file exist but an error occur in reading data. Using default theme instead");
                        return;
                    }
                }
            }
            catch
            {
                return;
            }

            if (themeValues.Count < 18)
            {
                ErrorManager.MessageDisplay("Not enough data", "", "A saved theme file exist but an error occur in reading data. Using default theme instead");
                return;
            }

            try
            {
                NormalColor = Color.FromArgb(themeValues[0], themeValues[1], themeValues[2]);
                FocusColor = Color.FromArgb(themeValues[3], themeValues[4], themeValues[5]);
                ForeColor = Color.FromArgb(themeValues[6], themeValues[7], themeValues[8]);
                ButtonForeColor = Color.FromArgb(themeValues[9], themeValues[10], themeValues[11]);
                BackgroundColor = Color.FromArgb(themeValues[12], themeValues[13], themeValues[14]);
                MenuColor = Color.FromArgb(themeValues[15], themeValues[16], themeValues[17]);
            }
            catch (Exception ex)
            {
                ErrorManager.MessageDisplay(ex.Message, "", "A saved theme file exist but an error occur in applying data. Using default theme instead");
                LoadDefaultThemeSetting();
                return;
            }
            UseCustomTheme = true;
        }

        internal static void DeleteCurrentThemeFile()
        {
            if (System.IO.File.Exists(defaultThemeFilePath))
            {
                try
                {
                    System.IO.File.Delete(defaultThemeFilePath);
                }
                catch 
                {
                }
            }
        }

        public static void LoadDefaultThemeSetting()
        {
            ThemeManager.NormalColor = ThemeManager.Default_NormalColor;
            ThemeManager.FocusColor = ThemeManager.Default_FocusColor;
            ThemeManager.ForeColor = ThemeManager.Default_ForeColor;
            ThemeManager.BackgroundColor = ThemeManager.Default_BackgroundColor;
            ThemeManager.MenuColor = ThemeManager.Default_MenuColor;
            ThemeManager.ButtonForeColor = ThemeManager.Default_ButtonForeColor;
            ThemeManager.BackgroundImageLink = "";
            ThemeManager.UseBackgroundImage = false;
            ThemeManager.UseCustomTheme = false;
        }

        internal static void SaveCurrentThemeToFile()
        {
            try
            {
                System.IO.StreamWriter savedFile = new System.IO.StreamWriter(defaultThemeFilePath);
                List<Color> temp = new List<Color>();
                temp.Add(NormalColor);
                temp.Add(FocusColor);
                temp.Add(ForeColor);
                temp.Add(ButtonForeColor);
                temp.Add(BackgroundColor);
                temp.Add(MenuColor);

                foreach (Color value in temp)
                {
                    savedFile.WriteLine(value.R.ToString());
                    savedFile.WriteLine(value.G.ToString());
                    savedFile.WriteLine(value.B.ToString());
                }
                savedFile.Close();
            }
            catch (Exception ex)
            {
                ErrorManager.MessageDisplay(ex.Message, "", "Can't saved data. Theme will be lost in the next reset");
                return;
            }


        }
        #endregion
    }
}
