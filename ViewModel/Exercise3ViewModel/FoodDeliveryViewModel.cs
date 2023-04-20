using Chapter9.Model.Exercise3Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter9.ViewModel.Exercise3ViewModel
{
    public class FoodDeliveryViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DeliveryModel> FoodDetails { get; set; }

        private int _position;
        public int Position
        {
            get => _position;
            set
            {
                _position= value;
                OnPropertyChanged();
            }
        }


        public event EventHandler NextPageEvent;
        public ICommand NextCommand { get; private set; }
        public ICommand ChangeCommand { get;private set; } 
        public FoodDeliveryViewModel()
        {
            Details();
            NextCommand = new Command(ChangeDetails);
        }

        public void Details()
        {
            FoodDetails = new ObservableCollection<DeliveryModel>
            {
                new DeliveryModel()
                {
                    Title="Delicious food",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    ImageSource="cooking"
                },
                 new DeliveryModel()
                {
                    Title="Free Delivery",
                    Description="Lorem ipsum dolor sit amet. Qui magnam ducimus et odio laudantium in aspernatur nemo et natus amet aut voluptas odit qui suscipit consequatur?",
                    ImageSource="delivery"
                },
                new DeliveryModel()
                {
                    Title="Order on one tap",
                    Description="Non veniam nostrum aut molestiae quaerat sed similique consequatur eum enim nulla sed facilis rerum aut quas ducimus et possimus officia.",
                    ImageSource="order"
                }
            };
        }

        public void ChangeDetails()
        {
            if (Position >= FoodDetails.Count - 1)
            {
                NextPageEvent?.Invoke(this, new EventArgs());
                Position = 0;
            }
            else
            {
                Position += 1;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
