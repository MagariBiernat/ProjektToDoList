﻿using System;
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
    /// Interaction logic for Udane.xaml
    /// </summary>
    public partial class Udane : UserControl
    {
        private static SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        public Udane()
        {
            InitializeComponent();
        }
        private void Window_Loaded_Udane(object sender, RoutedEventArgs e)
        {
            Displaydata();
        }
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
