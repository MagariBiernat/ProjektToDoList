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
    /// Code-behind dla Completed.xaml
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
        /// <summary>
        /// Metoda wywoluajca sie w momencie zaladowania okna Completed.xaml
        /// </summary>
        private void Window_Loaded_Completed(object sender, RoutedEventArgs e)
        {
         
            Displaydata();
        }
        /// <summary>
        /// wyswietlenie danych z bazy danych do datagrida ktore nie zostaly zastwierdzone jako pomyslnie lub nie, zakonczone.
        /// </summary>
        void Displaydata()
        {

            SqlCommand comm = new SqlCommand("SELECT Id, text, data FROM taskscompleted WHERE IsCompleted = '' ORDER BY data ASC", conn);
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            DataTable dt = new DataTable("TasksCompleted");
            sda.Fill(dt);
            CompletedTasks.ItemsSource = dt.DefaultView;
        }
        /// <summary>
        /// Funkcja
        /// </summary>
        void ChangeRow(string a, string b)
        {
            SqlCommand command = new SqlCommand();
            conn.Open();
            command.CommandText = "UPDATE TasksCompleted SET IsCompleted = '" + a + "' WHERE Id = '" + b + "' ;";
            command.Connection = conn;
            command.ExecuteNonQuery();
            conn.Close();
            
        }


        /// <summary>
        /// Context menu dla udanego zadania, jednoczesnie zwiekszajacego wartosc dla zmiennych w mainwindow.cs odnosnie wykresu z lewej strony % 
        /// </summary> 
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DataRowView drv = (DataRowView)CompletedTasks.SelectedItem;
                string a = "Udane";
                string b = drv["Id"].ToString();
                ChangeRow(a, b);
                 ((MainWindow)App.Current.MainWindow).temp++;
                ((MainWindow)App.Current.MainWindow).suma++;
                ((MainWindow)App.Current.MainWindow).GaugeValue.Value = ((MainWindow)App.Current.MainWindow).Get_CompletedValue();
                Displaydata();
                drv = null;
                 //((MainWindow)App.Current.MainWindow).Zliczanie();
                UpdateLayout();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Wystapil blad " + e1);
            }
        }
        /// <summary>
        /// Context menu dla nieudanego zadania, jednoczesnie zwiekszajacego wartosc dla zmiennych w mainwindow.cs odnosnie wykresu z lewej strony % 
        /// </summary> 
        private void Nieudane_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DataRowView drv = (DataRowView)CompletedTasks.SelectedItem;
                string a = "NieUdane";
                string b = drv["Id"].ToString();
                ChangeRow(a, b);
                ((MainWindow)App.Current.MainWindow).suma++;
                ((MainWindow)App.Current.MainWindow).GaugeValue.Value = ((MainWindow)App.Current.MainWindow).Get_CompletedValue();
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