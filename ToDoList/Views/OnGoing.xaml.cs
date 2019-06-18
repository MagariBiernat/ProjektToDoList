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
    /// Interaction logic for OnGoing.xaml
    /// </summary>
    public partial class OnGoing : UserControl
    {
        private static SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        public OnGoing()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Displaydata();
        }
        void Displaydata()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand comm = new SqlCommand("SELECT Id, text, data FROM tasks ORDER BY data ASC", con);
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            DataTable dt = new DataTable("Tasks");
            sda.Fill(dt);
            OnGoingTasks.ItemsSource = dt.DefaultView;
        }
        public void DisplayDataHandler()
        {
            Displaydata();
        }
        void DeleteRow(string a)
        {
            SqlCommand command = new SqlCommand();
            conn.Open();
            command.CommandText = "DELETE FROM Tasks WHERE Id = '" + a + "' ;";
            command.Connection = conn;
            command.ExecuteNonQuery();
            conn.Close();

        }
        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)OnGoingTasks.SelectedItem;
            string a = drv["Id"].ToString();
            DeleteRow(a);
            Displaydata();
        }
        
        
            

        
    }

}
