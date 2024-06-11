using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _5_TASKWpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadFromRegistry();
        }

        private void Save_button_Click(object sender, RoutedEventArgs e)
        {
            string textColor = textcolor.Text;
            string backgroundColor = backgroundcolor.Text;
            string fontStyle = fontstyle.Text;
            string fontSize = fontsize.Text;

            try
            {

                TEXTBLOCK.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(textColor));
                Pref_Window.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(backgroundColor));
                TEXTBLOCK.FontSize = int.Parse(fontSize);
                TEXTBLOCK.FontFamily = new FontFamily(fontStyle);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SaveToRegistry();
        }

        private void SaveToRegistry()
        {
            try
            {
                string textColor = textcolor.Text;
                string backgroundColor = backgroundcolor.Text;
                string fontStyle = fontstyle.Text;
                string fontSize = fontsize.Text;

                // Применяем настройки к элементам
                TEXTBLOCK.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(textColor));
                Pref_Window.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(backgroundColor));
                TEXTBLOCK.FontSize = int.Parse(fontSize);
                TEXTBLOCK.FontFamily = new FontFamily(fontStyle);

                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\MyAppSettings");
                key.SetValue("TextColor", textColor);
                key.SetValue("BackgroundColor", backgroundColor);
                key.SetValue("FontStyle", fontStyle);
                key.SetValue("FontSize", fontSize);
                key.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadFromRegistry()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MyAppSettings");
                if (key != null)
                {
                    string textColor = (string)key.GetValue("TextColor", "Black");
                    string backgroundColor = (string)key.GetValue("BackgroundColor", "White");
                    string fontStyle = (string)key.GetValue("FontStyle", "Arial");
                    string fontSize = (string)key.GetValue("FontSize", "12");

                    TEXTBLOCK.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(textColor));
                    Pref_Window.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(backgroundColor));
                    TEXTBLOCK.FontSize = int.Parse(fontSize);
                    TEXTBLOCK.FontFamily = new FontFamily(fontStyle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

