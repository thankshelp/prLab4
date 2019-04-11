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
using System.Windows.Shapes;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
        }

        public Add(string uid, string fio, string p, string m)
        {
            InitializeComponent();

            this.num.Text = uid;
            this.fio.Text = fio;
            this.fiz.Text = p;
            this.mat.Text = m;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Otm_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
