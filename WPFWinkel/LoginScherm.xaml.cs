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
    /// Interaction logic for LoginScherm.xaml
    /// </summary>
    public partial class LoginScherm : Page
    {
        public LoginScherm()
        {
            InitializeComponent();
        }

        private void inlogButton_Click(object sender, RoutedEventArgs e)
        {
            string IngegevenGebruikersnaam = gebruikersnaamTextBox.Text;
            string IngegevenWachtwoord = wachtwoordTextBox.Text;
            bool CombinatieOnjuist = new bool();
            CombinatieOnjuist = true;

            foreach (WebWinkelLibrary.Gebruikersnaam Gebruikersnaam in MainWindow.gebruikersnamenlijst)
            {
                if (Gebruikersnaam.Gebruiker == IngegevenGebruikersnaam)
                {
                    if (IngegevenWachtwoord == Gebruikersnaam.Wachtwoord)
                    {
                        MessageBox.Show("Wachtwoord is juist");

                        var mainWin = Application.Current.Windows
                            .Cast<Window>()
                            .FirstOrDefault(window => window is MainWindow) as MainWindow;

                        mainWin.GebruikersnaamLabel.Content = IngegevenGebruikersnaam;

                       CombinatieOnjuist = false;
                    }
                }
            }
            if (CombinatieOnjuist)
            {
                MessageBox.Show("Gebruikersnaam wachtwoord combinatie is incorrect");
            }
        }

        private void nieuweGebruikerButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWin = Application.Current.Windows
                            .Cast<Window>()
                            .FirstOrDefault(window => window is MainWindow) as MainWindow;

            mainWin.Hoofdscherm.Content = new NieuweGebruiker();
        }
    }
}
