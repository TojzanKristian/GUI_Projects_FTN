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
using System.Windows.Navigation;
using System.Windows.Shapes;

#region Globalne promenljive
public static class Globals
{
    private static string ulogovan;
    private static readonly string posetilacUN = "kristian";
    private static readonly string adminUN = "admin";

    public static string Ulogovan { get => ulogovan; set => ulogovan = value; }

    public static string PosetilacUN => posetilacUN;

    public static string AdminUN => adminUN;
}
#endregion

namespace Projekat
{
    public partial class MainWindow : Window
    {
        #region Polja za logovanje
        private readonly string adminPW = "ftn";
        private readonly string posetilacPW = "123";
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            #region Podešavanje početnih vrednosti
            textBoxIme.Text = "Unesite korisničko ime";
            textBoxIme.Foreground = Brushes.Gray;
            #endregion
        }

        #region  TextBox korisničko ime
        private void TextBoxIme_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxIme.Text.Trim().Equals("Unesite korisničko ime"))
            {
                textBoxIme.Text = "";
                textBoxIme.Foreground = Brushes.Black;
            }
        }

        private void TextBoxIme_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxIme.Text.Trim().Equals(string.Empty))
            {
                textBoxIme.Text = "Unesite korisničko ime";
                textBoxIme.Foreground = Brushes.Gray;
            }
        }
        #endregion

        #region Dugme za izlaz
        private void ButtonIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Dugme za potvrdu logovanja
        private void ButtonLogovanje_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                if(textBoxIme.Text.Equals(Globals.AdminUN) && PassBoxPrezime.Password.Equals(adminPW))
                {
                    Globals.Ulogovan = textBoxIme.Text;
                    MessageBox.Show("Ulogovao se admin!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    StartWindow sWin = new StartWindow();
                    sWin.ShowDialog();
                }
                else if (textBoxIme.Text.Equals(Globals.PosetilacUN) && PassBoxPrezime.Password.Equals(posetilacPW))
                {
                    Globals.Ulogovan = textBoxIme.Text;
                    MessageBox.Show("Ulogovao se posetilac!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    StartWindow sWin = new StartWindow();
                    sWin.ShowDialog();
                }
            }
        }
        #endregion

        #region Validacija unosa
        private bool Validate()
        {
            bool result = true;

            if (textBoxIme.Text.Trim().Equals("") || textBoxIme.Text.Trim().Equals("Unesite korisničko ime"))
            {
                result = false;
                textBoxIme.BorderBrush = Brushes.Red;
                textBoxIme.BorderThickness = new Thickness(3);
                MessageBox.Show("Greška! Korisničko ime mora biti popunjeno!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                textBoxIme.BorderBrush = Brushes.Gray;
                textBoxIme.BorderThickness = new Thickness(1);
            }

            if (PassBoxPrezime.Password.Trim().Equals(""))
            {
                result = false;
                PassBoxPrezime.BorderBrush = Brushes.Red;
                PassBoxPrezime.BorderThickness = new Thickness(3);
                MessageBox.Show("Greška! Lozinka mora biti popunjena!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                PassBoxPrezime.BorderBrush = Brushes.Gray;
                PassBoxPrezime.BorderThickness = new Thickness(1);
            }

            if(!(textBoxIme.Text.Trim().Equals(Globals.AdminUN) && PassBoxPrezime.Password.Trim().Equals(adminPW)) && !(textBoxIme.Text.Trim().Equals(Globals.PosetilacUN) && PassBoxPrezime.Password.Trim().Equals(posetilacPW)))
            {
                result = false;
                textBoxIme.BorderBrush = Brushes.Red;
                textBoxIme.BorderThickness = new Thickness(3);
                PassBoxPrezime.BorderBrush = Brushes.Red;
                PassBoxPrezime.BorderThickness = new Thickness(3);
                textBoxIme.Text = "Unesite korisničko ime";
                textBoxIme.Foreground = Brushes.Gray;
                PassBoxPrezime.Password = "";
                MessageBox.Show("Greška! Pogrešno korisničko ime ili lozinka!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                textBoxIme.BorderBrush = Brushes.Gray;
                textBoxIme.BorderThickness = new Thickness(1);
                PassBoxPrezime.BorderBrush = Brushes.Gray;
                PassBoxPrezime.BorderThickness = new Thickness(1);
            }

            return result;
        }
        #endregion
    }
}