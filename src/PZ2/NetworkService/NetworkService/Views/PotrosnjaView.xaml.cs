using System.Threading.Tasks;
using System.Windows.Controls;

namespace NetworkService.Views
{
    public partial class PotrosnjaView : UserControl
    {
        public PotrosnjaView()
        {
            InitializeComponent();
            this.DataContext = new NetworkService.ViewModel.PotrosnjaViewModel();
        }

        // Na dupli klik se poziva Virtualna tastatura za unos IDa za filtriranje entiteta
        private void IdFilter_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _ = VirtualKeyboardIdFilter();
        }

        // Pomoćna funkcija koja poziva Virtualnu tastaturu
        private async Task VirtualKeyboardIdFilter()
        {
            tbReadID.Text = await VirtualKeyboard.Wpf.VKeyboard.OpenAsync();
        }

        // Na dupli klik se poziva Virtualna tastatura za unos IDa za dodavanje entiteta
        private void IdAdd_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _ = VirtualKeyboardIdAdd();
        }

        // Pomoćna funkcija koja poziva Virtualnu tastaturu
        private async Task VirtualKeyboardIdAdd()
        {
            IdTb.Text = await VirtualKeyboard.Wpf.VKeyboard.OpenAsync();
        }

        // Na dupli klik se poziva Virtualna tastatura za unos Naziva za dodavanje novog entiteta
        private void NazivAdd_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _ = VirtualKeyboardNayivAdd();
        }

        // Pomoćna funkcija koja poziva Virtualnu tastaturu
        private async Task VirtualKeyboardNayivAdd()
        {
            NazivTb.Text = await VirtualKeyboard.Wpf.VKeyboard.OpenAsync();
        }
    }
}