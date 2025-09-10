using System.Globalization;
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
			string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (ujErtek)
			{
				kijelzo.Text = "0";
				ujErtek = false;
			}
			if (!kijelzo.Text.Contains(decimalSeparator))
			{
				kijelzo.Text += decimalSeparator;
			}
		}

		private void pluszminusz_click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(kijelzo.Text) || kijelzo.Text == "0") return;
			double value;
			if (double.TryParse(kijelzo.Text, out value))
			{
				value = -value;
				kijelzo.Text = value.ToString();
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

		private void ablakpreviewkeydown(object sender, KeyEventArgs e)
		{
			string keyString = "";

			if (e.Key >= Key.D0 && e.Key <= Key.D9)
			{
				keyString = (e.Key - Key.D0).ToString();
			}
			else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
			{
				keyString = (e.Key - Key.NumPad0).ToString();
			}
			else
			{
				return;
			}
			if (kijelzo.Text == "0" || ujErtek)
			{
				kijelzo.Text = keyString;
				ujErtek = false;
			}
			else
			{
				kijelzo.Text += keyString;
			}
			e.Handled = true;
			switch(e.Key)
			{
				case Key.Add:
					muvelet_Click(new Button() { Content = "+" }, new RoutedEventArgs());
					e.Handled = true;
					break;
				case Key.Subtract:
					muvelet_Click(new Button() { Content = "-" }, new RoutedEventArgs());
					e.Handled = true;
					break;
					case Key.Multiply:
					muvelet_Click(new Button() { Content = "*" }, new RoutedEventArgs());
					e.Handled = true;
					break;
				case Key.Divide:
					muvelet_Click(new Button() { Content = "/" }, new RoutedEventArgs());
					e.Handled = true;
					break;
				case Key.Enter:
					egyenloseg_Click(this, new RoutedEventArgs());
					e.Handled = true;
					break;
				case Key.Back:
					back_Click(this, new RoutedEventArgs());
					e.Handled = true;
					break;
				case Key.Delete:
					ce_Click(this, new RoutedEventArgs());
					e.Handled = true;
					break;
				case Key.Escape:
					c_Click(this, new RoutedEventArgs());
					e.Handled = true;
					break;
				case Key.Decimal:
				case Key.OemComma:
				case Key.OemPeriod:
					vesszo_click(this, new RoutedEventArgs());
					e.Handled = true;
					break;
			}
		}

	}
}