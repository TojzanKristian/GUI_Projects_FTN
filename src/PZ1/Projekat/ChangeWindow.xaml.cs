using Klasa;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
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
    public partial class ChangeWindow : Window
    {
        #region Pomoćna pola
        private static int index = 0;
        private static string pomoc = "";
        private static string fajlP = "";
        private static string slikaP = "";
        #endregion
        public ChangeWindow(int idx)
        {
            InitializeComponent();

            #region Podešavanje početnih vrednosti

            Igrac igrac = StartWindow.Igraci[idx];
            index = idx;

            cbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 };
            cbColor.ItemsSource = new List<string>() { "Black", "White", "Blue", "Red", "Green", "Yellow", "Gray", "Pink", "Brown", "Purple" };
            cbColor.SelectedIndex = 0;
            textSlika.Text = "";
            textSlika.Visibility = Visibility.Hidden;

            slikaP = igrac.Slika;
            Uri uri = new Uri(igrac.Slika);
            imgSlika.Source = new BitmapImage(uri);

            fajlP = igrac.Fajl;

            runText.Text = igrac.Ime;
            tbPrezime.Text = igrac.Prezime;
            tbVisina.Text = igrac.Visina.ToString();

            TextRange textRange;
            System.IO.FileStream fileStream;

            if (System.IO.File.Exists(fajlP))
            {
                textRange = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                using (fileStream = new System.IO.FileStream(fajlP, System.IO.FileMode.OpenOrCreate))
                {
                    textRange.Load(fileStream, System.Windows.DataFormats.Rtf);
                }
            }
            #endregion
        }

        #region Dugme za izlaz
        private void BtnIzalz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Promena u RichTextBoxu
        private void RtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object pPromenljiva = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (pPromenljiva != DependencyProperty.UnsetValue) && (pPromenljiva.Equals(FontWeights.Bold));

            pPromenljiva = rtbEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (pPromenljiva != DependencyProperty.UnsetValue) && (pPromenljiva.Equals(FontStyles.Italic));

            pPromenljiva = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (pPromenljiva != DependencyProperty.UnsetValue) && (pPromenljiva.Equals(TextDecorations.Underline));

            pPromenljiva = rtbEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cbFontFamily.SelectedItem = pPromenljiva;
            pPromenljiva = rtbEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cbFontSize.Text = pPromenljiva.ToString();
        }
        #endregion

        #region Promena tipa slova
        private void CbFontFamily_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbFontFamily.SelectedItem != null)
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cbFontFamily.SelectedItem);
            }
        }
        #endregion

        #region Promena veličine slova
        private void CbFontSize_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbFontSize.SelectedValue != null)
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cbFontSize.SelectedValue);
            }
        }
        #endregion

        #region Promena boje slova
        private void CbColor_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbColor.SelectedValue != null)
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.ForegroundProperty, cbColor.SelectedValue);
            }
        }
        #endregion

        #region Funkcija za prebrojavanje reči
        private void CountWordsInRTB()
        {
            int brojReci = 0, index = 0;
            string richText = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd).Text;

            while (index < richText.Length && char.IsWhiteSpace(richText[index]))
            {
                index++;
            }

            while (index < richText.Length)
            {
                while (index < richText.Length && !char.IsWhiteSpace(richText[index]))
                {
                    index++;
                }

                brojReci++;

                while (index < richText.Length && char.IsWhiteSpace(richText[index]))
                {
                    index++;
                }
            }
                tbBrojReci.Text = brojReci.ToString();
        }
        #endregion

        #region Kod promene texta poziva se funkcija za prebrojavanje
        private void RtbEditor_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CountWordsInRTB();
        }
        #endregion

        #region Dugme za izmenu slike
        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            textSlika.Visibility = Visibility.Hidden;
            textSlika.Text = "";
            if (openFileDialog.ShowDialog() == true)
            {
                pomoc = openFileDialog.FileName;
                Uri uri = new Uri(pomoc);
                imgSlika.Source = new BitmapImage(uri);
                textSlika.Visibility = Visibility.Hidden;
                textSlika.Text = "";
            }
        }
        #endregion

        #region Dugme za izmenu igrača
        private void BtnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                if (pomoc == "")
                {
                    pomoc = slikaP;
                }

                StartWindow.Igraci[index] = (new Klasa.Igrac(runText.Text, tbPrezime.Text, Int64.Parse(tbVisina.Text), pomoc, fajlP, DateTime.Now));

                TextRange textRange;
                FileStream fileStream;
                textRange = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                fileStream = new FileStream(fajlP, FileMode.Open);
                textRange.Save(fileStream, DataFormats.Rtf);
                fileStream.Close();

                this.Close();
            }
        }
        #endregion

        #region Validacija unosa
        private bool Validate()
        {
            bool result = true;

            if (rtbEditor.ToString().Trim().Equals(""))
            {
                result = false;
                rtbEditor.BorderBrush = Brushes.Red;
                rtbEditor.BorderThickness = new Thickness(3);
                MessageBox.Show("Greška! Ime igrača mora biti popunjeno!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                bool imeSadrziBrojeve = false;
                foreach (char c in runText.Text)
                {
                    if (Char.IsDigit(c))
                    {
                        imeSadrziBrojeve = true;
                    }
                }

                if (imeSadrziBrojeve)
                {
                    result = false;
                    rtbEditor.BorderBrush = Brushes.Red;
                    rtbEditor.BorderThickness = new Thickness(3);
                    MessageBox.Show("Greška! Ime igrača ne sme sadržati brojeve!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    rtbEditor.BorderBrush = Brushes.Black;
                    rtbEditor.BorderThickness = new Thickness(2);
                }
            }

            if (tbPrezime.Text.Trim().Equals(""))
            {
                result = false;
                tbPrezime.BorderBrush = Brushes.Red;
                tbPrezime.BorderThickness = new Thickness(3);
                MessageBox.Show("Greška! Prezime igrača mora biti popunjeno!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                bool prezimeSadrziBrojeve = false;
                foreach (char c in tbPrezime.Text)
                {
                    if (Char.IsDigit(c))
                    {
                        prezimeSadrziBrojeve = true;
                    }
                }

                if (prezimeSadrziBrojeve)
                {
                    result = false;
                    tbPrezime.BorderBrush = Brushes.Red;
                    tbPrezime.BorderThickness = new Thickness(3);
                    MessageBox.Show("Greška! Prezime igrača ne sme sadržati brojeve!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    tbPrezime.BorderBrush = Brushes.Black;
                    tbPrezime.BorderThickness = new Thickness(2);
                }
            }

            if (tbVisina.Text.Trim().Equals(""))
            {
                result = false;
                tbVisina.BorderBrush = Brushes.Red;
                tbVisina.BorderThickness = new Thickness(3);
                MessageBox.Show("Greška! Visina igrača mora biti popunjena!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                tbVisina.BorderBrush = Brushes.Black;
                tbVisina.BorderThickness = new Thickness(2);
            }

            var rez = Int64.TryParse(tbVisina.Text, out _);
            if (!rez)
            {
                result = false;
                tbVisina.BorderBrush = Brushes.Red;
                tbVisina.BorderThickness = new Thickness(3);
                MessageBox.Show("Greška! Visina igrača mora biti broj!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Int64.Parse(tbVisina.Text) <= 145 || Int64.Parse(tbVisina.Text) >= 235)
                {
                    result = false;
                    tbVisina.BorderBrush = Brushes.Red;
                    tbVisina.BorderThickness = new Thickness(3);
                    MessageBox.Show("Greška! Uneta visina nije validna!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    tbVisina.BorderBrush = Brushes.Black;
                    tbVisina.BorderThickness = new Thickness(2);
                }
            }

            if (textSlika.Text.Equals("Slika"))
            {
                result = false;
                textSlika.BorderBrush = Brushes.Red;
                textSlika.BorderThickness = new Thickness(3);
                MessageBox.Show("Greška! Slika igrača mora biti popunjena!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                textSlika.BorderBrush = Brushes.Black;
                textSlika.BorderThickness = new Thickness(0);
            }

            if (dpDatum.Text.Equals("") || dpDatum.Text.Equals("Dátum kiválasztása"))
            {
                result = false;
                dpDatum.BorderBrush = Brushes.Red;
                dpDatum.BorderThickness = new Thickness(3);
                MessageBox.Show("Greška! Datum mora biti popunjen!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                dpDatum.BorderBrush = Brushes.Black;
                dpDatum.BorderThickness = new Thickness(0);
            }

            return result;
        }
        #endregion

        #region Prikaz datuma
        private void DpDatum_MouseEnter(object sender, MouseEventArgs e)
        {
            dpDatum.Text = DateTime.Now.ToString();
            dpDatum.IsEnabled = false;
        }
        #endregion
    }
}