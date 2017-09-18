using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace WebWinkelLibrary
{

    public class Artikel : INotifyPropertyChanged
    {
        public string naam;
        public int hoeveelheid;
        public decimal prijs;
        public string verkoper;

        public string Naam
        {
            get
            {
                return naam;
            }

            set
            {
                if (naam != value)
                {
                    naam = value;
                    RaisePropertyChanged("Naam");
                    RaisePropertyChanged("Hoeveelheid");
                    RaisePropertyChanged("Prijs");
                    RaisePropertyChanged("Verkoper");
                }
            }
        }

        public int Hoeveelheid
        {
            get
            {
                return hoeveelheid;
            }

            set
            {
                if (hoeveelheid != value)
                {
                    hoeveelheid = value;
                    RaisePropertyChanged("Naam");
                    RaisePropertyChanged("Hoeveelheid");
                    RaisePropertyChanged("Prijs");
                    RaisePropertyChanged("Verkoper");
                }
            }
        }

        public decimal Prijs
        {
            get
            {
                return prijs;
            }

            set
            {
                if (prijs != value)
                {
                    prijs = value;
                    RaisePropertyChanged("Naam");
                    RaisePropertyChanged("Hoeveelheid");
                    RaisePropertyChanged("Prijs");
                    RaisePropertyChanged("Verkoper");
                }
            }
        }

        public string Verkoper
        {
            get
            {
                return verkoper;
            }

            set
            {
                if (verkoper != value)
                {
                    verkoper = value;
                    RaisePropertyChanged("Naam");
                    RaisePropertyChanged("Hoeveelheid");
                    RaisePropertyChanged("Prijs");
                    RaisePropertyChanged("Verkoper");
                }
            }
        }

        public string ArtikelString
        {
            get
            {
                return string.Format("{0} - #{1} - €{2}", Naam, Hoeveelheid, Prijs);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }


}
