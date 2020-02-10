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
using QR_LIBRARY;


namespace QR_work
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_generate_Click(object sender, RoutedEventArgs e)
        {
            string text = TBX_text.Text;
            string message = "";
            byte[] pic = null;
            int size = 0;
            foreach (RadioButton rb in spSize.Children)
            {
                if ((bool)rb.IsChecked)
                {
                    size = Convert.ToInt32(rb.Content);
                    break;
                }
            }

           if(QR.genQR(text, size,out message,out pic))
            {
                window pickWindow = new window(pic,150,150);
                pickWindow.Show();
            }


        }
    }
}
