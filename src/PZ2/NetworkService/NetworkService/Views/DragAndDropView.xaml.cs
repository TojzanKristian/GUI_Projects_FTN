using System.Windows.Controls;

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