using ShootingRegistrationSystem;
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
using System.Windows.Shapes;

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
            List<User> listOfUsers;
            List<ShootingTypes> listOfShootingTypes;
            List<PaymentTypes> listOfPaymentTypes;
            List<Caliber> listOfCalibers;

            using (var db = new srsDBEntities())
            {
                listOfCalibers = db.Caliber.ToList();
                listOfUsers = db.User.ToList();
                listOfPaymentTypes = db.PaymentTypes.ToList();
                listOfShootingTypes = db.ShootingTypes.ToList();

            }
            cboCaliber.ItemsSource = listOfCalibers;
            cboUser.ItemsSource = listOfUsers;
            cboPaymentType.ItemsSource = listOfPaymentTypes;
            cboShootingType.ItemsSource = listOfShootingTypes;
            populateShootingListBox();
        }

        private void addShootingButton_click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)cboUser.SelectedItem;
            ShootingTypes selectedsShootingType = (ShootingTypes)cboShootingType.SelectedItem;
            PaymentTypes selectedPaymentType = (PaymentTypes)cboPaymentType.SelectedItem;
            Caliber selectedCaliber = (Caliber)cboCaliber.SelectedItem;

            using (var db = new srsDBEntities())
            {
                Shooting newShooting = new Shooting()
                {
                    CreationDate = DateTime.Now,
                    ShootingType = selectedsShootingType.Id,
                    PaymentType = selectedPaymentType.Id,
                    Caliber = selectedCaliber.Id,
                    isDone = false,
                    

                };
                User user = db.User.Where(i => i.Id == selectedUser.Id).FirstOrDefault();
                user.Shooting.Add(newShooting);

                db.SaveChanges();
            }
            populateShootingListBox();
        }

        private void lstShootings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void populateShootingListBox()
        {
            if (getAllShootings() != null)
            {
                lstShootings.ItemsSource = getAllShootings();
            }

        }

        private IEnumerable<Shooting> getAllShootings()
        {
            using (var db = new srsDBEntities())
            {
                return db.Shooting.ToList();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewUser newUser = new NewUser();
            newUser.Show();
        }
    }
}
