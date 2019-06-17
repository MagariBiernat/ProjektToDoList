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


namespace ToDoList.Views
{
    /// <summary>
    /// Interaction logic for Completed.xaml
    /// </summary>
    public partial class Completed : UserControl
    {
        private static SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        public Completed()
        {
            InitializeComponent();
        }
        private void Window_Loaded_Completed(object sender, RoutedEventArgs e)
        {
            Displaydata();
        }
        void Displaydata()
        {
            
            SqlCommand comm = new SqlCommand("SELECT Id, text, data FROM taskscompleted WHERE IsCompleted = '' ORDER BY data ASC", conn);
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            DataTable dt = new DataTable("TasksCompleted");
            sda.Fill(dt);
            CompletedTasks.ItemsSource = dt.DefaultView;
        }
        void ChangeRow(string a, string b)
        {
            SqlCommand command = new SqlCommand();
            conn.Open();
            command.CommandText = "UPDATE TasksCompleted SET IsCompleted = '"+a+"' WHERE Id = '"+b+"' ;";    
            command.Connection = conn;
            command.ExecuteNonQuery();
            conn.Close();


        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)CompletedTasks.SelectedItem;
            string a = "Udane";
            string b = drv["Id"].ToString();
            ChangeRow(a, b);
            Displaydata();

        }
        private void Nieudane_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)CompletedTasks.SelectedItem;
            string a = "NieUdane";
            string b = drv["Id"].ToString();
            ChangeRow(a, b);
            Displaydata();
        }

    }
    
}
