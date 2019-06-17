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
            SqlCommand comm = new SqlCommand("SELECT text, data FROM tasks ORDER BY data ASC", con);
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            DataTable dt = new DataTable("Tasks");
            sda.Fill(dt);
            OnGoingTasks.ItemsSource = dt.DefaultView;
        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var contextMenu = (ContextMenu)menuItem.Parent;
            var item = (DataGrid)contextMenu.PlacementTarget;
            var item1 = (string)item.SelectedCells[0].Item;
            MessageBox.Show(item1);
        }
    }

}
