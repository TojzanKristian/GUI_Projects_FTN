using Klasa;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Projekat
{
    public partial class StartWindow : Window
    {
        #region Dodatna pola
        public static BindingList<Igrac> Igraci { get; set; }

        public static readonly Klasa.DataIO serializer = new Klasa.DataIO();

        private static BindingList<Igrac> brisanje = new BindingList<Igrac>();
        public static BindingList<Igrac> Brisanje { get => brisanje; set => brisanje = value; }

        private static bool cbOznacen = false;
        #endregion
        public StartWindow()
        {
            #region Inicijalizacija
            //Igraci = serializer.DeSerializeObject<BindingList<Igrac>>("igraci.xml");

            if (Igraci == null)
            {
                Igraci = new BindingList<Igrac>();
            }
            DataContext = this;
            #endregion

            InitializeComponent();

            #region Za posetilaca zabraniti izmene
            if (Globals.Ulogovan.Equals(Globals.PosetilacUN))
            {
                buttonObrisi.IsEnabled = false;
                buttonDodavanje.IsEnabled = false;
            }
            #endregion
        }

        #region Dugme za izlaz
        private void ButtonIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Save();
            this.Close();
        }
        #endregion

        #region Dugme za brisanje igrača
        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < brisanje.Count; i++)
            {
                Igraci.Remove(brisanje[i]);
                DetailsWindow.DNIgraci.Remove(brisanje[i]);
            }

            for (int i = 0; i < brisanje.Count; i++)
            {
                if (brisanje[i] != null)
                {
                    string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, brisanje[i].Fajl);
                    try
                    {
                        File.Delete(filePath);
                    }
                    catch (IOException exp)
                    {
                        Console.WriteLine(exp.Message);
                    }
                }
            }
        }
        #endregion

        #region Dugme za dodavanje igrača
        private void ButtonDodavanje_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWin = new AddWindow();
            addWin.ShowDialog();
        }
        #endregion

        #region Preusmerenje na odrđenu stranicu u zavisnosti od korisnika
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            if (Globals.Ulogovan.Equals(Globals.AdminUN))
            {
                ChangeWindow ch = new ChangeWindow(dataGridIgraci.SelectedIndex);
                ch.ShowDialog();
            }
            if (Globals.Ulogovan.Equals(Globals.PosetilacUN))
            {
                DetailsWindow dw = new DetailsWindow();
                dw.ShowDialog();
            }
        }
        #endregion

        #region Promena selekcije u dataGridu
        private void DataGridIgraci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbOznacen == true)
            {
                brisanje.Add((Igrac)dataGridIgraci.SelectedItem);
            }
            cbOznacen = false;
        }
        #endregion

        #region Na dupli klik prikaže se prozor sa detaljima
        private void DataGridIgraci_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Globals.Ulogovan.Equals(Globals.AdminUN))
            {
                DetailsWindow dw = new DetailsWindow();
                dw.ShowDialog();
            }
        }
        #endregion

        #region CheckBox označen
        private void CbBrisanje_MouseEnter(object sender, MouseEventArgs e)
        {
            cbOznacen = true;
        }
        #endregion

        #region Čuvanje igrača u XML fajlu
        public void Save()
        {
            serializer.SerializeObject<BindingList<Klasa.Igrac>>(Igraci, "igraci.xml");
        }
        #endregion
    }
}