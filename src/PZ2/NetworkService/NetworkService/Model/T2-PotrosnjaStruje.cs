using System.ComponentModel;
using System.Threading;
using System.Xml.Linq;

namespace NetworkService.Model
{
    public class T2_PotrosnjaStruje : INotifyPropertyChanged
    {
        #region Polja
        private int id;
        private string naziv;
        private Tip tip;
        private double vrednost;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Konstruktori
        public T2_PotrosnjaStruje()
        {
        }

        public T2_PotrosnjaStruje(int id, string naziv, Tip tip, double vrednost)
        {
            this.id = id;
            this.naziv = naziv;
            this.tip = tip;
            this.vrednost = vrednost;
        }

        public T2_PotrosnjaStruje(int id)
        {
            this.id = id;
        }

        public T2_PotrosnjaStruje(T2_PotrosnjaStruje p)
        {
            this.id = p.Id;
            this.Naziv = p.Naziv;
            this.vrednost =(double)p.vrednost;
            this.Tip = p.Tip;
        }
        #endregion

        #region Svojstva
        public int Id
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        public string Naziv
        {
            get { return naziv; }
            set
            {
                if (naziv != value)
                {
                    naziv = value;
                    RaisePropertyChanged("Naziv");
                }
            }
        }

        public Tip Tip
        {
            get => tip;
            set
            {
                tip = value;
                RaisePropertyChanged("Tip");
            }
        }
        public double Vrednost
        {
            get { return vrednost; }
            set
            {
                if (this.vrednost != value)
                {
                    this.vrednost = value;
                    RaisePropertyChanged("Vrednost");
                    ViewModel.GraphViewModel.ElementHeights.FirstBindingPoint = ViewModel.GraphViewModel.CalculateElementHeight();
                }
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