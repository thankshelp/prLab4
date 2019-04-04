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
using System.Data.SQLite;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Add adt;

        public MainWindow()
        {
            InitializeComponent();
            
            string db_name = "Lab4";

            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Sourse=" + db_name + ";Version=3");
        }

        private void Add_str_Click(object sender, RoutedEventArgs e)
        {
            adt = new Add();

            if (adt.ShowDialog() == true)
            {

            }
        }
    }
}
