using NetworkService.Model;
using NetworkService.ViewModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NetworkService.Views
{
    public partial class DragAndDropView : UserControl
    {
        public DragAndDropView()
        {
            InitializeComponent();
            this.DataContext = new NetworkService.ViewModel.DragandDropViewModel();
        }
    }
}