using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Globalization;

namespace Local
{
    public partial class MainPage : PhoneApplicationPage
    {
        int counter = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(App.CurrentLanguage))
                App.CurrentLanguage = App.CurrentLanguage == "zh-CN" ? "en-US" : "zh-CN";

            //must use current instance:
            var helper = Application.Current.Resources["LanguageHelper"] as LanguageHelper;
            helper.SetLanguage();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            counter += 1;
            MessageBox.Show(LanguageHelper.GetString("Hello", counter));
        }
    }
}