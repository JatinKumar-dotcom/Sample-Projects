using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SpareB_BGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Accommodation> accommodations = new List<Accommodation>();
        private AccommodationManager accommodationManager;
        public MainWindow()
        {
            InitializeComponent();
            accommodationManager = new AccommodationManager();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeData();
        }

        private void InitializeData()
        {
            itemListBox.ItemsSource = accommodationManager.GetAvailableAccommodations();
            itemListBox.DisplayMemberPath = "DisplayInfo"; // Corrected the assignment

        }
        public string DisplayInfo
        {
            get
            {
                return accommodationManager.GetAvailableAccommodationsAsString();
            }
        }
        public string DisplayData
        {
            get
            {
                return accommodationManager.GetBookedAccommodationsAsString();
            }
        }
        private void BookItem_Click(object sender, RoutedEventArgs e)
        {
            if (itemListBox.SelectedItem is Accommodation selectedAccommodation && selectedAccommodation != null)
            {
                string userName = detailsTextBox.Text;
                User currentUser = new User(userName);

                if (!string.IsNullOrEmpty(userName))
                {
                    accommodationManager.MakeBooking(selectedAccommodation, currentUser);
                    MessageBox.Show("Booking Confirmed."+ userName);
                    // Update the itemListBox to reflect changes
                    itemListBox.ItemsSource = accommodationManager.GetAvailableAccommodations();
                    itemListBox.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Please select a user.");
                }
            }
            else
            {
                MessageBox.Show("Please select a bookable item.");
            }
        }
    }
}
