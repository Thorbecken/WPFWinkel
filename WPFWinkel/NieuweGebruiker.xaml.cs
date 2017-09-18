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

namespace WPFWinkel
{
    /// <summary>
    /// Interaction logic for NieuweGebruiker.xaml
    /// </summary>
    public partial class NieuweGebruiker : Page
    {
        public NieuweGebruiker()
        {
            InitializeComponent();
        }

        private void gebruikersnaamAanmaakButton_Click(object sender, RoutedEventArgs e)
        {
            #region BlancoIngevuld
            if (gebruikersnaamTextBox.Text == "")
            { MessageBox.Show("Vul een gebruikersnaam in"); }
            else if (wachtwoordTextBox.Text == "")
            { MessageBox.Show("Vul een wachtwoord in"); }
            else if (voornaamTextBox.Text == "")
            { MessageBox.Show("Vul een voornaam in"); }
            else if (achternaamTextBox.Text == "")
            { MessageBox.Show("Vul een achternaam in"); }
            else if (emailAdresTextBox.Text == "")
            { MessageBox.Show("Vul een email adres in"); }
            #endregion
            else
            {
                string nieuwGebruikersnaam = gebruikersnaamTextBox.Text;
                string nieuwWachtwoord = wachtwoordTextBox.Text;
                string nieuwVoornaam = voornaamTextBox.Text;
                string nieuwAchternaam = achternaamTextBox.Text;
                string nieuwEmailAdres = emailAdresTextBox.Text;
                bool gebruikersnaamNietGebruikt = new bool();
                gebruikersnaamNietGebruikt = true;

                foreach (WebWinkelLibrary.Gebruikersnaam gebruiker in MainWindow.gebruikersnamenlijst)
                {
                    if (nieuwGebruikersnaam == gebruiker.Gebruiker)
                    { gebruikersnaamNietGebruikt = false; }
                }

                if (gebruikersnaamNietGebruikt)
                {
                    WebWinkelLibrary.Gebruikersnaam nieuwGebruiker = new WebWinkelLibrary.Gebruikersnaam
                    {
                        Gebruiker = nieuwGebruikersnaam,
                        Wachtwoord = nieuwWachtwoord,
                        Voornaam = nieuwVoornaam,
                        Achternaam = nieuwAchternaam,
                        Email = nieuwEmailAdres,
                    };
                    MainWindow.gebruikersnamenlijst.Add(nieuwGebruiker);
                    MessageBox.Show("Gebruikersnaam is aangemaakt");
                }
            }
        }
    }
}
