using NetworkService.Model;
using NetworkService.More;
using NetworkService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetworkService
{
    public class MainWindowViewModel : BindableBase
    {
        // Pomoćna polja
        public MyICommand<string> NavCommand { get; private set; } // Komanda za Meni
        private readonly PotrosnjaViewModel potrosnjaViewModel = new PotrosnjaViewModel(); // pomoćna promenljiva za prikaz potrošnji
        private readonly DragandDropViewModel networkViewModel = new DragandDropViewModel(); // pomoćna promenljiva za Canvas prikaz
        private readonly GraphViewModel graphViewModel = new GraphViewModel(); // pomoćna promenljiva za prikaz grafikona
        private BindableBase currentViewModel; // promeljiva koja prikazuje odabran prozor iz Menia
        private readonly List<string> UndoDestinations = new List<string>(); // pomoćna lista za Undo komandu
        public MyICommand UndoCommand { get; set; } // Undo komanda

        // Konstruktor
        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<String>(OnNav);
            CurrentViewModel = potrosnjaViewModel;
            UndoDestinations.Add("Network Data");
            NavCommand = new MyICommand<string>(OnNav, OnUndoNav);
            UndoCommand = new MyICommand(OnUndo);
        }

        // Svojstvo za trenutini prozor
        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        // Funkcija koja omogućava rad Menia
        private void OnNav(string destination)
        {
            UndoDestinations.Add(destination);
            switch (destination)
            {
                case "Network Data":
                    CurrentViewModel = potrosnjaViewModel;
                    break;
                case "Network View":
                    CurrentViewModel = networkViewModel;
                    break;
                case "Data Chart":
                    CurrentViewModel = graphViewModel;
                    break;
            }
        }

        // Funkcija za promenu prozora za Undo dugme
        private void OnUndoNav()
        {
            if (UndoDestinations.Count > 1)
            {
                string destination = UndoDestinations.ElementAt(UndoDestinations.Count - 2);
                switch (destination)
                {
                    case "Network Data":
                        CurrentViewModel = potrosnjaViewModel;
                        break;
                    case "Network View":
                        CurrentViewModel = networkViewModel;
                        break;
                    case "Data Chart":
                        CurrentViewModel = graphViewModel;
                        break;
                }
                UndoDestinations.RemoveAt(UndoDestinations.Count - 1);
            }
        }

        // Funkcija koja iz DataGrid uklanja element kada se stisne na Undo dugme
        public void OnUndo()
        {
            if (StaticData.myICommands.Count > 0)
            {
                ICommandUndo command = StaticData.myICommands.Pop();
                command.UnExecute();
            }
            if (PotrosnjaViewModel.Potrosnje.Count > 0)
            {
                PotrosnjaViewModel.Potrosnje.RemoveAt(PotrosnjaViewModel.Potrosnje.Count - 1);
            }
        }
    }
}