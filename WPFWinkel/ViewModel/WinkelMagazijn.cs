using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WebWinkelLibrary;

namespace WPFWinkel.ViewModel
{
    public class WinkelMagazijn
    {
        public class GebruikersnamenLijst : ObservableCollection<Gebruikersnaam>
        {
            public GebruikersnamenLijst()
            {
                Add(new Gebruikersnaam { Gebruiker = "Henk", Wachtwoord = "Henkie" });
                Add(new Gebruikersnaam { Gebruiker = "Ingrid", Wachtwoord = "Bloempot" });
            }
        }

        public List<Artikel> NieweWinkelLijst
        {
            get
            {
                return new List<Artikel>{
                new Artikel { Naam = "Boter", Hoeveelheid = 12, Prijs = 2M, Verkoper = "Admin" }, // creerd een artikel
                new Artikel { Naam = "Kaas", Hoeveelheid = 8, Prijs = 3M, Verkoper = "Admin" }, // creerd een artikel
                new Artikel { Naam = "Eieren", Hoeveelheid = 40, Prijs = 1M, Verkoper = "Admin" } // creerd een artikel
            };
            }
        }

        public WinkelMagazijn()
        {

        }

        public class WinkelVoorraad : ObservableCollection<Artikel>
        {
            public WinkelVoorraad()
            {
                Add(new Artikel { Naam = "Boter", Hoeveelheid = 12, Prijs = 2M, Verkoper = "Admin" }); // creerd een artikel
                Add(new Artikel { Naam = "Kaas", Hoeveelheid = 8, Prijs = 3M, Verkoper = "Admin" }); // creerd een artikel
                Add(new Artikel { Naam = "Eieren", Hoeveelheid = 40, Prijs = 1M, Verkoper = "Admin" }); // creerd een artikel
            }
        }

        /*public void LaadArtikelen()
        {
            ObservableCollection<Artikel> winkelLijst = new ObservableCollection<Artikel>();

            winkelLijst.Add(new Artikel { Naam = "Boter", Hoeveelheid = 12, Prijs = 2M, Verkoper = "Admin" }); // creerd een artikel
            winkelLijst.Add(new Artikel { Naam = "Kaas", Hoeveelheid = 8, Prijs = 3M, Verkoper = "Admin" }); // creerd een artikel
            winkelLijst.Add(new Artikel { Naam = "Eieren", Hoeveelheid = 40, Prijs = 1M, Verkoper = "Admin" }); // creerd een artikel

            //WinkelLijst = winkelLijst;
        }*/

        public class WinkelMandje : ObservableCollection<Artikel>
        {
            public WinkelMandje()
            { }
        }

        #region OudeCode
        /*public void LaadWinkelWagen()
        {
            System.Collections.ObjectModel.ObservableCollection < Artikel > winkelWagen = new ObservableCollection<Artikel>();

            winkelWagen.Add(new Artikel { Naam = "Boter", Hoeveelheid = 12, Prijs = 2M, Verkoper = "Admin" }); // creerd een artikel
            winkelWagen.Add(new Artikel { Naam = "Kaas", Hoeveelheid = 8, Prijs = 3M, Verkoper = "Admin" }); // creerd een artikel
            winkelWagen.Add(new Artikel { Naam = "Eieren", Hoeveelheid = 40, Prijs = 1M, Verkoper = "Admin" }); // creerd een artikel

            //WinkelWagen = winkelWagen;
        }*/
        #endregion
    }
}
