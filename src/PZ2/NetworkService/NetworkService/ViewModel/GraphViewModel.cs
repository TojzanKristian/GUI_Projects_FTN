using NetworkService.Model;
using NetworkService.More;
using System.Collections.Generic;

namespace NetworkService.ViewModel
{
    public class GraphViewModel : BindableBase
    {
        // Pomoćna polja
        public static GraphUpdater ElementHeights { get; set; } = new GraphUpdater();
        public List<int> ComboBoxData { get; set; } = new List<int>();

        private static int idForShow = -1;
        public MyICommand ShowCommand { get; set; }

        private int selektovanID;

        // Svojstvo za selektovan ID
        public int IDForShow
        {
            get { return idForShow; }
            set { if (idForShow != value) { idForShow = value; } }
        }

        // Funkcija koja menja grafikon
        public static double CalculateElementHeight(double value, int index)
        {
            if (idForShow == index || idForShow == -1) { return 60 + (2.73*1000 - value) * 0.001; }
            return 100;
        }

        // Konstruktor
        public GraphViewModel()
        {
            ShowCommand = new MyICommand(OnShow);
            foreach (T2_PotrosnjaStruje p in PotrosnjaViewModel.Potrosnje) { ComboBoxData.Add(p.Id); }
        }

        // Prikaz kada se stisne na Show dugme
        private void OnShow()
        {
            idForShow = selektovanID;
        }

        // Promena u ComboBoxu
        public int SelektovanID
        {
            get { return selektovanID; }
            set
            {
                if (selektovanID != value)
                {
                    selektovanID = value;
                    OnPropertyChanged("SelektovanID");
                }
            }
        }
    }
}