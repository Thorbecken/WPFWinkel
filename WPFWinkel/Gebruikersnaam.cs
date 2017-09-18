using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebWinkelLibrary
{
    public class Gebruikersnaam
    {
        public string Gebruiker { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }

        public List<Artikel> WinkelWagenLijst { get; set; }
    }
}
