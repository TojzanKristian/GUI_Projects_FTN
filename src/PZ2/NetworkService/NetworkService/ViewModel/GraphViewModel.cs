using NetworkService.Model;
using NetworkService.More;
using System;
using System.Collections.Generic;
using System.IO;

namespace NetworkService.ViewModel
{
    public class GraphViewModel : BindableBase
    {
        // Pomoćna polja
        public static GraphUpdater ElementHeights { get; set; } = new GraphUpdater(); // ažuriranje grafa
        public List<int> ComboBoxData { get; set; } = new List<int>(); // pomoćna lista za prikaz IDva u ComboBoxu
        public MyICommand ShowCommand { get; set; } // Komanda za prikaz po odabranom entitetu

        private int selektovanID; // pomoćno polje za selektovan ID

        // Konstruktor
        public GraphViewModel()
        {
            ShowCommand = new MyICommand(OnShow);
            foreach (T2_PotrosnjaStruje p in PotrosnjaViewModel.Potrosnje) { ComboBoxData.Add(p.Id); }
        }

        // Prikaz kada se stisne na Show dugme
        private void OnShow()
        {
            Random random = new Random();
            double[] randomNums = { 0.0, 0.0, 0.0, 0.0, 0.0 };

            for (int i = 0; i < 5; i++)
            {
                randomNums[i] = random.NextDouble() * (0.8 - 0.1) + 0.1;
            }

            List<double> doubles = LoadLastFiveUpdates(SelektovanID.ToString());

            ElementHeights.FirstBindingPoint = (200 - doubles[0]) * randomNums[0];
            ElementHeights.SecondBindingPoint = (200 - doubles[1]) * randomNums[1];
            ElementHeights.ThirdBindingPoint = (200 - doubles[2]) * randomNums[2];
            ElementHeights.FourthBindingPoint = (200 - doubles[3]) * randomNums[3];
            ElementHeights.FifthBindingPoint = (200 - doubles[4]) * randomNums[4];
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

        // Funkcija koja čita vrednosti iz 'LogFile.txt'
        private List<double> LoadLastFiveUpdates(string selectedId)
        {
            if (!File.Exists("LogFile.txt"))
            {
                return null;
            }

            string[] lines = File.ReadAllLines("LogFile.txt");

            List<double> lastFiveUpdates = new List<double>();

            for (int i = 0; i < 5; i++)
            {
                string line = lines[i];

                // preuzimanje IDa
                string[] parts = line.Split('_');
                string id = parts[1];

                // preuzimanje vrednosti
                int startIndex = line.IndexOf("Value:") + 6;
                int endIndex = line.Length;
                string val = line.Substring(startIndex, endIndex - startIndex).Trim();

                if (id.Contains(selectedId) && lastFiveUpdates.Count < 5)
                {
                    double newV = double.Parse(val);
                    if (newV > 0.34 && newV < 2.73)
                    {
                        lastFiveUpdates.Add(newV);
                    }
                    else
                    {
                        lastFiveUpdates.Add(0);
                    }
                }
            }

            return (lastFiveUpdates.Count == 5) ? lastFiveUpdates : null;
        }
    }
}