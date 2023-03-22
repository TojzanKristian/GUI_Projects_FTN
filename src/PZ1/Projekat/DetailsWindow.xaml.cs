using Klasa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekat
{
    public partial class DetailsWindow : Window
    {
        #region Dodatna polja
        private static BindingList<Igrac> dNIgraci = new BindingList<Igrac>();
        public static BindingList<Igrac> DNIgraci { get => dNIgraci; set => dNIgraci = value; }
        private static readonly Klasa.DataIO serializer = new Klasa.DataIO();
        #endregion
        public DetailsWindow()
        {
            #region Inicijalizacija
            DNIgraci = serializer.DeSerializeObject<BindingList<Igrac>>("igraci.xml");
            DataContext = this;
            #endregion

            InitializeComponent();
        }

        #region Dugme za izlaz
        private void ButtonIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}