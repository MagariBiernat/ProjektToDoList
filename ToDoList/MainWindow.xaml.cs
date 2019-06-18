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
        string DejtaContext = "OnGoingModel";
        private static SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new OnGoingModel();
        }

        private void OnGoingTasks_Bttn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new OnGoingModel();
            DejtaContext = "OnGoingModel";
        }
        private void CompletedTasks_Bttn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CompletedModel();
            DejtaContext = "CompletedModel";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new UdaneModel();
            DejtaContext = "UdaneModel";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataContext = new NieUdaneModel();
            DejtaContext = "NieUdaneModel";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        
private void Create_Task_Query(string name_of_task, string date, string time)
        {
            SqlCommand command = new SqlCommand();
            
            command.CommandText = "INSERT INTO Tasks (text, data) VALUES ( '" + name_of_task + "' , convert(datetime,'" + date + " " + time + " AM', 103));";
            
            try
            {
                conn.Open();
                command.Connection = conn;
                command.ExecuteNonQuery();
              /*  if (DejtaContext == "OnGoingModel")
                {
                    NotifyPropertyChanged("DataContext"); 
                } */ // tutaj jakis event co bedzie zmienial ongoing model w przypadku gdzie sie zmieni i jest aktualny na ekranie.

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
            var SavedDate = Date_Task.SelectedDate.Value.Date;
            var SavedText = Nameof_Task.Text;
            string datax = SavedDate.ToShortDateString();
            string x = Time_Task.SelectedTime.ToString();
            string[] data = x.Split(' ');
            if (SavedText != "" && datax.Length > 0 && data[1].Length > 0)
            {
                try
                {
                    Create_Task_Query(SavedText, datax, data[1]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystapil blad! :" + ex);
                }
                
            }
            else
            {
                MessageBox.Show("Wprowadziles niepoprawne dane !");
            }
            
        }
    }
   
}
