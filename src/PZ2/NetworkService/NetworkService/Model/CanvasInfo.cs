using NetworkService.More;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NetworkService.Model
{
    public class CanvasInfo : BindableBase
    {
        #region Polja
        private T2_PotrosnjaStruje entitet;
        private bool taken;
        private int x, y;
        private readonly ObservableCollection<int> lines;
        #endregion

        #region Konstruktori
        public CanvasInfo(int ind)
        {
            Taken = false;
            Entitet = new T2_PotrosnjaStruje();
            X = 40 + (ind % 4) * 60;
            Y = 60 + (ind / 4) * 80;
            lines = new ObservableCollection<int>();
        }

        public CanvasInfo(T2_PotrosnjaStruje entitet, bool taken, int ind)
        {
            this.Entitet = entitet;
            this.Taken = taken;
            X = 40 + (ind % 4) * 60;
            Y = 60 + (ind / 4) * 80;
            lines = new ObservableCollection<int>();
        }
        #endregion

        #region Svojstva
        public Brush Background
        {
            get
            {
                if (Entitet.Tip != null)
                {
                    BitmapImage slika = new BitmapImage();
                    slika.BeginInit();
                    slika.UriSource = new Uri(Entitet.Tip.Slika);
                    slika.EndInit();
                    return new ImageBrush(slika);
                }
                else
                    return Brushes.Gainsboro;
            }
        }

        public string Text { get => Entitet.Naziv != null ? "Id: " + Entitet.Id + " Name: " + Entitet.Naziv + "Type: " + Entitet.Tip.Ime : ""; }

        public string Foreground { get => Uslov() ? "Blue" : "Red"; }

        public bool Uslov()
        {
            if (Entitet.Tip != null)
            {
                return false;
            }
            return true;
        }

        public bool Taken
        {
            get => taken;
            set
            {
                if (taken != value)
                {
                    taken = value;
                    OnPropertyChanged("Taken");
                }
            }
        }

        public T2_PotrosnjaStruje Entitet
        {
            get => entitet;
            set
            {
                entitet = value;
                OnPropertyChanged("Entitet");
                OnPropertyChanged("Foreground");
                OnPropertyChanged("Text");
            }
        }

        public int X
        {
            get => x;
            set
            {
                x = value;
                OnPropertyChanged("X");
            }
        }
        public int Y
        {
            get => y;
            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }

        public ObservableCollection<int> Lines
        {
            get => lines;
            set { Lines = value; OnPropertyChanged("Lines"); }
        }
    }
    #endregion
}