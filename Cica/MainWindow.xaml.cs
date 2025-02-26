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

namespace Cica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Adatbazis a;
        private List<Cicak> lista;
        public MainWindow()
        {
            InitializeComponent();
            a = new Adatbazis();
        }

        private void adatokBetolteseButton_Click(object sender, RoutedEventArgs e)
        {
            lista = a.Feltolt();

            adatokDataGrid.ItemsSource = lista;
            adatokBetolteseButton.IsEnabled = false;
        }

        private void f2_Click(object sender, RoutedEventArgs e)
        {
            tBlock.Text = a.Kereses(textBox.Text);
        }

        private void nehez_Click(object sender, RoutedEventArgs e)
        {
            var legnehezebb = a.LengehezebbCica();

            tBlock.Text = $"{legnehezebb.Nev} {legnehezebb.Suly}";
        }

        private void rendetlen_Click(object sender, RoutedEventArgs e)
        {
            var legrendetlenebb = a.LengRendetlenebbCica();

            tBlock.Text = $"{legrendetlenebb.Nev} {legrendetlenebb.Rendetlensegi_szint}";
        }

        private void hozzaad_Click(object sender, RoutedEventArgs e)
        {
            string cicaNev = nev.Text;
            string cicaFajta = fajta.Text;
            float.TryParse(suuly.Text, out float suly);
            int.TryParse(rendetlenseg.Text, out int rendetlensegiSzint);

            bool siker = a.CicaHozzaadas(cicaNev, cicaFajta, suly, rendetlensegiSzint);
            if (siker)
            {
                tBlock.Text = "Sikeresen hozzáadva";
            }
            else
            {
                tBlock.Text = "Hiba történt";
            }
        }

        private void torles_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(textBox.Text);
        }
    }
}
