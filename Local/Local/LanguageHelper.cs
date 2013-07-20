using System.ComponentModel;
using System.Globalization;
using System.Threading;
using Local.Resources;

namespace Local
{
    public class LanguageHelper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void SetLanguage()
        {
            Helper.InitLanguage();
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Item[]"));
        }

        public string this[string key]
        {
            get
            {
                return Helper.GetString(key);
            }
        }

        /// <summary>
        /// for dynamic strings, used in code behind(.cs file)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string GetString(string key, params object[] parameters)
        {
            return string.Format(Helper.GetString(key), parameters);
        }

        /// <summary>
        /// singleton
        /// </summary>
        private class Helper
        {
            #region property
            private static bool isInit;
            #endregion

            public static void InitLanguage()
            {
                isInit = false;
            }

            public static string GetString(string key)
            {
                if (!isInit)
                    InitCurrentCulture();
                return AppResources.ResourceManager.GetString(key);
            }

            #region private method
            private static void InitCurrentCulture()
            {
                //change language here:
                var ci = CultureInfo.CurrentUICulture;
                if (!string.IsNullOrEmpty(App.CurrentLanguage))
                    ci = new CultureInfo(App.CurrentLanguage);
                else
                    App.CurrentLanguage = ci.Name;
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
                isInit = true;
            }
            #endregion
        }
    }
}
