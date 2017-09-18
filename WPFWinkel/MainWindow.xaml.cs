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
using System.ComponentModel;

namespace WPFWinkel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window//, INotifyPropertyChanged
    {
        public static ViewModel.WinkelMagazijn.WinkelVoorraad winkellijst = new ViewModel.WinkelMagazijn.WinkelVoorraad();
        public static ViewModel.WinkelMagazijn.WinkelMandje winkelmandje = new ViewModel.WinkelMagazijn.WinkelMandje();
        public static ViewModel.WinkelMagazijn.GebruikersnamenLijst gebruikersnamenlijst = new ViewModel.WinkelMagazijn.GebruikersnamenLijst();


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            WinkelLader();
        }

        private void WinkelLader() // Start de app op met de WinkelPagina
        {

            Hoofdscherm.Content = new LoginScherm();

        }
        #region Actions
        private void WinkelButton_Click(object sender, RoutedEventArgs e)
        {
            Hoofdscherm.Content = new WinkelPagina();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Hoofdscherm.Content = new LoginScherm();
        }

        private void MagazijnButton_Click(object sender, RoutedEventArgs e)
        {
            Hoofdscherm.Content = new Magazijn();
        }
        #endregion
    }
}