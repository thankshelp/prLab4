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

        public Add(string sql, string gr)
        {
            InitializeComponent();

            this.num.Text = Uid.ToString();
            this.fio.Text = fio.ToString();
            //this.fiz.Text = phys
            //this.mat.Text = math
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
