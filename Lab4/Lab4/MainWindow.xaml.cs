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
using Microsoft.Win32;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class CTest
    {
        public int uid { get; set; }
        public string FIO { get; set; }
    }

    public partial class MainWindow : Window
    {
        Add adt;
        SQLiteConnection m_dbConnection;

        public MainWindow()
        {
            InitializeComponent();
            
            OpenFileDialog dlg = new OpenFileDialog();
             dlg.ShowDialog();

            m_dbConnection = new SQLiteConnection("Data Source=" + dlg.FileName + ";Version=3;");
            m_dbConnection.Open();
            
        }
        

        private void Add_str_Click(object sender, RoutedEventArgs e)
        {


            adt = new Add();

            if (adt.ShowDialog() == true)
            {
                //    //int n = int.Parse(adt.num.Text);
                //    //string str = adt.fio.Text;
                //    //int f = int.Parse(adt.fiz.Text);
                //    //int m = int.Parse(adt.mat.Text);

                string sql = "INSERT INTO students (uid, FIO) VALUES (" + adt.num.Text + ",'" + adt.fio.Text + "')";
                string gr = "INSERT INTO grades (uid, phys, math) VALUES (" + adt.num.Text + "," + adt.fiz.Text + "," + adt.mat.Text + ")";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteCommand grad = new SQLiteCommand(gr, m_dbConnection);
                command.ExecuteNonQuery();
                grad.ExecuteNonQuery();
            }
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM test2 ORDER BY uid";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())

        }
    }
}
