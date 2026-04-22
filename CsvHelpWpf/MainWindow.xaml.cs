using CsvCompEx;
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

namespace CsvHelpWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<CsvPersonData> importedPesons = new List<CsvPersonData>();

        public MainWindow()
        {
            InitializeComponent();
            importedPesons = CsvImporter.ImportSomeRecords("some-data.csv");

            dgCsvPersonData.ItemsSource = importedPesons;
        }
    }
}