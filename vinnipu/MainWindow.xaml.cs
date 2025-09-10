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

namespace vinnipu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double elsoszam = 0;
        private string muvelet = "";
        private bool ujErtek=false;
        public MainWindow()
        {
            InitializeComponent();
        }

		private void szam_Click(object sender, RoutedEventArgs e)
		{
            var gomb = (Button)sender;
            var szam= gomb.Content.ToString();
            if (kijelzo.Text=="0" || ujErtek)
            {
                kijelzo.Text = szam;
                ujErtek = false;
            }
            else
            {
                kijelzo.Text += szam;
            }
		}

		private void muvelet_Click(object sender, RoutedEventArgs e)
		{
            var gomb= (Button)sender;
            elsoszam = double.Parse(kijelzo.Text);
            muvelet= gomb.Content.ToString();
            ujErtek= true;
		}

		private void egyenloseg_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}