using Chapter9.Model.Exercise4Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter9.ViewModel.Exercise4ViewModel.ViewModelOrder
{
    public class FoodOrderViewModel:INotifyPropertyChanged
    {
        public ObservableCollection<OrderModel> OrderDetails { get; set; }

        private Color _buttonColor;
        public Color ButtonColor
        {
            get => _buttonColor;
            set
            {
                _buttonColor = value;
                OnPropertyChanged();
            }
        }

        private int _position;
        public int Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged();
            }
        }

        private OrderModel _currentItem;
        public OrderModel CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                OnPropertyChanged();
            }
        }


        public event EventHandler NextPageEvent;
        public ICommand NextCommand { get; private set; }
        public ICommand ChangeCommand { get; private set; }
       
        
        public FoodOrderViewModel() 
        {
            Details();
            CurrentItem = OrderDetails.FirstOrDefault();
            ButtonColor = CurrentItem.Color;
            NextCommand = new Command(ChangeDetails);
            ChangeCommand=new Command(ChangeColor);
        }
        public void Details()
        {
            OrderDetails = new ObservableCollection<OrderModel>
            {
                new OrderModel()
                {
                    Title="Choose your favourite food",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    ImageSource="burger",
                    Color=Colors.DarkOrange
                },
                 new OrderModel()
                {
                    Title="Good delivery at your step",
                    Description="Lorem ipsum dolor sit amet. Qui magnam ducimus et odio laudantium in aspernatur nemo et natus amet aut voluptas odit qui suscipit consequatur?",
                    ImageSource="delivery_man",
                    Color= Colors.ForestGreen
                },
                new OrderModel()
                {
                    Title="We have 70000+ reviews on our app",
                    Description="Non veniam nostrum aut molestiae quaerat sed similique consequatur eum enim nulla sed facilis rerum aut quas ducimus et possimus officia.",
                    ImageSource="food_delivery",
                    Color=Colors.DodgerBlue
                }
            };
        }

        public void ChangeColor()
        {
            ButtonColor = CurrentItem.Color;
        }
        public void ChangeDetails()
        {

            ButtonColor = CurrentItem.Color;
            if (Position >= OrderDetails.Count - 1)
            {
                NextPageEvent?.Invoke(this, new EventArgs());
                Position = 0;
            }
            else
            {
                Position++;
                CurrentItem = OrderDetails.ElementAt(Position);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
