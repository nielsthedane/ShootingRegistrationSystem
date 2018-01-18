using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AutoMapper;
using Shared.Models;
using DAL;


namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IdbManager dbManager;


        public MainWindow()
        {
            this.dbManager = new DbManager();
            InitializeComponent();
            populateLists();
        }

        private void populateLists()
        {
            cboUser.ItemsSource = dbManager.GetAllUsers();
            cboCaliber.ItemsSource = dbManager.GetAllCaliberTypes();
            cboPaymentType.ItemsSource = dbManager.GetAllPaymentTypes();
            cboShootingType.ItemsSource = dbManager.GetAllShootingTypes();
            populateShootingListBox();
        }

        public MainWindow(DbManager dbManager)
        {
            this.dbManager = dbManager;
        }

        private void addShootingButton_click(object sender, RoutedEventArgs e)
        {
            dbManager.addNewShooting((UserModel)cboUser.SelectedItem,(ShootingTypesModel)cboShootingType.SelectedItem,(PaymentTypesModel)cboPaymentType.SelectedItem,(CaliberModel)cboCaliber.SelectedItem);
            populateShootingListBox();
        }

        private void lstShootings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void populateShootingListBox()
        {
            if (dbManager.GetAllShootings() != null)
            {
                var shootings = dbManager.GetAllShootings();
                lstShootings.ItemsSource = shootings;
            }
        }

        //}

            //private IEnumerable<Shooting> getAllShootings()
            //{
            //    using (var db = new srsDBEntities())
            //    {
            //        return db.Shooting.ToList();
            //    }

            //}

            private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewUser newUser = new NewUser();
            newUser.Show();
        }
    }
}
