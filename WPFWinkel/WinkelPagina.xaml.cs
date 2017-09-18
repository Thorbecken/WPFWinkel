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
    /// Interaction logic for WinkelPagina.xaml
    /// </summary>
    public partial class WinkelPagina : Page
    {
        //private List<Artikel> winkelWagen = new List<Artikel>();
        //private List<Artikel> items = new List<Artikel>();

        public WinkelPagina()
        {
            InitializeComponent();
            //SetupData();

            AssortimentBox.ItemsSource = MainWindow.winkellijst;
            WinkelWagenBox.ItemsSource = MainWindow.winkelmandje;
        }

        /*private void SetupData() // gooit wat data in het programma
        {
            // Gebruikersnaam demoGebruikersnaam = new Gebruikersnaam(); // pas nodig wanneer er ingelogd kan worden            
            items.Add(new Artikel { Naam = "Boter", Hoeveelheid = 12, Prijs = 2M, Verkoper = "Admin" }); // creerd een artikel
            items.Add(new Artikel { Naam = "Kaas", Hoeveelheid = 8, Prijs = 3M, Verkoper = "Admin" }); // creerd een artikel
            items.Add(new Artikel { Naam = "Eieren", Hoeveelheid = 40, Prijs = 1M, Verkoper = "Admin" }); // creerd een artikel

            //winkel.Verkoper = "Boer Harms";
        }*/

        private void Kwanteit_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AssortimentBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ToevoegButton_Click(object sender, RoutedEventArgs e) // doet de gewenste hoeveelheid van het geselecteerde product van het magazijn naar de winkelwagen
        {
            #region Informatie verzamelen
            Artikel geselecteerdeArtikel = (Artikel)AssortimentBox.SelectedItem; // zorgt ervoor dat het geselcteerde item in het assortiment een instantie krijgt
            int GekozenHoeveelheid; // maakt een variabele hoeveelheid aan
            bool KwantiteitCorrectIngevuld = new bool();
            KwantiteitCorrectIngevuld = true;
            #endregion

            #region CijferControle

            try
            {
                GekozenHoeveelheid = Convert.ToInt32(Kwantiteit.Text);
            }
            catch (System.FormatException)
            {
                System.Windows.MessageBox.Show("Graag alleen cijfers");
                KwantiteitCorrectIngevuld = false;
            }

            #endregion

            if (KwantiteitCorrectIngevuld)
            {
                #region Hoeveelheidscontrole
                GekozenHoeveelheid = Convert.ToInt32(Kwantiteit.Text);
                if (GekozenHoeveelheid < 1)
                { }
                else if (GekozenHoeveelheid > geselecteerdeArtikel.Hoeveelheid)
                {
                    KwantiteitCorrectIngevuld = false;
                    System.Windows.MessageBox.Show("Hellaas hebben we niet zoveel op voorraad");
                }
                #endregion
                else
                {
                    // stap 2 producten uit de winkel halen
                    geselecteerdeArtikel.Hoeveelheid = (geselecteerdeArtikel.Hoeveelheid - GekozenHoeveelheid); // haald het aantal producten uit de winkellijst 

                    // stap 3 producten in de winkelwagen stoppen
                    Artikel toegevoegdArtikel = new Artikel { Naam = geselecteerdeArtikel.Naam, Hoeveelheid = GekozenHoeveelheid, Prijs = geselecteerdeArtikel.Prijs, Verkoper = "Admin" }; // maakt een nieuw object aan die de naam en prijs overneemt van het geselecteerde object en de hoeveelheid die geselecteerd is
                    MainWindow.winkelmandje.Add(toegevoegdArtikel); // voegt het geselecteerde artikel toe aan de winkelwagenlijst

                    //stap 4 informatie zichtbaarmaken
                    AssortimentBox.Items.Refresh(); // zorgt ervoor dat de assortimentbox 'up to date' is
                    WinkelWagenBox.Items.Refresh(); // zorgt ervoor dat de winkelwagenbox 'up to date' is

                    //MessageBox.Show(GekozenHoeveelheid.ToString()); // test of de int goed wordt gepakt.
                    //MessageBox.Show(geselcteerdeArtikel); // test of het geselecteerde artikel goed wordt gepakt    
                }
            }
        }
        public string SelectedPath { get; set; }

        #region OudekoopButton
        private void KoopButton_Click(object sender, RoutedEventArgs e)// maakt het winkelwagentje leeg en laat je een text bestand opslaan van de bestelling
        {
            System.Windows.MessageBox.Show("Hallo");
            string printDocument = "Uw bestelling:" + System.Environment.NewLine;
            decimal totaleKosten = 0; //dit voorkomt een "can't decimal to int" problemen
            foreach (var Artikel in MainWindow.winkelmandje) // Maakt voor elk artikel in de winkelwagen een popup waarin de Naam+Hoeveelheid+Prijs+Subtotaal wordt weergegen
            {
                string printRegel = (string.Format("Product: {0}", Artikel.Naam + " - Hoeveelheid: " + Artikel.Hoeveelheid + " - Prijs: €" + Artikel.Prijs + " Subtotaal: €" + (Artikel.Hoeveelheid * Artikel.Prijs) + " "));
                printDocument += (System.Environment.NewLine + printRegel);

                decimal aankoopHoeveelheid = (decimal)Artikel.Hoeveelheid;
                totaleKosten += (aankoopHoeveelheid * Artikel.Prijs);
            }
            printDocument += (System.Environment.NewLine + System.Environment.NewLine + "Totale kosten: €" + totaleKosten);
            //System.Windows.MessageBox.Show(printDocument); // test de de regels die geprint moeten worden

            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, printDocument);

            MainWindow.winkelmandje.Clear(); // leegt de winkelwagen
            WinkelWagenBox.Items.Refresh(); // zorgt ervoor dat de winkelwagenbox 'up to date' is
        }
        #endregion

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void KoopButton_Click_1(object sender, RoutedEventArgs e)// maakt het winkelwagentje leeg en laat je een text bestand opslaan van de bestelling
        {
            string printDocument = "Uw bestelling:" + System.Environment.NewLine;
            decimal totaleKosten = 0; //dit voorkomt een "can't decimal to int" problemen
            foreach (var Artikel in MainWindow.winkelmandje) // Maakt voor elk artikel in de winkelwagen een popup waarin de Naam+Hoeveelheid+Prijs+Subtotaal wordt weergegen
            {
                string printRegel = (string.Format("Product: {0}", Artikel.Naam + " - Hoeveelheid: " + Artikel.Hoeveelheid + " - Prijs: €" + Artikel.Prijs + " Subtotaal: €" + (Artikel.Hoeveelheid * Artikel.Prijs) + " "));
                printDocument += (System.Environment.NewLine + printRegel);

                decimal aankoopHoeveelheid = (decimal)Artikel.Hoeveelheid;
                totaleKosten += (aankoopHoeveelheid * Artikel.Prijs);
            }
            printDocument += (System.Environment.NewLine + System.Environment.NewLine + "Totale kosten: €" + totaleKosten);
            //System.Windows.MessageBox.Show(printDocument); // test de de regels die geprint moeten worden

            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, printDocument);

            MainWindow.winkelmandje.Clear(); // leegt de winkelwagen
            WinkelWagenBox.Items.Refresh(); // zorgt ervoor dat de winkelwagenbox 'up to date' is
        }
    }
}