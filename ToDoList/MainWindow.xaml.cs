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
using System.Data;
using System.Data.SqlClient;
using ToDoList.ViewModels;
using ToDoList.Views;
using System.ComponentModel;


namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new OnGoingModel();
        }

        private void OnGoingTasks_Bttn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new OnGoingModel();
        }
        private void CompletedTasks_Bttn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CompletedModel();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new UdaneModel();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataContext = new NieUdaneModel();
        }
        

        private void Create_Task_Query(string name_of_task, string date, string time)
        {
            SqlCommand command = new SqlCommand();
            
            command.CommandText = "INSERT INTO Tasks (text, data) VALUES ( '" + name_of_task + "' , convert(datetime,'" + date + " " + time + " AM', 103));";
            

            try
            {
                conn.Open();
                command.Connection = conn;
                command.ExecuteNonQuery();
               

            }
            catch (Exception e)
            {
                MessageBox.Show("Wystapil blad! :" +e);
            }
            finally
            {
                conn.Close();
            }
            
        }
        private void Create_Task_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            string current_time_now = dt.ToShortTimeString();
            string current_date_today = dt.ToShortDateString();
            string[] current_time = current_time_now.Split(':');
            string[] current_date = current_date_today.Split('.');
            var SavedDate = Date_Task.SelectedDate.Value.Date;
            var SavedText = Nameof_Task.Text;
            
            string datax = SavedDate.ToShortDateString();
            string x = Time_Task.SelectedTime.ToString();
            string[] dzisiaj = datax.Split('.');
            string[] kczas = x.Split(' ');
            string[] data = kczas[1].Split(':');
            
            
            if (Int32.Parse(dzisiaj[2]) >= Int32.Parse(current_date[2]))
            {
                if ((Int32.Parse(dzisiaj[1]) >= Int32.Parse(current_date[1])) && (Int32.Parse(dzisiaj[0]) >= Int32.Parse(current_date[0])))
                {
                    if ((current_date_today == datax) && (Int32.Parse(data[0]) == Int32.Parse(current_time[0])) && (Int32.Parse(data[1]) <= Int32.Parse(current_time[1]) )  )
                    {
                        MessageBox.Show("Wprowadziles zla godzine!");

                    }
                    else if ((current_date_today == datax) && (Int32.Parse(data[0]) < Int32.Parse(current_time[0])))
                    {
                        MessageBox.Show("Wprowadziles zla godzine!");
                    }
                    else
                    {

                        if (SavedText != "" && datax.Length >= 0 && data[1].Length > 0)
                        {
                            try
                            {
                                Create_Task_Query(SavedText, datax, kczas[1]);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Wystapil blad! :" + ex);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Nie wprowadziles nazwy zadania !");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wprowadziles niepoprawna date !");
                }
            }
            else
            {
                MessageBox.Show("Wprowadziles niepoprawna date! !");
            }
        }
    }
   
}
