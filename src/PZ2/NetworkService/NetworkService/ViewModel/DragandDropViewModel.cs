using NetworkService.Model;
using NetworkService.More;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace NetworkService.ViewModel
{
    public class DragandDropViewModel : BindableBase
    {
        // Pomoćna polja
        public static ObservableCollection<T2_PotrosnjaStruje> EntitetList { get; set; } //Lista entiteta u koju dodajem one koje su u tabeli na prvom prozoru
        public static ObservableCollection<CanvasInfo> Canvases { get; set; } //Kanvas na slici da bude ono ao greska i 
        public static ObservableCollection<Model.Line> Lines { get; set; } // Linije
        public MyICommand<ListView> SelectionChangedCommand { get; set; }
        public MyICommand MouseLeftButtonUpCommand { get; set; }
        public MyICommand<Canvas> ButtonCommand { get; set; }
        public MyICommand<Canvas> DragOverCommand { get; set; }
        public MyICommand<Canvas> DropCommand { get; set; }
        public MyICommand<Canvas> MouseLeftButtonDownCommand { get; set; }
        public MyICommand AutoPlaceCommand { get; set; }
        public MyICommand HelpCommand { get; set; }

        bool dragging = false;

        T2_PotrosnjaStruje selectedEntitet;

        CanvasInfo currentCanvas;

        // Funkcija za uklanjanje linija
        public static void RemoveFromList(T2_PotrosnjaStruje e)
        {
            foreach (T2_PotrosnjaStruje entitet in EntitetList)
            {
                if (entitet.Id == e.Id)
                {
                    EntitetList.Remove(entitet);
                    return;
                }
            }

            for (int i = 0; i < 12; i++)
            {
                if (Canvases[i].Entitet.Id == e.Id)
                {
                    foreach (int id in Canvases[i].Lines)
                        RemoveLine(id);
                    Canvases[i] = new CanvasInfo(i);
                    return;
                }
            }
        }

        // Funkcija za ažuriranje linija
        public static void UpdateList(T2_PotrosnjaStruje e)
        {
            for (int i = 0; i < EntitetList.Count; i++)
            {
                if (EntitetList[i].Id == e.Id)
                {
                    EntitetList[i].Vrednost = e.Vrednost;
                    return;
                }
            }

            for (int i = 0; i < 12; i++)
            {
                if (Canvases[i].Entitet.Id == e.Id)
                {
                    Canvases[i].Entitet = e;
                    return;
                }
            }
        }

        // Svojstvo za izabranog entiteta iz ListView
        public T2_PotrosnjaStruje SelectedEntitet
        {
            get => selectedEntitet;
            set
            {
                selectedEntitet = value;
                OnPropertyChanged("SelectedEntitet");
            }
        }

        // Dodela određenog Canvasa
        public CanvasInfo CurrentCanvas
        {
            get => currentCanvas;
            set
            {
                currentCanvas = value;
                OnPropertyChanged("CurrentCanvas");
            }
        }

        // Funkcija za proveru zauzetosti Canvasa
        bool Cmp(CanvasInfo c)
        {
            return CurrentCanvas.Entitet == c.Entitet && CurrentCanvas.Taken == c.Taken && CurrentCanvas.Text == c.Text;
        }

        // Konstruktor
        public DragandDropViewModel()
        {
            if (EntitetList == null)
            {
                EntitetList = new ObservableCollection<T2_PotrosnjaStruje>();
            }

            if (Canvases == null)
            {
                Canvases = new ObservableCollection<CanvasInfo>();
                for (int i = 0; i < 12; i++)
                {
                    Canvases.Add(new CanvasInfo(i));
                }
            }

            if (Lines == null)
            {
                Lines = new ObservableCollection<Model.Line>();
            }

            DragOverCommand = new MyICommand<Canvas>(DragOver);
            DropCommand = new MyICommand<Canvas>(Drop);
            ButtonCommand = new MyICommand<Canvas>(ButtonCommandFreeing);
            SelectionChangedCommand = new MyICommand<ListView>(SelectionChanged);
            MouseLeftButtonUpCommand = new MyICommand(MouseLeftButtonUp);
            MouseLeftButtonDownCommand = new MyICommand<Canvas>(MouseLeftButtonDown);
        }

        // Izmena linija
        void ChangeLine(int id, int x, int y, int nx, int ny)
        {
            for (int i = 0; i < Lines.Count; i++)
            {
                if (Lines[i].Id == id)
                {
                    if (Lines[i].X1 == x && Lines[i].Y1 == y)
                    {
                        Lines[i].X1 = nx;
                        Lines[i].Y1 = ny;
                    }
                    else
                    {
                        Lines[i].X2 = nx;
                        Lines[i].Y2 = ny;
                    }
                    return;
                }
            }
        }

        // Funkcija koja reaguje na Drop u Canvas
        private void Drop(Canvas obj)
        {
            if (SelectedEntitet != null)
            {
                int id = int.Parse(obj.Name.Substring(1));
                if (!Canvases[id].Taken)
                {
                    Canvases[id] = new CanvasInfo(SelectedEntitet, true, id);
                    EntitetList.Remove(SelectedEntitet);
                }
            }
            else if (CurrentCanvas != null)
            {
                int id = int.Parse(obj.Name.Substring(1));
                if (!Canvases[id].Taken)
                {
                    for (int i = 0; i < 12; i++)
                        if (Cmp(Canvases[i]))
                        {
                            Canvases[i] = new CanvasInfo(i);
                            break;
                        }
                    Canvases[id] = new CanvasInfo(CurrentCanvas.Entitet, true, id);
                    foreach (int i in CurrentCanvas.Lines)
                    {
                        ChangeLine(i, CurrentCanvas.X, CurrentCanvas.Y, Canvases[id].X, Canvases[id].Y);
                        Canvases[id].Lines.Add(i);
                    }
                }
                else
                {
                    for (int i = 0; i < 12; i++)
                        if (Cmp(Canvases[i]))
                        {
                            Model.Line line = new Model.Line(Canvases[i].X, Canvases[id].X, Canvases[i].Y, Canvases[id].Y);
                            Lines.Add(line);
                            Canvases[i].Lines.Add(line.Id);
                            Canvases[id].Lines.Add(line.Id);
                            break;
                        }
                }
            }
            MouseLeftButtonUp();
        }

        // Funkcija za DragOver
        private void DragOver(Canvas obj)
        {
            int id = int.Parse(obj.Name.Substring(1));
            if (!Canvases[id].Taken)
                obj.AllowDrop = true;
            else
                obj.AllowDrop = false;
        }

        // Funkcija koja reaguje na poštanje levog klika
        private void MouseLeftButtonUp()
        {
            SelectedEntitet = null;
            CurrentCanvas = null;
            dragging = false;
        }

        // Funkcija koja reaguje levi klik
        private void MouseLeftButtonDown(Canvas c)
        {
            int id = int.Parse(c.Name.Substring(1));
            if (Canvases[id].Taken)
            {
                CurrentCanvas = Canvases[id];
                if (!dragging)
                {
                    dragging = true;
                    DragDrop.DoDragDrop(c, CurrentCanvas, DragDropEffects.Copy | DragDropEffects.Move);
                }
            }
        }

        // Sklanjanje linija 
        static void RemoveLine(int id)
        {
            for (int i = 0; i < Lines.Count; i++)
            {
                if (Lines[i].Id == id)
                {
                    Lines.RemoveAt(i);
                    return;
                }
            }
        }
        
        // Uklanjanje slike sa Canvasa
        private void ButtonCommandFreeing(Canvas obj)
        {
            int id = int.Parse(obj.Name.Substring(1));
            if (Canvases[id].Taken)
            {
                foreach (int i in Canvases[id].Lines)
                    RemoveLine(i);
                EntitetList.Add(Canvases[id].Entitet);
                Canvases[id] = new CanvasInfo(id);
            }
        }

        // Promena u ListBoxu
        private void SelectionChanged(ListView obj)
        {
            if (!dragging)
            {
                dragging = true;
                DragDrop.DoDragDrop(obj, SelectedEntitet, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
    }
}