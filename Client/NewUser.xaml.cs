using System;
using System.Collections;
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
using Business;
using Shared.Models;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        private readonly IdbManager dbManager;
        public NewUser()
        {
            dbManager = new DbManager();
            InitializeComponent();
            lstCalibreListBox.ItemsSource = dbManager.getAllCalibers();
        }


        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (firstNameBox.Text.Length != 0 && lastNameBox.Text.Length != 0 &&
                lstCalibreListBox.SelectedItems.Count != 0)
            {
                ICollection<CaliberModel> calibers = new List<CaliberModel>();
                foreach (CaliberModel caliber in lstCalibreListBox.SelectedItems)
                {
                    calibers.Add(caliber);
                }
                var userModel = new UserModel()
                {
                    FirstName = firstNameBox.Text,
                    LastName = lastNameBox.Text,
                    Caliber = calibers
                };
                dbManager.addNewUser(userModel);

                firstNameBox.Clear();
                lastNameBox.Clear();
                lstCalibreListBox.SelectedItems.Clear();

                MessageBox.Show("Brugeren er blevet tilføjet!");
            }
            else
            {
                MessageBox.Show("Du har enten glemt Fornavn, Efternavn, eller kalibre");
            }

        }
    }
}
