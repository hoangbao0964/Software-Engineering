using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.BLL
{
    class LanguageManager
    {
        protected static string currentLanguage = "Language.En.resx";
        protected static CultureInfo cultureProvider;   
        protected static ResourceManager source = new ResourceManager("Project_BookCoffeeManagement.Resources.Languages.Language", typeof(MainActive).Assembly);
        protected static string default_CurrentLanguage = "Language.En.resx";
        protected static CultureInfo default_CultureProvider = CultureInfo.CreateSpecificCulture("En");

        protected static bool useCustomLanguage = false;

        #region Get/Set properties
        public static string CurrentLanguage
        {
            get
            {
                return currentLanguage;
            }

            set
            {
                currentLanguage = value;
            }
        }

        public static CultureInfo CultureProvider
        {
            get
            {
                return cultureProvider;
            }

            set
            {
                cultureProvider = value;
            }
        }

        public static ResourceManager Source
        {
            get
            {
                return source;
            }
        }

        public static string Default_CurrentLanguage
        {
            get
            {
                return default_CurrentLanguage;
            }
        }

        public static CultureInfo Default_CultureProvider
        {
            get
            {
                return default_CultureProvider;
            }
        }

        public static bool UseCustomLanguage
        {
            get
            {
                return useCustomLanguage;
            }

            set
            {
                useCustomLanguage = value;
            }
        }

        #endregion

        public string ChangeName(string NameTag)
        {
            return Source.GetString(NameTag, CultureProvider);
        }

        public static void LoadDefaultLanguageSetting()
        {
            LanguageManager.CurrentLanguage = LanguageManager.Default_CurrentLanguage;
            LanguageManager.CultureProvider = LanguageManager.Default_CultureProvider;
            LanguageManager.UseCustomLanguage = false;
        }

    }
}
