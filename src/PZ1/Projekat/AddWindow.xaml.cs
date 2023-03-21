using Klasa;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Projekat
{
    public partial class AddWindow : Window
    {
        private string slika;
        public AddWindow()
        {
            InitializeComponent();

            #region Podešavanje početnih vrednosti
            tbPrezime.Text = "Unesite prezime igrača";
            tbPrezime.Foreground = Brushes.Gray;
            tbVisina.Text = "Unesite visinu igrača";
            tbVisina.Foreground = Brushes.Gray;

            cbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 };
            cbColor.ItemsSource = new List<string>() { "Black", "White", "Blue", "Red", "Green", "Yellow", "Gray", "Pink", "Brown", "Purple" };
            cbColor.SelectedIndex = 0;
            #endregion
        }

        #region Dugme za izlaz
        private void BtnIzalz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Dugme za dodavanje igrača
        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                string naziv = tbPrezime.Text + ".rtf";

                TextRange range;
                FileStream fStream;
                range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                fStream = new FileStream(naziv, FileMode.Create);
                range.Save(fStream, DataFormats.Rtf);
                fStream.Close();

                this.Close();

                Klasa.Igrac i = new Klasa.Igrac(runText.Text, tbPrezime.Text, Int64.Parse(tbVisina.Text), slika, naziv, DateTime.Now);
                StartWindow.Igraci.Add(i);
                DetailsWindow.DNIgraci.Add(i);
            }
        }
        #endregion

        #region Validacija unosa
        private bool Validate()
        {
            bool result = true;

            if (runText.Text.Trim().Equals(string.Empty) || runText.Text.Trim().Equals("Unesite ime igrača"))
            {
                result = false;
                rtbEditor.BorderBrush = Brushes.Red;
                rtbEditor.BorderThickness = new Thickness(3);
                MessageBox.Show("Greška! Ime igrača mora biti popunjeno!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                rtbEditor.BorderBrush = Brushes.Gray;
                rtbEditor.BorderThickness = new Thickness(2);
            }

            if (tbPrezime.Text.Trim().Equals("") || tbPrezime.Text.Trim().Equals("Unesite prezime igrača"))
            {
                result = false;
                tbPrezime.BorderBrush = Brushes.Red;
                tbPrezime.BorderThickness = new Thickness(3);
                MessageBox.Show("Greška! Prezime igrača mora biti popunjeno!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                tbPrezime.BorderBrush = Brushes.Gray;
                tbPrezime.BorderThickness = new Thickness(2);
            }

            if (tbVisina.Text.Trim().Equals("") || tbVisina.Text.Trim().Equals("Unesite visinu igrača"))
            {
                result = false;
                tbVisina.BorderBrush = Brushes.Red;
                tbVisina.BorderThickness = new Thickness(3);
                MessageBox.Show("Greška! Visina igrača mora biti popunjena!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                tbVisina.BorderBrush = Brushes.Gray;
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
                    tbVisina.BorderBrush = Brushes.Gray;
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
                textSlika.BorderBrush = Brushes.Gray;
                textSlika.BorderThickness = new Thickness(0);
            }

            return result;
        }
        #endregion

        #region TextBox Prezime
        private void TbPrezime_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbPrezime.Text.Trim().Equals("Unesite prezime igrača"))
            {
                tbPrezime.Text = "";
                tbPrezime.Foreground = Brushes.Black;
            }
        }

        private void TbPrezime_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbPrezime.Text.Trim().Equals(string.Empty))
            {
                tbPrezime.Text = "Unesite prezime igrača";
                tbPrezime.Foreground = Brushes.Gray;
            }
        }
        #endregion

        #region TextBox Visina
        private void TbVisina_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbVisina.Text.Trim().Equals("Unesite visinu igrača"))
            {
                tbVisina.Text = "";
                tbVisina.Foreground = Brushes.Black;
            }
        }

        private void TbVisina_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbVisina.Text.Trim().Equals(string.Empty))
            {
                tbVisina.Text = "Unesite visinu igrača";
                tbVisina.Foreground = Brushes.Gray;
            }

        }
        #endregion

        #region RichTextBox ime igrača
        private void RtbEditor_GotFocus(object sender, RoutedEventArgs e)
        {
            if (runText.Text.Trim().Equals("Unesite ime igrača"))
            {
                runText.Text = "";
                runText.Foreground = Brushes.Black;
            }

        }

        private void RtbEditor_LostFocus(object sender, RoutedEventArgs e)
        {
            if (runText.Text.Trim().Equals(string.Empty))
            {
                runText.Text = "Unesite ime igrača";
                runText.Foreground = Brushes.Gray;
            }
        }
        #endregion

        #region Prikaz datuma
        private void DpDatum_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            dpDatum.Text = DateTime.Now.ToString();
        }
        #endregion

        #region Dugme za dodavanje slike
        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            textSlika.Visibility = Visibility.Hidden;
            textSlika.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                slika = openFileDialog.FileName;
                Uri fileUri = new Uri(slika);
                ibSlika.Source = new BitmapImage(fileUri);
            }
        }
        #endregion

        #region Promena u RichTextBoxu
        private void RtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object pomoc = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (pomoc != DependencyProperty.UnsetValue) && (pomoc.Equals(FontWeights.Bold));

            pomoc = rtbEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (pomoc != DependencyProperty.UnsetValue) && (pomoc.Equals(FontStyles.Italic));

            pomoc = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (pomoc != DependencyProperty.UnsetValue) && (pomoc.Equals(TextDecorations.Underline));

            pomoc = rtbEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cbFontFamily.SelectedItem = pomoc;
            pomoc = rtbEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cbFontSize.Text = pomoc.ToString();
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

        #region Prikaz broja izbrojanih reči
        private void RtbEditor_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CountWordsInRTB();
        }
        #endregion

        /*#region Čuvanje igrača u XML fajlu
        public void Save(object sender, CancelEventArgs e)
        {
            StartWindow.serializer.SerializeObject<BindingList<Klasa.Igrac>>(StartWindow.Igraci, "igraci.xml");
        }
        #endregion*/
    }
}