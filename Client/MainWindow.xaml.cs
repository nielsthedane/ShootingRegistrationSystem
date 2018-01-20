using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Threading;
using Business;
using Shared.Models;
using Binding = System.Windows.Data.Binding;
using Button = System.Windows.Controls.Button;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;


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
            setupDataGrid();
        }

        private void setupDataGrid()
        {
            dataGrid.CanUserAddRows = false;
            dataGrid.CellEditEnding += dataGrid_CellEditEnding;
            cboUser.SelectionChanged += cboUser_SelectionIndexChanged;
            Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() => dataGrid_DataBindingComplete(null, null)));
        }
        private void startShootingButton(object sender, RoutedEventArgs routedEventArgs)
        {
            var shooting = (ShootingModel) dataGrid.SelectedItem;
            dbManager.startStopShooting(shooting);
            populateLists();
        }

        private void sortDatagrid()
        {
            foreach (ShootingModel sModel in dataGrid.ItemsSource)
            {
                DataGridTemplateColumn buttonColumn = new DataGridTemplateColumn();
                DataTemplate buttonTemplate = new DataTemplate();
                FrameworkElementFactory buttonFactory = new FrameworkElementFactory(typeof (Button));
                buttonTemplate.VisualTree = buttonFactory;
            }
        }

        private void dataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //sortDatagrid();
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

        private void cboUser_SelectionIndexChanged(object sender, System.EventArgs e)
        {
            UserModel selectedUser = (UserModel)cboUser.SelectedItem;
            cboCaliber.ItemsSource = selectedUser.Caliber;
        }

        private void populateShootingListBox()
        {
            if (dbManager.GetAllShootings() != null)
            {
                var shootings = dbManager.GetAllShootings();
                dataGrid.ItemsSource = dbManager.GetAllShootings();
            }
        }

            private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewUser newUser = new NewUser();
            newUser.Show();
        }
    }
}
