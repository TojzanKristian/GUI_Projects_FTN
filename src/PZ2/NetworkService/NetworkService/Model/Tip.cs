using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Documents;

namespace NetworkService.Model
{
    public class Tip : INotifyPropertyChanged
    {
        #region Polja
        private string ime;
        private string slika;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Konstruktori
        public Tip(string ime, string slika)
        {
            this.ime = ime;
            this.slika = slika;
        }

        public Tip()
        {
            ime = string.Empty;
            slika = string.Empty;
        }
        #endregion

        #region Svojstva
        public string Ime
        {
            get => ime;
            set
            {
                ime = value;
                RaisePropertyChanged("ime");
            }
        }

        public string Slika
        {
            get => slika;
            set
            {
                slika = value;
                RaisePropertyChanged("slika");
            }
        }
        #endregion

        #region Promena svojstva
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion
    }
}