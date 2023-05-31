using System.Windows.Controls;

namespace NetworkService.Views
{
    public partial class GraphView : UserControl
    {
        public GraphView()
        {
            InitializeComponent();
            this.DataContext = new NetworkService.ViewModel.GraphViewModel();
        }
    }
}