using NetworkService.Model;
using NetworkService.More;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NetworkService.ViewModel
{
    class DragandDropViewModel : BindableBase
    {
        // Lista Potrosnji koja se prikazuje na TreeViewu
        public ObservableCollection<T2_PotrosnjaStruje> Items { get; set; }

        // Definisanje komandi koje koristimo
        public MyICommand<Canvas> MouseLeftButtonDown { get; set; }
        public MyICommand<Canvas> DropCommand { get; set; }
        public MyICommand<Canvas> LoadCanvasCommand { get; set; }
        public MyICommand MouseLeftButtonUp { get; set; }
        public MyICommand<T2_PotrosnjaStruje> SelectionChangedCommand { get; set; }
        public MyICommand<ListView> LoadPotrosnjeiListCommand { get; set; }
        public MyICommand<Canvas> OslobodiCommand { get; set; }

        // Pomoćna polja
        public Canvas sourceCanvas = null;
        private T2_PotrosnjaStruje selectedItem = null;
        private bool dragging = false;
        private T2_PotrosnjaStruje draggedItem = null;
        private ListView listView;

        // Preuzimanje označenog elementa iz ListViewa
        public T2_PotrosnjaStruje SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        // Konstruktor
        public DragandDropViewModel()
        {
            Items = new ObservableCollection<T2_PotrosnjaStruje>();
            foreach (T2_PotrosnjaStruje generator in PotrosnjaViewModel.Potrosnje)
            {
                Items.Add(generator);
            }

            MouseLeftButtonDown = new MyICommand<Canvas>(OnMouseLeftButtonDown);
            DropCommand = new MyICommand<Canvas>(OnDropCommand);
            MouseLeftButtonUp = new MyICommand(OnMouseLeftButtonUp);
            SelectionChangedCommand = new MyICommand<T2_PotrosnjaStruje>(OnSelectionChanged);
            LoadPotrosnjeiListCommand = new MyICommand<ListView>(OnLoadPotrosnjeListCommand);
            OslobodiCommand = new MyICommand<Canvas>(OnOslobodiCommand);
        }

        // Vraćanje sa Canvasa u ListView
        public void OnOslobodiCommand(Canvas canvas)
        {
            if (canvas.Resources["taken"] != null)
            {
                canvas.Background = Brushes.Azure;
                ((Border)canvas.Children[0]).BorderBrush = Brushes.Azure;
                foreach (T2_PotrosnjaStruje generator in PotrosnjaViewModel.Potrosnje)
                {
                    if (!Items.Contains(generator))
                    {
                        Items.Add(generator);
                    }
                }
                canvas.Resources.Remove("taken");
            }
        }

        // Pomoćna funkcija koja minimalno promeni pozadinu Canvasa
        public void OnIskljuci(TextBlock textBlock)
        {
            textBlock.Foreground = Brushes.Transparent;
        }

        // Povezivanje ListViewa sa XAML
        public void OnLoadPotrosnjeListCommand(ListView list)
        {
            listView = list;
        }

        // Promena selekcije u ListViewu
        public void OnSelectionChanged(T2_PotrosnjaStruje p)
        {
            if (!dragging)
            {
                dragging = true;
                draggedItem = new T2_PotrosnjaStruje(p);
                DragDrop.DoDragDrop(listView, draggedItem, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        // Reakcija na pritisak levog dugmeta na mišu
        public void OnMouseLeftButtonUp()
        {
            draggedItem = null;
            dragging = false;
            selectedItem = null;
        }

        // Smeštanje na Canvas
        public void OnDropCommand(Canvas canvas)
        {
            if (draggedItem != null)
            {
                if (canvas.Resources["taken"] == null)
                {
                    BitmapImage slika = new BitmapImage();
                    slika.BeginInit();
                    slika.UriSource = new Uri(draggedItem.Tip.Slika);
                    slika.EndInit();
                    canvas.Background = new ImageBrush(slika);

                    foreach (var keyValuePair in ZaCanvas.CanvasObjects.Where(kvp => kvp.Value.Id == draggedItem.Id).ToList()) // Omogućava prevlačenje iz jednog canvasa u drugi
                    {
                        ZaCanvas.CanvasObjects.Remove(keyValuePair.Key); // Sslobađanje canvasa skog smo prevukli
                        sourceCanvas.Background = Brushes.Azure;
                        ((Border)sourceCanvas.Children[0]).BorderBrush = Brushes.Azure;
                        sourceCanvas.Resources.Remove("taken");
                    }

                    ZaCanvas.CanvasObjects[canvas.Name] = draggedItem;
                    canvas.Resources.Add("taken", true);

                    bool sadrzi = false;
                    foreach (T2_PotrosnjaStruje g in Items)
                    {
                        if (g.Id == draggedItem.Id)
                        {
                            sadrzi = true;
                        }
                    }
                    if (sadrzi)
                    {
                        foreach (T2_PotrosnjaStruje g in Items)
                        {
                            if (g.Id.Equals(draggedItem.Id))
                            {
                                Items.Remove(g);
                                break;
                            }
                        }

                    }
                }
                dragging = false;
            }
        }

        // Prebacivanje slike iz jednog u drugi kanvas
        public void OnMouseLeftButtonDown(Canvas canvas)
        {
            if (!dragging)
            {
                dragging = true;
                sourceCanvas = canvas;
                DragDrop.DoDragDrop(canvas, draggedItem, DragDropEffects.Move);
            }
        }
    }
}