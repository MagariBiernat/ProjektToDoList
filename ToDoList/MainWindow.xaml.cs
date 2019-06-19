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
        private static SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new OnGoingModel();
        }

        private void OnGoingTasks_Bttn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new OnGoingModel();
        }
        private void CompletedTasks_Bttn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CompletedModel();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new UdaneModel();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataContext = new NieUdaneModel();
        }
        

        private void Create_Task_Query(string name_of_task, string date, string time)
        {
            SqlCommand command = new SqlCommand();
            
            command.CommandText = "INSERT INTO Tasks (text, data) VALUES ( '" + name_of_task + "' , convert(datetime,'" + date + " " + time + " AM', 103));";
            

            try
            {
                conn.Open();
                command.Connection = conn;
                command.ExecuteNonQuery();
               

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
                        string[] cd = cdt.Split('.');   // [0] = dzien, [1] miesiac [2] rok [AKTUALNE]

                        string[] task_date = datax.Split('.'); // [0] = dzien, [1] miesiac [2] rok TASKA
                        string[] czas_of_task = x.Split(' ');
                        string[] task_time = czas_of_task[1].Split(':'); // [0] = godz, [1] minuty, [2] sekundy TASKA //
                        if (Int32.Parse(task_date[2]) == Int32.Parse(cd[2]))
                        {
                            if (Int32.Parse(task_date[1]) > Int32.Parse(cd[1]))
                            {

                                try
                                {
                                    Create_Task_Query(SavedText, datax, czas_of_task[1]);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Wystapil blad! :" + ex);
                                }



                            }
                            else if (Int32.Parse(task_date[1]) == Int32.Parse(cd[1]))
                            {
                                if (Int32.Parse(task_date[0]) > Int32.Parse(cd[0]))
                                {
                                    try
                                    {
                                        Create_Task_Query(SavedText, datax, czas_of_task[1]);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Wystapil blad! :" + ex);
                                    }
                                }
                                else if (Int32.Parse(task_date[0]) == Int32.Parse(cd[0]))
                                {
                                    if (Int32.Parse(task_time[0]) > Int32.Parse(ct[0]))
                                    {
                                        try
                                        {
                                            Create_Task_Query(SavedText, datax, czas_of_task[1]);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Wystapil blad! :" + ex);
                                        }
                                    }
                                    else if (Int32.Parse(task_time[0]) == Int32.Parse(ct[0]))
                                    {
                                        if (Int32.Parse(task_time[1]) > Int32.Parse(ct[1]))
                                        {
                                            try
                                            {
                                                Create_Task_Query(SavedText, datax, czas_of_task[1]);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("Wystapil blad! :" + ex);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Podales zla godzine");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Podales zla godzine");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Podales zla date");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Podales zla date");
                            }
                        }
                        else if (Int32.Parse(task_date[2]) > Int32.Parse(cd[2]))
                        {

                            try
                            {
                                Create_Task_Query(SavedText, datax, czas_of_task[1]);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Wystapil blad! :" + ex);
                            }


                        }
                        else
                        {
                            MessageBox.Show("Podales zla date");
                        }

                    }

                    else
                    {
                        MessageBox.Show("Nie wprowadziles nazwy zadania !");
                    }
                }
                else
                {
                    MessageBox.Show("Podaj godzine...");
                }
            }
            else
            {
                MessageBox.Show("Podaj date...");
            }

        }
    }
   
}

