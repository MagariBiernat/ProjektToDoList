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
    /// code-behind dla Udane.xaml
    /// </summary>
    public partial class Udane : UserControl
    {
        /// <summary>
        /// polaczenie
        /// </summary>
        private static SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        public Udane()
        {
            InitializeComponent();
        }
        private void Window_Loaded_Udane(object sender, RoutedEventArgs e)
        {
            Displaydata();
        }
        /// <summary>
        /// wyswietlenie danych z bazy danych dla rekordo z taskscompleted ktore maja w kolumnie "iscompleted" slowo udane.
        /// </summary>
        void Displaydata()
        {

            SqlCommand comm = new SqlCommand("SELECT Id, text, data FROM taskscompleted WHERE IsCompleted = 'Udane' ORDER BY data ASC", conn);
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            DataTable dt = new DataTable("TasksCompleted");
            sda.Fill(dt);
            CompletedTasks.ItemsSource = dt.DefaultView;
        }
    }
}
