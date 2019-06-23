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
        static public int CompletedValuee = 0;
        static public int NotCompletedValuee = 0;
        private static SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True");
        public Completed()
        {
            InitializeComponent();
        }
        private void Window_Loaded_Completed(object sender, RoutedEventArgs e)
        {
            Zliczanie();
            Displaydata();
        }
        private void Zliczanie()
        {
            List<string> Udane = new List<string>();
            List<string> NieUdane = new List<string>();
            SqlCommand komendaU = new SqlCommand("SELECT * FROM TasksCompleted WHERE IsCompleted = 'Udane' ;", conn);
            SqlCommand komendaN = new SqlCommand("SELECT * FROM TasksCompleted WHERE IsCompleted = 'NieUdane' ;", conn);
            try
            {
                conn.Open();
                SqlDataReader reader = komendaU.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Udane.Add((reader.GetInt32(0)).ToString());
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Wystapil blad !" + e);
            }
            finally
            {
                conn.Close();
            }

            try
            {
                conn.Open();
                SqlDataReader reader = komendaN.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        NieUdane.Add((reader.GetInt32(0)).ToString());
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Wystapil blad !" + e);
            }
            finally
            {
                conn.Close();
            }
            CompletedValuee = Udane.Count();
            NotCompletedValuee = NieUdane.Count();
            // MessageBox.Show(aaa + " helo " + bbb);

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
            command.CommandText = "UPDATE TasksCompleted SET IsCompleted = '" + a + "' WHERE Id = '" + b + "' ;";
            command.Connection = conn;
            command.ExecuteNonQuery();
            conn.Close();


        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DataRowView drv = (DataRowView)CompletedTasks.SelectedItem;
                string a = "Udane";
                string b = drv["Id"].ToString();
                ChangeRow(a, b);
                Displaydata();
                drv = null;
                UpdateLayout();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Wystapil blad " + e1);
            }
        }
        private void Nieudane_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DataRowView drv = (DataRowView)CompletedTasks.SelectedItem;
                string a = "NieUdane";
                string b = drv["Id"].ToString();
                ChangeRow(a, b);
                Displaydata();
                drv = null;
                UpdateLayout();
            }
            catch (Exception e2)
            {
                MessageBox.Show("Wystapil blad " + e2);
            }
        }

    }

}