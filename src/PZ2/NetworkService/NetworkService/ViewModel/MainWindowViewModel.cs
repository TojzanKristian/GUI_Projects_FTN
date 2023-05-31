using NetworkService.More;
using NetworkService.ViewModel;
using System;

namespace NetworkService
{
    public class MainWindowViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private readonly PotrosnjaViewModel potrosnjaViewModel = new PotrosnjaViewModel();
        private readonly DragandDropViewModel networkViewModel = new DragandDropViewModel();
        private readonly GraphViewModel graphViewModel = new GraphViewModel();
        private BindableBase currentViewModel;

        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<String>(OnNav);
            CurrentViewModel = potrosnjaViewModel;
        }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "Network Data":
                    CurrentViewModel = potrosnjaViewModel;
                    break;
                case "Network View":
                    CurrentViewModel = networkViewModel;
                    break;
                case "Data Chart":
                    CurrentViewModel = graphViewModel;
                    break;
            }
        }
    }
}