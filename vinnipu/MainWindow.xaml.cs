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
            double eredmeny=0;
            switch(muvelet)
            {
                case "+":
                    eredmeny = elsoszam + double.Parse(kijelzo.Text);
                    break;
                case "-":
                    eredmeny = elsoszam - double.Parse(kijelzo.Text);
                    break;
                case "*":
                    eredmeny = elsoszam * double.Parse(kijelzo.Text);
                    break;
                case "/":
                    if (kijelzo.Text == "0")
                    {
                        MessageBox.Show("Nullával való osztás nem lehetséges!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
						eredmeny = elsoszam / double.Parse(kijelzo.Text);
					}
                    break;
            }
            kijelzo.Text = eredmeny.ToString();
            ujErtek = true;
		}

		private void c_Click(object sender, RoutedEventArgs e)
		{
            kijelzo.Text = "0";
            elsoszam = 0;
            muvelet = "";
            ujErtek = false;
		}

		private void vesszo_click(object sender, RoutedEventArgs e)
		{

		}

		private void pluszminusz_click(object sender, RoutedEventArgs e)
		{
            if (kijelzo.Text.StartsWith("."))
            {

            }
		}

		private void ce_Click(object sender, RoutedEventArgs e)
		{
			kijelzo.Text = "0";
			elsoszam = 0;
			muvelet = "";
			ujErtek = false;
		}

		private void back_Click(object sender, RoutedEventArgs e)
		{
            if (ujErtek) return;
            if (kijelzo.Text.Length > 1)
            {
                kijelzo.Text = kijelzo.Text.Remove(kijelzo.Text.Length - 1);
			}
            else
            {
                kijelzo.Text = "0";
			}
		}
	}
}