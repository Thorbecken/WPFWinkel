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
using WebWinkelLibrary;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace WPFWinkel
{
    /// <summary>
    /// Interaction logic for Magazijn.xaml
    /// </summary>
    public partial class Magazijn : Page
    {
        /*public List<Artikel> NieweWinkelLijst
        {
            get
            {
                return new List<Artikel>{
                new Artikel { Naam = "Boter", Hoeveelheid = 12, Prijs = 2M, Verkoper = "Admin" }, // creerd een artikel
                new Artikel { Naam = "Kaas", Hoeveelheid = 8, Prijs = 3M, Verkoper = "Admin" }, // creerd een artikel
                new Artikel { Naam = "Eieren", Hoeveelheid = 40, Prijs = 1M, Verkoper = "Admin" } // creerd een artikel
            };
            }
        }*/

        public Magazijn()
        {
            InitializeComponent();
            DataContext = this;

            magazijnListbox.ItemsSource = MainWindow.winkellijst; // moet geen two way binding hebben om te werken
        }

        #region Actions
        private void nieuwArtikelButton_Click(object sender, RoutedEventArgs e)
        {
            #region DataControle
            bool HoeveelheidCorrect = new bool();
            bool PrijsCorrect = new bool();
            HoeveelheidCorrect = true;
            PrijsCorrect = true;

            try { Convert.ToInt32(hoeveelheidTextBox.Text); }
            catch (System.FormatException)
            {
                HoeveelheidCorrect = false;
                System.Windows.MessageBox.Show("Graag een hoeveelheid in cijfers aangeven");
            }

            if (HoeveelheidCorrect)
            {
                try { Convert.ToDecimal(prijsTextBox.Text); }
                catch (System.FormatException)
                {
                    PrijsCorrect = false;
                    System.Windows.MessageBox.Show("Graag een prijs in cijfers aangeven");
                }
            }

            if (HoeveelheidCorrect)
            {
                if (PrijsCorrect)
                {

                    #endregion

                    #region DataVerzameling
                    string nieuwArtikelNaam = naamTextBox.Text; // maakt variabele nieuwArtikelNaam aan met input van de naamTextBox
                    int nieuwArtikelHoeveelheid = Convert.ToInt32(hoeveelheidTextBox.Text); //nieuwArtikelHoeveelheid
                    decimal nieuwArtikelPrijs = Convert.ToDecimal(prijsTextBox.Text); //nieuwArtikelPrijs
                    #endregion

                    #region ArtikelToevoegen
                    Artikel nieuwArtikel = new Artikel
                    {
                        Naam = nieuwArtikelNaam,
                        Hoeveelheid = nieuwArtikelHoeveelheid,
                        Prijs = nieuwArtikelPrijs,
                        Verkoper = "Admin"
                    }; // maakt een nieuw object aan die de naam en prijs overneemt van het geselecteerde object en de hoeveelheid die geselecteerd is
                    MainWindow.winkellijst.Add(nieuwArtikel); // voegt het geselecteerde artikel toe aan de winkelwagenlijst
                    #endregion
                }
            }
        }

        private void verwijderButton_Click(object sender, RoutedEventArgs e)
        {
            Artikel geselecteerdeArtikel = (Artikel)magazijnListbox.SelectedItem; // zorgt ervoor dat het geselcteerde item in het assortiment een instantie krijgt
            MainWindow.winkellijst.Remove(geselecteerdeArtikel);
        }

        private void wijzigArtikelButton_Click(object sender, RoutedEventArgs e)
        {
            #region DataControle
            bool HoeveelheidCorrect = new bool();
            bool PrijsCorrect = new bool();
            HoeveelheidCorrect = true;
            PrijsCorrect = true;

            try { Convert.ToInt32(hoeveelheidTextBox.Text); }
            catch (System.FormatException)
            {
                HoeveelheidCorrect = false;
                System.Windows.MessageBox.Show("Graag een hoeveelheid in cijfers aangeven");
            }
            try { Convert.ToDecimal(prijsTextBox.Text); }
            catch (System.FormatException)
            {
                PrijsCorrect = false;
                System.Windows.MessageBox.Show("Graag een prijs in cijfers aangeven");
            }

            if (HoeveelheidCorrect)
            {
                if (PrijsCorrect)
                {

                    #endregion

                    Artikel geselecteerdeArtikel = (Artikel)magazijnListbox.SelectedItem;
                    geselecteerdeArtikel.Naam = naamTextBox.Text;
                    geselecteerdeArtikel.Hoeveelheid = Convert.ToInt32(hoeveelheidTextBox.Text);
                    geselecteerdeArtikel.Prijs = Convert.ToDecimal(prijsTextBox.Text);

                    magazijnListbox.Items.Refresh();
                }
            }
        }
        #endregion
    }
}
