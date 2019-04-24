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
        public int phys { get; set; }
        public int math { get; set; }
        
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
            try
            {
                m_dbConnection = new SQLiteConnection("Data Source=" + dlg.FileName + ";Version=3;");
                m_dbConnection.Open();
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Вы не выбрали файл!");
            }
            
        }
        

        private void Add_str_Click(object sender, RoutedEventArgs e)
        {
            

            adt = new Add();

            if (adt.ShowDialog() == true)
            {
                //int n = int.Parse(adt.num.Text);
                //string str = adt.fio.Text;
                //int f = int.Parse(adt.fiz.Text);
                //int m = int.Parse(adt.mat.Text);
                try
                {
                    if ((int.Parse(adt.fiz.Text) <= 5) && (int.Parse(adt.mat.Text) <= 5))
                    {
                        string sql = "INSERT INTO students (uid, FIO) VALUES (" + adt.num.Text + ",'" + adt.fio.Text + "')";
                        string gr = "INSERT INTO grades (uid, phys, math) VALUES (" + adt.num.Text + "," + adt.fiz.Text + "," + adt.mat.Text + ")";

                        SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                        SQLiteCommand grad = new SQLiteCommand(gr, m_dbConnection);
                        command.ExecuteNonQuery();
                        grad.ExecuteNonQuery();

                        var data = new CTest { uid = int.Parse(adt.num.Text), math = int.Parse(adt.mat.Text), phys = int.Parse(adt.fiz.Text), FIO = adt.fio.Text };
                        datag.Items.Add(data);
                    }
                    else
                    {
                        MessageBox.Show("Введены неверные оценки!");
                    }
                }
                catch (SQLiteException)
                {
                    MessageBox.Show("Неверный формат записи!");
                }
            }
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            datag.Items.Clear();
            
                string sql = "SELECT * FROM students, grades WHERE students.uid = grades.uid ORDER BY uid";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if ((int.Parse(reader["math"].ToString()) <= 5) && (int.Parse(reader["phys"].ToString()) <= 5))
                {
                    var data = new CTest { uid = int.Parse(reader["uid"].ToString()), math = int.Parse(reader["math"].ToString()), phys = int.Parse(reader["phys"].ToString()), FIO = reader["FIO"].ToString() };
                    datag.Items.Add(data);
                    //lb.Items.Add(reader["math"].ToString());
                    //lb.Items.Add(reader["FIO"].ToString());
                }
                else
                {
                    MessageBox.Show("Введеныне верные оценки!");
                    break;
                }
            }


        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (datag.SelectedIndex > -1)
            {
                CTest test = (CTest)datag.SelectedItem;

                adt = new Add(test.uid.ToString(), test.FIO.ToString(), test.phys.ToString(), test.math.ToString());

                if (adt.ShowDialog() == true)
                {
                    try
                    {
                        int si = datag.SelectedIndex;

                        datag.Items.RemoveAt(si);

                        string sql = "UPDATE students SET uid = " + adt.num.Text + ", FIO ='" + adt.fio.Text + "' WHERE uid = " + test.uid.ToString();
                        string gr = "UPDATE grades SET uid = " + adt.num.Text + ", phys =" + adt.fiz.Text + ", math =" + adt.mat.Text + " WHERE uid = " + test.uid.ToString();
                        SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                        SQLiteCommand grad = new SQLiteCommand(gr, m_dbConnection);

                        command.ExecuteNonQuery();
                        grad.ExecuteNonQuery();

                        var data = new CTest { uid = int.Parse(adt.num.Text), FIO = adt.fio.Text, phys = int.Parse(adt.fiz.Text), math = int.Parse(adt.mat.Text) };
                        datag.Items.Insert(si, data);
                        datag.Items.Refresh();
                    }
                    catch (FormatException)
                    {
                    MessageBox.Show("Неверный формат записи!");
                    }
                    catch (SQLiteException)
                    {
                        MessageBox.Show("Неверный формат записи!");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MessageBox.Show("База данных пуста или вы не вбрали элемент!");
                    }
                }
            }
            else
            {
                MessageBox.Show("База данных пуста!");
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (datag.SelectedIndex > -1)
            {
                
                    CTest test = (CTest)datag.SelectedItem;

                    datag.Items.RemoveAt(datag.SelectedIndex);

                    string sql = "DELETE FROM students WHERE uid =" + test.uid;
                    string gr = "DELETE FROM grades WHERE uid =" + test.uid;

                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    SQLiteCommand grad = new SQLiteCommand(gr, m_dbConnection);
                    command.ExecuteNonQuery();
                    grad.ExecuteNonQuery();
                
            }
            else
            {
                MessageBox.Show("База данных пуста или вы не вбрали элемент!");
            }
        }
    }
}
