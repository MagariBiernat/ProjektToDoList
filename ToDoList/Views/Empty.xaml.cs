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

namespace ToDoList.Views
{

    public partial class Empty : UserControl
    {
        private static SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True");
        public Empty()
        {

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CheckIfCompleted();
            Displaydata();

        }
        public void Displaydata()
        {
            SqlCommand comm = new SqlCommand("SELECT Id, text, data FROM tasks ORDER BY data ASC", conn);
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            DataTable dt = new DataTable("Tasks");
            sda.Fill(dt);
            EmptyTasks.ItemsSource = dt.DefaultView;
            if (EmptyTasks.Items.Count == 0)
            {
                EmptyTasks.Visibility = Visibility.Hidden;
                //Zdjencie.Source = Properties.Resources.no_tasks;
                Zdjencie.Visibility = Visibility.Visible;
            }
            else
            {
                Zdjencie.Visibility = Visibility.Hidden;
                EmptyTasks.Visibility = Visibility.Visible;

            }
        }
        public void DisplayDataHandler()
        {
            Displaydata();
        }
        static public void Refresh()
        {
            OnGoing Ongoing = new OnGoing();
            Ongoing.Displaydata();
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
            DataRowView drv = (DataRowView)EmptyTasks.SelectedItem;
            string a = drv["Id"].ToString();
            DeleteRow(a);
            Displaydata();
        }

        private void CheckIfCompleted()
        {
            DateTime dt = DateTime.Now;
            string ct = dt.ToShortTimeString();
            string cd = dt.ToShortDateString();
            string[] current_time = ct.Split(':');
            string[] current_date = cd.Split('.');
            List<string> IdCompleted = new List<string>(); // '2011-04-12T00:00:00.000' 
            SqlCommand comm = new SqlCommand("SELECT * FROM Tasks WHERE data <= CURRENT_TIMESTAMP ;", conn);
            // MessageBox.Show(" hi ");
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    string wynik = "";
                    while (reader.Read())
                    {
                        wynik += (reader.GetInt32(0).ToString());

                        IdCompleted.Add((reader.GetInt32(0)).ToString());
                    }
                    //     MessageBox.Show(wynik);
                }
                reader.Close();

                if (IdCompleted.Count > 0)
                {
                    for (int i = 0; i < IdCompleted.Count; i++)
                    {
                        SqlCommand komenda = new SqlCommand("DELETE FROM Tasks WHERE Id = " + IdCompleted[i] + " ;", conn);
                        SqlCommand command = new SqlCommand("INSERT INTO TasksCompleted (text, data, IsCompleted) VALUES((SELECT text FROM Tasks WHERE Id = " + IdCompleted[i] + "), (SELECT data FROM Tasks WHERE Id = " + IdCompleted[i] + "), '' );");
                        try
                        {
                            command.Connection = conn;
                            command.ExecuteNonQuery();
                            //           MessageBox.Show(IdCompleted[i]);
                            komenda.Connection = conn;
                            komenda.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Wystapil blad !" + ex);
                        }


                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Wystapil blad" + e);
            }
            finally
            {
                Displaydata();
                conn.Close();
            }

        }





    }

}