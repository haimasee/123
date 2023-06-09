using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace WpfAppPract4
{
    public partial class add_tip_window : Window
    {
        public add_tip_window()
        {
            InitializeComponent();
            update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tip_textbox.Text != "")
            {
                (Application.Current.MainWindow as MainWindow).new_tip = tip_textbox.Text;
                //MessageBox.Show(mainWindow.new_tip);
                DialogResult = true;
            }
        }

        private void set_ru(object sender, RoutedEventArgs e)
        {
            string a = "them.txt";
            File.WriteAllText(a, "ru_local");
            update();
        }

        private void set_eng(object sender, RoutedEventArgs e)
        {
            string a = "them.txt";
            File.WriteAllText(a, "eng_local");
            update();
        }
        void update()
        {
            string a = "them.txt";
            if (!File.Exists(a) || File.ReadAllText(a) == "")
            {
                File.WriteAllText(a, "ru_local");
            }
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary { Source = new Uri($"pack://application:,,,/local;component/{File.ReadAllText(a)}.xaml") });
            if (File.ReadAllText(a) == "ru_local")
            {
                (cont.Items[0] as MenuItem).Header = "Поставить русский язык";
                (cont.Items[1] as MenuItem).Header = "Поставить английский язык";
            }
            else
            {
                (cont.Items[0] as MenuItem).Header = "set russian language";
                (cont.Items[1] as MenuItem).Header = "Set english language";

            }
        }
    }
}
