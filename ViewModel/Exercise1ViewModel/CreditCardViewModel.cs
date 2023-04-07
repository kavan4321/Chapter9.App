
using Chapter9.Model.Exercise1Model;
using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter9.ViewModel.Exercise1ViewModel.ViewModelCredit
{
    public class CreditCardViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CreditCardModel> CardDetails { get; set; }
        
        private ObservableCollection<CreditCardModel> _currentCardDetail;
        public ObservableCollection<CreditCardModel> CurrentCardDetail
        {
            get => _currentCardDetail;
            set
            {
                _currentCardDetail = value;
                OnPropertyChanged();
            }
        }
       
        private CreditCardModel _currentItem;
        public CreditCardModel CurrentItem
        {
            get => _currentItem;
            set
            {
                _currentItem = value;
                OnPropertyChanged();
            }
        }
      
        public ICommand ChangedCommand { get; private set; }
        public CreditCardViewModel()
        {
            CardDetailShow();
            ChangedCommand = new Command(CurrentDetails);
            CurrentItem=CardDetails.FirstOrDefault();
        }

        public void CardDetailShow()
        {
            CardDetails = new ObservableCollection<CreditCardModel>
            {
                new CreditCardModel()
                {
                    CardName="First Premier Bank",
                    CardLimit="45000",
                    CardImage="visa"
                },
                new CreditCardModel()
                {
                    CardName="Icon Finance",
                    CardLimit="48000",
                    CardImage="credit_card"
                },
                new CreditCardModel()
                {
                    CardName="Visa Master Card",
                    CardLimit="40000",
                    CardImage="credit_card2"
                },
            };                     
        }       
        public void CurrentDetails()
        {
            CurrentCardDetail = CardDetails.Where(x => x == CurrentItem).ToObservableCollection();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
