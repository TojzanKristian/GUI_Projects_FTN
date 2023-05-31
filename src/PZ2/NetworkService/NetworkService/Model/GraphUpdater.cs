using NetworkService.More;

namespace NetworkService.Model
{
    public class GraphUpdater : BindableBase
    {
        #region Polja
        private double firstBindingPoint;
        private double secondBindingPoint;
        private double thirdBindingPoint;
        private double fourthBindingPoint;
        private double fifthBindingPoint;
        #endregion

        #region Svojstva
        public double FirstBindingPoint
        {
            get { return firstBindingPoint; }
            set
            {
                SecondBindingPoint = firstBindingPoint;
                firstBindingPoint = value;
                OnPropertyChanged("FirstBindingPoint");
            }
        }

        public double SecondBindingPoint
        {
            get { return secondBindingPoint; }
            set
            {
                ThirdBindingPoint = secondBindingPoint;
                secondBindingPoint = value;
                OnPropertyChanged("SecondBindingPoint");
            }
        }

        public double ThirdBindingPoint
        {
            get { return thirdBindingPoint; }
            set
            {
                FourthBindingPoint = thirdBindingPoint;
                thirdBindingPoint = value;
                OnPropertyChanged("ThirdBindingPoint");
            }
        }

        public double FourthBindingPoint
        {
            get { return fourthBindingPoint; }
            set
            {
                FifthBindingPoint = fourthBindingPoint;
                fourthBindingPoint = value;
                OnPropertyChanged("FourthBindingPoint");
            }
        }

        public double FifthBindingPoint
        {
            get { return fifthBindingPoint; }
            set
            {
                fifthBindingPoint = value;
                OnPropertyChanged("FifthBindingPoint");
            }
        }
        #endregion
    }
}