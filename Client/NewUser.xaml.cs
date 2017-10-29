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
using ShootingRegistrationSystem;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Caliber> listOfCalibers;
            using (var db = new srsDBEntities())
            {
                listOfCalibers = db.Caliber.ToList();
            }
            lstCalibreListBox.ItemsSource = listOfCalibers;
        }


        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new srsDBEntities())
            {
                User newUser = new User()
                {
                    FirstName = firstNameBox.Text,
                    LastName = lastNameBox.Text,
                };

                foreach (Caliber caliber in lstCalibreListBox.SelectedItems)
                {
                    newUser.Caliber.Add(db.Caliber.Where(o => o.Name == caliber.Name).FirstOrDefault());
                }

                db.User.Add(newUser);
                db.SaveChanges();
            }

            firstNameBox.Clear();
            lastNameBox.Clear();

            MessageBox.Show("Brugeren er blevet tilføjet!");
        }
    }
}
