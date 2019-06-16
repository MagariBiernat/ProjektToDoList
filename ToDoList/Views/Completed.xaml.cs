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
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand comm = new SqlCommand("SELECT text, data, priority, IsCompleted FROM taskscompleted", con);
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            DataTable dt = new DataTable("TasksCompleted");
            sda.Fill(dt);
            CompletedTasks.ItemsSource = dt.DefaultView;
        }
    }
}
