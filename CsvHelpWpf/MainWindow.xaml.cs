using CsvCompEx;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace CsvHelpWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<CsvPersonData> importedPersons = new List<CsvPersonData>();

        //NEW CSV for AU places
        public List<AustraliaPlace> auPlaces = CsvImporter.ImportPlaces("australia-100-places.csv");
        public List<AustraliaTouristSpot> auTouristSpots = CsvImporter.ImportTouristPlaces("australia-tourist-spots.csv");

        //Interface for sorting, filtering, grouping, etc. of the data in the UI
        //CollectionView wraps around a List
        private ICollectionView? _personView;

        private ICollectionView? _placeView;

        //private ICollectionView? _touristView;

        public MainWindow()
        {
            InitializeComponent();
            importedPersons = CsvImporter.ImportSomeRecords("some-data.csv");

            //List wraps CollectionView and binds to DG
            _personView = CollectionViewSource.GetDefaultView(importedPersons);

            _placeView = CollectionViewSource.GetDefaultView(auTouristSpots);
            //dgCsvPersonData.ItemsSource = importedPersons;
            dgCsvPersonData.ItemsSource = auTouristSpots;
        }

        private void CSVPersonData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 

            if (dgCsvPersonData.SelectedItem is CsvPersonData selectedPerson)
            {
                //MessageBox.Show($"Hey you click on {selectedPerson.Name}");
                //LETS update OUR FORM x:Name
                fnameTxtBox.Text = selectedPerson.Name;
                genderTxtBox.Text = selectedPerson.Gender;
                ageTxtBox.Text = $"{selectedPerson.Age}";//selectedPerson.Age.ToString(); //AGE is int

                birthdayYear.Content = $"{selectedPerson.Id}.Birthday Year: {selectedPerson.BirthdayYear}";
            }
        }

        private void FilterTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //If empty we can't find anything so just return > save resources
            if (_placeView == null) return;

            string filterText = filterTxtBox.Text.ToLower();

            // If the box is empty > remove the filter THEN show everything
            if (string.IsNullOrWhiteSpace(filterText))
            {
                _placeView.Filter = null;
            }
            else
            {
                // Returns true = show, false = hide > Filter Props
                _placeView.Filter = item =>
                {
                    if (item is AustraliaTouristSpot place)
                        return place.State != null &&
                               place.State.ToLower().Contains(filterText);
                    return false;
                };
            }
        }
    }
}