using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using AutoMapper;
using Business;
using Shared.Models;


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
            dataGrid.CellEditEnding += dataGrid_CellEditEnding;
        }

        private void startShootingButton(object sender, RoutedEventArgs routedEventArgs)
        {
            var shooting = (ShootingModel) dataGrid.SelectedItem;
            dbManager.startShooting(shooting);
            populateLists();
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var column = e.Column as DataGridBoundColumn;
                if (column != null)
                {
                    var bindingPath = (column.Binding as Binding).Path.Path;
                    if (bindingPath == "Shoots")
                    {
                        int rowIndex = e.Row.GetIndex();
                        var el = e.EditingElement as TextBox;
                        var shooting = (ShootingModel) dataGrid.SelectedItem;
                        int shootingid = shooting.Id;
                        int numberofShoots = Int32.Parse(el.Text);
                        dbManager.changeShootsOnShooting(numberofShoots,shootingid);
                    }
                }
            }
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
                dataGrid.ItemsSource = dbManager.GetAllShootings();
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
