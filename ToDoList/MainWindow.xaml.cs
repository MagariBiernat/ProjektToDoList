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
using System.Threading;


namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool a = true;
        static string AM = "AM";
        public int temp = 0;
        public float suma = 0;
        public float wynik = 0;
        public decimal CompletedValue = 0;
        /// <summary>
        /// polaczenie
        /// </summary>
        private static SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True");
       
        public MainWindow()
        {
            Zliczanie();
            InitializeComponent();
            this.DataContext = new OnGoingModel();
            a = true;
            GaugeValue.Value = Convert.ToDouble(CompletedValue);





        }
        /// <summary>
        /// funkcja zliczajaca udane i nieudane zadania, zeby pozniej moc procentowo okreslic ilosc wykonanych pomyslnie zadan.
        /// </summary>
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
            //  gauge.CompletedValue = Udane.Count();
              temp = Udane.Count();
              suma = temp + NieUdane.Count();
              wynik = (temp / suma) * 100;
            // CompletedValue = temp.ToString();
            if (temp != 0)
            {
                CompletedValue = Convert.ToDecimal(Math.Round(wynik, 0 ));
            }

        }
        /// <summary>
        /// zwraca % wartosc wykonanych zadan.
        /// </summary>
        public double Get_CompletedValue()
        {
            // suma = temp + NieUdane.Count();
            wynik = (temp / suma) * 100;
            CompletedValue = Convert.ToDecimal(Math.Round(wynik, 0));
            return Convert.ToDouble(CompletedValue);
        }
        /// <summary>
        /// Wyswietlenie OnGoing strony poprzez model MVVM
        /// </summary>
        private void OnGoingTasks_Bttn_Click(object sender, RoutedEventArgs e)
        {
            a = true;
            DataContext = new OnGoingModel();
        }
        /// <summary>
        /// Wyswietlenie Completed strony poprzez model MVVM
        /// </summary>
        private void CompletedTasks_Bttn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CompletedModel();
        }
        /// <summary>
        /// Wyswietlenie Udane strony poprzez model MVVM
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new UdaneModel();
        }
        /// <summary>
        /// Wyswietlenie NieUdane strony poprzez model MVVM
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataContext = new NieUdaneModel();
        }

        /// <summary>
        /// funkcja dodajaca zadanie do bazy danych tasks z wartosciami podanymi w parametrach
        /// </summary>
        private void Create_Task_Query(string name_of_task, string date, string time)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "INSERT INTO Tasks (text, data) VALUES ( '" + name_of_task + "' , convert(datetime,'" + date + " " + time + " " + AM + "', 103));";


            try
            {
                conn.Open();
                command.Connection = conn;
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Wystapil blad! :" + e);
            }
            finally
            {
                
                conn.Close();
            }

        }
        /// <summary>
        /// Funkcja sprawdzajaca czy uzytkownik przypadkiem nie chce ustawic zadania na przeszla date.
        /// </summary>
        static public int CompareDates(DateTime actual, DateTime Task)
        {
            int value = DateTime.Compare(actual, Task);
            return value;
        }
        /// <summary>
        /// Button "utworz" tworzacy zadanie i uzywajacy poprzednie funkcje do dodania zadania, pobiera dane z kontrolek jak textbox, data i time picker, sprawdza czy nie sa puste/przeszle, i dodaje rekord do bazy, oraz przerzuca pomiedzy stronami modelu MVVM, jak OnGoing i Empty, by moc odswiezyc wyswietlane rekordy.
        /// </summary>
        private void Create_Task_Click(object sender, RoutedEventArgs e)
        {
         //   Check(); 
         
            
            DateTime dt = DateTime.Now;
            string ctn = dt.ToShortTimeString();
            string cdt = dt.ToShortDateString();
            var SavedDate = Date_Task.SelectedDate.Value.Date;
            var SavedText = Nameof_Task.Text;
            string datax = SavedDate.ToShortDateString();
            string x = Time_Task.SelectedTime.ToString();

            if ((datax != null) && (datax != ""))
            {
                if ((x != null) && (x != ""))
                {
                    if (SavedText != "")
                    {
                        string[] ct = ctn.Split(':'); // [0] = godz, [1] minuty, [2] sekundy [AKTUALNE]
                        string[] cd = cdt.Split('.', '/', '-');   // [0] = dzien, [1] miesiac [2] rok [AKTUALNE]

                        string[] task_date = datax.Split('.', '/','-'); // [0] = dzien, [1] miesiac [2] rok TASKA
                        string[] czas_of_task = x.Split(' ');
                        string[] task_time = czas_of_task[1].Split(':'); // [0] = godz, [1] minuty, [2] sekundy TASKA //

                        DateTime task = new DateTime(Int32.Parse(task_date[2]), Int32.Parse(task_date[1]), Int32.Parse(task_date[0]), Int32.Parse(task_time[0]), Int32.Parse(task_time[1]), 00);
                        int value = CompareDates(dt, task);
                        if (Int32.Parse(task_time[0]) > 12)
                            AM = "PM";
                        if (AM == "PM")
                        {
                            task_time[0] = (Int32.Parse(task_time[0]) - 12).ToString();
                        }


                        if (value < 0)
                        {
                            try
                            {
                                Create_Task_Query(SavedText, datax, czas_of_task[1]);
                                this.DataContext = new OnGoingModel();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Wystapil blad! :" + ex);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Podales stara date !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wpisz nazwe zadania");
                    }
                }
                else
                {
                    MessageBox.Show("Nie podales godziny !");
                }
            }
            else
            {
                MessageBox.Show("Nie podales daty !");
            }
            if (a == true)
            {
                this.DataContext = new EmptyModel();
                a = false;
            }
            else
            {
                this.DataContext = new OnGoingModel();
                a = true;
            }
        }
    }

    
    
}

