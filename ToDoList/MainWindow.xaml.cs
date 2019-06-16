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
using ToDoList.ViewModels;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
    }
}
