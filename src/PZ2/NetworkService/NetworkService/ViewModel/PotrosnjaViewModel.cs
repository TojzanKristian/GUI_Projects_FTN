using NetworkService.Model;
using NetworkService.More;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace NetworkService.ViewModel
{
    class PotrosnjaViewModel : BindableBase
    {
        // Definicija listi koji nam trebaju za rad
        public static List<string> T2Tipovi { get; set; } = new List<string> { "Interval Meter", "Smart Meter" };
        private ObservableCollection<T2_PotrosnjaStruje> FilterPotrosnje { get; set; } = new ObservableCollection<T2_PotrosnjaStruje>();
        public static ObservableCollection<T2_PotrosnjaStruje> Potrosnje { get; set; } = new ObservableCollection<T2_PotrosnjaStruje>();
        public static ObservableCollection<T2_PotrosnjaStruje> PotrosnjeCopy { get; set; } = new ObservableCollection<T2_PotrosnjaStruje>();
        public ObservableCollection<Tip> Tipovi_Potrosnje { get; set; }

        // Pomoćna polja za funkcionisanje
        private string selektovanTipPotrosnje = string.Empty; // Za selekciju Tipa za filtriranje
        private string idForFilterText = ""; // Za unos IDa za filtriranje
        private int lowOrHigh = -1; // Za odabir <, > ili =
        private T2_PotrosnjaStruje selektovanaPotrosnja; // Za prikaz u DataGridu
        private string idText; // Za unos IDa kod dodavanje novog entiteta
        private string nazivText; // Za unos naziva kod dodavanje novog entiteta
        private string selektovanTipPotrosnje2 = string.Empty; // Za selekciju Tipa za dodavenje novog entiteta
        private bool filtercan = false; // Promenljiva za rad filtriranja
        private int idForFilter = -1; // Promenljiva za id kod filtriranja

        // Definisanje komandi
        public MyICommand LowValueCommand { get; set; } // Ako se označi radioButton za manje
        public MyICommand HighValueCommand { get; set; } // Ako se označi radioButton za veće
        public MyICommand EqualValueCommand { get; set; } // Ako se označi radioButton za jednako
        public MyICommand FilterCommand { get; set; } // Komanda za pokretanje filtriranja
        public MyICommand CancelFilterCommand { get; set; } // Komanda za poništavanje filtriranja
        public MyICommand AddCommand { get; set; } // Komanda za dodavenj novog entiteta
        public MyICommand DeleteCommand { get; set; } // Komanda za brisanje entiteta iz DataGrida

        // Konstruktor
        public PotrosnjaViewModel()
        {
            LowValueCommand = new MyICommand(OnLow);
            HighValueCommand = new MyICommand(OnHigh);
            EqualValueCommand = new MyICommand(OnEqual);
            FilterCommand = new MyICommand(OnFilter, CanFilter);
            CancelFilterCommand = new MyICommand(OnCancel, CanCancel);
            AddCommand = new MyICommand(OnAdd, CanAdd);
            DeleteCommand = new MyICommand(OnDelete, CanDelete);

            Tipovi_Potrosnje = new ObservableCollection<Tip>();
            Tipovi_Potrosnje.Add(DodavanjeSlike.tipovi_potrosnje[0]);
            Tipovi_Potrosnje.Add(DodavanjeSlike.tipovi_potrosnje[1]);
        }

        // Svojstvo za selektovan tip potrošnje kod filtriranja
        public string SelektovanTipPotrosnje
        {
            get => selektovanTipPotrosnje;
            set
            {
                if (selektovanTipPotrosnje != value)
                {
                    selektovanTipPotrosnje = value;
                    OnPropertyChanged("SelektovanTipPotrosnje");
                    FilterCommand.RaiseCanExecuteChanged();
                }
            }
        }

        // Svojstvo za selektovanu potrošnju
        public T2_PotrosnjaStruje SelektovanaPotrosnja
        {
            get
            {
                return selektovanaPotrosnja;
            }
            set
            {
                selektovanaPotrosnja = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        // Svojstvo za unos IDa
        public string IdText
        {
            get
            {
                return idText;
            }
            set
            {
                if (idText != value)
                {
                    idText = value;
                    OnPropertyChanged("IdText");
                    AddCommand.RaiseCanExecuteChanged();
                }
            }
        }

        // Svojstvo za unos Naziva
        public string NazivText
        {
            get
            {
                return nazivText;
            }
            set
            {
                if (nazivText != value)
                {
                    nazivText = value;
                    OnPropertyChanged("NzivText");
                    AddCommand.RaiseCanExecuteChanged();
                }
            }
        }

        // Svojstvo za selektovan tip potrošnje kod dodavanja
        public string SelektovanTipPotrosnje2
        {
            get => selektovanTipPotrosnje2;
            set
            {
                if (selektovanTipPotrosnje2 != value)
                {
                    selektovanTipPotrosnje2 = value;
                    OnPropertyChanged("SelektovanTipPotrosnje2");
                    AddCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public int LowOrHigh { get => lowOrHigh; set => lowOrHigh = value; } // Svojstvo za označeno <, >, =
        public int IdForFilter { get => idForFilter; set => idForFilter = value; } // Svojstvo za ID kod filtriranja
        public string IdForFilterText { get => idForFilterText; set => idForFilterText = value; } // Svojstvo unet ID kod filtriranja 

        // Provera da li može da se briše, da li je nešto označeno
        private bool CanDelete()
        {
            return SelektovanaPotrosnja != null;
        }

        // Brisanje entiteta iz DataGrida
        private void OnDelete()
        {
            Potrosnje.Remove(SelektovanaPotrosnja);
        }

        // Provera da li je moguće dodavanje, da li su sva polja popunjena
        private bool CanAdd()
        {
            if (SelektovanTipPotrosnje2 != null && IdText != null && NazivText != null)
            {
                return true;
            }
            return false;
        }

        // Dodavanje entiteta
        private void OnAdd()
        {
            int tempID = 0;
            try
            {
                tempID = Int32.Parse(IdText);
            }
            catch
            {
                System.Windows.MessageBox.Show("ID must be a number!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string tempS = NazivText;
            if (string.IsNullOrWhiteSpace(tempS))
            {
                System.Windows.MessageBox.Show("The name must not be a white space!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            bool exists = false;
            foreach (T2_PotrosnjaStruje s in Potrosnje)
            {
                if (s.Id == tempID)
                {
                    exists = true;
                }
            }
            if (exists)
            {
                System.Windows.MessageBox.Show("ID must be unique!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Random random = new Random();
            double randomNum = random.NextDouble() * (2.73 - 0.34) + 0.34;
            double roundedNum = Math.Round(randomNum, 2);
            Model.Tip temp;
            if (selektovanTipPotrosnje2.Equals("Interval Meter"))
            {
                temp = new Model.Tip(SelektovanTipPotrosnje2, "C:/Users/38162/Desktop/NetworkService/NetworkService/Pictures/intervalMeter.jpg");
            }
            else
            {
                temp = new Model.Tip(SelektovanTipPotrosnje2, "C:/Users/38162/Desktop/NetworkService/NetworkService/Pictures/smartMeter.jpg");
            }
            Potrosnje.Add(new T2_PotrosnjaStruje { Id = tempID, Naziv = NazivText, Vrednost = roundedNum, Tip = temp });
        }

        // Funkcija za postavljanje rezima < za filtriranje
        private void OnLow()
        {
            LowOrHigh = 1;
            FilterCommand.RaiseCanExecuteChanged();
        }

        // Funkcija za postavljanje rezima > za filtriranje
        private void OnHigh()
        {
            LowOrHigh = 2;
            FilterCommand.RaiseCanExecuteChanged();
        }

        // Funkcija za postavljanje rezima = za filtriranje
        private void OnEqual()
        {
            LowOrHigh = 3;
            FilterCommand.RaiseCanExecuteChanged();
        }

        // Provera da li može da se filtrira
        private bool CanFilter()
        {
            bool filter;
            if (LowOrHigh != -1 || SelektovanTipPotrosnje != string.Empty)
            {
                filter = true;
            }
            else
            {
                filter = false;
            }
            return filter;
        }

        // Filtriranje podataka u DataGridu
        private void OnFilter()
        {
            int val;
            FilterPotrosnje.Clear();
            if (IdForFilterText == "")
                val = -1;
            else
            {
                try
                {
                    val = Int32.Parse(IdForFilterText);
                }
                catch
                {
                    System.Windows.MessageBox.Show("ID must be a number!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            foreach(T2_PotrosnjaStruje p in Potrosnje)
            {
                PotrosnjeCopy.Add(p);
            }
            
            List<T2_PotrosnjaStruje> filteredList = new List<T2_PotrosnjaStruje>();

            foreach (T2_PotrosnjaStruje entity in Potrosnje)
            {
                filteredList.Add(entity);
            }

            if (SelektovanTipPotrosnje != null)
            {
                List<T2_PotrosnjaStruje> entitiesToDelete = new List<T2_PotrosnjaStruje>();
                for (int i = 0; i < filteredList.Count; i++)
                {
                    if (filteredList[i].Tip.Ime != SelektovanTipPotrosnje)
                    {
                        entitiesToDelete.Add(filteredList[i]);
                    }
                }

                foreach (T2_PotrosnjaStruje entity in entitiesToDelete)
                {
                    filteredList.Remove(entity);
                }
            }

            if (LowOrHigh != -1)
            {
                // Filtrirati da li je manje, veće ili jednako od zadatog id-a
                if (LowOrHigh == 1)
                {
                    List<T2_PotrosnjaStruje> entitiesToDelete = new List<T2_PotrosnjaStruje>();
                    for (int i = 0; i < filteredList.Count; i++)
                    {
                        if (filteredList[i].Id > val)
                        {
                            entitiesToDelete.Add(filteredList[i]);
                        }
                    }
                    foreach (T2_PotrosnjaStruje entity in entitiesToDelete)
                    {
                        filteredList.Remove(entity);
                    }
                }
                else if (LowOrHigh == 2)
                {
                    List<T2_PotrosnjaStruje> entitiesToDelete = new List<T2_PotrosnjaStruje>();
                    for (int i = 0; i < filteredList.Count; i++)
                    {
                        if (filteredList[i].Id < val)
                        {
                            entitiesToDelete.Add(filteredList[i]);
                        }
                    }
                    foreach (T2_PotrosnjaStruje entity in entitiesToDelete)
                    {
                        filteredList.Remove(entity);
                    }
                }
                else if (LowOrHigh == 3)
                {
                    List<T2_PotrosnjaStruje> entitiesToDelete = new List<T2_PotrosnjaStruje>();
                    for (int i = 0; i < filteredList.Count; i++)
                    {
                        if (filteredList[i].Id != val)
                        {
                            entitiesToDelete.Add(filteredList[i]);
                        }
                    }
                    foreach (T2_PotrosnjaStruje entity in entitiesToDelete)
                    {
                        filteredList.Remove(entity);
                    }
                }
            }

            if (filteredList.Count > 0)
            {
                Potrosnje.Clear();
                foreach (T2_PotrosnjaStruje entity in filteredList)
                {
                    Potrosnje.Add(entity);
                }
            }
            else
            {
                Potrosnje.Clear();
            }

            IdForFilterText = "";
            LowOrHigh = -1;
            idForFilter = -1;
            SelektovanTipPotrosnje = string.Empty;
            OnPropertyChanged("SelektovanTipPotrosnje");
            filtercan = true;
            OnPropertyChanged("Potrosnje");
            CancelFilterCommand.RaiseCanExecuteChanged();
        }

        // Provera da li može da se poništi filtriranje
        private bool CanCancel()
        {
            return filtercan;
        }

        // Poništavanje filtriranja (Reset)
        private void OnCancel()
        {
            Potrosnje.Clear();
            foreach (T2_PotrosnjaStruje s in PotrosnjeCopy)
            {
                Potrosnje.Add(s);
            }
            PotrosnjeCopy.Clear();
            OnPropertyChanged("Potrosnje");
            filtercan = false;
            CancelFilterCommand.RaiseCanExecuteChanged();
        }
    }
}