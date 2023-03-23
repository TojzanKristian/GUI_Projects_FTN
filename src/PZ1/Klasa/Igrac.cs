using System;
using System.Text;

namespace Klasa
{
    [Serializable]
    public class Igrac
    {
        #region Polja
        private string ime;
        private string prezime;
        private Int64 visina; 
        private string slika;
        private string fajl;
        private System.DateTime datum;
        #endregion

        #region Properties
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public Int64 Visina { get => visina; set => visina = value; }
        public string Slika { get => slika; set => slika = value; }
        public string Fajl { get => fajl; set => fajl = value; }
        public System.DateTime Datum { get => datum; set => datum = value; }
        #endregion

        #region Konstruktori
        public Igrac(string ime, string prezime, Int64 visina, string slika, string fajl, System.DateTime datum)
        {
            Ime = ime;
            Prezime = prezime;
            Visina = visina;
            Slika = slika;
            Fajl = fajl;
            Datum = datum;
        }

        public Igrac()
        {
        }
        #endregion
    }
}