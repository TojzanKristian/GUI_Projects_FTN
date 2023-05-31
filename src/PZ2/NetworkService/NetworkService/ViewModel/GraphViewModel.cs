using NetworkService.Model;
using NetworkService.More;

namespace NetworkService.ViewModel
{
    public class GraphViewModel : BindableBase
    {
        public static GraphUpdater ElementHeights { get; set; } = new GraphUpdater();

        public static double CalculateElementHeight()
        {
            return 1;
        }
    }
}