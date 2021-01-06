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
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.IO;
using System.Security.Cryptography;

namespace VerticalRoot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            databaseconnection d = new databaseconnection();
            d.Show();
            this.Title = "Login";
            InitializeComponent();

            //OPENING FORMS FOR TESTING
           // databaseconnection egg = new databaseconnection();
           // egg.Show();

            //plantdetail p = new plantdetail();
            //p.Show();

            //Dashboard dash = new Dashboard();
            //dash.Show();

            //CropDetail cropdetail = new CropDetail();
            //cropdetail.Show();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;


            //tbUsername.Text = "Enter text here...";

            //tbUsername.GotFocus += GotFocus.EventHandle(RemoveText);
            //tbUsername.LostFocus += LostFocus.EventHandle(AddText);
        }
        //public void RemoveText(object sender, EventArgs e)
        //{
        //    if (tbUsername.Text == "Enter text here...")
        //    {
        //        tbUsername.Text = "";
        //    }
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = tbUsername2.Text;
            string password = tbPassword2.Text;
            Login login = new Login();
            login.checkLogin(username, password);


            //if login is succesfull
            if (true)
            {
                MainWindow mnwindow = new MainWindow();
                mnwindow.Close();
                Dashboard dash = new Dashboard();
                dash.Show();
            }
            //if login is onsuccesfull
            if (false)
            {
                MessageBox.Show("Login unsuccessfull, please try again");

            }

       

        }

        private void SearchTermTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
